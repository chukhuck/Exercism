using System;
using System.Linq;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
        var sut = new Matrix("1 2 3\n4 5 6\n7 8 9\n8 7 6");
            Console.WriteLine(sut.Column(3));
        }


    }

    public class Matrix
    {
        int[][] items;
        int rows;
        int columns;

        MatrixParser parser = new MatrixParser();

        public Matrix(string input)
        {
            items = parser.Parse(input);
            rows = items.Length;
            columns = (items.FirstOrDefault() ?? throw new Exception("The matrix is empty.")).Length;
        }

        public int Rows => rows;


        public int Cols => columns;

        public int[] Row(int row)
        {
            return items[row - 1];
        }

        public int[] Column(int col)
        {
            int[] column = new int[rows];

            for (int i = 0; i < rows; i++)
                column[i] = items[i][col - 1];

            return column;
        }
    }

    internal class MatrixParser
    {
        readonly static char rowSeparator = '\n';

        readonly static char columnSeparator = ' ';

        internal int[][] Parse(string input)
        {
            int[][] items = input.Split(rowSeparator, StringSplitOptions.RemoveEmptyEntries)
                        .Select(r => r.Split(columnSeparator, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(i => int.Parse(i))
                                        .ToArray())
                        .ToArray();

            int columns = (items.FirstOrDefault() ?? throw new Exception("The matrix is empty.")).Length;

            if (!items.All(r => r.Length == columns))
                throw new FormatException("It is not a matrix.");

            return items;
        }

        internal int[] Parse1(string input)
        {
            int[][] items = input.Split(rowSeparator, StringSplitOptions.RemoveEmptyEntries)
                        .Select(r => r.Split(columnSeparator, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(i => int.Parse(i))
                                        .ToArray())
                        .ToArray();

            int columns = (items.FirstOrDefault() ?? throw new Exception("The matrix is empty.")).Length;
            int rows = items.Length;


            if (!items.All(r => r.Length == columns))
                throw new FormatException("It is not a matrix.");

            int[] data = new int[columns * rows];

            for (int i = 0; i < items.Length; i++)
                items[i].CopyTo(data, i * columns);

            return data;
        }
    }

}
