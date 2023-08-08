using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorkOtus9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageDownloader downloader;
        Task downloadTask;

        public MainWindow()
        {
            InitializeComponent();

            downloader = new ImageDownloader();
            downloader.ImageStarted += DisplayMessage;
            downloader.ImageCompleted += DisplayMessage;
            downloader.Result += DisplayMessage;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
           
            string url = PathImage.Text;
            string savePath = SavePath.Text;
            //url = "https://img3.akspic.ru/crops/3/4/4/3/7/173443/173443-besplatnyj_minimalist-ubuntu-minimalizm-tsvetnoy-linkin_park-7680x4320.jpg";
            //savePath = "C:/tst.jpg";
            downloadTask = downloader.Download(url, savePath);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void StateDownload_Click(object sender, RoutedEventArgs e)
        {
            txtInfo.Text = "Состояние загрузки картинки: " + downloadTask.IsCompleted;
            //await Task.Delay(1000);
        }

        void DisplayMessage(string message)
        {
            txtInfo.Text = message;
        }

        /* async static Task MainWindow()
{
ImageDownloader downloader = new ImageDownloader();
//downloader.OnImageStarted;
//downloader.OnImageCompleted;
downloader.ImageStarted += DisplayMessage;
downloader.ImageCompleted += DisplayMessage;
string url = PathImage.Text;
// string url = "https://img3.akspic.ru/crops/3/4/4/3/7/173443/173443-besplatnyj_minimalist-ubuntu-minimalizm-tsvetnoy-linkin_park-7680x4320.jpg"; 
string savePath = "/Users/yulia/Desktop/bigimage.jpg";
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
}*/


        //static void DisplayMessage(string message) => Console.WriteLine(message);
    }
}
