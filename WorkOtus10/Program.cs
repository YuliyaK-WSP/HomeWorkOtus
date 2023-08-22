using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
 class Program
{
    static async Task Main(string[] args)
    {
        string dir1Path = @"c:\Otus\TestDir1";
        string dir2Path = @"c:\Otus\TestDir2";
         // Создание директорий
        DirectoryInfo dir1 = Directory.CreateDirectory(dir1Path);
        DirectoryInfo dir2 = Directory.CreateDirectory(dir2Path);
         // Создание и запись файлов в директории 1
        for (int i = 1; i <= 10; i++)
        {
            string filePath = Path.Combine(dir1Path, $"File{i}.txt");
            await WriteToFile(filePath, $"File{i}.txt: текст", true);
        }
         // Создание и запись файлов в директории 2
        for (int i = 1; i <= 10; i++)
        {
            string filePath = Path.Combine(dir2Path, $"File{i}.txt");
            await WriteToFile(filePath, $"File{i}.txt: текст", false);
        }
         // Чтение и вывод содержимого файлов
        ReadAndPrintFiles(dir1Path);
        ReadAndPrintFiles(dir2Path);
    }
	/// <summary>
/// Записывает содержимое в файл.
/// </summary>
/// <param name="filePath">Путь к файлу.</param>
/// <param name="content">Содержимое, которое будет записано в файл.</param>
/// <param name="sync">Флаг, указывающий на синхронность операции записи.</param>
     static async Task WriteToFile(string filePath, string content, bool sync)
    {
        try
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: !sync))
            {
                byte[] encodedContent = Encoding.UTF8.GetBytes(content + " " + DateTime.Now.ToString());
                if (sync)
                {
                    fileStream.Write(encodedContent, 0, encodedContent.Length);
                }
                else
                {
                    await fileStream.WriteAsync(encodedContent, 0, encodedContent.Length);
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Ошибка доступа при записи в файл: {filePath}");
        }
    }
	/// <summary>
/// Читает и выводит содержимое файлов из указанной директории.
/// </summary>
/// <param name="directoryPath">Путь к директории.</param>
     static void ReadAndPrintFiles(string directoryPath)
    {
        Console.WriteLine($"Файлы в директории: {directoryPath}");
        string[] files = Directory.GetFiles(directoryPath);
        foreach (string filePath in files)
        {
            try
            {
                string content = File.ReadAllText(filePath, Encoding.UTF8);
                Console.WriteLine($"{Path.GetFileName(filePath)}: {content}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Ошибка доступа при чтении файла: {filePath}");
            }
        }
        Console.WriteLine();
    }
}