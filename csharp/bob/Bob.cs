using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        string trimmedStatement = statement.Trim();

        bool isScream = false;
        if (trimmedStatement.Any(char.IsLetter))
            isScream = trimmedStatement.Where(char.IsLetter).All(char.IsUpper);

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