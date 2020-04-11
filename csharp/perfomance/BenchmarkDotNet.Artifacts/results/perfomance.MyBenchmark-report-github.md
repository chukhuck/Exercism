``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i5 CPU M 430 2.27GHz, 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
|            Method |       Mean |     Error |    StdDev |
|------------------ |-----------:|----------:|----------:|
|   CountingUpTo100 |   102.0 ns |   1.99 ns |   2.13 ns |
| CountingUpTo10000 | 9,126.8 ns | 171.06 ns | 168.00 ns |
