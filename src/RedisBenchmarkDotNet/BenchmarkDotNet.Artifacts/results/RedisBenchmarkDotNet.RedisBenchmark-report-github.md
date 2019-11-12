``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i7-6500U CPU 2.50GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 2.1.13 (CoreCLR 4.6.28008.01, CoreFX 4.6.28008.01), X64 RyuJIT
  Job-FQSSQL : .NET Core 2.1.13 (CoreCLR 4.6.28008.01, CoreFX 4.6.28008.01), X64 RyuJIT
  ShortRun   : .NET Core 2.1.13 (CoreCLR 4.6.28008.01, CoreFX 4.6.28008.01), X64 RyuJIT

LaunchCount=1  

```
| Method |      Job | IterationCount | WarmupCount |     Mean |    Error |  StdDev |  StdErr |      Min |       Q1 |   Median |       Q3 |      Max |    Op/s |
|------- |--------- |--------------- |------------ |---------:|---------:|--------:|--------:|---------:|---------:|---------:|---------:|---------:|--------:|
|    Get |  Default |              1 |           1 | 210.8 us |       NA | 0.00 us | 0.00 us | 210.8 us | 210.8 us | 210.8 us | 210.8 us | 210.8 us | 4,743.3 |
|    Set |  Default |              1 |           1 | 323.2 us |       NA | 0.00 us | 0.00 us | 323.2 us | 323.2 us | 323.2 us | 323.2 us | 323.2 us | 3,094.5 |
|    Get | ShortRun |              3 |           3 | 211.8 us | 28.57 us | 1.57 us | 0.90 us | 210.3 us | 210.3 us | 211.7 us | 213.4 us | 213.4 us | 4,721.6 |
|    Set | ShortRun |              3 |           3 | 335.4 us |  8.60 us | 0.47 us | 0.27 us | 334.9 us | 334.9 us | 335.6 us | 335.7 us | 335.7 us | 2,981.6 |
