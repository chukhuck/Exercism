using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{


private static readonly Dictionary<string, string> encodingTable = new Dictionary<string, string>()
{
    {"AUG","Methionine"},
    {"UUU","Phenylalanine"}, {"UUC","Phenylalanine"},
    {"UUA","Leucine"}, {"UUG","Leucine"},
    {"UCU","Serine"}, {"UCC","Serine"}, {"UCA","Serine"}, {"UCG","Serine"},
    {"UAU","Tyrosine"}, {"UAC","Tyrosine"},
    {"UGU","Cysteine"}, {"UGC","Cysteine"},
    {"UGG","Tryptophan"},
    {"UAA","STOP"}, {"UAG","STOP"}, {"UGA","STOP"}
};



    public static string[] Proteins(string strand)
    {
        return GetCodons(strand).
               Select(codon => encodingTable[codon]).
               TakeWhile(protein => protein != "STOP").
               ToArray();
    }

    private static IEnumerable<string> GetCodons(string strand)
    {
        for (int i = 0; i < strand.Length; i+=3)
            yield return strand.Substring(i, 3);
    }
}