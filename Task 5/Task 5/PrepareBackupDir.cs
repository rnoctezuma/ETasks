using System;
using System.Collections.Generic;
using System.Configuration;
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
        public static void PrepareBackupDirectory()
        {
            if (Directory.Exists(Constants.backupPath) && Directory.Exists(Constants.backupPath))
            {
                if (File.Exists(Constants.logPath))
                {
                    return;
                }
                else
                {
                    Directory.Delete(Constants.backupPath, true);
                }
            }
            Directory.CreateDirectory(Constants.backupPath);
            while (true)
            {
                try
                {
                    File.Create(Constants.logPath).Close();
                    break;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(1));
                }
            }

            HashCopy(new DirectoryInfo(Constants.watchPath), new DirectoryInfo(Constants.backupPath));

            Directory.CreateDirectory(Constants.sourcePath);
            FullCopy(new DirectoryInfo(Constants.watchPath), new DirectoryInfo(Constants.sourcePath));
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

        public static void ClearFolder(string path)
        {
            DirectoryInfo watchFolder = new DirectoryInfo(path);

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
