using System;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOtusReflection
{
    public class CsvFileClass
    {
        public int Number { get; set; }

        public static void LoadFromCsvFile(string filePath)
        {
            Console.WriteLine("Сериализация CSV:");
            List<CsvFileClass> data = new List<CsvFileClass>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                data = csv.GetRecords<CsvFileClass>().ToList();
            }
            foreach (var item in data)
            {
                Console.WriteLine(item.Number);
            }
        }
    }
}
