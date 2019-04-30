using System;
using System.Linq;
using System.Text;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        return string.Join("",input.Reverse());
    }

    public static string ReverseByOtherWay(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;


        StringBuilder builder = new StringBuilder();

        for (int i = input.Length - 1; i > -1; i--)
            builder.Append(input[i]);


        return builder.ToString();
    }
}