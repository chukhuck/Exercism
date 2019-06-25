using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2)
            throw  new ArgumentOutOfRangeException();

        bool[] primeNumbers = Enumerable.Repeat(true, limit - 1).ToArray();

        for (int i = 2; i < Math.Ceiling(Math.Sqrt(limit)); i++)
            foreach (int multiplier in GetMultipliersFor(i, limit))
                primeNumbers[multiplier - 2] = false;

        return primeNumbers.Select((isPrime, idx) => isPrime ? idx + 2 : -1).Where(b => b != -1).ToArray();               
    }

    public static int[] Primes1(int limit)
    {
        if (limit < 2)
            throw  new ArgumentOutOfRangeException();

        IEnumerable<int> primeNumber = Enumerable.Range(2, limit - 1);

         Enumerable
                .Range(2, (int)Math.Ceiling(Math.Sqrt(limit)))
                .ToList()
                .ForEach(i => primeNumber = primeNumber.Except(GetMultipliersFor(i, limit)));
                
        return primeNumber.ToArray();                     
    }

    public static IEnumerable<int> GetMultipliersFor(int number, int limit)
    {
        for (int i = 2; i <= limit / number; i++)
            yield return number * i;
    }
}