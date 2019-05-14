using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        List<int> temp = new List<int>();

        foreach (var item in multiples)
        {
            if (item == 0)
                break;

            int limit = max%item == 0 ? max / item : max / item + 1;
            
            for (int i = 1; i < limit; i++)
                temp.Add(i*item);
        }

        return temp.Distinct().Sum();
    }
}