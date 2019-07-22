using System;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int begin = 0;
        int end = input.Length - 1;
        int notFoundValue = -1;
        int middle;

        while (begin <= end)
        {
            middle = (int)Math.Ceiling((double)(end + begin) / 2);

            if (value == input[middle])
                return middle;
            else if (value > input[middle])
                begin = middle + 1;
            else
                end = middle - 1;
        }

        return notFoundValue;
    }
}