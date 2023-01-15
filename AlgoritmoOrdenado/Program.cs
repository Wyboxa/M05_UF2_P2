using System;
using System.Diagnostics;

namespace AlgoritmoOrdenado
{
    
    
        class ArraySort
        {
            int[] array;
            int[] arrayIncreasing;
            int[] arrayDecreasing;

            public ArraySort(int elements, Random random)
            {

                array = new int[elements];
                arrayIncreasing = new int[elements];
                arrayDecreasing = new int[elements];

                for (int i = 0; i < elements; i++)
                {
                    array[i] = random.Next();
                }
                Array.Copy(array, arrayIncreasing, elements);
                Array.Sort(arrayIncreasing);

                Array.Copy(arrayIncreasing, arrayDecreasing, elements);
                Array.Reverse(arrayDecreasing);
            }

            public void Benchmark(Action<int[]> function)
            {
                int[] temp = new int[array.Length];
                Array.Copy(array, temp, array.Length);
                Stopwatch stopwatch = new Stopwatch();
                function(temp);

                Console.WriteLine(function.Method.Name);

                stopwatch.Start();
                function(temp);
                stopwatch.Stop();
                Console.WriteLine("Random: " + stopwatch.ElapsedMilliseconds + "ms " + stopwatch.ElapsedTicks + "ticks");
                stopwatch.Reset();
            
                stopwatch.Start();
                function(temp);
                stopwatch.Stop();
                Console.WriteLine("Increasing: " + stopwatch.ElapsedMilliseconds + "ms " + stopwatch.ElapsedTicks + "ticks");
                stopwatch.Reset();

                Array.Reverse(temp); 
                stopwatch.Start();
                function(temp);
                stopwatch.Stop();
                Console.WriteLine("Decreasing: " + stopwatch.ElapsedMilliseconds + "ms " + stopwatch.ElapsedTicks + "ticks");
                
            }

            public void BubbleSort(int[]arr)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = 0; j < arr.Length - 1; i++)
                    {
                        if(arr[j] > arr[j + 1])
                        {
                            int temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }
                    }
                }
            }
            public void BubbleSortEarlyExit(int[] arr)
            {
                bool isOrdered = true;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    isOrdered = true;
                    for (int j = 0; j < arr.Length - 1; i++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            isOrdered = false;
                            int temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }
                    }
                    if (isOrdered)
                        return;
                }
            }
            public void QuickSort(int[]arr)
            {
                QuickSort(arr, 0, arr.Length - 1);
            }
            public void QuickSort(int[] arr, int left, int right)
            {
               if(left < right)
                {
                    int pivot = QuickSortIndex(arr, left, right);
                    QuickSort(arr, left, pivot);
                    QuickSort(arr, pivot + 1, right);
                }
            }
            public int QuickSortIndex(int[] arr, int left, int right)
            {
                int pivot = arr[(left + right) / 2];

                while(true)
                {
                    while(arr[left] < pivot)
                    {
                        left--;
                    }
                    if(right <= left)
                    {
                        return right;
                    }
                    else
                    {
                        int temp = arr[left];
                        arr[left] = arr[right];
                        arr[right] = temp;
                        right--;left++;
                    }
                }
            }
            public void CustomSort(int[]arr)
            {

            }
            
        }
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Cuantos numero quieres?");
            int elements = int.Parse(Console.ReadLine());
            Console.WriteLine("Que semilla quieres usar?");
            int seed = int.Parse(Console.ReadLine());
            Random random = new Random(seed);
            ArraySort arraySort = new ArraySort(elements, random);
            arraySort.Benchmark(arraySort.BubbleSort);
            arraySort.Benchmark(arraySort.QuickSort);
            arraySort.Benchmark(arraySort.CustomSort);

            Console.Clear();
        }
    }
}
