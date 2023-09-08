using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace WorkOtus12Librarian
{
    public class Program
    {
        static ConcurrentDictionary<string, int> library = new ConcurrentDictionary<string, int>();
        static bool isRunning = true;

        static void Main(string[] args)
        {
            Thread progressThread = new Thread(UpdateProgress);
            progressThread.Start();

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1 - добавить книгу");
                Console.WriteLine("2 - вывести список непрочитанного");
                Console.WriteLine("3 - выйти");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.KeyChar)
                {
                    case '1':
                        AddBook();
                        break;
                    case '2':
                        PrintBooks();
                        break;
                    case '3':
						isRunning = false;
						progressThread.Join();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Такого значения нет");
                        break;
                }
            }
        }

        static void AddBook()
        {
            Console.WriteLine(" Введите название книги:");
            string nameBook = Console.ReadLine();
            if (!library.ContainsKey(nameBook))
            {
                library.TryAdd(nameBook, 0);
            }
        }

        static void PrintBooks()
        {
            foreach (var book in library)
            {
                Console.WriteLine($" {book.Key} - {book.Value}%");
            }
        }

        static void UpdateProgress()
        {
            while (isRunning)
            {
                Thread.Sleep(1000);

                foreach (var book in library)
                {
                    if (book.Value < 100)
                    {
                        library.TryUpdate(book.Key, book.Value + 1, book.Value);
                    }
                    else
                    {
                        library.TryRemove(book.Key, out _);
                    }
                }
            }
        }
    }
}
