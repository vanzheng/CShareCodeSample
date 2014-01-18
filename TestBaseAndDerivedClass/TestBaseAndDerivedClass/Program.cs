using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public class Program
    {
        static void Main(string[] args)
        {
            IShape ishape = new Square("长方形");
            //Square square = new Square("方形");
            //Shape shape = (Shape)square;
            //shape.Length = 10.0m;
            //shape.Width = 20m;
            //Console.WriteLine(shape.Area());
            //Console.WriteLine("shape type is: " + shape.GetType());
            //if (shape is App.Shape)
            //    Console.WriteLine("shape type is Square");
            ishape.Length = 10m;
            ishape.Width = 20m;
            Console.WriteLine("ishape type is: " + ishape.GetType());
            Console.WriteLine(ishape.Area());
            Console.WriteLine(Environment.CurrentDirectory);
            
            Console.ReadKey();
        }
    }
}
