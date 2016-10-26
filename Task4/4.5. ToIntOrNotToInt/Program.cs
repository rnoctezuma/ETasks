using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._5.ToIntOrNotToInt
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string s = "1.4545e4";

            Console.WriteLine(s.IsPositiveIntNumber());
        }
    }
}