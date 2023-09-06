using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace WorkOtus12
{
    internal class Program
    {
        static int NextId = 0;

        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Customer customer = new Customer();

            shop.Items.CollectionChanged += customer.OnItemsChanged;
            Console.WriteLine("Для добавления товара нажмите 'A'");
            Console.WriteLine("Для удаления товара нажмите 'D'");
            Console.WriteLine("Для просмотра списка товаров нажмите 'L'");
            Console.WriteLine("Для выхода из программы нажмите 'X'");

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.A:
                        NextId++;
                        // Генерация нового товара с текущей датой и временем
                        Item newItem = new Item { Id = NextId, Name = $"Товар от {DateTime.Now}" };
                        shop.Add(newItem);
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine(" Введите идентификатор товара для удаления:");
                        int itemId = Convert.ToInt32(Console.ReadLine());
                        Item itemToRemove = shop.Items.FirstOrDefault(x => x.Id == itemId);
                        if (itemToRemove != null)
                        {
                            shop.Remove(itemToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Товар с указанным идентификатором не найден.");
                        }
                        break;
                    case ConsoleKey.X:
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.L:
                        if (shop.Items.Count != 0)
                        {
                            foreach (Item item in shop.Items)
                            {
                                Console.WriteLine($" {item.Name} (ID: {item.Id})");
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Список товаров пуст");
                        }
                        break;
                }
            }
        }
    }
}
