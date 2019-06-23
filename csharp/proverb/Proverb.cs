using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public static class Proverb
{
    static List<string> song = new List<string>();

    public static string[] Recite(string[] subjects)
    {
        song.Clear();

        if (subjects.Length > 1)
        {
            for (int i = 0; i < subjects.Length - 1; i++)
                song.Add($"For want of a {subjects[i]} the {subjects[i + 1]} was lost.");
        }

        if (subjects.Length != 0)
        {
            if(subjects.Contains("nail"))
                song.Add("And all for the want of a nail.");
            else
                song.Add($"And all for the want of a {subjects.First()}.");
        } 

        return song.ToArray();
    }
}