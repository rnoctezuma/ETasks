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
            Regex regex = new Regex(@"(((?:0[1-9]|1[0-9]|2[0-8])-(?:0[1-9]|1[0-2]))|((?:29|30|31)-(?:0[13578]|1[02]))|((?:29|30)-(?:0[469]|11))|((?:28|29)-02))-(?:[0-9]){4}");

            string text = "tfe331-01-1996346паикецуbretg";

            MatchCollection matches = regex.Matches(text);

            Console.WriteLine($"Found matches: {matches.Count}");

            foreach (var match in matches)
            {
                Console.WriteLine($"Date: {match}");
            }
        }
    }
}