using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3._4.HardcodeMode
{
    class Program
    {
        static void Main(string[] args)
        {
            CycledDynamicArray<int> cyrcled = new CycledDynamicArray<int>(new int[] {1});
            
            foreach (var item in cyrcled)
            {
                Console.WriteLine(item);
                Thread.Sleep(500);
            }
        }
    }
}
