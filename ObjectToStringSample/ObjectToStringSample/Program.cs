using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ObjectToStringSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Type t = car.GetType();
            //TypeAttributes attributes = t.Attributes;
            Console.WriteLine(car.ToString());
            Console.WriteLine(t.GUID.ToString());
            Console.Read();
        }
    }

    public class Car 
    {
        public string Name { get; set; }
        public int Wheels { get; set; }
        public decimal Length { get; set; }

        //public void Run() 
        //{
        //    Console.WriteLine("The car " + this.Name + " is running.");
        //}
    }
}
