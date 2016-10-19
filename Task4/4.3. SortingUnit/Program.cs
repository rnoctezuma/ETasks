using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._3.SortingUnit
{
    internal class Program
    {
        public static int Predicate(string x, string y)
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

        private static void SortFinished(object sender, EventArgs e)
        {
            Console.WriteLine("Sort Finished");
        }

        private static void Main(string[] args)
        {
            try
            {
                string[] array = { "aaqqq", "baqqq", "baqqq", "bbqqq", "Bbqqq", "Abqqq", "Aaqqq", "H", "ER", "bdy" };
                SortUnit<string> sortUnit = new SortUnit<string>(null, Predicate);

                Console.Write("Source array: ");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write("{0} ", array[i]);
                }
                Console.WriteLine();
                sortUnit.SortComplete += SortFinished;
                sortUnit.SortInSeparateThread();

                Console.Write("Modified array: ");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write("{0} ", array[i]);
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}