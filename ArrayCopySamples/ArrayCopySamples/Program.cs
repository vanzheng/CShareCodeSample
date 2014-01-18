using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayCopySamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str1 = new string[] { "1", "2", "3" };
            string[] str2 = new string[3];
            Array.Copy(str1, str2, 3);
            str1[0] = "a";

            Console.WriteLine("str2[0] = " + str2[0]);
            Console.ReadLine();
        }
    }
}
