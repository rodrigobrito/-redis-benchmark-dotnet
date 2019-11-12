using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisBenchmarkDotNet.Utils.ShellProgressBar;

namespace RedisBenchmarkDotNet.Utils
{
    public static class Util
    {
        public const string KeyPrefix = "BenchmarkDotNet{0}";
        private const string BenchmarkDotNetKeysCreated = "BenchmarkDotNetKeysCreated";

        public static void Initialize()
        {
            var assemblyDirectory = AssemblyDirectory;

            var config = new ConfigurationBuilder()
                .SetBasePath(assemblyDirectory)
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton(config);
            services.AddSingleton<RedisSettings>();
            services.AddSingleton<BenchmarkSettings>();

            var provider = services.BuildServiceProvider();
            BenchmarkSettings = provider.GetService<BenchmarkSettings>();
            var redisSettings = provider.GetService<RedisSettings>();
            ConnectionManagement = ConnectionManagement.GetInstance(redisSettings.ConnectionString);
        }

        public static ConnectionManagement ConnectionManagement { get; private set; }
        public static BenchmarkSettings BenchmarkSettings { get; private set; }
        public static void CreateConfiguredKeys()
        {
            var redis = ConnectionManagement.GetInstance();
            var keysCreated = redis.GetKey<bool>(BenchmarkDotNetKeysCreated);
            if (keysCreated) return;

            Console.WriteLine("Creating keys to execute the \"GET\" benchmarks:");

            var amountOfKeys = BenchmarkSettings.AmountOfKeys;
            using (var progress = new ProgressBar(amountOfKeys, $"Creating {amountOfKeys} keys..."))
            {
                for (var i = 0; i <= amountOfKeys; i++)
                {
                    var keyName = string.Format(KeyPrefix, i);
                    try
                    {
                        redis.CreateKey(keyName, BenchmarkSettings.KeyDataContent);
                    }
                    catch (Exception ex)
                    {
                        progress.WriteLine($"Failed to key {keyName} creation: {ex}");
                    }
                    progress.Tick(i == amountOfKeys ? "Done!" : $"Creating {i} of {amountOfKeys} key(s)...");
                }
            }
            redis.CreateKey(BenchmarkDotNetKeysCreated, true, TimeSpan.FromSeconds(28800));
            Console.WriteLine($"{BenchmarkSettings.AmountOfKeys} key(s) created.");
        }

        private static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
