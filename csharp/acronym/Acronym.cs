using System;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        char[] denySymbols = {',', '\'', '_', '.'};
        char[] separators = {' ', '-'};

        return string.Join("", phrase
                                    .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(
                                        word => word.ToUpper().TrimStart(denySymbols).First())); 
    }
}