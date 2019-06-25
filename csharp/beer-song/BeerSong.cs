using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        StringBuilder builder = new StringBuilder();
        
        for (int i = startBottles; i >= 0 && i > startBottles - takeDown; i--)
            BuildVerse(builder, i);

        return builder.ToString().Trim(new char[]{'\n'});
    }

    public static string Recite1(int startBottles, int takeDown) =>
        string.Join("\n", Enumerable.
                                Range(startBottles - takeDown + 1, takeDown).
                                Reverse().
                                Select(i => GetFirstSentence(i) + GetSecondSentence(i))).
                                TrimEnd(new char[]{'\n'});

    private static void BuildVerse(StringBuilder builder, int i)
    {
        builder.Append(GetFirstSentence(i));
        builder.Append(GetSecondSentence(i));
        builder.Append("\n");
    }

    private static string BottlesToString(int i, bool isInStartPosition = false)
    {
        return $"{(i != 0 ? i.ToString() : (isInStartPosition ? "No more" : "no more") )} bottle{(i == 1 ? "" : "s")}";
    }

    private static string GetFirstSentence(int i)
    {
        return $"{BottlesToString(i, isInStartPosition:true)} of beer on the wall, {BottlesToString(i)} of beer.\n";
    }

    private static string GetSecondSentence(int i)
    {
        if (i > 0)
            return $"Take {(i > 1 ? "one" : "it")} down and pass it around, {BottlesToString(i - 1)} of beer on the wall.\n";
        else
            return "Go to the store and buy some more, 99 bottles of beer on the wall.\n";
    }
}