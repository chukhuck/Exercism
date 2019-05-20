using System;
using System.Collections.Generic;

public static class Darts
{
    public const double OUTER_RADIUS = 10; 
    public const double MIDDLE_RADIUS = 5;
    public const double INNER_RADIUS = 1; 
    public const int NO_TARGET_SCORE = 0;
    public const int OUTER_RADIUS_SCORE = 1;
    public const int MIDDLE_RADIUS_SCORE = 5;
    public const int INNER_RADIUS_SCORE = 10; 


    public static int Score(double x, double y)
    {
        double distance = Math.Sqrt(x*x + y*y);

        if(distance <= INNER_RADIUS)
            return INNER_RADIUS_SCORE;
        else if(distance <= MIDDLE_RADIUS)
            return MIDDLE_RADIUS_SCORE;
        else if(distance <= OUTER_RADIUS)
            return OUTER_RADIUS_SCORE;
        else
            return NO_TARGET_SCORE;
       
    }
}
