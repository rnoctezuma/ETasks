using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Task_5
{
    public static class LogWrite
    {
        public static void HashWrite(string changeType, string path, string hash)
        {       
            using (StreamWriter writer = new StreamWriter(Constants.logPath, true))
            {
                writer.WriteLine($"{changeType}|{path}|{Constants.DateFormat(DateTime.Now)}|{hash}");
            }
        }

        public static void WithoutHashWrite(string changeType, string path)
        {
            using (StreamWriter writer = new StreamWriter(Constants.logPath, true))
            {
                writer.WriteLine($"{changeType}|{path}|{Constants.DateFormat(DateTime.Now)}");
            }
        }

        public static void RenameWrite(string changeType, string oldFullPath, string newFullPath)
        {
            using (StreamWriter writer = new StreamWriter(Constants.logPath, true))
            {
                writer.WriteLine($"{changeType}|{oldFullPath}|{Constants.DateFormat(DateTime.Now)}|{newFullPath}");
            }
        }
    }
}
