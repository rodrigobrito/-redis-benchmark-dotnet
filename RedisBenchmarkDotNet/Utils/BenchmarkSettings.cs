using System;
using Microsoft.Extensions.Configuration;

namespace RedisBenchmarkDotNet.Utils
{
    public class BenchmarkSettings
    {
        public BenchmarkSettings(IConfigurationRoot configuration)
        {
            var config = configuration ?? throw new ArgumentNullException(nameof(configuration));
            var section = config.GetSection("Benchmark") ?? throw new ArgumentNullException(nameof(BenchmarkSettings), "Benchmark section is not defined in configuration file.");
            KeyDataContent = section.GetSection(nameof(KeyDataContent)).Value;
            if (int.TryParse(section.GetSection(nameof(AmountOfKeys)).Value, out var amountOfKeys))
                AmountOfKeys = amountOfKeys;
        }

        public int AmountOfKeys { get; set; }
        public string KeyDataContent { get; set; }
    }
}
