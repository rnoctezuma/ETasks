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
            string str = " g g g    ";
            int wordCounter = 0;
            int letterCounter = 0;

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (Char.IsLetter(str[i]))
                {
                    letterCounter++;
                    if (!Char.IsLetter(str[i + 1]))
                        wordCounter++;
                }
            }

            if (Char.IsLetter(str[str.Length - 1]))
            {
                wordCounter++;
                letterCounter++;
            }

            Console.WriteLine("{0:#.##}", (double)letterCounter/(double)wordCounter);            
        }
    }
}
