﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = Process.GetCurrentProcess().MainModule.FileName;//获得当前执行的exe的文件名。
            string str2 = Environment.CurrentDirectory;//获取和设置当前目录的完全限定路径。
            string str3 = Directory.GetCurrentDirectory();//获取应用程序的当前工作目录。
            string str4 = AppDomain.CurrentDomain.BaseDirectory;//获取基目录，它由程序集冲突解决程序用来探测程序集。
            string str5 = Application.StartupPath;//获取启动了应用程序的可执行文件的路径，不包括可执行文件的名称。
            string str6 = Application.ExecutablePath;//获取启动了应用程序的可执行文件的路径，包括可执行文件的名称。
            string str7 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//获取或设置包含该应用程序的目录的名称。

            Console.WriteLine("Process.GetCurrentProcess().MainModule.FileName: " + str1);
            Console.WriteLine("Environment.CurrentDirectory:" + str2);
            Console.WriteLine("Directory.GetCurrentDirectory():" + str3);
            Console.WriteLine("AppDomain.CurrentDomain.BaseDirectory: " + str4);
            Console.WriteLine("Application.StartupPath: " + str5);
            Console.WriteLine("Application.ExecutablePath: " + str6);
            Console.WriteLine("AppDomain.CurrentDomain.SetupInformation.ApplicationBase: " + str7);
            Console.WriteLine(Path.IsPathRooted("~/mypath"));
            Console.WriteLine(Path.IsPathRooted("~/mypath/"));
            Console.ReadKey();

            //A[] arr = new A[]
            //{
            //    new A("1"),
            //    new A("2"),
            //    new A("3")
            //};

            

            //if (Path.IsPathRooted("\\web\\"))
            //{
            //    Console.WriteLine("true");
            //}
            //Console.WriteLine("a.txt full path: " + Path.GetFullPath("a.txt"));
            //Console.ReadKey();

			//修改
        }
    }

    public class A 
    {
        public A(string name) 
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
