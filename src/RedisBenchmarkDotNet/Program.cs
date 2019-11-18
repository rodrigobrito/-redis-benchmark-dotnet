#if DEBUG
using BenchmarkDotNet.Configs;
#endif
using System;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using RedisBenchmarkDotNet.Utils;

namespace RedisBenchmarkDotNet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting REDIS benchmarks with StackExchange.Redis client...");
            Util.Initialize();
            Console.WriteLine("Started.");
            Util.CreateConfiguredKeys();
#if DEBUG
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
#else
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            //BenchmarkRunner.Run<RedisBenchmark>();
#endif
        }

        internal class CustomConfig : ManualConfig
        {
            protected Job Configure(Job j)
                => j.With(new GcMode { Force = true })
            //.With(InProcessToolchain.Instance)
            ;

            public CustomConfig()
            {
                Add(MemoryDiagnoser.Default);
                Add(StatisticColumn.OperationsPerSecond);
                Add(JitOptimizationsValidator.FailOnError);
               // Add(Configure(Job.InProcess));
            }
        }
    }
}