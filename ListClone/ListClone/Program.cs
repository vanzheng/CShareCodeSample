using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListClone
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Insert(0, "0");
            List<string> list2 = list;
            string[] arr = new string[4];
            list.CopyTo(arr);

            //Action<string> action = s => { Console.WriteLine(s); };
            //Array.ForEach(arr, action);
            string[] newArr = arr.Select(s => "[" + s + "]").ToArray();
            //list[2] = "4";

            //foreach (string s in list)
            //{
            //    Console.WriteLine(s);
            //}

            //foreach (string s in list2)
            //{
            //    Console.WriteLine(s);
            //}

            foreach (string s in arr)
            {
                Console.WriteLine(s);
            }

            foreach (string s in newArr) 
            {
                Console.WriteLine(s);
            }

            //string[] a1 = new string[] { "1", "2", "3" };
            //string[] a2 = new string[3];
            //Array.Copy(a1, a2, 3);

            //Console.WriteLine("Before array change");
            //Console.WriteLine("Array a1");
            //DisplayArray(a1);
            //Console.WriteLine("Array a2");
            //DisplayArray(a2);

            //a1[0] = "a";
            //Console.WriteLine("After array changed");
            //Console.WriteLine("Array a1");
            //DisplayArray(a1);
            //Console.WriteLine("Array a2");
            //DisplayArray(a2);

            //int i = 1;
            //int i2 = 2;
            //Console.WriteLine(string.ReferenceEquals(i, i2));
            Console.Read();
        }

        private static void DisplayArray(string[] arr) 
        {
            if (arr != null) 
            {
                foreach (string s in arr) 
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
