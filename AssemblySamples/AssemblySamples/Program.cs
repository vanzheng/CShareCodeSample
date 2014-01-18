using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AssemblySamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            Console.WriteLine("Assembly FullName: " + ass.FullName);
            Console.WriteLine("Assembly Location: " + ass.Location);
            Console.WriteLine("Assembly CodeBase: " + ass.CodeBase);

            AssemblyName assName = new AssemblyName(ass.FullName);
            Console.WriteLine("Assembly Name: " + assName.Name);
            Console.WriteLine("Assembly Full Name: " + assName.FullName);

            string[] arr = { "1", "" };
            arr[1].Trim();

            Console.ReadLine();
        }
    }
}
