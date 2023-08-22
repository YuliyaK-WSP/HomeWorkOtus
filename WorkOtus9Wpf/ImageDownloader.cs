using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WorkOtus9
{
	internal class ImageDownloader
	{
		public delegate void ImageSave(string message);
		public event ImageSave ImageStarted;
		public event ImageSave ImageCompleted;
		public event ImageSave Result;

		public async Task Download(string url, string savePath)
		{
			using (WebClient client = new WebClient())
			{
				try
				{
					OnImageStarted();
					await client.DownloadFileTaskAsync(url, savePath);
					OnImageCompleted();
					Result?.Invoke("Картинка успешно скачана и сохранена по пути: " + savePath);
				}
				catch (Exception ex)
				{
					Result?.Invoke("Ошибка при скачивании картинки: " + ex.Message + ex.InnerException);
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
}
