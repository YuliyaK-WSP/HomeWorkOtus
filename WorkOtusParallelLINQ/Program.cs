using System;
using System.Threading;
using System.Linq;
using System.Diagnostics;

namespace WorkOtusParallelLINQ
{
    class Program
    {
        static int[] array = { 1, 2, 3, 4, 5 };
        static int totalSum = 0;

        static void Main()
        {
            MeasureTime(Default, "Default");
            MeasureTime(MyThread, "MyThread");
            MeasureTime(ParallelLINQ, "ParallelLINQ");
			
        }

        static void Default()
        {
            int sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }
            Console.WriteLine($"Сумма элементов массива Default: {sum}");
        }

        static void MyThread()
        {
            Thread thread1 = new Thread(SumPartOfArray);
            Thread thread2 = new Thread(SumPartOfArray);
            thread1.Start(0);
            thread2.Start(2);
            thread1.Join();
            thread2.Join();
            Console.WriteLine($"Сумма элементов массива MyThread: {totalSum}");
        }

        static void SumPartOfArray(object startIndexObj)
        {
            int startIndex = (int)startIndexObj;
            int partialSum = 0;
            for (int i = startIndex; i < Math.Min(startIndex + 3, array.Length); i++)
            {
                partialSum += array[i];
            }
            Interlocked.Add(ref totalSum, partialSum);
        }

        static void ParallelLINQ()
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
