using System;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        if (string.IsNullOrEmpty(word))
            return true;

        var cleanWord = word.Replace(" ", "").Replace("-", "").ToLower();

        return cleanWord.GroupBy(letter => letter).Count() == cleanWord.Length;
    }
}
