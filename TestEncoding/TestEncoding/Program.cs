using System;
using System.Text;

namespace TestEncoding
{
    public class Program
    {
        static void Main()
        {
            string s = "abc123";
            string s2 = "我";
            //Encoding ascii2 = Encoding.ASCII;
            Encoding ascii = Encoding.GetEncoding("ascii");
            Encoding utf = Encoding.GetEncoding("utf-16");
            Encoding utf8 = Encoding.UTF8;
            Encoding gb2312 = Encoding.GetEncoding("GB2312");
            byte[] asciiBytes = ascii.GetBytes(s);
            byte[] asciiBytes2 = ascii.GetBytes(s2);
            byte[] utfBytes = utf.GetBytes(s2);
            byte[] utf8Bytes = utf8.GetBytes(s2);
            int gb2312Count = gb2312.GetByteCount(s);
            int gb2312Count2 = gb2312.GetByteCount(s2);
            int utfCount = utf.GetByteCount(s);

            Console.WriteLine("/* ASCII start */");
            foreach (byte b in asciiBytes) 
            {
                Console.WriteLine(b);
            }
            Console.WriteLine(System.Environment.NewLine);
            foreach (byte b in asciiBytes2)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine(System.Environment.NewLine);
            Console.WriteLine("/* UTF-16 start */");
            foreach (byte b in utfBytes) 
            {
                Console.WriteLine(b);
            }
            
            Console.WriteLine("/* UTF-8 start */");
            foreach (byte b in utf8Bytes) 
            {
                Console.WriteLine(b);
            }
            Console.WriteLine("GB2312 byte count");
            Console.WriteLine(gb2312Count);
            Console.WriteLine(gb2312Count2);
            Console.WriteLine("Utf bytes:" + utfCount);
            Console.ReadKey();
        }
    }
}
