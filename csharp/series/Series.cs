using System;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (numbers.Length == 0 || sliceLength < 1 || numbers.Length  < sliceLength)
            throw new ArgumentException("Invalid parameter");

        string[] slices = new string[numbers.Length - sliceLength + 1];

        for (int i = 0; i < numbers.Length - sliceLength + 1; i++)
            slices[i] = numbers.Substring(i, sliceLength); 

        return slices;
    }
}