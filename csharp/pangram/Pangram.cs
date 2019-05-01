using System;
using System.Linq;

public static class Pangram
{
    private const string alphabet = "abcdefghijklmnopqrstuvwxyz";

    public static bool IsPangram1(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;


        input = input.ToLowerInvariant();

        foreach (var letter in alphabet)
        {
            if (!input.Contains(letter))
                return false;
        }

        return true;
    }

    public static bool IsPangram2(string input)
    {
        return input.ToLower().Where(char.IsLetter).Distinct().Count() == 26;
    }

        public static bool IsPangram(string input)
    {
        return alphabet.Except(input.ToLower().Where(char.IsLetter)).Count() == 0;
    }


}
