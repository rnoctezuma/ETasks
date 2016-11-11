using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    public class Constants
    {
        public static string dateFormat { get; }
        public static string watchPath { get; }
        public static string backupPath { get; }
        public static string logPath { get; }
        public static string sourcePath { get; }

        static Constants()
        {
            watchPath = ConfigurationManager.AppSettings["watchingPath"];
            backupPath = ConfigurationManager.AppSettings["backupPath"];
            dateFormat = "dd/MM/yyyy/HH/mm/ss";
            logPath = Path.Combine(backupPath, "log.txt");
            sourcePath = Path.Combine(backupPath, "SourceFolder");
        }

        public static string DateFormat(DateTime item)
        {
            string format = String.Format("{0}/{1}/{2}/{3}/{4}/{5}", item.Year, item.Month, item.Day, item.Hour, item.Minute, item.Second);
            return format;
        }
    }
}
