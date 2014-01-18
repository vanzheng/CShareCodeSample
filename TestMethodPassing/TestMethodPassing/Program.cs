using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestMethodPassing
{
    class Program
    {
        static void Main(string[] args)
        {
            Sample sample = new Sample();
            sample.Value = 10;
            ChangeValue(sample);
            Console.WriteLine(sample.Value);
            ChangeValue(ref sample.Value);
            Console.WriteLine(sample.Value);
            Console.ReadKey();
        }

        static void ChangeValue(Sample sample) 
        {
            sample.Value = 20;
        }

        static void ChangeValue(ref int value) 
        {
            value = 30;
        }
    }

    public class Sample 
    {
        public int Value;
    }
}
