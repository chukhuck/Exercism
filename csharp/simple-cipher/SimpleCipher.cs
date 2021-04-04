using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class SimpleCipher
{
    private string key;
    private static readonly int lenghtOfAlphabet = 26;
    private static readonly char beginingOfAlphabet = 'a';
    private IKeyGenerator generator;
    public SimpleCipher()
    {
        generator = new SimpleRamndomGenerator(lenghtOfAlphabet, beginingOfAlphabet);
        key = generator.CreateKey(100);
    }

    public SimpleCipher(string key)
    {
        this.key = key;
    }

    public string Key
    {
        get
        {
            return key;
        }
    }

    public string Encode(string plaintext)
    {
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < plaintext.Length; i++)
            builder.Append(((
                plaintext[i].ToDigit(beginingOfAlphabet) + key[i % key.Length].ToDigit(beginingOfAlphabet))
                .Mod(lenghtOfAlphabet))
                .ToChar(beginingOfAlphabet));

        return builder.ToString();
    }

    public string Decode(string ciphertext)
    {
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < ciphertext.Length; i++)
        {
            builder.Append(
                ((ciphertext[i].ToDigit(beginingOfAlphabet) -key[i % key.Length].ToDigit(beginingOfAlphabet)).
                Mod(lenghtOfAlphabet)).
                ToChar(beginingOfAlphabet));
        }

        return builder.ToString();
    }
}

internal class SimpleRamndomGenerator : IKeyGenerator
{
    private int modulo;
    private char firstChar;

    public SimpleRamndomGenerator(int modulo, char firstChar)
    {
        this.modulo = modulo;
        this.firstChar = firstChar;
    }

    public string CreateKey(int keyLenght)
    {
        Random randomGenerator = new Random();
        char[] keyAsArray = new char[keyLenght];

        for (int i = 0; i < keyLenght; i++)
            keyAsArray[i] = (char)(randomGenerator.Next(modulo) + firstChar);
        
        return new String(keyAsArray);  
    }
}

internal interface IKeyGenerator
{
    string CreateKey(int v);
}

public static class Extensions
{
    public static int ToDigit(this char c, char firstLetter)
    {
        return c - firstLetter;
    }

    public static char ToChar(this int digit, char firstLetter)
    {
        return (char)(digit + firstLetter);
    }

    public static int Mod(this int digit, int mod)
    {
        int result = digit % mod;
        return result >= 0 ? result : result + mod;
    }


}