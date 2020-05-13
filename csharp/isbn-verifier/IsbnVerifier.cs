using System;
using System.Text.RegularExpressions;
using System.Linq;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        Regex isbnPattern = new Regex(@"^\d-?\d{3}-?\d{5}-?[\dX]$");

        if (!isbnPattern.IsMatch(number))
            return false;

        int sum = number.Replace("-", "")
                     .Replace("X", "A")
                     .Select((c, idx) => Convert.ToInt32(c.ToString(), 16) * (10 - idx))
                     .Sum();

        return sum % 11 == 0;


    }
}