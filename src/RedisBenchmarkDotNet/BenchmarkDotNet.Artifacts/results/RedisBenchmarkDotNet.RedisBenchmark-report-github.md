``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i7-6500U CPU 2.50GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT
  Job-OBEJVW : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT
  ShortRun   : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT

LaunchCount=1  

```
| Method |      Job | IterationCount | WarmupCount |     Mean |    Error |  StdDev |  StdErr |      Min |       Q1 |   Median |       Q3 |      Max |    Op/s |
|------- |--------- |--------------- |------------ |---------:|---------:|--------:|--------:|---------:|---------:|---------:|---------:|---------:|--------:|
|    Get |  Default |              1 |           1 | 263.4 us |       NA | 0.00 us | 0.00 us | 263.4 us | 263.4 us | 263.4 us | 263.4 us | 263.4 us | 3,796.7 |
|    Set |  Default |              1 |           1 | 346.0 us |       NA | 0.00 us | 0.00 us | 346.0 us | 346.0 us | 346.0 us | 346.0 us | 346.0 us | 2,890.3 |
|    Get | ShortRun |              3 |           3 | 264.3 us | 51.32 us | 2.81 us | 1.62 us | 261.7 us | 261.7 us | 263.9 us | 267.3 us | 267.3 us | 3,783.9 |
|    Set | ShortRun |              3 |           3 | 319.5 us | 38.94 us | 2.13 us | 1.23 us | 317.9 us | 317.9 us | 318.6 us | 321.9 us | 321.9 us | 3,130.1 |
