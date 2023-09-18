using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkOtus13
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = list.Top(30);
            Console.WriteLine(string.Join(", ", result));

            var people = new List<Person>()
            {
                new Person("Tom", "Holand"),
                new Person("Bob", "Marley"),
                new Person("Sam", "Din")
            };
            var result2 = people.Top(30, person => person.LastName);
            foreach (var person in result2)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName);
            }
        }

        public static IEnumerable<T> Top<T>(this IEnumerable<T> enumCollection, int percent)
        {
            if (percent < 1 || percent > 100)
            {
                throw new ArgumentException("Процент должен находиться в диапазоне от 1 до 100");
            }
            int count = (int)Math.Ceiling(enumCollection.Count() * (percent / 100.0));
            return enumCollection.OrderByDescending(x => x).Take(count);
        }

        public static IEnumerable<T> Top<T, TKey>(
            this IEnumerable<T> enumCollection,
            int percent,
            Func<T, TKey> keySelector
        )
        {
            if (percent < 1 || percent > 100)
            {
                throw new ArgumentException("Процент должен находиться в диапазоне от 1 до 100");
            }
            int count = (int)Math.Ceiling(enumCollection.Count() * (percent / 100.0));
            return enumCollection.OrderByDescending(keySelector).Take(count);
        }
    }
}
