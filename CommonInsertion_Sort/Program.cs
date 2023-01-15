﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonInsertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10] { -65, 5, -7, -57, 56, 31, 98, 86, -12, 87 };
            Console.WriteLine("\nOriginal Array Elements :");
            PrintIntegerArray(numbers);
            Console.WriteLine("\nSorted Array Elements :");
            PrintIntegerArray(InsertionSort(numbers));
            Console.WriteLine("\n");
        }

        static int[] InsertionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }
            return inputArray;
        }
        public static void PrintIntegerArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i.ToString() + "  ");
            }
        }
    }
}
