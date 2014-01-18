using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuncSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int> result = () => { return 1; };
            Console.WriteLine(result());
            Console.ReadLine();
        }
    }
}
