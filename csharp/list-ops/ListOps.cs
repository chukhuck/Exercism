using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input) => Foldl(input, 0, (count, _) => count + 1);

    public static List<T> Reverse<T>(List<T> input)
    => Foldl(input, new List<T>(), (list , item) => Append(new List<T>(){item}, list));

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    => Foldl(input, new List<TOut>(), (list , item) => Append(list, new List<TOut>(){map(item)}));

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    => Foldl(input, new List<T>(), (list, item) => predicate(item) ? Append(list, new List<T>(){item}) : NoAction(list));

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        TOut temp = start;

        for (int i = 0; i < input.Count; i++)
            temp = func(temp, input[i]);

        return temp; 
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    => Foldl(Reverse(input), start, (val, i) => func(i, val));

    public static List<T> Concat<T>(List<List<T>> input)
    => Foldl(input, new List<T>(), (commonList, subList) => Append(commonList, subList));

    public static List<T> Append<T>(List<T> left, List<T> right)
    => Foldl(right, new List<T>(left), (list, item) => list.Append(item).ToList());

    public static List<T> NoAction<T>(List<T> input) => input;
}