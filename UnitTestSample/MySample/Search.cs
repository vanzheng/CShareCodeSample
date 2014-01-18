using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySample
{
    public class Search
    {
        public static int Largest(int[] list) 
        {
            if (list == null)
                throw new ArgumentNullException("list");
            if (list.Length == 0)
                throw new ArgumentException("empty list");

            int i, max;
            max = list[0];
            for (i = 0; i < list.Length; i++) 
            {
                if (list[i] > max)
                    max = list[i];
            }
            return max;
        }
    }
}
