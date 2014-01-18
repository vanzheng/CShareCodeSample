using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThrowArgumentNullException();
            //ThrowArgumentException();
            ThrowException();
        }

        private static void ThrowArgumentNullException() 
        {
            throw new ArgumentNullException("my");
        }

        private static void ThrowArgumentException() 
        {
            throw new ArgumentException();
        }

        private static void ThrowException() 
        {
            throw new Exception("aaa");
        }
    }
}
