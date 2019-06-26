using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private Dictionary<string, int> studentWithGrades = new Dictionary<string, int>();

    public void Add(string student, int grade)
    {
        studentWithGrades[student] = grade;
    }

    public IEnumerable<string> Roster()
    {
         return from s in studentWithGrades
                orderby s.Value, s.Key
                select s.Key;
    }

    public IEnumerable<string> Grade(int grade)
    {
        return from s in studentWithGrades
               where s.Value == grade
               orderby s.Key
               select s.Key;
    }
}