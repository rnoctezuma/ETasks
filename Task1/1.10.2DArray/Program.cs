using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._10._2DArray
{   
    class Program
    {
        public static int[,] InitArray(Random Rnd)
        {
            int[,] array = new int[3, 3];
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = Rnd.Next(-100, 100);
            return array;
        }

        public static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        public static void SumEvenNumbers(int[,] array)
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

        static void Main(string[] args)
        {
            Random Rnd = new Random();
            int[,] array = InitArray(Rnd);
            Console.WriteLine("Source array: ");
            PrintArray(array);
            //SumOfEvenElements(array);
        }
    }
}