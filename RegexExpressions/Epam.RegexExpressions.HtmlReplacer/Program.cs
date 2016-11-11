using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.RegexExpressions.HtmlReplacer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Regex regex = new Regex(@"<[^<>]*>");

            string text = "<ваек<<<<> укре <<sdfhd>> ик eergwf<>fd<<>b<>!<>";
            Console.Write("Source text: {0}", text);
            Console.WriteLine();
            text = regex.Replace(text, "_");
            Console.Write("Changed text: {0}", text);
            Console.WriteLine();
        }
    }
}