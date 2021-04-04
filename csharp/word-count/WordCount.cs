using System;
using System.Collections.Generic;
using System.Linq;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        string[] separators = new string[]{" ", ",", "\n", };
        char[] trimmedChars = new char[]{'!', '&', '@', '$', ':', '%', '^', '\'', '.'};
        
        return phrase.Split(separators, StringSplitOptions.RemoveEmptyEntries)
              .Select(word => word.Trim(trimmedChars).ToLower())
              .GroupBy(word => word)
              .ToDictionary(groupedWord => groupedWord.Key, groupedWord => groupedWord.Count());
    }
}