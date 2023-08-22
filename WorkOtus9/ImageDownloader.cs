using System;
using System.Net;
public class ImageDownloader
{
	public delegate void ImageSave(string message);
	public event ImageSave ImageStarted;
	public event ImageSave ImageCompleted;

	public async Task Download(string url, string savePath)
	{
		using (WebClient client = new WebClient())
		{
			try
			{
				OnImageStarted();
				await client.DownloadFileTaskAsync(url, savePath);
				OnImageCompleted();
				Console.WriteLine("Картинка успешно скачана и сохранена по пути: " + savePath);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ошибка при скачивании картинки: " + ex.Message);
			}

		}




	}
	public void OnImageStarted()
	{
		ImageStarted?.Invoke("Скачивание файла началось");
	}
	public void OnImageCompleted()
	{
		ImageCompleted?.Invoke("Скачивание файла закончилось");
	}
}