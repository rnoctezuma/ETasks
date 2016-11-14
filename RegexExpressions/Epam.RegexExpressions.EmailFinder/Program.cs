﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.RegexExpressions.EmailFinder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Regex regex = new Regex(@"(?:[^\W_][\w-\.]*[^\W_]|[^\W_])@[^\W_]+\.[^\W\d_]{2,6}");
            string text = "f_gh@yefgh.rtytrybrrtrtertbe@yandex.cc_g@hr.еgh";

            MatchCollection matches = regex.Matches(text);
            Console.WriteLine("List of e-mails: ");
            foreach (Match match in matches)
            {
                Console.WriteLine($"e-mail: {match}");
            }
        }
    }
}