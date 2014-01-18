using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCompareSample
{
    public class Program
    {
        static void Main(string[] args)
        {
            string a = "abc";
            string b = "ab";
            string c = "abc";
            string d = "1abc";
            string[] arr = new string[] { "a", "c", "d", "b" };
            Array.Sort(arr);
            Console.WriteLine("Compare b to a: " + string.Compare(b, a));
            Console.WriteLine("Compare a to c: " + string.Compare(a, c));
            Console.WriteLine("Compare a to d: " + string.Compare(a, d));
            Console.WriteLine("Start Array: ");
            
            foreach (string s in arr) 
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
