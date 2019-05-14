using System;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum1(int max)
    {
        return (int)Math.Pow(Enumerable.Range(1,max).Sum(), 2);
    }

    public static int CalculateSquareOfSum(int max)
    {
        return (int)Math.Pow((1 + max)* max/2, 2);
    }

    public static int CalculateSumOfSquares1(int max)
    {
        return Enumerable.Range(1,max).Select(i=>i*i).Sum();
    }
    
    public static int CalculateSumOfSquares(int max)
    {
        return max * (max + 1) * (2*max + 1) / 6;
    }

    public static int CalculateDifferenceOfSquares1(int max)
    {
        int sumOfIntegers = max * (1 + max) / 2;

        return (int)Math.Pow(sumOfIntegers, 2) - sumOfIntegers * (2*max + 1)/3;
    }

        public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}