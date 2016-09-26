using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._6.FontAdjustment
{
    class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("Введите:");
            Console.WriteLine("       1: bold");
            Console.WriteLine("       2: italic");
            Console.WriteLine("       3: underline");
            Console.WriteLine("Press 'q' to exit");
        }

        static void ShowFontInfo(FontAdjustment fontInfo)
        {
            Console.WriteLine("Параматры надписи: {0}", fontInfo);
        }

        static void Main(string[] args)
        {
            FontAdjustment fontInfo = FontAdjustment.None;

            ShowFontInfo(fontInfo);
            ShowMenu();
            string command = Console.ReadLine();
            while (command != "q")
            {                
                switch (command)
                {
                    case "1":
                        fontInfo ^= FontAdjustment.Bold;
                        break;
                    case "2":
                        fontInfo = fontInfo ^ FontAdjustment.Italic;
                        break;
                    case "3":
                        fontInfo = fontInfo ^ FontAdjustment.Underline;
                        break;
                    default:
                        return;
                }
                ShowFontInfo(fontInfo);
                ShowMenu();
                command = Console.ReadLine();
            }
        }
    }
}
