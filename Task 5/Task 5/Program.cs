using System;
using System.IO;
using System.Globalization;
using System.Security.Permissions;
using System.Text;
using System.Threading;

namespace Task_5
{
    public class Watcher
    {
        private static FileSystemWatcher watcher = new FileSystemWatcher(@"C:\Users\rnoctezuma\Desktop\ForTask5");
        private static FileSystemWatcher dirWatcher = new FileSystemWatcher(@"C:\Users\rnoctezuma\Desktop\ForTask5");
        private static DateTime lastRead = DateTime.MinValue;
        private static string logPath;
        private static string backupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup");

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            bool notCompleted = true;
            while (notCompleted)
            {
                try
                {
                    FileAttributes attributes = File.GetAttributes(e.FullPath);     ////////MUST HAVE
                    if ((source == watcher) && !((attributes.HasFlag(FileAttributes.Directory))))
                    {
                        using (StreamWriter writer = new StreamWriter(logPath, true))
                        {
                            string newHash = GetHashFromFile(e.FullPath);
                            writer.WriteLine($"{e.ChangeType}|{e.FullPath}|{DateTime.UtcNow.AddHours(3).ToString("dd/MM/yyyy/HH/mm/ss")}|{newHash}");
                            File.Copy(e.FullPath, Path.Combine(backupPath, newHash), true);
                        }
                    }
                    notCompleted = false;
                }
                catch
                {
                    Thread.Sleep(1);
                }
            }
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            bool notCompleted = true;
            while (notCompleted)
            {
                try
                {
                    FileAttributes attr = File.GetAttributes(e.FullPath);
                    if ((source == watcher) && !(attr.HasFlag(FileAttributes.Directory)))
                    {
                        using (StreamWriter writer = new StreamWriter(logPath, true))
                        {
                            string hash = GetHashFromFile(e.FullPath);
                            writer.WriteLine($"{e.ChangeType}|{e.FullPath}|{DateTime.UtcNow.AddHours(3).ToString("dd/MM/yyyy/HH/mm/ss")}|{hash}");
                            File.Copy(e.FullPath, Path.Combine(backupPath, hash), true);
                        }
                    }
                    else
                    {
                        using (StreamWriter writer = new StreamWriter(logPath, true))
                        {
                            writer.WriteLine($"CreateDirectory|{e.FullPath}|{DateTime.UtcNow.AddHours(3).ToString("dd/MM/yyyy/HH/mm/ss")}");
                            var files = Directory.GetFiles(e.FullPath, "*.txt*", SearchOption.AllDirectories);
                            for (int i = 0; i < files.Length; i++)
                            {
                                string hash = GetHashFromFile(files[i]);
                                writer.WriteLine($"{e.ChangeType}|{files[i]}|{DateTime.UtcNow.AddHours(3).ToString("dd/MM/yyyy/HH/mm/ss")}|{hash}");
                                File.Copy(files[i], Path.Combine(backupPath, hash), true);
                            }
                        }
                    }
                    notCompleted = false;
                }
                catch
                {
                    Thread.Sleep(1);
                }
            }
        }

        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            bool notCompleted = true;
            while (notCompleted)
            {
                try
                {
                    if (source == watcher)
                    {
                        using (StreamWriter writer = new StreamWriter(logPath, true))
                        {
                            writer.WriteLine($"{e.ChangeType}|{e.FullPath}|{DateTime.UtcNow.AddHours(3).ToString("dd/MM/yyyy/HH/mm/ss")}");
                        }
                    }
                    else
                    {
                        using (StreamWriter writer = new StreamWriter(logPath, true))
                        {
                            writer.WriteLine($"DeleteDirectory|{e.FullPath}|{DateTime.UtcNow.AddHours(3).ToString("dd/MM/yyyy/HH/mm/ss")}");
                        }
                    }
                    notCompleted = false;
                }
                catch
                {
                    Thread.Sleep(1);
                }
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            bool notCompleted = true;
            while (notCompleted)
            {
                try
                {
                    //  FileAttributes attr = File.GetAttributes(e.FullPath);
                    if (source == watcher)// && !(attr.HasFlag(FileAttributes.Directory)))
                    {
                        using (StreamWriter writer = new StreamWriter(logPath, true))
                        {
                            writer.WriteLine($"{e.ChangeType}|{e.OldFullPath}|{DateTime.UtcNow.AddHours(3).ToString("dd/MM/yyyy/HH/mm/ss")}|{e.FullPath}");
                        }
                    }
                    else
                    {
                        using (StreamWriter writer = new StreamWriter(logPath, true))
                        {
                            writer.WriteLine($"RenameDirectory|{e.OldFullPath}|{DateTime.UtcNow.AddHours(3).ToString("dd/MM/yyyy/HH/mm/ss")}|{e.FullPath}");
                        }
                    }
                    notCompleted = false;
                }
                catch
                {
                    Thread.Sleep(1);
                }
            }
        }

