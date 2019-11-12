using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
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
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            BenchmarkRunner.Run<RedisBenchmark>();
#endif
        }
    }
}