using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class House
{
    private static List<(string, string)> rythmObjects = new List<(string, string)>()
    {
        ("house" , "Jack built"),
        ("malt" , "lay in"),
        ("rat" , "ate"),
        ("cat" , "killed"),
        ("dog" , "worried"),
        ("cow with the crumpled horn" , "tossed"),
        ("maiden all forlorn" , "milked"),
        ("man all tattered and torn" , "kissed"),
        ("priest all shaven and shorn" , "married"),
        ("rooster that crowed in the morn" , "woke"),
        ("farmer sowing his corn" , "kept"),
        ("horse and the hound and the horn" , "belonged to")
    };



    public static string Recite(int verseNumber)
    {
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < verseNumber; i++)
        {
            if(i == 0)
                builder.Append($"This is the {rythmObjects[verseNumber - i - 1].Item1} that {rythmObjects[verseNumber - i - 1].Item2}");
            else
                builder.Append($" the {rythmObjects[verseNumber - i - 1].Item1} that {rythmObjects[verseNumber - i - 1].Item2}");
        }

        builder.Append(".");

        return builder.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        return string.Join("\n", Enumerable.Range(startVerse, endVerse - startVerse + 1).Select(i => Recite(i)));
    }
}