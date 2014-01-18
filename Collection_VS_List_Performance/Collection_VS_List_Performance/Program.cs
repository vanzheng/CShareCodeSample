using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Collection_VS_List_Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCollectionPerformance();
            TestListPerformance();

            Console.ReadLine();
        }

        private static void TestCollectionPerformance()
        {
            ICollection<string> collection = new Collection<string>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                collection.Add(i.ToString());
            }

            IEnumerable<string> mystring = collection;

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine("The ICollection<string> elapsed time: " + elapsedTime.Milliseconds);
        }

        private static void TestListPerformance()
        {
            IList<string> list = new List<string>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(i.ToString());
            }

            IEnumerable<string> mystring = list;

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine("The IList<string> elapsed time: " + elapsedTime.Milliseconds);
        }
    }
}
