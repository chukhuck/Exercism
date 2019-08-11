using System;
using System.Linq;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = AffineCipher.Encode("The quick brown fox jumps over the lazy dog.", 17, 33);
            var etalon = "swxtj npvyk lruol iejdc blaxk swxmh qzglf";

            for (int i = 0; i < etalon.Length; i++)
            {
                System.Console.WriteLine($"{i} - {test[i] == etalon[i]}");
            }
            Console.WriteLine( test);
            System.Console.WriteLine(etalon);
            System.Console.WriteLine(etalon.Equals( test));
        }
    }

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
        MMI = GetMMI(a);
    }

    public int A { get; private set; } = -1;

    public int MMI { get; private set; } = -1;

    public int B { get; private set; } = -1;

    public readonly int M = 26;

    public void SetKey(int a, int b)
    {
        A = a;
        B = b;
        MMI = GetMMI(a);
    }

    private int GetMMI(int a)
    {
        if (!IsCoprime(a, M))
            throw new ArgumentException();

        int mmi = 1;
        while (mmi < M)
        {
            if(((mmi * a) % M) == 1)
                break; 

            mmi++;
        }

        return mmi;
    }

private bool IsCoprime(int a, int b)
    {
        List<int> firstFactors = GetFactors(a);
        List<int> secondFactors = GetFactors(b);
        return firstFactors.Intersect(secondFactors).Count() == 0;
    }

    private List<int> GetFactors(int a)
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

    public char Decode(char letter)
    {
        var cipheredNumber = letter - 'a';
        return (char)((MMI * (cipheredNumber > B ? cipheredNumber - B : cipheredNumber - B + M * (B / M + 1))) % M + 'a');

    }

    public char Encode(char letter)
    {
        return (char)(((letter - 'a') * A + B) % M + 'a');
    }
}
}
