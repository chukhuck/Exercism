using System;
using System.Collections.Generic;
using System.Linq;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (outputBase < 2 || inputBase < 2 || inputDigits.Any(d=>d < 0 || d >= inputBase))
            throw new ArgumentException("Invalid parameter");

        return inputDigits.ToInt(inputBase).ToBase(outputBase);
    }

    public static int[] ToBase(this int integer, int outputBase)
    {
        List<int> digits = new List<int>();

        int temp = integer;

        while (temp >= outputBase )
        {
            digits.Add(temp%outputBase);
            temp /= outputBase;
        }

        digits.Add(temp);
        digits.Reverse();

        return digits.ToArray();
    }

    public static int ToInt(this int[] inputDigits, int @base )
    {
        int lenght = inputDigits.Length;

        return (int)inputDigits.
                        Select((d,idx) => Math.Pow(@base, lenght - idx - 1)*d).
                        Sum();
    }

    
}