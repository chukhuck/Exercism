using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    public static int[] Factors(long number)
    {
        List<int> factors = new List<int>();

        long i = 2;
        long limit = number/2 + 1;


        while (number != 1)
        {
            if (number%i==0)
            {
                number /= i;
                limit = number/2 + 1;
                factors.Add((int)i);
            }
            else
                i++;
        }


        return factors.ToArray();
    }
}