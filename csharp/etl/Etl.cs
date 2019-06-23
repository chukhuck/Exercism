 using System;
using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> oldScores)
    {
        return oldScores.
                  SelectMany(score => score.Value, (score, letter) => (Letter: letter.ToLower(), Score: score.Key)).
                  ToDictionary(z => z.Letter, z => z.Score);; 
    }
}