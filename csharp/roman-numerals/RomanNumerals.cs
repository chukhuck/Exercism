using System;
using System.Collections.Generic;
using System.Linq;



public static class RomanNumeralExtension
{
    static Dictionary<int, string> ra = new Dictionary<int, string>
        { { 1000, "M" },  { 900, "CM" },  { 500, "D" },  { 400, "CD" },  { 100, "C" },
                          { 90 , "XC" },  { 50 , "L" },  { 40 , "XL" },  { 10 , "X" },
                          { 9  , "IX" },  { 5  , "V" },  { 4  , "IV" },  { 1  , "I" } };

    public static string ToRoman(this int value)
    {
        var temp = ra.Where(d => value >= d.Key).FirstOrDefault();
        return temp.Key == 0 ? "" : temp.Value + ToRoman(value - temp.Key);
    }
}