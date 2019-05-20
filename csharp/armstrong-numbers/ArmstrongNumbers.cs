using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        string numberAsString = number.ToString();

        return number == numberAsString.Select(c=> Math.Pow(int.Parse(c.ToString()), numberAsString.Length)).Sum();
    }
}