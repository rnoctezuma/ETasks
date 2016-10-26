using System;
using System.IO;
using System.Globalization;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

public class Watcher
{
    private static FileSystemWatcher watcher = new FileSystemWatcher(@"C:\Users\rnoctezuma\Desktop\ForTask5");
    private static FileSystemWatcher dirWatcher = new FileSystemWatcher(@"C:\Users\rnoctezuma\Desktop\ForTask5");

    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        try
        {
            watcher.EnableRaisingEvents = false;

            string newHash = GetHashFromFile(e.FullPath);
            Console.WriteLine("pomenal");

            using (StreamWriter writer = new StreamWriter(@"C:\Users\rnoctezuma\Desktop\Backup\log.txt", true))
            {
                string logLine = e.ChangeType + "|" + e.FullPath + "|" + DateTime.UtcNow.AddHours(3) + "|" + newHash;
                writer.WriteLine(logLine);
            }

            File.Copy(e.FullPath, Path.Combine(@"C:\Users\rnoctezuma\Desktop\Backup\", newHash), true);
        }

        finally
        {
            watcher.EnableRaisingEvents = true;
        }
    }
    private static void OnCreated(object source, FileSystemEventArgs e)
    {
        // if (Path.GetFileName(e.FullPath) != String.Empty)
        // {
        //it's a directory.
        string hash = GetHashFromFile(e.FullPath);

        File.Copy(e.FullPath, Path.Combine(@"C:\Users\rnoctezuma\Desktop\Backup\", hash), true);
        using (StreamWriter writer = new StreamWriter(@"C:\Users\rnoctezuma\Desktop\Backup\log.txt", true))
        {
            writer.WriteLine($"{e.ChangeType}|{e.FullPath}|{DateTime.UtcNow.AddHours(3)}");
        }
        //  }
    }

    private static void OnDeleted(object source, FileSystemEventArgs e)
    {
        using (StreamWriter writer = new StreamWriter(@"C:\Users\rnoctezuma\Desktop\Backup\log.txt", true))
        {
            writer.WriteLine($"{e.ChangeType}|{e.FullPath}|{DateTime.UtcNow.AddHours(3)}");
        }
    }

    private static void OnRenamed(object source, RenamedEventArgs e)
    {
        if (source == watcher)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\rnoctezuma\Desktop\Backup\log.txt", true))
            {
                string line = $"{e.ChangeType}|{e.OldFullPath}|{DateTime.UtcNow.AddHours(3)}|{e.FullPath}";
                writer.WriteLine(line);
            }
        }
        else
        {
            var files = Directory.GetFiles(e.FullPath, "*.txt*", SearchOption.AllDirectories);

            using (StreamWriter writer = new StreamWriter(@"C:\Users\rnoctezuma\Desktop\Backup\log.txt", true))
            {
                foreach (var item in files)
                {
                    string oldPath = e.OldFullPath + item.Remove(0, e.FullPath.Length);
                    string line = $"{e.ChangeType}|{oldPath}|{DateTime.UtcNow}|{item}";
                    writer.WriteLine(line);
                }
                //        writer.WriteLine($"RenameDirectory|{e.OldFullPath}|{DateTime.UtcNow}|{e.FullPath}"); 
            }
        }
    }


    /*
    private static bool IsChangedBefore(ref string oldHash, string path)
    {
        bool isChangedBefore = false;
        using (StreamReader reader = new StreamReader(@"C:\Users\rnoctezuma\Desktop\Backup\log.txt", System.Text.Encoding.Default))
        {
            string temp;
            while ((temp = reader.ReadLine()) != null)
            {
                if (temp.Contains("Changed") && temp.Contains(path))
                {
                    oldHash = temp.Split('|')[4];
                    isChangedBefore = true;
                }
            }
        }
        return isChangedBefore;
    }*/

    private static void BackUp()
    {
        using (StreamReader reader = new StreamReader(@"C:\Users\rnoctezuma\Desktop\Backup\log.txt", System.Text.Encoding.Default))
        {
            string temp;
            string[] line;
            while ((temp = reader.ReadLine()) != null)
            {
                line = temp.Split('|');
                // if (line[0] == "Changed" && line[2] 
            }
        }
    }

    private static string GetHashFromFile(string path)
    {
        string content = "";
        using (StreamReader reader = new StreamReader(path, System.Text.Encoding.Default))
        {
            content = reader.ReadToEnd();
        }

        System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
        System.Text.StringBuilder hash = new System.Text.StringBuilder();
        byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(content), 0, Encoding.UTF8.GetByteCount(content));
        foreach (byte theByte in crypto)
        {
            hash.Append(theByte.ToString("x2"));
        }
        hash.Append(".txt");
        return hash.ToString();
    }
    //Подготовка backup директория (создание копий файлов из репозитория по хэшу, создание log и hashlog файлов)
    private static void PrepareBackupDir(string watchFolder)
    {
        string backupDir = @"C:\Users\rnoctezuma\Desktop\Backup";
        if (Directory.Exists(backupDir))
        {
            DeleteBackupDir(backupDir);
        }
        Directory.CreateDirectory(backupDir);
        File.Create(@"C:\Users\rnoctezuma\Desktop\Backup\log.txt").Close();
        CopyFilesRecursively(new DirectoryInfo(watchFolder), new DirectoryInfo(backupDir));
    }

    //создание копий файлов из репозитория по хэшу в backup папке
    private static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
    {

        foreach (DirectoryInfo dir in source.GetDirectories())
            CopyFilesRecursively(dir, target);
        foreach (FileInfo file in source.GetFiles("*.txt"))
        {
            file.CopyTo(Path.Combine(target.FullName, GetHashFromFile(file.FullName)), true);
        }
    }

    private static void DeleteBackupDir(string path)
    {
        Directory.Delete(path, true);
    }

    public static void Main()
    {
        //     var InvokerForm = new Form();
        //   var dummy = InvokerForm.Handle; // force handle creation
        // Application.Run(InvokerForm);
        var InvokerForm = new Form();
       var dummy = InvokerForm.Handle; // force handle creation
                watcher.SynchronizingObject = InvokerForm;
            Application.Run(InvokerForm);

        Console.WriteLine("Press \'0\' to quit. Press \'1\' for watching. Press \'2\' for backup.");
        int command = -1;
        while (command != 0)
        {
            command = int.Parse(Console.ReadLine());
            if (command == 1)
            {
                Console.WriteLine("Watching folder...");
                PrepareBackupDir(@"C:\Users\rnoctezuma\Desktop\ForTask5");

                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.LastAccess;
                watcher.Filter = "*.txt";
                watcher.IncludeSubdirectories = true;
                watcher.InternalBufferSize = 1024;

                //Watcher for directories
                dirWatcher.IncludeSubdirectories = true;
                dirWatcher.NotifyFilter = NotifyFilters.DirectoryName;
                dirWatcher.EnableRaisingEvents = true;

            //    dirWatcher.Renamed += new RenamedEventHandler(OnRenamed);
            //    dirWatcher.Deleted += new FileSystemEventHandler(OnDeleted);

                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnCreated);
                watcher.Deleted += new FileSystemEventHandler(OnDeleted);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
                // Begin watching.
                watcher.EnableRaisingEvents = true;

            }
            if (command == 2)
            {
                Console.WriteLine("Enter date for backup:");

                BackUp();
            }

        }
    }
}

