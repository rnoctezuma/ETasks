using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._10._2DArray
{   
    class Program
    {
        public static void SumOfEvenElements(int[,] array)
        {

            int Sum = 0;
            int rowNumber = 0;
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i += 2)
            {
                if ((i / 4) % 2 == 0)
                {
                    rowNumber++;

                }
                if (rowNumber % 2 == 0)
                    Sum += array[i / 4, i % 2];
                else
                {
                    if (i % 2 == 0)
                        Sum += array[i / 4, i % 2];
                }
            }
            Console.WriteLine("Sum of even elements:" + Sum);
        }

        public static void ShowArray(int[,] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {

                    Console.Write(array[i, j] + " ");

                }
            }
        }

        static void Main(string[] args)
        {
            /*int n = 3;
            int m = 4;*/
            int[,] array = new int[,] { { 1, 2 }, { 1, 2 }, { 1, 2 }, { 1, 2 } };
            // RandomArray(array);
            ShowArray(array);
            SumOfEvenElements(array);
        }
    }
}