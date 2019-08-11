using System;
using System.Linq;
using System.Collections.Generic;

public static class AffineCipher
{
    public static ISubstitutionCipher cipher;

    public static string Encode(string plainText, int a, int b)
    {
        cipher = new MyAffineCipher( a,  b);

        var cipherText = string.Concat( plainText
                                .ToLower()
                                .Where(char.IsLetterOrDigit)
                                .Select(l => char.IsLetter(l) ? cipher.Encode(l) : l)); 

        return string.Concat(GroupCipheredText(cipherText, ' ', 5));
    }

    public static string Decode(string cipheredText, int a, int b)
    {
        cipher = new MyAffineCipher( a,  b);
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

public class MyAffineCipher : ISubstitutionCipher
{
    public MyAffineCipher(int a, int b)
    {
        A = a;
        B = b;
        MMI = MathHelper.GetMMIFor(a, M);

    }

    public int A { get; private set; } = -1;

    public int MMI { get; private set; } = -1;

    public int B { get; private set; } = -1;

    public readonly int M = 26;

    public char Decode(char letter)
    {
        return (char)((MMI * MathHelper.Mod(letter - 'a' - B, M)) % M + 'a');
    }
    public char Encode(char letter)
    {
        return (char)(((letter - 'a') * A + B) % M + 'a');
    }
}

public class MathHelper
{
    public static bool IsCoprime(int a, int b)
    {
        List<int> firstFactors = GetFactorsFor(a);
        List<int> secondFactors = GetFactorsFor(b);
        return firstFactors.Intersect(secondFactors).Count() == 0;
    }

    public static List<int> GetFactorsFor(int a)
    {
        List<int> factors = new List<int>();

        int i = 2;

        while(i <= a / 2)
        {
            if(a % i == 0)
                factors.Add(i);

            i++;
        }

        factors.Add(a);

        return factors;
    }

    //Calculate Modular Multiplicative Inverse
    public static int GetMMIFor(int a, int modulo)
    {
        if (!IsCoprime(a, modulo))
            throw new ArgumentException();

        int mmi = 1;
        while (mmi < modulo)
        {
            if(((mmi * a) % modulo) == 1)
                break; 

            mmi++;
        }

        return mmi;
    }

    public static int Mod(int number, int modulo)
    {
        return (number > 0 ? number : number + modulo * (Math.Abs(number) / modulo + 1));
    }
}
