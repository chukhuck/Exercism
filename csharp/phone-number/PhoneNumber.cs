using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        string numberPattern = @"^[2-9]\d\d[2-9]\d\d\d\d\d\d";

        var cleanedNumber = string.Join("", phoneNumber.Where(char.IsDigit));

        if(cleanedNumber.Length == 11 && cleanedNumber[0] == '1')
            cleanedNumber = cleanedNumber.Substring(1);

        if (!Regex.IsMatch(cleanedNumber, numberPattern) || cleanedNumber.Length > 10)
            throw new ArgumentException("Invalid argument.");

        return cleanedNumber;
    }
}