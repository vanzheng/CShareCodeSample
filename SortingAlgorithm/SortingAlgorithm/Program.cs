using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithm
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        /// <summary>
        /// Bubble sort.
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(ref int[] arr)
        {
            int n = arr.Length;
            int i, j, temp;
            for (i = 0; i < n; i++) 
            {
                for (j = i; j < n - i; j++) 
                {
                    if (arr[j] > arr[j+1]) 
                    {
                        temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Selection sort.
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(ref int[] arr)
        {
            int n = arr.Length;
            int i, j, min, temp;
            for (i = 0; i < n; i++) 
            {
                min = i;

                for (j = i + i; j < n; j++) 
                {
                    if (arr[j] < arr[min]) 
                    {
                        min = j;
                    }
                }

                if (min != i) 
                {
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
        }


    }
}
