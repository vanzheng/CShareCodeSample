using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DebugConditionalSample
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("This is Debug info.");
#endif 
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
