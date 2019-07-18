using System;

public class Clock
{
    private int _hours;

    private int _minutes;

    public Clock(int hours, int minutes)
    {
        _hours = (hours + minutes/60) % 24;
        _minutes = minutes % 60;

        _hours = _minutes < 0 ? _hours - 1 : _hours;
        _hours = _hours < 0 ? _hours + 24 : _hours;
        

        _minutes = _minutes < 0 ? _minutes + 60 : _minutes;
    }

    public int Hours
    {
        get
        {
            return _hours;
        }
    }

    public int Minutes
    {
        get
        {
            return _minutes;
        }
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(_hours + minutesToAdd / 60, _minutes + minutesToAdd % 60);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(_hours - minutesToSubtract / 60, _minutes - minutesToSubtract % 60);    }

    public override string ToString()
    {
        return $"{_hours:00}:{_minutes:00}";
    }

    public override bool Equals(Object obj)
   {
      if ((obj == null) || ! this.GetType().Equals(obj.GetType())) 
      {
         return false;
      }
      else { 
         Clock p = (Clock) obj; 
         return (_hours == p._hours) && (_minutes == p._minutes);
      }   
   }

   public override int GetHashCode()
   {
      return (_hours << 5) ^ _minutes;
   }
}