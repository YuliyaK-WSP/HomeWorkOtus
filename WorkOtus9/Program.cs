using System.Threading.Tasks;
internal class Program
{
	async static Task Main(string[] args)
	{
		ImageDownloader downloader = new ImageDownloader();
		downloader.ImageStarted += DisplayMessage;
		downloader.ImageCompleted += DisplayMessage;
		string url = "https://img3.akspic.ru/crops/3/4/4/3/7/173443/173443-besplatnyj_minimalist-ubuntu-minimalizm-tsvetnoy-linkin_park-7680x4320.jpg"; string savePath = "/Users/yulia/Desktop/bigimage.jpg";
		Task downloadTask = downloader.Download(url, savePath);
		ConsoleKeyInfo keyInfo;
		do
		{
			Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
			keyInfo = Console.ReadKey();

			if (keyInfo.Key != ConsoleKey.A)
			{
				Console.WriteLine();
				Console.WriteLine("Состояние загрузки картинки: " + downloadTask.IsCompleted);
				await Task.Delay(1000);
			}
		} while (keyInfo.Key != ConsoleKey.A);

		Environment.Exit(0);
	}


	static void DisplayMessage(string message) => Console.WriteLine(message);
}
