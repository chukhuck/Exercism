using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace perfomance
{
    class Program
    {
        static void Main(string[] args)
        {
        }

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
