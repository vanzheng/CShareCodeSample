using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecimalTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal d = 0.00m;
            decimal d2 = 20.105m;
            decimal d3 = 20.004m;
            decimal d4 = 18;

            if (d == 0)
            {
                Console.WriteLine("true");
            }
            else 
            {
                Console.WriteLine("false");
            }
            Console.WriteLine(Math.Round(d2, 2));
            Console.WriteLine(Math.Round(d3, 2));
            Console.WriteLine(Math.Round(d4, 2));

            Console.Read();
        }
    }
}
