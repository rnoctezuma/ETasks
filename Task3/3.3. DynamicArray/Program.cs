using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.DynamicArray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DynamicArray<int> array = new DynamicArray<int>(new int[] { 1, 2, 5, -1 });
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            

            /*
            for (int i = 0; i < 5; i++)
            {
                ints[i] = i;
            }
            foreach (var item in ints)
            {
                Console.Write("{0} ", item);
            }*/
        }
    }
}