        private static void BackUp(DateTime backupDate)
        {
            PrepareBackupDir.ClearWatchingDir();
            string sourceDir = Path.Combine(backupPath, "SourceFolder");
            PrepareBackupDir.FullCopy(new DirectoryInfo(sourceDir), new DirectoryInfo(@"C:\Users\rnoctezuma\Desktop\ForTask5"));

            using (StreamReader reader = new StreamReader(logPath, System.Text.Encoding.Default))
            {
                string temp;
                while ((temp = reader.ReadLine()) != null)
                {
                    string[] line = temp.Split('|');
                    if (DateTime.ParseExact(line[2], "dd.MM.yyyy.HH.mm.ss", CultureInfo.InvariantCulture).CompareTo(backupDate) > 0)
                    {
                        break;
                    }
                    switch (line[0])
                    {
                        case "Created": case "Changed":
                            File.Copy(Path.Combine(backupPath, line[3]), line[1], true);
                            break;
                        case "Renamed":
                            File.Move(line[1], line[3]);
                            break;
                        case "Deleted":
                            File.Delete(line[1]);
                            break;
                        case "CreateDirectory":
                            Directory.CreateDirectory(line[1]);
                            break;
                        case "DeleteDirectory":
                            Directory.Delete(line[1], true);
                            break;
                        case "RenameDirectory":
                            Directory.Move(line[1], line[3]);
                            break;
                        default:
                            throw new Exception("Something wrong with log");
                    }
                }
            }
            Console.WriteLine("Backup success");
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

        private static void CallBackup(string backupDate)
        {
            DateTime date;

            if (DateTime.TryParseExact(backupDate, "dd/MM/yyyy/HH/mm/ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                if (date.CompareTo(backupDateBarrier()[0]) >= 0 && date.CompareTo(backupDateBarrier()[1]) <= 0)
                {
                    BackUp(date);
                }
                else
                {
                    throw new ArgumentException($"Error: Backup date must be between {backupDateBarrier()[0]} and {backupDateBarrier()[1]}");
                }
            }
            else
            {
                throw new ArgumentException("Error: Date has incorrect format");
            }
        }


        private static DateTime [] backupDateBarrier()
        {
            DateTime[] firstLastDates = new DateTime[2];
            string firstLogDate = String.Empty;
            string lastLogDate = String.Empty;
            using (StreamReader reader = new StreamReader(logPath, System.Text.Encoding.Default))
            {
                firstLogDate = reader.ReadLine();
                lastLogDate = firstLogDate;

                string temp;
                while ((temp = reader.ReadLine()) != null)
                {
                    lastLogDate = temp;
                }

                if (firstLogDate != String.Empty)
                {
                    firstLastDates[0] = DateTime.ParseExact(firstLogDate.Split('|')[2], "dd.MM.yyyy.HH.mm.ss", CultureInfo.InvariantCulture);
                    firstLastDates[1] = DateTime.ParseExact(lastLogDate.Split('|')[2], "dd.MM.yyyy.HH.mm.ss", CultureInfo.InvariantCulture);
                    return firstLastDates;
                }
                else
                {
                    throw new Exception("Error: Log file empty!");
                }
            }
        }

        public static void Main()
        {
            
            Console.WriteLine("Press \'0\' to quit. Press \'1\' for watching. Press \'2\' for backup.");
            Console.WriteLine("----------------------------------------------------------------");
            Console.Write("Enter command: ");
            int command = -1;
            while (command != 0)
            {
                // int command;
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
                            PrepareBackupDir.PrepareBackupDirectory(@"C:\Users\rnoctezuma\Desktop\ForTask5", out logPath);
                            Console.WriteLine("Watching folder...");

                            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.LastAccess;
                            watcher.Filter = "*.txt";
                            watcher.IncludeSubdirectories = true;
                            watcher.InternalBufferSize = 1048576;

                            //Watcher for directories
                            dirWatcher.IncludeSubdirectories = true;
                            dirWatcher.NotifyFilter = NotifyFilters.DirectoryName;
                            dirWatcher.EnableRaisingEvents = true;
                            watcher.EnableRaisingEvents = true;

                            dirWatcher.Renamed += new RenamedEventHandler(OnRenamed);
                            dirWatcher.Deleted += new FileSystemEventHandler(OnDeleted);
                            dirWatcher.Created += new FileSystemEventHandler(OnCreated);
                            dirWatcher.Changed += new FileSystemEventHandler(OnChanged);

                            watcher.Changed += new FileSystemEventHandler(OnChanged);
                            watcher.Created += new FileSystemEventHandler(OnCreated);
                            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
                            watcher.Renamed += new RenamedEventHandler(OnRenamed);
                            Console.Write("Enter command: ");
                        }
                        break;
                    case 2:
                        {
                            try
                            {
                                dirWatcher.EnableRaisingEvents = false;
                                watcher.EnableRaisingEvents = false;
                                PrepareBackupDir.PrepareBackupDirectory(@"C:\Users\rnoctezuma\Desktop\ForTask5", out logPath);
                                Console.WriteLine("----------------------------------------------------------------");
                                Console.WriteLine($"Enter the date between {backupDateBarrier()[0]} and {backupDateBarrier()[1]}");
                                Console.Write("Enter backup date (format - dd/MM/yyyy/HH/mm/ss): ");
                                string backupDate = Console.ReadLine();
                                CallBackup(backupDate);
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


