using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListCopySample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");

            string[] arr = list.ToArray();
            string[] arr2 = new string[3];
            list.CopyTo(arr2);
            list.Add("4");
            Console.WriteLine("List Element:");
            foreach (string s in list) 
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Array Element:");
            arr[1] = "a";
            foreach (string s in arr) 
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Array2 Element:");
            foreach (string s in arr2) 
            {
                Console.WriteLine(s);
            }

            Console.ReadLine();
        }
    }
}
