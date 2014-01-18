using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateSamples
{
    class Program
    {
        delegate void OutputString(string s);

        static void Main(string[] args)
        {
            OutputString output = WriteString;
            OutputString output2 = new OutputString(WriteString);
            //OutputString output3 = WriteString2;

            output("a");
            output2("b");

            //string a="aaa";
            Console.ReadKey();
        }

        static void WriteString(string s) 
        {
            Console.WriteLine(s);
        }

        static void WriteString(string s, string p) 
        {
            Console.WriteLine("{0} {1}", s, p);
        }

        static void WriteString2(string s, string a) 
        {
            Console.WriteLine("{0} {1}", s, a);
        }
    }
}
