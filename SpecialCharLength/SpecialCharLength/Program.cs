using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialCharLength
{
    public class Program
    {
        static void Main(string[] args)
        {
            string s = @"\t";
            string s2 = @"\n";
            string s3 = @"\t\n";
            string str = @"123\n1";
            Console.WriteLine(s.Length);
            Console.WriteLine(s2.Length);
            Console.WriteLine(s3.Length);
            Console.WriteLine(str.Length);
            Console.WriteLine(str[4]);
            Console.Read();
        }
    }
}
