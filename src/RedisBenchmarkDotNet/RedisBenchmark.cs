using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using RedisBenchmarkDotNet.Utils;

namespace RedisBenchmarkDotNet
{
    [SimpleJob]
    [AllStatisticsColumn]
    [RPlotExporter]
    public class RedisBenchmark
    {
        private ConnectionManagement _connectionManagement;
        private readonly Random _random = new Random();
        private int _amountOfKeys;
        private long _setCount;

        [GlobalSetup]
        public void Setup()
        {
            Util.Initialize();
            _connectionManagement = Util.ConnectionManagement;
            _amountOfKeys = Util.BenchmarkSettings.AmountOfKeys;
        }

        [Benchmark]
        public string Get()
        {
            var i = _random.Next(_amountOfKeys);
            var keyName = string.Format(Util.KeyPrefix, i);
            return _connectionManagement.GetKey<string>(keyName);
        }

        [Benchmark]
        public bool Set()
        {
            _setCount++;
            return _connectionManagement.CreateKey($"BenchmarkDotNetSet{_setCount}", Util.BenchmarkSettings.KeyDataContent);
        }
    }
}