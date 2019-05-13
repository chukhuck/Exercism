using System;

public class SpaceAge
{
    private const int EARTH_ORBITAL_PERIOD_IN_SECONDS = 31557600;
    private const double MERCURY_ORBITAL_PERIOD_IN_EARTH_YEAR = 0.2408467;
    private const double VENUS_ORBITAL_PERIOD_IN_EARTH_YEAR = 0.61519726;
    private const double MARS_ORBITAL_PERIOD_IN_EARTH_YEAR = 1.8808158;
    private const double JUPITER_ORBITAL_PERIOD_IN_EARTH_YEAR = 11.862615;
    private const double SATURN_ORBITAL_PERIOD_IN_EARTH_YEAR = 29.447498;
    private const double URANUS_ORBITAL_PERIOD_IN_EARTH_YEAR = 84.016846;
    private const double NEPTUNE_ORBITAL_PERIOD_IN_EARTH_YEAR = 164.79132;


    private int _ageInSeconds;

    public SpaceAge(int seconds)
    {
        _ageInSeconds = seconds;
    }

    public double OnEarth()
    {
        return _ageInSeconds / EARTH_ORBITAL_PERIOD_IN_SECONDS ;
    }

    public double OnMercury()
    {
        return OnEarth() * MERCURY_ORBITAL_PERIOD_IN_EARTH_YEAR;
    }

    public double OnVenus()
    {
        return OnEarth() * VENUS_ORBITAL_PERIOD_IN_EARTH_YEAR;
    }

    public double OnMars()
    {
        return OnEarth() * MERCURY_ORBITAL_PERIOD_IN_EARTH_YEAR;
    }

    public double OnJupiter()
    {
        return OnEarth() * JUPITER_ORBITAL_PERIOD_IN_EARTH_YEAR;
    }

    public double OnSaturn()
    {
        return OnEarth() * SATURN_ORBITAL_PERIOD_IN_EARTH_YEAR;
    }

    public double OnUranus()
    {
        return OnEarth() * URANUS_ORBITAL_PERIOD_IN_EARTH_YEAR;
    }

    public double OnNeptune()
    {
        return OnEarth() * NEPTUNE_ORBITAL_PERIOD_IN_EARTH_YEAR;
    }
}