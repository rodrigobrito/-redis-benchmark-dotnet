# redis-benchmark-dotnet
Benchmarks of redis clients for DotNet frameworks

dotnet run --framework netcoreapp2.1 -c Release -- --warmupCount 20 --iterationCount 20 --iterationTime 1000 --launchCount 3 --runtimes netcoreapp21  --job short -f *
