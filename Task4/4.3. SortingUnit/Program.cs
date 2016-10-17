using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._3.SortingUnit
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SortingUnit sortUnit = new SortingUnit();

            int[] array = { 1, -6, 36, 100, 37, -100, 546, 35 };
            Console.Write("Source array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
            sortUnit.SortComplete += SortingUnit.SortFinished;
            sortUnit.BubbleSort(array,sortUnit.Predicate);

            Console.Write("Modified array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
    }
}