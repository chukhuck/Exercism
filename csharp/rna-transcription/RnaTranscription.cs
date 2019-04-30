using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        if (string.IsNullOrEmpty( nucleotide))
            return string.Empty;

        return GetRNA(nucleotide);
    }

    private static string GetRNA(string nucleotide)
    {
        return nucleotide
                        .Replace('G', 'X')
                        .Replace('C', 'G')
                        .Replace('X', 'C')
                        .Replace('A', 'U')
                        .Replace('T', 'A');
    }

    private static string GetRNA1(string nucleotide)
    {
        var encodeTable = CreateEncodeTable();

        return string.Join("", nucleotide.Select(c=> encodeTable[c]));
    }

    private static string GetRNA2(string nucleotide)
    {
        var encodeTable = CreateEncodeTable();

        StringBuilder builder = new StringBuilder();
        
        foreach (var letter in nucleotide)
            builder.Append(encodeTable[letter]);

        return builder.ToString();
    }

    private static Dictionary<char, char> CreateEncodeTable()
    {
        Dictionary<char, char> encodeTable = new Dictionary<char, char>();
        encodeTable.Add('G', 'C');
        encodeTable.Add('C', 'G');
        encodeTable.Add('A', 'U');
        encodeTable.Add('T', 'A');

        return encodeTable;
    }
}