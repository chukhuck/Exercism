using System;

public static class Pangram
{
    private const string alphabet = "abcdefghijklmnopqrstuvwxyz";

    public static bool IsPangram(string input)
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
}
