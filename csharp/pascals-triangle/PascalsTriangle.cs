using System;
using System.Collections.Generic;
using System.Linq;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate1(int rows)
    {
        if (rows < 0)
            throw new ArgumentException("Invalid parameter.");

        List<List<int>> pascalsTriangle = new List<List<int>>();

        for (int i = 1; i <= rows; i++)
            pascalsTriangle.Add(NextPascalsTriangleRow(pascalsTriangle.Count == 0 ? 
                                                                                    new List<int>() : 
                                                                                    pascalsTriangle.Last()));

        return pascalsTriangle;
    }

    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        if (rows < 0)
            throw new ArgumentException("Invalid parameter.");

        if(rows == 0)
            return new List<List<int>>();

        return Enumerable.Range(1, rows).Select(i => NextPascalsTriangleRow(i));
    }

    private static List<int> NextPascalsTriangleRow(List<int> prevRow)
    {
        List<int> nextRow = new List<int>();

        if(prevRow.Count == 0)
            nextRow.Add(1);

        for (int i = 0; i < prevRow.Count - 1; i++)
            nextRow.Add(prevRow[i] + prevRow[i + 1]);

        if(prevRow.Count != 0)
        {
            nextRow.Insert(0, 1);
            nextRow.Add(1);
        }

        return nextRow;
    }

    private static IEnumerable<int> NextPascalsTriangleRow(int row)
    {
        //Here we must calculate the coefficients up to row/2, then we just copy it.
        //But it is not so elegant
        
        return Enumerable.Range(1, row).Select(i => GetBinomialCoefficient(i - 1, row - 1)) ;
    }

    private static int GetBinomialCoefficient(int i, int row)
    {
        return row.Factorial() / (i.Factorial() * (row - i).Factorial());
    }

    public static int Factorial(this int number)
    {
        if(number < 0)
            throw new ArgumentException("Invalid parameter.");

        if(number == 0)
            return 1;

        int product = 1;

        for (int i = 1; i <= number; i++)
            product *= i;

        return product;
    }
}