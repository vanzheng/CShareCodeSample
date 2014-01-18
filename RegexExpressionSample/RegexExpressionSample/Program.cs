using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexExpressionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = "  {$paging 1 20}{123}distinctselect distinct * from mytable";
            
            //Regex reg = new Regex(@"\{\$paging (\d+) (\d+)\}", RegexOptions.Compiled);
            //Match match = reg.Match(text);
            //if (match.Success) 
            //{
            //    //Console.WriteLine(match.Index);
            //    Regex allWord = new Regex(@"\ball\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //    Regex distinctWord = new Regex(@"\bdistinct\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //    Match distinctMatch = distinctWord.Match(text);
            //    if (distinctMatch.Success) 
            //    {
            //        Console.WriteLine("distinct index: " + distinctMatch.Index);
            //    }

            //    GroupCollection groups = match.Groups;
            //    foreach (Group p in groups) 
            //    {
            //        Console.WriteLine(p.Value);
            //    }
            //}

            //string text2 = "{$top 20}select * from mytable";
            //Regex reg2 = new Regex(@"\{\$top (\d+)\}", RegexOptions.Compiled);
            //Match match2 = reg2.Match(text2);
            //if (match2.Success) 
            //{
            //    GroupCollection groups2 = match2.Groups;
            //    foreach (Group p in groups2)
            //    {
            //        Console.WriteLine(p.Value);
            //    }
            //}

            string a = "aaaa 123 56 bbbb cccc";
            int ai = 0, bi = 12;
            string sub = a.Substring(ai + 4, bi - ai - 4);
            Console.WriteLine(sub);
            Console.ReadLine();
        }
    }
}
