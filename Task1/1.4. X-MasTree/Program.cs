using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4.X_MasTree
{
    class Program
    {
        static void DrawRectangle(int counter, int lineCounter)
        {
            int count = 1;
            for (int i = counter; i > 0; i--)
            {

                for (int j = i + lineCounter - counter; j > 1; j--)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < count; j++)
                {
                    Console.Write("*");
                }
                count = count + 2;
                Console.WriteLine();
            }
            count = 1;
        }

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
                Console.WriteLine("The number must be an integer and not negative.");
                return;
            }

            for (int counter = 1; counter <= lineCounter; counter++)
            {
                DrawRectangle(counter, lineCounter);
            }
        }
    }
}
