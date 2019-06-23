using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public static class Proverb
{

    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length == 0)
            return new string[0];

        return subjects.
                Zip(subjects.Skip(1), (x, y) => $"For want of a {x} the {y} was lost.").
                Append($"And all for the want of a {subjects.First()}.").
                ToArray();
    }
}