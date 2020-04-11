using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace perfomance
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MyBenchmark>();
        }
    }

    public class MyBenchmark
    {
        [Benchmark]
        public int CountingUpTo100()
        {
            return Method(100);
        }

        [Benchmark]
        public int CountingUpTo10000()
        {
            return Method(10_000);
        }

        public int Method(int count)
        {
            int outputValue = 0;
            for (int i = 0; i < count; i++)
            {
                outputValue += i;
            }
            return outputValue;
        }
    }
}
