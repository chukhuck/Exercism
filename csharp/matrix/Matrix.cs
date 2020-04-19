using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

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

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("111");
        BenchmarkRunner.Run<MyBenchmark>();
    }
}

public class MyBenchmark
{
    private int[][] jaggedItems;
    private int[] plainItems;
    private int[,] multiItems;

    [Params(1000, 5000)]
    public int row;

    [Params(100)]
    public int col;

    [Params(9)]
    public int requestedItem;

    [GlobalSetup]
    public void Setup()
    {

        Random generator = new Random(42);
        multiItems = new int[row, col];
        plainItems = new int[row * col];
        jaggedItems = new int[row][];


        for (int i = 0; i < row; i++)
        {
            jaggedItems[i] = new int[col];

            for (int j = 0; j < col; j++)
            {
                int randomNumber = generator.Next();

                plainItems[col * i + j] = randomNumber;
                multiItems[i, j] = randomNumber;
                jaggedItems[i][j] = randomNumber;
            }
        }
    }

    [Benchmark]
    public int[] GetJaggedRow()
    {
        return jaggedItems[requestedItem];
    }

    [Benchmark]
    public int[] GetMultiRow()
    {
        int[] requestedRow = new int[col];

        for (int i = 0; i < col; i++)
            requestedRow[i] = multiItems[requestedItem, i];

        return requestedRow;
    }

    [Benchmark]
    public int[] GetPlainRowWithSpan()
    {
        return plainItems.AsSpan(requestedItem * col, col).ToArray();
    }

    [Benchmark]
    public int[] GetPlainRowWithMemory()
    {
        return plainItems.AsMemory(requestedItem * col, col).ToArray();
    }

    [Benchmark]
    public int[] GetPlainRowWithCopy()
    {
        int[] requestedRow = new int[col];
        Array.Copy(plainItems, requestedItem * col, requestedRow, 0, col);

        return requestedRow;
    }

    [Benchmark]
    public int[] GetPlainRow()
    {
        int[] requestedRow = new int[col];

        int startIndex = requestedItem * col;
        for (int i = 0; i < col; i++)
            requestedRow[i] = plainItems[startIndex + i];

        return requestedRow;
    }

    [Benchmark]
    public int[] GetJaggedColumn()
    {
        int[] column = new int[row];

        for (int i = 0; i < row; i++)
            column[i] = jaggedItems[i][requestedItem];

        return column;
    }

    [Benchmark]
    public int[] GetMultiColumn()
    {
        int[] column = new int[row];

        for (int i = 0; i < row; i++)
            column[i] = multiItems[i, requestedItem];

        return column;
    }

    [Benchmark]
    public int[] GetPlainColumn()
    {
        int[] column = new int[row];

        for (int i = 0; i < row; i++)
            column[i] = plainItems[i * col + requestedItem];

        return column;
    }

    [Benchmark]
    public int GetJaggedItem()
    {
        int sum = 0;
        for (int i = 0; i < 10000; i++)
        {
            sum += jaggedItems[requestedItem][requestedItem];
            sum += jaggedItems[row - requestedItem][requestedItem];
        }
        return sum;
    }

    [Benchmark]
    public int GetMultiItem()
    {
        int sum = 0;
        for (int i = 0; i < 10000; i++)
        {
            sum += multiItems[requestedItem, requestedItem];
            sum += multiItems[row - requestedItem, requestedItem];
        }
        return sum;
    }

    [Benchmark]
    public int GetPlainItem()
    {
        int sum = 0;
        for (int i = 0; i < 10000; i++)
        {
            sum += plainItems[requestedItem * col + requestedItem];
            sum += plainItems[(row - requestedItem) * col + requestedItem];
        }
        return sum;
    }


    [Benchmark]
    public void SetJaggedItem()
    {
        for (int i = 0; i < 10000; i++)
        {
            jaggedItems[requestedItem][requestedItem] = i;
            jaggedItems[row - requestedItem][requestedItem] = i;
        }

    }

    [Benchmark]
    public void SetMultiItem()
    {
        for (int i = 0; i < 10000; i++)
        {
            multiItems[requestedItem, requestedItem] = i;
            multiItems[row - requestedItem, requestedItem] = i;
        }

    }

    [Benchmark]
    public void SetPlainItem()
    {
        for (int i = 0; i < 10000; i++)
        {
            plainItems[requestedItem * col + requestedItem] = i;
            plainItems[(row - requestedItem) * col + requestedItem] = i;
        }

    }
}