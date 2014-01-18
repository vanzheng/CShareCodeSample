using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PathTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = "c:\\";
            string path2 = "a.txt";
            string path3 = "~/a.txt";
            string path4 = "~\\a.txt";
            string path5 = "\\a.txt";
            string path6 = "/a.txt";

            Console.WriteLine(Path.Combine(path1, path2));
            Console.WriteLine(Path.Combine(path1, path3));
            Console.WriteLine(Path.Combine(path1, path4));
            Console.WriteLine(Path.Combine(path1, path5));
            Console.WriteLine(Path.Combine(path1, path6));
            Console.WriteLine("Temp file:" + Path.GetTempFileName());
            Console.WriteLine("Temp folder:" + Path.GetTempPath());

            string path = @"\mydir\";
            string fileName = "myfile.ext";
            string fullPath = @"C:\mydir\myfile.ext";
            string pathRoot;

            pathRoot = Path.GetPathRoot(path);
            Console.WriteLine("GetPathRoot('{0}') returns '{1}'",
                path, pathRoot);

            pathRoot = Path.GetPathRoot(fileName);
            Console.WriteLine("GetPathRoot('{0}') returns '{1}'",
                fileName, pathRoot);

            pathRoot = Path.GetPathRoot(fullPath);
            Console.WriteLine("GetPathRoot('{0}') returns '{1}'",
                fullPath, pathRoot);

            string directoryPath = "C:\\a\\b\\c.txt";
            string directoryPath2 = "~\\a\\c.txt";
            Console.WriteLine("Directory Name:" + Path.GetDirectoryName(directoryPath));
            Console.WriteLine("Full Path:" + Path.GetFullPath(directoryPath2));
            Console.WriteLine(Path.IsPathRooted(path6));
            Console.ReadLine();
        }
    }
}
