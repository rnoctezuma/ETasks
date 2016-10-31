using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_5
{
    public static class PrepareBackupDir
    {
        //Подготовка backup директория
        public static void PrepareBackupDirectory(string watchFolder, out string logPath)
        {
            logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup\\log.txt");
            string backupDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup");
            string sourceDir = Path.Combine(backupDir, "SourceFolder");
            if (Directory.Exists(backupDir) && Directory.Exists(sourceDir))
            {
                if (File.Exists(logPath))
                {
                    return;
                }
                else
                {
                    Directory.Delete(backupDir, true);
                }
            }
            Directory.CreateDirectory(backupDir);
            Thread.Sleep(10);
            File.Create(logPath).Close();
            HashCopy(new DirectoryInfo(watchFolder), new DirectoryInfo(backupDir));
            Directory.CreateDirectory(sourceDir);
            FullCopy(new DirectoryInfo(watchFolder), new DirectoryInfo(sourceDir));
        }

        //создание копий файлов из репозитория по хэшу в backup папке
        private static void HashCopy(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                HashCopy(dir, target);
            foreach (FileInfo file in source.GetFiles("*.txt"))
                file.CopyTo(Path.Combine(target.FullName, Watcher.GetHashFromFile(file.FullName)), true);
        }

        //полное копирование исходной папки
        public static void FullCopy(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                FullCopy(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles("*.txt"))
                file.CopyTo(Path.Combine(target.FullName, file.Name));
        }

        public static void ClearWatchingDir()
        {
            DirectoryInfo watchFolder = new DirectoryInfo(@"C:\Users\rnoctezuma\Desktop\ForTask5");

            foreach (FileInfo file in watchFolder.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in watchFolder.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
