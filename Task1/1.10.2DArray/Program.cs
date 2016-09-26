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
            int[,] array = new int[4, 2];
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = Rnd.Next(-10, 10);
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


        public static void SumEvenNumbers(int[,] array, Random Rnd)
        {
            int Sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = i % 2; j < array.GetLength(1); j+=2)
                {
                    Sum += array[i, j];
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
            SumEvenNumbers(array,Rnd);

         //   Console.WriteLine(1%2);
        }
    }
}