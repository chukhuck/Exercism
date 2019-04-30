﻿using System;

public static class Grains
{
    public static ulong Square(int n)
    {
        if(n < 1 || n > 64)
            throw new ArgumentOutOfRangeException();

        return (ulong)Math.Pow(2, n - 1);
    }

    //A standard formula is used to calculate the sum of the geometric progression 
    public static ulong Total()
    {
        return (ulong)Math.Pow(2, 64) - 1;
    }
}