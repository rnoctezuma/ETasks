using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._5.SumOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            for (int i3 = 0, i5 = 0; i3 < 1000 || i5 < 1000; i3 += 3, i5 += 5)
            {
                result += i3;
                if (i5 < 1000 && i5 % 3 != 0)
                {
                    result += i5;
                }
            }
            Console.WriteLine(result);
        }
    }
}
