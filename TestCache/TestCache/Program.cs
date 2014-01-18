using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCache
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            //dict.Add("a", "1");
            //dict.Add("b", "2");
            Console.WriteLine(dict["a"]);

            Dictionary<string, string> dict2 = new Dictionary<string, string>();
            //Console.WriteLine(dict2["a"]);
            Console.ReadKey();
        }
    }
}
