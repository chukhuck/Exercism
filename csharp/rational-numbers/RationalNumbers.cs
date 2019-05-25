using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return Math.Pow(realNumber, (double)r.Numerator / r.Denomerator);
    }
}

public struct RationalNumber
{
    public readonly int Numerator;
    public readonly int Denomerator;


    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denomerator = denominator;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Denomerator + r1.Denomerator * r2.Numerator, r1.Denomerator * r2.Denomerator).Reduce() ;
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Denomerator - r1.Denomerator * r2.Numerator, r1.Denomerator * r2.Denomerator).Reduce() ;
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Numerator, r1.Denomerator * r2.Denomerator).Reduce() ;
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Denomerator, r1.Denomerator * r2.Numerator).Reduce() ;
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(Numerator), Math.Abs(Denomerator));
    }

    public RationalNumber Reduce()
    {
        int factor = Numerator != 0 ? GetGreatestCommonDivisorFor(Math.Abs(Numerator), Math.Abs( Denomerator)) : Denomerator; 
        int sign = Math.Sign(Denomerator);
       
       return new RationalNumber(Numerator * sign / factor, Denomerator * sign / factor);

    }

    public RationalNumber Exprational(int power)
    {
        return new RationalNumber((int)Math.Pow(Numerator, power), (int)Math.Pow(Denomerator, power));
    }

    public double Expreal(int baseNumber)
    {
       return baseNumber.Expreal(this);
    }


    private int GetGreatestCommonDivisorFor(int _a, int _b)
    {
        int a = _a > _b ? _a : _b;
        int b = _a > _b ? _b : _a;

        while(a  % b != 0)
        {
            int tempa = b;
            b = a % b;
            a = tempa;
        }

        return  b;
    }
}