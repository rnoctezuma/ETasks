using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.RegexExpressions.NumberValidator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Regex normalNotation = new Regex(@"(?:-|\+)?\d+(?:\.d+)?");
            Regex scientificNotation = new Regex(@"(?:-|\+)?\d+\.\d+e(?:-|\+)?\d+");

            string text = "1.3e+1";

            MatchCollection matchesNormalNotation = normalNotation.Matches(text);
            MatchCollection matchesScientificNotation = scientificNotation.Matches(text);

            Console.WriteLine(matchesScientificNotation.Count);
            if (matchesNormalNotation.Count != 0)
            {
                Console.WriteLine($"{text} - number in normal notation");
                return;
            }
            if (matchesScientificNotation.Count != 0)
            {
                Console.WriteLine($"{text} - number in scientific notation");
                return;
            }

            Console.WriteLine($"{text} - not a digit");
        }
    }
}