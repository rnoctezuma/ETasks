using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._11.AverageStringLength
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "fgj63656345 ,, g dfrterh. hr '';; 457";
            int wordCounter = 0;
            int letterCounter = 0;

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (Char.IsLetter(str[i]))
                {
                    wordCounter++;
                    if (!Char.IsLetter(str[i + 1]))
                        letterCounter++;
                }
            }

            if (Char.IsLetter(str[str.Length - 1]))
                letterCounter++;

            Console.WriteLine("{0:#.##}", (double)wordCounter/letterCounter);            
        }
    }
}
