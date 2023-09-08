using System;
using System.Collections.Generic;

namespace WorkOtus12HouseJack
{
    class Program
    {
        static void Main()
        {
            Part1 part1 = new Part1();
            Part2 part2 = new Part2();
            Part3 part3 = new Part3();
            Part4 part4 = new Part4();
            Part5 part5 = new Part5();
            Part6 part6 = new Part6();
            Part7 part7 = new Part7();
            Part8 part8 = new Part8();
            Part9 part9 = new Part9();

            List<string> poem = part9.AddPart(
                part8.AddPart(
                    part7.AddPart(
                        part6.AddPart(
                            part5.AddPart(part4.AddPart(part3.AddPart(part2.AddPart(part1.Poem))))
                        )
                    )
                )
            );

            Console.WriteLine("Строфа 1:");
            foreach (string line in part1.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nСтрофа 2:");
            foreach (string line in part2.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nСтрофа 3:");
            foreach (string line in part3.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nСтрофа 4:");
            foreach (string line in part4.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nСтрофа 5:");
            foreach (string line in part5.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nСтрофа 6:");
            foreach (string line in part6.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nСтрофа 7:");
            foreach (string line in part7.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nСтрофа 8:");
            foreach (string line in part8.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nСтрофа 9:");
            foreach (string line in part9.Poem)
            {
                Console.WriteLine(line);
            }
        }
    }
}
