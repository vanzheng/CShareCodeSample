using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleLinqSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");

            var hasName = from str in list
                          where str == "3"
                          select str;

            //if (hasName == null) 
            //{
            //    Console.WriteLine("The list doesn't have 3.");
            //}

            if (hasName.Count() == 0) 
            {
                Console.WriteLine("The list doesn't have 3.");
            }

            Console.ReadLine();
        }
    }
}
