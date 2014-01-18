using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace PropertyInfoSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Name = "Tone";
            p.Age = 20;
            Person.FamilyName = "Bill";

            PropertyInfo pi = p.GetType().GetProperty("Name");
            string name = Convert.ToString(pi.GetValue(p, null));
            PropertyInfo[] pis = p.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //foreach (PropertyInfo pio in p.GetType().GetProperties(BindingFlags.Public)) 
            //{
                
            //}

            Console.WriteLine(name);
            Console.Read();
        }
    }

    public class Person 
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public static string FamilyName { get; set; }
    }
}
