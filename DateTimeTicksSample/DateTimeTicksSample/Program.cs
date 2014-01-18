using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace DateTimeTicksSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(DateTime.Now.Ticks);
            //Console.WriteLine(DateTime.Now.Ticks);
            //Console.WriteLine(DateTime.Now.Ticks);
            //Console.WriteLine(DateTime.Now.Ticks);
            //Console.WriteLine(DateTime.Now.Ticks);
            //Console.WriteLine(DateTime.Now.Ticks);
            //Console.WriteLine(DateTime.Now.Ticks);
            //Console.WriteLine(DateTime.Now.Ticks);
            //Console.WriteLine(DateTime.Now.Ticks);
            //Console.WriteLine(DateTime.Now.Ticks);
            //int i = 1000;
            //Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(i)));
            //Console.WriteLine(125.ToString("x2"));
            //Console.WriteLine(i >> 3);
            //Console.WriteLine(long.MaxValue);
            //Console.WriteLine(long.MaxValue >> 32);

            //Console.WriteLine(Next(10));
            //string s = new string[];
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(CreateRandomCode(5));
            }
            Console.Read();
        }

        private static int Next(int max)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] randb = new byte[4];
            rng.GetBytes(randb);
            int value = BitConverter.ToInt32(randb, 0);
            value = value % (max + 1);
            if (value < 0)
                value = -value;
            return value;
        }

        public static string CreateRandomCode(int codeCount)
        {
            char[] allcodes = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 
                                  'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'w', 'x', 'y', 'z', 
                                  'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'W', 'X', 'Y', 'Z' };

            int len = allcodes.Length;
            StringBuilder randomCode = new StringBuilder();
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] byteSeed = new byte[4];
            int seed, pos;

            for (int i = 0; i < codeCount; i++)
            {
                rng.GetBytes(byteSeed);
                seed = Math.Abs(BitConverter.ToInt32(byteSeed, 0));
                Random random = new Random(seed);
                pos = random.Next(len - 1);
                randomCode.Append(allcodes[pos]);
            }

            return randomCode.ToString();
        }
    }
}
