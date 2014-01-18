using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StreamWriterSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string filepath = @"a\b\1.txt";
            string path = Path.Combine(basePath, filepath);
            using (StreamWriter writer = new StreamWriter(path, true)) 
            {
                writer.WriteLine("Hello!");
                writer.Flush();
            }

            Console.WriteLine("The file created.");
            Console.ReadLine();
        }
    }
}
