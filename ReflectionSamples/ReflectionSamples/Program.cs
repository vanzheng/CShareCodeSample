using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ReflectionSamples
{
    public class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            Type animalType = animal.GetType();
            PropertyInfo[] pis = animalType.GetProperties();

            foreach (PropertyInfo pi in pis) 
            {
                Console.WriteLine(String.Format("Name: {0}; Value: {1}; DataType: {2}.", pi.Name, pi.GetValue(animal, null), pi.PropertyType.ToString()));
            }

            Console.ReadLine();
        }
    }

    public class Animal 
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public bool Gender { get; set; }

        public void DoWork() 
        {
        
        }
    }
}
