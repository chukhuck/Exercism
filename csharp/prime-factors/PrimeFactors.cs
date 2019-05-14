using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    public static int[] Factors(long number)
    {
        List<int> factors = new List<int>();

        while (number != 1)
        {
            int minFactor = GetMinFactor(number);
            factors.Add(minFactor);
            number /= minFactor;
        }

        return factors.ToArray();
    }

    private static int GetMinFactor(long number)
    {
        int limit = (int)Math.Sqrt(number) + 1;
        for (int i = 2; i < limit; i++)
            if (number%i==0)
                return i;

        return (int)number;
    }
}