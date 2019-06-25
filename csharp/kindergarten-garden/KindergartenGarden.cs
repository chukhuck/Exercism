using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{   
    private readonly int countOfPlantsPerStudent = 2;
    private readonly char[] splitters = {'\n'};
    private string _diagram;

    private List<string> children = new List<string>()
    {
        "Alice", "Bob", "Charlie", "David",
        "Eve", "Fred", "Ginny", "Harriet",
        "Ileana", "Joseph", "Kincaid", "Larry"
    };

    public KindergartenGarden(string diagram)
    {
        _diagram = diagram;
        children.Sort();
    }

    public IEnumerable<Plant> Plants(string student)
    {
        return _diagram
                    .Split(splitters)
                    .SelectMany(row => ConvertFrom(row.Substring(
                                                            children.IndexOf(student) * countOfPlantsPerStudent, 
                                                            countOfPlantsPerStudent)));
    }

    private Plant ConvertFrom(char code)
    {
        switch (code)
        {
            case 'V': return Plant.Violets;
            case 'R': return Plant.Radishes;
            case 'C': return Plant.Clover;
            case 'G': return Plant.Grass;
            default: throw new ArgumentException();
        }
    }

    private IEnumerable<Plant> ConvertFrom(string code)
    {
        foreach (var letter in code)
            yield return ConvertFrom(letter);
    }
}