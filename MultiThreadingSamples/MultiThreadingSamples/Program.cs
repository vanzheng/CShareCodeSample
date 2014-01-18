using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreadingSamples
{
    public class Program
    {
        bool done;

        static void Main(string[] args)
        {
            // MultiThread
            //Thread t = new Thread(WriteY);
            //t.Start();

            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.Write("X");
            //}


            // Demonstrate instance field multithreading
            //Program p = new Program();
            //Thread t = new Thread(p.Go);
            //t.Start();
            //p.Go();

            // MultiThread safety
            //ThreadSafety ts = new ThreadSafety();
            //Thread t = new Thread(ts.Go);
            //t.Start();

            //Thread t2 = new Thread(StaticThreadSafety.Go);
            //t2.Start();


            // Thread Join and Sleep.
            //Thread t = new Thread(delegate() 
            //    { 
            //        WriteY("b"); 
            //    });
            //Thread t = new Thread(() => WriteY("a"));
            //Thread.Sleep(1000);
            //t.Start();
            //t.Join();
            //Console.Write(Environment.NewLine);
            //Console.WriteLine("Thread t has ended.");

            //for (int i = 0; i < 10; i++) 
            //{
            //    int temp = i;
            //    new Thread(() => Console.Write(temp)).Start();
            //}

            // Thread Name
            //Thread.CurrentThread.Name = "main";
            //Thread worker = new Thread(PrintCurrentThreadName);
            //worker.Name = "worker";
            //worker.Start();
            //PrintCurrentThreadName();

            // Foreground and background threads.
            //BackgroundTest shortTest = new BackgroundTest(10);
            //Thread foregroundThread =
            //    new Thread(new ThreadStart(shortTest.RunLoop));
            //foregroundThread.Name = "ForegroundThread";

            //BackgroundTest longTest = new BackgroundTest(50);
            //Thread backgroundThread =
            //    new Thread(new ThreadStart(longTest.RunLoop));
            //backgroundThread.Name = "BackgroundThread";
            //backgroundThread.IsBackground = true;

            //foregroundThread.Start();
            //backgroundThread.Start();

            char use = 'a';

            Thread t1 = new Thread(ThreadNew);
            t1.Name = "NewThread";
            //IsBackground属性设置为false时 线程 NewThread是可以在主线程执行完毕后打印出两条消息的
            //IsBackground如果为true,则在主线程结束后，就打印不出第二条消息了 因为主线程（前台线程）结束了，后台线程也就跟着退出了。
            t1.IsBackground = true;
            t1.Start();

            Console.WriteLine("主线程已经结束");
        }

        static void WriteY(string s)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write(s);
            }
        }

        static void PrintCurrentThreadName()
        {
            Console.WriteLine("Hello from " + Thread.CurrentThread.Name);
        }

        void Go()
        {
            if (!done)
            {
                Console.WriteLine("Done");
                done = true;
            }
        }

        static void ThreadNew()
        {
            Console.WriteLine("新的线程开始输出消息");
            Thread.Sleep(10000);//停止4秒中让主线程可以比NewThread提前结束
            Console.WriteLine("新的线程结束输出消息");
            Console.ReadKey();
        }
    }

    public class ThreadSafety
    {
        bool done;
        object locker = new object();

        public void Go()
        {
            lock (locker)
            {
                if (!done)
                {
                    Console.WriteLine("Instance Done");
                    done = true;
                }
            }
        }
    }

    public class StaticThreadSafety
    {
        static bool done;
        static object locker = new object();

        public static void Go()
        {
            lock (locker)
            {
                if (!done)
                {
                    Console.WriteLine("Static Done");
                    done = true;
                }
            }
        }
    }

    class BackgroundTest
    {
        int maxIterations;

        public BackgroundTest(int maxIterations)
        {
            this.maxIterations = maxIterations;
        }

        public void RunLoop()
        {
            String threadName = Thread.CurrentThread.Name;

            for (int i = 0; i < maxIterations; i++)
            {
                Console.WriteLine("{0} count: {1}",
                    threadName, i.ToString());
                Thread.Sleep(250);
            }
            Console.WriteLine("{0} finished counting.", threadName);
        }
    }


}
