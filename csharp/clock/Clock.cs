using System;

public struct Clock
{
    public Clock(int hours, int minutes)
    {
        Hours = (hours + minutes/60) % 24;
        Minutes = minutes % 60;

        Hours = Minutes < 0 ? Hours - 1 : Hours;
        Hours = Hours < 0 ? Hours + 24 : Hours;
        

        Minutes = Minutes < 0 ? Minutes + 60 : Minutes;
    }

    public int Hours {get; private set;}

    public int Minutes {get; private set;}


    public Clock Add(int minutesToAdd) => new Clock(Hours + minutesToAdd / 60, Minutes + minutesToAdd % 60);

    public Clock Subtract(int minutesToSubtract) => new Clock(Hours - minutesToSubtract / 60, Minutes - minutesToSubtract % 60);


    public override string ToString() => $"{Hours:00}:{Minutes:00}";


   //public override bool Equals(Object obj)
   //{
   //    if ((obj == null) || ! this.GetType().Equals(obj.GetType())) 
   //    {
   //       return false;
   //    }
   //    else { 
   //       Clock p = (Clock) obj; 
   //       return (Hours == p.Hours) && (Minutes == p.Minutes);
   //    }   
   //}
  
   //ublic override int GetHashCode() => (Hours << 5) ^ Minutes;
}