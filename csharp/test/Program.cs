using System;
using System.Linq;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in CountWords("Joe can't tell between 'large' and large."))
            {
                Console.WriteLine($"{item.Key}-{item.Value}");
            }
            
        }

        public static IDictionary<string, int> CountWords(string phrase)
        {
            string[] separators = new string[] { " ", ",", "\n", };
            char[] trimmedChars = new char[] { '!', '&', '@', '$', ':', '%', '^', '\'', '.' };

            return phrase.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                  .Select(word => word.Trim(trimmedChars).ToLower())
                  .GroupBy(word => word)
                  .ToDictionary(groupedWord => groupedWord.Key, groupedWord => groupedWord.Count());
        }

    }
}
