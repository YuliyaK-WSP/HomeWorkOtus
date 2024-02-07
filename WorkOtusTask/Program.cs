using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace WorkOtusTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = "../WorkOtusTask/file";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalSpaces = CountSpacesInFiles(folderPath);
            stopwatch.Stop();
            string[] files = Directory.GetFiles(folderPath);
            foreach (string filePath in files)
            {
                int spacesCount = CountSpacesInFile(filePath);
                Console.WriteLine(
                    $"Файл: {Path.GetFileName(filePath)}, Количество пробелов: {spacesCount}"
                );
            }
            Console.WriteLine($"Общее количество пробелов в файлах: {totalSpaces}");
            Console.WriteLine($"Время выполнения: {stopwatch.Elapsed}");
        }

        static int CountSpacesInFile(string filePath)
        {
            int spaces = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    spaces += line.Split(' ').Length - 1;
                }
            }
            return spaces;
        }

        static int CountSpacesInFiles(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);
            int totalSpaces = 0;
            Task<int>[] tasks = new Task<int>[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                string filePath = files[i];
                tasks[i] = Task.Run(() => CountSpacesInFile(filePath));
            }
            Task.WaitAll(tasks);
            foreach (var task in tasks)
            {
                totalSpaces += task.Result;
            }
            return totalSpaces;
        }
    }
}