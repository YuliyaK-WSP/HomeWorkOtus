using System.Data;
using System;
using System.Threading;
using System.Linq;
using System.Diagnostics;

namespace WorkOtusParallelLINQ
{
    class Program
    {
        static void Main()
        {
            int[] array100K = GenerateRandomArray(100000);
            int[] array1M = GenerateRandomArray(1000000);
            int[] array10M = GenerateRandomArray(10000000);

            MeasureTime(() => Default(array100K), "Default 100K");
            MeasureTime(() => Default(array1M), "Default 1M");
            MeasureTime(() => Default(array10M), "Default 10M");
			Console.WriteLine();
            MeasureTime(() => MyThread(array100K), "MyThread 100K");
            MeasureTime(() => MyThread(array1M), "MyThread 1M");
            MeasureTime(() => MyThread(array10M), "MyThread 10M");
			Console.WriteLine();
            MeasureTime(() => ParallelLINQ(array100K), "ParallelLINQ 100K");
            MeasureTime(() => ParallelLINQ(array10M), "ParallelLINQ 10M");
            MeasureTime(() => ParallelLINQ(array1M), "ParallelLINQ 1M");
        }

        static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(1, 100);
            }
            return array;
        }

        static void Default(int[] array)
        {
            int sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }
            Console.WriteLine($"Сумма элементов массива Default: {sum}");
        }

        static void MyThread(int[] array)
        {
            int totalSum = 0;
            Thread thread1 = new Thread(() => SumPartOfArray(array, 0, 3, ref totalSum));
            Thread thread2 = new Thread(() => SumPartOfArray(array, 3, 3, ref totalSum));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine($"Сумма элементов массива MyThread: {totalSum}");
        }

        static void SumPartOfArray(int[] array, int startIndex, int length, ref int totalSum)
        {
            int partialSum = 0;
            for (int i = startIndex; i < startIndex + length; i++)
            {
                partialSum += array[i];
            }
            Interlocked.Add(ref totalSum, partialSum);
        }

        static void ParallelLINQ(int[] array)
        {
            int sum = array.AsParallel().Sum();
            Console.WriteLine($"Сумма элементов массива ParallelLINQ: {sum}");
        }

        static void MeasureTime(Action method, string methodName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            method();
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения процесса {methodName}: {stopwatch.Elapsed}");
        }
    }
}
