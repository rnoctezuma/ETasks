using System;
using System.IO;
using System.Globalization;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Configuration;

namespace Task_5
{
    public class Watcher
    {
        private static FileSystemWatcher watcher = new FileSystemWatcher(Constants.watchPath);
        private static FileSystemWatcher dirWatcher = new FileSystemWatcher(Constants.watchPath);

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            while (true)
            {
                try
                {
                    FileAttributes attributes = File.GetAttributes(e.FullPath);     ////////MUST HAVE
                    if ((source == watcher) && !((attributes.HasFlag(FileAttributes.Directory))))
                    {
                        string newHash = GetHashFromFile(e.FullPath);
                        LogWrite.HashWrite(e.ChangeType.ToString(), e.FullPath, newHash);
                        File.Copy(e.FullPath, Path.Combine(Constants.backupPath, newHash), true);
                    }
                    return;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(1));
                }
            }
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            while (true)
            {
                try
                {
                    FileAttributes attr = File.GetAttributes(e.FullPath);
                    if ((source == watcher) && !(attr.HasFlag(FileAttributes.Directory)))
                    {
                        string hash = GetHashFromFile(e.FullPath);
                        LogWrite.HashWrite(e.ChangeType.ToString(), e.FullPath, hash);
                        File.Copy(e.FullPath, Path.Combine(Constants.backupPath, hash), true);
                    }
                    else
                    {
                        LogWrite.WithoutHashWrite("CreateDirectory", e.FullPath);
                        var files = Directory.GetFiles(e.FullPath, "*.txt*", SearchOption.AllDirectories);
                        for (int i = 0; i < files.Length; i++)
                        {
                            string hash = GetHashFromFile(files[i]);
                            LogWrite.HashWrite(e.ChangeType.ToString(), files[i], hash);
                            File.Copy(files[i], Path.Combine(Constants.backupPath, hash), true);
                        }
                    }
                    return;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(1));
                }
            }
        }

        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (source == watcher)
                    {
                        LogWrite.WithoutHashWrite(e.ChangeType.ToString(), e.FullPath);
                    }
                    else
                    {
                        LogWrite.WithoutHashWrite("DeleteDirectory", e.FullPath);
                    }
                    return;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(1));
                }
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (source == watcher)
                    {
                        LogWrite.RenameWrite(e.ChangeType.ToString(), e.OldFullPath, e.FullPath);
                    }
                    else
                    {
                        LogWrite.RenameWrite("RenameDirectory", e.OldFullPath, e.FullPath);
                    }
                    return;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(1));
                }
            }
        }



        public static string GetHashFromFile(string path)
        {
            string content = String.Empty;
            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.Default))
            {
                content = reader.ReadToEnd();
            }
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(content), 0, Encoding.UTF8.GetByteCount(content));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            hash.Append(".txt");
            return hash.ToString();
        }

        private static void InitFileWatcher()
        {
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.LastAccess;
            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            watcher.InternalBufferSize = 1024 * 1024;
            watcher.EnableRaisingEvents = true;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
        }

        private static void InitDirWatcher()
        {
            dirWatcher.IncludeSubdirectories = true;
            dirWatcher.NotifyFilter = NotifyFilters.DirectoryName;
            dirWatcher.EnableRaisingEvents = true;
            dirWatcher.Renamed += new RenamedEventHandler(OnRenamed);
            dirWatcher.Deleted += new FileSystemEventHandler(OnDeleted);
            dirWatcher.Created += new FileSystemEventHandler(OnCreated);
            dirWatcher.Changed += new FileSystemEventHandler(OnChanged);
        }

        public static void Main()
        {
            Console.WriteLine("Press \'0\' to quit. Press \'1\' for watching. Press \'2\' for backup.");
            Console.WriteLine("----------------------------------------------------------------");
            Console.Write("Enter command: ");
            int command = -1;
            while (command != 0)
            {
                bool tryCommand = true;
                while (tryCommand)
                {
                    bool result = Int32.TryParse(Console.ReadLine(), out command);
                    if (result && command >= 0 && command <= 2)
                    {
                        tryCommand = false;
                    }
                    else
                    {
                        Console.WriteLine("Try again...");
                        Console.Write("Enter command: ");
                    }
                }

                switch (command)
                {
                    case 1:
                        {
                            PrepareBackupDir.PrepareBackupDirectory();
                            Console.WriteLine("Watching folder...");
                            InitFileWatcher();
                            InitDirWatcher();
                            Console.Write("Enter command: ");
                        }
                        break;
                    case 2:
                        {
                            try
                            {
                                dirWatcher.EnableRaisingEvents = false;
                                watcher.EnableRaisingEvents = false;
                                PrepareBackupDir.PrepareBackupDirectory();
                                Console.WriteLine("----------------------------------------------------------------");
                                Console.WriteLine($"Enter the date between {Backup.backupDateBarrier()[0]} and {Backup.backupDateBarrier()[1]}");
                                Console.Write($"Enter backup date (format - {Constants.dateFormat}): ");
                                string backupDate = Console.ReadLine();
                                Backup.CallBackup(backupDate);
                                Console.Write("Enter command: ");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.Write("Enter command: ");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}