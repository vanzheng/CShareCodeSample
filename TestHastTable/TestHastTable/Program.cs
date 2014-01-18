using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestHastTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add("1", "a");
            ht.Add("2", "b");
            ht.Add("3", "c");
            ht.Add("4", "d");
            //ht.Add("1", "z");
            ht["1"] = "z";

            Console.WriteLine(ht["1"]);
            //foreach (object obj in ht.Values) 
            //{
            //    Console.WriteLine(obj);
            //}
            //Console.WriteLine("Hashtable keys:" + ht.Keys);
            //Console.WriteLine("Hashtable values:" + ht.Values);
            Console.ReadKey();
        }
    }

}
