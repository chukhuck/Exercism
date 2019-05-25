using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if(firstStrand.Length != secondStrand.Length)
            throw new ArgumentException("Invalid parameter");

        return Enumerable.Range(1, firstStrand.Length).Sum( i => firstStrand[i - 1] == secondStrand[i - 1] ? 0 : 1);
    }
}