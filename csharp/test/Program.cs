using System;
using System.Linq;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] array = new char[] { };
            var value = 11;
            Console.WriteLine( Response("ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!"));
            System.Console.WriteLine(array.Any(char.IsUpper));
            System.Console.WriteLine("".Where(char.IsLetter).Any(char.IsLower));
        }

        public static string Response(string statement)
    {
        string trimmedStatement = statement.Trim();

        bool isScream = !trimmedStatement.Where(char.IsLetter).All(char.IsUpper);

        bool isSilent = !trimmedStatement.Any(char.IsLetterOrDigit);

        bool isQuestion = trimmedStatement.EndsWith('?');

        return AnswerOn(isScream, isQuestion, isSilent);
    }

    private static string AnswerOn(bool isNoise, bool isQuestion, bool isSilent)
    {
        if (isNoise && isQuestion)
            return "Calm down, I know what I'm doing!";
        else if (isNoise)
            return "Whoa, chill out!";
        else if (isQuestion)
            return "Sure.";
        else if (isSilent)
            return "Fine. Be that way!";
        else
            return "Whatever.";
    }
    }
}
