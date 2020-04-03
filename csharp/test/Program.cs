using System;
using System.Linq;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "a";
           
            Console.WriteLine( -1%3);


        }

        public static int? HandleErrorByReturningNullableType(string input)
        {
            return int.TryParse(input, out int output) ? (int?)output : null;
        }
    }

}
