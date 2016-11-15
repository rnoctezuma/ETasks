using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexExpressions
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Regex regex = new Regex(@"\b(((?:0[1-9]|1[0-9]|2[0-9])-(?:0[1-9]|1[0-2]))|((?:30|31)-(?:0[13578]|1[02]))|((?:30)-(?:0[469]|11)))-(?:[0-9]){4}\b");

            string text = "tfe3 31-01-1996 346паикецуbretg";

            MatchCollection matches = regex.Matches(text);

            Console.WriteLine($"Found matches: {matches.Count}");

            foreach (var match in matches)
            {
                Console.WriteLine($"Date: {match}");
            }
        }
    }
}