using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._9.Non_NegativeSum
{
    class Program
    {
        static int[] InitArray(Random Rnd)
        {
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Rnd.Next(-10, 10);
            }
            return array;
        }

        static int SumArray(int[] array)
        {
            int sum = 0;
            for (int i=0;i<array.Length;i++)
            {
                if (array[i] > 0)
                    sum += array[i];
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Random Rnd = new Random();
            int[] array = InitArray(Rnd);
            Console.Write("Source array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
            Console.Write("Sum of non-negative elements is: {0}", SumArray(array));
            Console.WriteLine();
        }
    }
}
