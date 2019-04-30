using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if(number < 1)
         throw new ArgumentException();

        int counter = 0;

        while (number != 1)
        {    
            number = DoStep(number);
            counter++;
        }

        return counter;
    }

    private static int DoStep(int number)
    {
        return number % 2 == 0 ? number / 2 : number * 3 + 1;
    }
}