using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2.CustomSortDemo
{
    internal class Program
    {
        private static int Predicate(string x, string y)
        {
            int isEqual = 0;
            if (x.Length > y.Length)
                return 1;
            if (y.Length > x.Length)
                return -1;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < y[i])
                    return -1;
                if (x[i] != y[i])
                    isEqual = 1;
            }
            return isEqual;
        }

        private static int Partition<T>(T[] array, int left, int right, Func<T, T, int> Predicate)
        {
            int i = left;
            for (int j = left; j <= right; j++)
            {
                if (Predicate(array[j], array[right]) <= 0)
                {
                    T t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                    i++;
                }
            }
            return i - 1;
        }

        private static void QuickSort<T>(T[] m, int left, int right, Func<T, T, int> Predicate)
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
            string[] stringArray = { "aaqqq", "baqqq", "baqqq", "bbqqq", "Bbqqq", "Abqqq", "Aaqqq", "H", "ER", "bdy" };
            QuickSort(stringArray, 0, stringArray.Length - 1, Predicate);
            foreach (var item in stringArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}