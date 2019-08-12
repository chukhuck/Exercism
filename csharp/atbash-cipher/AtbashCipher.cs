using System;
using System.Linq;
using System.Collections.Generic;

public static class AtbashCipher
{
    public static ISubstitutionCipher cipher;

    public static string Encode(string plainText)
    {
        cipher = new MyAtbashCipher();

        var cipherText = string.Concat( plainText
                                .ToLower()
                                .Where(char.IsLetterOrDigit)
                                .Select(l => char.IsLetter(l) ? cipher.Encode(l) : l)); 

        return string.Concat(GroupCipheredText(cipherText, ' ', 5));
    }

    public static string Decode(string cipheredText)
    {
        cipher = new MyAtbashCipher();
        return string.Concat( cipheredText
                                .ToLower()
                                .Where(char.IsLetterOrDigit)
                                .Select(l => char.IsLetter(l) ? cipher.Decode(l) : l));      
    }

    private static IEnumerable<char> GroupCipheredText(IEnumerable<char> cipherText, char splitter, int countSymbolsInGroup)
    {
        int count = cipherText.Count();
        for (int i = 0; i < count; i++)
        {
            yield return cipherText.ElementAt(i);

            if(i % countSymbolsInGroup == countSymbolsInGroup - 1 && i != count - 1)
                yield return splitter;
        }
    }
}

public interface ISubstitutionCipher
{
    char Encode(char letter);

    char Decode(char letter);
}

internal class MyAtbashCipher : ISubstitutionCipher
{
    public readonly int LenghtOfAlphabet = 26;

    public char Decode(char letter)
    {
        return (char)(LenghtOfAlphabet - 1 - (letter - 'a') + 'a');
    }

    public char Encode(char letter)
    {
        return (char)(LenghtOfAlphabet - 1 - (letter - 'a') + 'a');
    }
}


