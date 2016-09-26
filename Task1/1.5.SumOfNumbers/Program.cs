using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._5.SumOfNumbers
{
    class Program
    {
        static int SumOfArithmeticSeries(int firstElement, int lastElement)
        {
            return (firstElement + lastElement) * (lastElement / firstElement) / 2;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(SumOfArithmeticSeries(3, 999) + SumOfArithmeticSeries(5, 995) - SumOfArithmeticSeries(15, 990));
        }
    }
}
