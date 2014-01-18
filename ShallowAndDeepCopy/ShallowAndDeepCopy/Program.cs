using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ShallowAndDeepCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            a.Name = "This is a class.";
            a.Version = "1.0";
            a.Length = 10;
            a.Worth = 1000m;
            a.PublishTime = DateTime.Now;

            A a2 = (A)a.Clone();
            A a3 = DeepCopy<A>(a);

            Console.WriteLine("Before change");
            Console.WriteLine("a1");
            a.Display();
            Console.WriteLine("a2");
            a2.Display();
            Console.WriteLine("-----------------------");

            a2.Num[0] = 10;
            a2.Name = "This is a2 class.";
            a2.Version = "2.0";
            a2.Length = 20;
            a2.Worth = 2000m;
            a2.PublishTime = DateTime.Now.AddDays(2);

            a3.Num[0] = 20;
            a3.Name = "This is a3 class.";
            a3.Version = "3.0";
            a3.Length = 30;
            a3.Worth = 3000m;
            a3.PublishTime = DateTime.Now.AddDays(3);
            Console.WriteLine("After changed");
            Console.WriteLine("a1");
            a.Display();
            Console.WriteLine("a2");
            a2.Display();
            Console.WriteLine("a3");
            a3.Display();

            Console.ReadKey();
        }

        public static T DeepCopy<T>(T item)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, item);
            stream.Seek(0, SeekOrigin.Begin);
            T result = (T)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
    }

    [Serializable]
    public class A : ICloneable
    {

        public int[] Num = { 3, 4, 5, 6 };

        public int Length { get; set; }

        public decimal Worth { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public DateTime PublishTime { get; set; }

        public void Display() 
        {
            foreach (int i in Num) 
            {
                Console.Write(i + ",");
            }
            Console.WriteLine();
            Console.WriteLine("class name:" + Name);
            Console.WriteLine("version:" + Version);
            Console.WriteLine("length:" + Length);
            Console.WriteLine("worth:" + Worth);
            Console.WriteLine("publish time:" + PublishTime.ToString());
        }

        public object Clone() 
        {
            return this.MemberwiseClone();
        }
    }
}
