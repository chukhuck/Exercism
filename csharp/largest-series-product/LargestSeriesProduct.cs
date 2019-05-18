using System;
using System.Collections.Generic;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if (span < 0 || digits.Length  < span || digits.Any(c=>!char.IsDigit(c)))
            throw new ArgumentException("Invalid parameter");

        return GetSlices(digits, span).
                                    Max(slice => slice.
                                        Select(c=>int.Parse(c.ToString())).
                                        Multiply());
    }

    public static IEnumerable<string> GetSlices(string numbers, int sliceLength)
    {
        string[] slices = new string[numbers.Length - sliceLength + 1];

        for (int i = 0; i < numbers.Length - sliceLength + 1; i++)
            slices[i] = numbers.Substring(i, sliceLength); 

        return slices;
    }

    public static long Multiply(this IEnumerable<int> collection)
    {
        int product = 1;

        foreach (var item in collection)
            product *= item;

        return product;
    }
}