using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace WorkOtusDelegatesEvents
{
    public class FileSearcher
    {
        public event EventHandler<FileArgs> FileFound;
        public event EventHandler SearchCancelled;
        public bool isCanceled;

        public void SearchFiles(string directory)
        {
            if (isCanceled)
            {
                OnSearchCancelled();
                SearchCancelled = null;
                return;
            }

            foreach (string file in Directory.GetFiles(directory))
            {
                OnFileFound(file);
                // Проверка на отмену поиска
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        isCanceled = true;
                        return;
                    }
                }
            }

            foreach (string subdirectory in Directory.GetDirectories(directory))
            {
                SearchFiles(subdirectory);
            }
        }

        protected virtual void OnFileFound(string fileName)
        {
            FileFound?.Invoke(this, new FileArgs(fileName));
        }

        protected virtual void OnSearchCancelled()
        {
            SearchCancelled?.Invoke(this, EventArgs.Empty);
        }
    }
}
