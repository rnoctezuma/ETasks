using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Globalization;

namespace Task_5
{
    public static class Backup
    {
        private static void BackUp(DateTime backupDate)
        {
            PrepareBackupDir.ClearFolder(Constants.watchPath);
            PrepareBackupDir.FullCopy(new DirectoryInfo(Constants.sourcePath), new DirectoryInfo(Constants.watchPath));

            using (StreamReader reader = new StreamReader(Constants.logPath, System.Text.Encoding.Default))
            {
                string temp;
                while ((temp = reader.ReadLine()) != null)
                {
                    string[] line = temp.Split('|');
                    if (DateTime.ParseExact(line[2], Constants.dateFormat, CultureInfo.InvariantCulture).CompareTo(backupDate) > 0)
                    {
                        break;
                    }
                    switch (line[0])
                    {
                        case "Created":
                        case "Changed":
                            File.Copy(Path.Combine(Constants.backupPath, line[3]), line[1], true);
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

        public static void CallBackup(string backupDate)
        {
            DateTime date;

            if (DateTime.TryParseExact(backupDate, Constants.dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                if (date >= backupDateBarrier()[0] && date <= backupDateBarrier()[1])
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

        public static DateTime[] backupDateBarrier()
        {
            DateTime[] firstLastDates = new DateTime[2];
            string firstLogDate = String.Empty;
            string lastLogDate = String.Empty;
            using (StreamReader reader = new StreamReader(Constants.logPath, System.Text.Encoding.Default))
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
                    firstLastDates[0] = DateTime.ParseExact(firstLogDate.Split('|')[2], Constants.dateFormat, CultureInfo.InvariantCulture);
                    firstLastDates[1] = DateTime.ParseExact(lastLogDate.Split('|')[2], Constants.dateFormat, CultureInfo.InvariantCulture);
                    return firstLastDates;
                }
                else
                {
                    throw new Exception("Error: Log file empty!");
                }
            }
        }
    }
}
