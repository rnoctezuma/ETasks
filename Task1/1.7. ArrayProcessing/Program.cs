using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._7.ArrayProcessing
{
    class Program
    {
        static Random Rnd = new Random();

        static void quickSort(int[] array, int l, int r)
        {
            int temp;
            int x = array[l + (r - l) / 2];
            int i = l;
            int j = r;
            while (i <= j)
            {
                while (array[i] < x) i++;
                while (array[j] > x) j--;
                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < r)
                quickSort(array, i, r);

            if (l < j)
                quickSort(array, l, j);
        }

        static int MaxArrayValue(int[] array)
        {
            int maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (maxValue < array[i])
                    maxValue = array[i];
            }
            return maxValue;
        }


        static int MinArrayValue(int[] array)
        {
            int minValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (minValue > array[i])
                    minValue = array[i];
            }
            return minValue;
        }

        static int [] InitArray()
        {
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Rnd.Next(-100, 100);
            }
            return array;
        }

        static void Main()
        {
            
            int[] array = InitArray();
            Console.Write("Source array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Min Value: {0}", MinArrayValue(array));
            Console.WriteLine("Max Value: {0}", MaxArrayValue(array));
            quickSort(array, 0, array.Length-1);
            Console.Write("Modified array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
    }
}
