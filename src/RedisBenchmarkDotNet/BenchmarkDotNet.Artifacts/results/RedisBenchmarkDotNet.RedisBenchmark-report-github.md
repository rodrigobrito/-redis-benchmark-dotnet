``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i7-6500U CPU 2.50GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 2.1.13 (CoreCLR 4.6.28008.01, CoreFX 4.6.28008.01), X64 RyuJIT
  DefaultJob : .NET Core 2.1.13 (CoreCLR 4.6.28008.01, CoreFX 4.6.28008.01), X64 RyuJIT


```
| Method |     Mean |   Error |  StdDev |  StdErr |      Min |       Q1 |   Median |       Q3 |      Max |    Op/s |
|------- |---------:|--------:|--------:|--------:|---------:|---------:|---------:|---------:|---------:|--------:|
|    Get | 212.9 us | 2.09 us | 1.85 us | 0.49 us | 209.8 us | 211.8 us | 212.7 us | 213.2 us | 217.5 us | 4,697.5 |
|    Set | 326.5 us | 1.96 us | 1.83 us | 0.47 us | 324.0 us | 324.9 us | 326.2 us | 327.8 us | 330.6 us | 3,062.9 |
