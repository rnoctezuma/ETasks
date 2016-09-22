using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3.AnotherTriangle
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

            int count = 1;
            for (int i = lineCounter; i>0; i--)
            {
                
                for (int j=i; j>1; j--)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j<count;j++)
                {
                    Console.Write("*");
                }
                count = count + 2;
                Console.WriteLine();
            }

        }   
    }
}
