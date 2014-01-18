using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractClassSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child();
            child.Eat("meal");
            Console.Read();
        }
    }

    public abstract class Person
    {
        public virtual void Eat(string food)
        {
            Console.WriteLine(food);
        }
    }

    public class Child : Person
    {
    
    }
}
