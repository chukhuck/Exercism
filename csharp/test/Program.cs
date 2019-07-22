using System;
using System.Linq;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //,"enlists", "google", "banana"
            var candidates = new[] {  "inlets" };
            var sut = new Anagram("listen");

            Console.WriteLine(sut.FindAnagrams(candidates));
        }
    }

        public struct LetterDistributionItem
    {
        public char Letter;
        public int Count;
    }

    public static class IListLetterDistributionExtension
    {
        public static bool EqualsTo(this IList<LetterDistributionItem> distrib, IList<LetterDistributionItem> otherDistrib) 
        {
            if(distrib.Count != otherDistrib.Count)
                return false;
    
            for (int i = 0; i < distrib.Count; i++)
                {if (distrib[i].Letter != otherDistrib[i].Letter || distrib[i].Count != otherDistrib[i].Count)
                    Console.WriteLine($"{distrib[i].Letter} - {otherDistrib[i].Letter}, {distrib[i].Count} - {otherDistrib[i].Count}");
                    return false;
                }
    
            return true;
        }
    }



public class Anagram
{
    private string baseWord;
    private IList<LetterDistributionItem> etalonLetterDistribution;
    
    public Anagram(string _baseWord)
    {
        baseWord = _baseWord.ToLower();
        etalonLetterDistribution = GetLetterDistribution(baseWord);

        foreach (var item in etalonLetterDistribution)
        {
            Console.WriteLine($"{item.Letter} - {item.Count}");
        }
    }

    private IList<LetterDistributionItem> GetLetterDistribution(string word)
    {
        return (from c in word
                group c by c into letterGroup
                orderby letterGroup.Key
                select new LetterDistributionItem { 
                    Letter = letterGroup.Key, 
                    Count = letterGroup.Count() }).ToList();
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        return potentialMatches
                        .Where(match => match.ToLower() != baseWord &&
                                        match.Count() == baseWord.Count() &&
                                        etalonLetterDistribution.EqualsTo(GetLetterDistribution(match.ToLower())))
                        .ToArray();
    }
}
}
