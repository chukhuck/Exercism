using System;
using System.Linq;

public static class ResistorColor
{
    public enum ResistorColors
    {
        Black=0,
        Brown=1,
        Red=2,
        Orange=3,
        Yellow=4,
        Green=5,
        Blue=6,
        Violet=7,
        Grey=8,
        White=9 
    }

    public static int ColorCode(string color)
    {
        return Colors().IndexAt(color);
    }

    public static string[] Colors()
    {
        return new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
    }
}