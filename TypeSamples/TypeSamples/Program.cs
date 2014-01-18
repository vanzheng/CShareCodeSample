using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            bool mybool = false;
            byte mybyte = 1;
            sbyte mysbyte = 1;
            byte[] mybytes = new byte[] { 1, 2 };
            DateTime myDateTime = DateTime.Now;
            
            int? i = 1;
            Type itype = i.GetType();
            string str = "a";
            Type strtype = str.GetType();
            byte[] arrbytes = new byte[] { 1, 2, 5 };
            Type byteType = arrbytes.GetType();
            Console.WriteLine(byteType.Name);
            Console.WriteLine(strtype.Name);
            Console.WriteLine(itype.Name);
            Console.ReadKey();
        }
    }
}
