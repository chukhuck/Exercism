using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number < 1)
            throw new ArgumentOutOfRangeException();

        int sumOfFactors = GetFactors(number).Sum();

        if (sumOfFactors == number)
            return Classification.Perfect;
        else if (sumOfFactors > number)
            return Classification.Abundant;
        else
            return Classification.Deficient;
    }

    public static IEnumerable<int> GetFactors(int number)
    {
        List<int> factors = new List<int>();

        for (int i = 1; i <= number/2; i++)
            if (number%i==0)
                factors.Add(i);

        return factors;
    }
}
