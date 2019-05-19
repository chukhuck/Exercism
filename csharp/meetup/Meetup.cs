using System;

public enum Schedule
{
    Teenth = -1,
    First = 0,
    Second = 1,
    Third = 2,
    Fourth = 3,
    Last = -2
}

public class Meetup
{
    private readonly int _month;
    private readonly int _year;

    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
       switch (schedule)
       {
           case Schedule.First:
           case Schedule.Second:
           case Schedule.Third:
           case Schedule.Fourth:
                return GetFirstDayOfWeek(dayOfWeek).AddWeeks((int)schedule);
           case Schedule.Last:
                DateTime forth = GetFirstDayOfWeek(dayOfWeek).AddWeeks(3);
                return DateTime.DaysInMonth(_year, _month) - forth.Day < 7 ? forth : forth.AddWeeks(1);
           case Schedule.Teenth:
                DateTime first = GetFirstDayOfWeek(dayOfWeek);
                return first.Day < 6 ? first.AddWeeks(2) : first.AddWeeks(1);
           default:
                throw new ArgumentException("Invalid argument");
       }
    }

    private DateTime GetFirstDayOfWeek(DayOfWeek dayOfWeek)
    {
        DateTime realDate = new DateTime(_year, _month, 1);
        
        while (realDate.DayOfWeek != dayOfWeek)
            realDate = realDate.AddDays(1);

        return realDate;
    }
}

public static class DateTimeExtension
{
    public static DateTime AddWeeks(this DateTime dt, int countOfWeek) 
    {
        return dt.AddDays(7 * countOfWeek);
    }
}
