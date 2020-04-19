``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18362.778 (1903/May2019Update/19H1)
Intel Core i5 CPU M 430 2.27GHz, 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
|                Method |  row | col | requestedItem |            Mean |         Error |        StdDev |          Median |
|---------------------- |----- |---- |-------------- |----------------:|--------------:|--------------:|----------------:|
|          **GetJaggedRow** | **1000** | **100** |             **9** |       **0.6043 ns** |     **0.1482 ns** |     **0.1314 ns** |       **0.5972 ns** |
|           GetMultiRow | 1000 | 100 |             9 |     378.7467 ns |     6.8597 ns |     6.4166 ns |     378.9254 ns |
|   GetPlainRowWithSpan | 1000 | 100 |             9 |      90.8863 ns |     1.8399 ns |     1.9687 ns |      91.1163 ns |
| GetPlainRowWithMemory | 1000 | 100 |             9 |      96.1479 ns |     2.0659 ns |     3.0922 ns |      95.8157 ns |
|   GetPlainRowWithCopy | 1000 | 100 |             9 |     120.4814 ns |     2.5595 ns |     2.8449 ns |     120.1959 ns |
|           GetPlainRow | 1000 | 100 |             9 |     270.9368 ns |     3.9748 ns |     3.5236 ns |     270.4137 ns |
|       GetJaggedColumn | 1000 | 100 |             9 |   5,069.9017 ns |    85.0203 ns |    79.5280 ns |   5,087.0113 ns |
|        GetMultiColumn | 1000 | 100 |             9 |   4,642.2910 ns |    72.7131 ns |    60.7187 ns |   4,639.5676 ns |
|        GetPlainColumn | 1000 | 100 |             9 |   3,526.6258 ns |    54.1115 ns |    45.1855 ns |   3,525.0996 ns |
|         GetJaggedItem | 1000 | 100 |             9 |  32,416.1351 ns |   409.2903 ns |   341.7759 ns |  32,292.5873 ns |
|          GetMultiItem | 1000 | 100 |             9 |  56,230.3304 ns |   907.5178 ns |   848.8927 ns |  56,372.9431 ns |
|          GetPlainItem | 1000 | 100 |             9 |  23,272.0977 ns |   325.3529 ns |   304.3353 ns |  23,326.8509 ns |
|         SetJaggedItem | 1000 | 100 |             9 |  77,675.2764 ns | 1,119.5636 ns |   992.4639 ns |  77,491.1194 ns |
|          SetMultiItem | 1000 | 100 |             9 | 169,563.9176 ns | 2,008.8905 ns | 1,879.1174 ns | 170,089.7949 ns |
|          SetPlainItem | 1000 | 100 |             9 |  59,814.5707 ns |   833.3599 ns |   779.5253 ns |  59,824.7681 ns |
|          **GetJaggedRow** | **5000** | **100** |             **9** |       **0.0615 ns** |     **0.0726 ns** |     **0.0680 ns** |       **0.0343 ns** |
|           GetMultiRow | 5000 | 100 |             9 |     378.6925 ns |     7.6531 ns |     9.6787 ns |     375.3469 ns |
|   GetPlainRowWithSpan | 5000 | 100 |             9 |      97.2278 ns |     2.0363 ns |     2.3450 ns |      97.4521 ns |
| GetPlainRowWithMemory | 5000 | 100 |             9 |     100.6429 ns |     2.1308 ns |     2.5366 ns |      99.8421 ns |
|   GetPlainRowWithCopy | 5000 | 100 |             9 |     129.9434 ns |     2.7491 ns |     5.6158 ns |     128.7426 ns |
|           GetPlainRow | 5000 | 100 |             9 |     269.6634 ns |     3.9622 ns |     3.0935 ns |     268.9463 ns |
|       GetJaggedColumn | 5000 | 100 |             9 |  37,583.9847 ns |   687.9190 ns |   706.4422 ns |  37,590.7593 ns |
|        GetMultiColumn | 5000 | 100 |             9 |  29,870.5950 ns |   442.8105 ns |   414.2053 ns |  29,815.3946 ns |
|        GetPlainColumn | 5000 | 100 |             9 |  24,768.8765 ns |   493.9819 ns |   568.8703 ns |  24,782.1350 ns |
|         GetJaggedItem | 5000 | 100 |             9 |  32,779.7235 ns |   516.3067 ns |   482.9536 ns |  32,785.4462 ns |
|          GetMultiItem | 5000 | 100 |             9 |  55,622.3216 ns |   801.0076 ns |   749.2630 ns |  55,611.7218 ns |
|          GetPlainItem | 5000 | 100 |             9 |  23,288.2676 ns |   323.3439 ns |   302.4561 ns |  23,303.6987 ns |
|         SetJaggedItem | 5000 | 100 |             9 |  77,655.6222 ns | 1,216.2076 ns | 1,137.6413 ns |  77,497.8088 ns |
|          SetMultiItem | 5000 | 100 |             9 | 168,439.8636 ns | 3,318.6614 ns | 3,259.3693 ns | 166,638.2812 ns |
|          SetPlainItem | 5000 | 100 |             9 |  59,309.2006 ns |   836.9644 ns |   782.8970 ns |  59,739.2792 ns |
