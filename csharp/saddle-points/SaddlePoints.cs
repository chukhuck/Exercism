using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        return GetMinsInColumns(matrix).Intersect(GetMaxsinRows(matrix)).ToArray();
    }

    private static HashSet<(int, int)> GetMaxsinRows(int[,] matrix)
    {
        List<(int, int)> maxs = new List<(int, int)>();

        int rowSize = matrix.GetLength(0);
        int columnSize = matrix.GetLength(1);

        for (int i = 0; i < rowSize; i++)
        {
            int max = int.MinValue;
            List<(int, int)> temp = new List<(int, int)>();

            for (int j = 0; j < columnSize; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    temp.Clear();
                    temp.Add((i + 1, j + 1));
                }
                else if (matrix[i, j] == max)
                {
                    temp.Add((i + 1, j + 1));
                }
            }
            maxs.AddRange(temp);
        }

        return new HashSet<(int, int)>(maxs);

    }

    private static HashSet<(int, int)> GetMinsInColumns(int[,] matrix)
    {
        List<(int, int)> mins = new List<(int, int)>();

        int rowSize = matrix.GetLength(0);
        int columnSize = matrix.GetLength(1);

        for (int i = 0; i < columnSize; i++)
        {
            int min = int.MaxValue;
            List<(int, int)> temp = new List<(int, int)>();

            for (int j = 0; j < rowSize; j++)
            {
                if (matrix[j, i] < min)
                {
                    min = matrix[j, i];
                    temp.Clear();
                    temp.Add((j + 1, i + 1));
                }
                else if (matrix[j, i] == min)
                {
                    temp.Add((j + 1, i + 1
                    ));
                }
            }
            mins.AddRange(temp);
        }

        return new HashSet<(int, int)>(mins);
    }
}
