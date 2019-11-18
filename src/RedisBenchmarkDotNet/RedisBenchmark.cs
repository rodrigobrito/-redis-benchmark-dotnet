using BenchmarkDotNet.Attributes;
using RedisBenchmarkDotNet.Utils;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RedisBenchmarkDotNet
{
    [Config(typeof(Program.CustomConfig))]
    public class RedisBenchmark
    {
        private const int Operations = 100;
        private readonly Random _random = new Random();
        private Task<string>[] _tasksToGet;
        private ConnectionManagement _connectionManagement;
        private int _amountOfKeys;
        private long _setCount;

        [GlobalSetup]
        public void GlobalSetup()
        {
            Util.Initialize();
            _connectionManagement = Util.ConnectionManagement;
            _amountOfKeys = Util.BenchmarkSettings.AmountOfKeys;
        }

        [IterationSetup(Target = nameof(GetMultithreadedOperations))]
        public void CreateTasks()
        {
            var tasksToGet = new List<Task<string>>();
            for (var i = 0; i < Operations; i++)
            {
                var task = new Task<string>(SimpleGet);
                tasksToGet.Add(task);
            }
            _tasksToGet = tasksToGet.ToArray();
        }

        [Benchmark]
        public string Get()
        {
            return SimpleGet();
        }

        [Benchmark(OperationsPerInvoke = Operations)]
        public List<string> GetOperations()
        {
            var result = new List<string>();
            for (var i = 0; i < Operations; i++)
            {
                var get = SimpleGet();
                result.Add(get);
            }
            return result;
        }

        [Benchmark(OperationsPerInvoke = Operations)]
        public string[] GetMultithreadedOperations()
        {
            Parallel.ForEach<Task>(_tasksToGet, task => { task.Start(); });
            var results = Task.WhenAll(_tasksToGet).Result;
            return results;
        }

        [Benchmark]
        public async Task<string> GetAsync()
        {
            return await SimpleGetAsync();
        }


        [Benchmark]
        public bool Set()
        {
            _setCount++;
            return _connectionManagement.CreateKey($"BenchmarkDotNetSet{_setCount}", Util.BenchmarkSettings.KeyDataContent);
        }

        private string SimpleGet()
        {
            var i = _random.Next(_amountOfKeys);
            var keyName = string.Format(Util.KeyPrefix, i);
            return _connectionManagement.GetKey<string>(keyName);
        }

        public async Task<string> SimpleGetAsync()
        {
            var i = _random.Next(_amountOfKeys);
            var keyName = string.Format(Util.KeyPrefix, i);
            return await _connectionManagement.GetKeyAsync<string>(keyName);
        }
    }
}