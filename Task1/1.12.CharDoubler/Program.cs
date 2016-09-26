using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._12.CharDoubler
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstString = "написать программу, которая";
            string secondString = "описание";
            
            StringBuilder result = new StringBuilder(firstString.Length*2);
            for (int i = 0; i < firstString.Length; i++)
            {
                if (secondString.Contains(firstString[i]))
                {
                    result.Append(firstString[i], 2);
                }
                else
                {
                    result.Append(firstString[i]);
                }
            }
            Console.WriteLine(result);
        }
    }
}
