using System;
using Microsoft.Extensions.Configuration;

namespace RedisBenchmarkDotNet.Utils
{
    public class RedisSettings
    {
        public RedisSettings(IConfigurationRoot configuration)
        {
            var config = configuration ?? throw new ArgumentNullException(nameof(configuration));
            var section = config.GetSection(nameof(StackExchange.Redis)) ?? throw new ArgumentNullException(nameof(RedisSettings), "Redis section is not defined in configuration file.");
            ConnectionString = section.GetSection(nameof(ConnectionString)).Value;
        }

        public string ConnectionString { get; set; }
    }
}