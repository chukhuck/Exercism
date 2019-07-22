using System;
using System.Linq;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 1, 3, 4, 6, 8, 9, 11};
            var value = 11;
            Console.WriteLine( Find(array, value));
        }

        public static int Find(int[] input, int value)
        {
            int begin = 0;
            int end = input.Length - 1;
            int pointer = -1;
            int middle;

            while (begin <= end)
            {
                middle = (int)Math.Ceiling((double)(end + begin) / 2);

                if (value == input[middle])
                    { pointer = middle; break; }
                else if (value > input[middle])
                    begin = middle + 1;
                else
                    end = middle - 1;
            }

            return pointer;
        }
    }
}
