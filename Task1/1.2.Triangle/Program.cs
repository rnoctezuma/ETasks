using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2.Triangle
{

    class Program
    {
        static void Main(string[] args)
        {
            int lineCounter;
            Console.Write("Enter the number of rows: ");
            try
            {
                lineCounter = int.Parse(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("The number must be an integer");
                return;
            }

            for (int i = 0; i < lineCounter; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }
    }
}
