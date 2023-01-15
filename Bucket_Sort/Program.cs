using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bucket_Sort
{
    class Program
    {
		static void Main(string[] args)
		{
			int[] numbers = new int[10] { -65, 5, -7, -57, 56, 31, 98, 86, -12, 87 };
			Console.WriteLine("\nOriginal Array Elements :");
			PrintIntegerArray(numbers);
			Console.WriteLine("\nSorted Array Elements :");
			PrintIntegerArray(BucketSort(numbers));
			Console.WriteLine("\n");
		}

		public static void BucketSort(ref int[] data)
		{
			int minValue = data[0];
			int maxValue = data[0];

			for (int i = 1; i < data.Length; i++)
			{
				if (data[i] > maxValue)
					maxValue = data[i];
				if (data[i] < minValue)
					minValue = data[i];
			}

			List<int>[] bucket = new List<int>[maxValue - minValue + 1];

			for (int i = 0; i < bucket.Length; i++)
			{
				bucket[i] = new List<int>();
			}

			for (int i = 0; i < data.Length; i++)
			{
				bucket[data[i] - minValue].Add(data[i]);
			}

			int k = 0;
			for (int i = 0; i < bucket.Length; i++)
			{
				if (bucket[i].Count > 0)
				{
					for (int j = 0; j < bucket[i].Count; j++)
					{
						data[k] = bucket[i][j];
						k++;
					}
				}
			}
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
