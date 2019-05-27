using System;
using System.Collections.Generic;
using System.Linq;

public static class NucleotideCount
{


    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> table = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };

            var groupedDNA = from nucleotide in sequence
                             group nucleotide by nucleotide into g
                             select new { Value = g.Key , Count = g.Count()};

            foreach (var item in groupedDNA)
            {
                if(table.ContainsKey(item.Value))
                    table[item.Value] = item.Count;
                else
                    throw new ArgumentException();
            }

        return table;
    }

    public static IDictionary<char, int> Count1(string sequence)
    {
        Dictionary<char, int> table = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };

        try
        {
            sequence.GroupBy(n => n).ToList().ForEach(item => table[item.Key] = item.Count());
        }
        catch (KeyNotFoundException)
        {         
            throw new ArgumentException();
        }

        return table;
    }
}