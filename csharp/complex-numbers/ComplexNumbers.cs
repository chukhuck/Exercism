using System;

public struct ComplexNumber
{
    public readonly double R;

    public readonly double I;

    public ComplexNumber(double real, double imaginary)
    {
        R = real;
        I = imaginary;
    }

    public double Real()
    {
        return R;
    }

    public double Imaginary()
    {
        return I;
    }

    public ComplexNumber Mul(ComplexNumber other)
    {
        return new ComplexNumber(R*other.R - I*other.I, I*other.R +  R*other.I);    
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(R + other.R, I + other.I);    
    }

    public ComplexNumber Sub(ComplexNumber other)
    {
        return new ComplexNumber(R - other.R, I - other.I);    
    }

    public ComplexNumber Div(ComplexNumber other)
    {
        return new ComplexNumber((R*other.R + I*other.I)/Math.Pow(other.Abs(), 2), (I*other.R -  R*other.I)/Math.Pow(other.Abs(), 2));    
    }

    public double Abs()
    {
        return Math.Sqrt(R*R + I*I);
    }

    public ComplexNumber Conjugate()
    {
        return new ComplexNumber(R, -1*I);
    }
    
    public ComplexNumber Exp()
    {
        return new ComplexNumber(Math.Pow( Math.E, R)*Math.Cos(I), Math.Pow( Math.E, R)*Math.Sin(I));
    }
}