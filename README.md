# redis-benchmark-dotnet
Benchmarks of redis clients for DotNet

## Quick Start

The first thing that you need to choose is the Target Framework. Available options are: netcoreapp2.1|netcoreapp2.2|net472. You can specify the target framework using -f | --framework argument. For the sake of simplicity, example below use  netcoreapp2.1 as the target framework.

```cmd
dotnet run --framework netcoreapp2.1 -c Release -- --warmupCount 20 --iterationCount 20 --iterationTime 1000 --launchCount 3 --runtimes netcoreapp21  --job short -f *
```