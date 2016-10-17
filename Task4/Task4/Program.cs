using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        private static Random Rnd = new Random();

        private static int[] InitArray()
        {
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Rnd.Next(-100, 100);
            }
            return array;
        }

        private static bool Predicate<T>(T first, T second)
            where T : IComparable<T>
        {
            return (first.CompareTo(second) >= 0);
        }

        private static int Partition<T>(T[] array, int left, int right, Func<T, T, bool> Predicate)
        {
            int i = left;
            for (int j = left; j <= right; j++)
            {
                if (Predicate(array[right], array[j]))
                {
                    T t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                    i++;
                }
            }
            return i - 1;
        }

        private static void QuickSort<T>(T[] m, int left, int right, Func<T, T, bool> Predicate)
        {
            if (Predicate == null)
                throw new ArgumentNullException(nameof(Predicate));
            if (left >= right) return;
            int c = Partition(m, left, right, Predicate);
            QuickSort(m, left, c - 1, Predicate);
            QuickSort(m, c + 1, right, Predicate);
        }

        private static void Main(string[] args)
        {
            int[] array = InitArray();
            Console.Write("Source array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
            QuickSort(array, 0, array.Length - 1, Predicate);
            Console.Write("Modified array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
    }
}