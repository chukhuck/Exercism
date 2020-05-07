using System;
using System.Linq;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 2, 5 };
            var initial = 5;
            var function = new Func<int, int, int>((x, y) => x / y);
            Console.WriteLine(Foldr(list, initial, function));
        }

        public static int Length<T>(List<T> input)
    {
        return input.Count;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        List<T> temp = new List<T>(input.Count);

        for (int i = input.Count - 1; i > -1; i--)
        {
            temp.Add(input[i]);
        }

        return temp;
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        List<TOut> temp = new List<TOut>(input.Count);

        for (int i = 0; i < input.Count; i++)
        {
            temp.Add(map(input[i]));
        }

        return temp;
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        List<T> temp = new List<T>(input.Count);

        for (int i = 0; i < input.Count; i++)
        {
            if (predicate(input[i]))
                temp.Add(input[i]);
        }

        return temp;
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        TOut temp = start;

        for (int i = 0; i < input.Count; i++)
        {
            temp = func(temp, input[i]);
        }

        return temp; 
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        TOut temp = start;

        for (int i = 0; i < input.Count; i++)
        {
            temp = func(input[i], temp);
        }

        return temp; 
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        List<T> temp = new List<T>();

        for (int i = 0; i < input.Count; i++)
        {
            temp.AddRange(input[i]);
        }

        return temp;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        List<T> temp = new List<T>(left.Count + right.Count);
        temp.AddRange(left);
        temp.AddRange(right);

        return temp;
    }

    }
}
