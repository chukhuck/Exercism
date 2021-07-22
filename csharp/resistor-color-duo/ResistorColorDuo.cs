using System;
using System.Linq;
using System.Collections.Generic;

public static class ResistorColorDuo
{
    private static List<string> pallette = new List<string>
    {
            "black",
            "brown",
            "red",
            "orange",
            "yellow",
            "green",
            "blue",
            "violet",
            "grey",
            "white"
    };
    public static int Value(string[] colors)
    {
        return pallette.IndexOf(colors[0])*10 + pallette.IndexOf(colors[1]) ;
    }
}
