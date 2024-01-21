namespace WorkOtusDelegatesEvents
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Функция GetMax
            List<int> numbers = new List<int> { 10, 5, 8, 3, 12 };
            int maxNumber = numbers.GetMax(x => x);
            Console.WriteLine("Максимальное число: " + maxNumber);
            Console.WriteLine(
                "Введите директорию для поиска файлов, для отмены поиска нажмите пробел"
            );
            string filePath = Console.ReadLine();
            // Класс FileSearcher
            FileSearcher fileSearcher = new FileSearcher();
            fileSearcher.FileFound += FileSearcher_FileFound;
            fileSearcher.SearchCancelled += FileSearcher_SearchCancelled;
            fileSearcher.SearchFiles(filePath);

            Console.ReadLine();
        }

        private static void FileSearcher_FileFound(object sender, FileArgs e)
        {
            Console.WriteLine("Найден файл: " + e.FileName);
        }

        private static void FileSearcher_SearchCancelled(object sender, EventArgs e)
        {
            Console.WriteLine("Поиск отменен.");
        }
    }
}
