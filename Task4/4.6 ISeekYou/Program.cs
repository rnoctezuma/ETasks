using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._6_ISeekYou
{
    class Program
    {
        private static Random rnd = new Random();

        private static int[] InitArray()
        {
            int[] array = new int[1000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-10000, 10000);
            }
            return array;
        }

        private static int PositiveCount(int[] array)
        {
            int count = 0;
            foreach (var item in array)
            {
                if (item > 0)
                {
                    count++;
                }
            }
            return count;
        }

        private static int PositiveCount(int[] array, Func<int, bool> Predicate)
        {
            if (Predicate == null)
                throw new ArgumentNullException(nameof(Predicate));
            int count = 0;
            foreach (var item in array)
            {
                if (Predicate(item))
                {
                    count++;
                }
            }
            return count;
        }

        private static bool Predicate(int element)
        {
            return element > 0;
        }

        static void Main(string[] args)
        {
            int[] array = InitArray();
            Func<int, bool> predicate = Predicate;
            int count = 40;

            Stopwatch stopWatch = new Stopwatch();
            double[] times = new double[count];

            for (int i = 0; i < count; i++)
            {
                stopWatch.Restart();
                PositiveCount(array);
                stopWatch.Stop();
                times[i] = stopWatch.Elapsed.TotalMilliseconds;
            }
            Array.Sort(times);
            Console.WriteLine($"{times[count / 2]} time for method");

            for (int i = 0; i < count; i++)
            {
                stopWatch.Restart();
                PositiveCount(array, predicate);
                stopWatch.Stop();
                times[i] = stopWatch.Elapsed.TotalMilliseconds;
            }
            Array.Sort(times);
            Console.WriteLine($"{times[count / 2]} time for method + delegate");

            for (int i = 0; i < count; i++)
            {
                stopWatch.Restart();
                PositiveCount(array, delegate (int elem) { return elem > 0; });
                stopWatch.Stop();
                times[i] = stopWatch.Elapsed.TotalMilliseconds;
            }
            Array.Sort(times);
            Console.WriteLine($"{times[count / 2]} time for anonimous method");

            for (int i = 0; i < count; i++)
            {
                stopWatch.Restart();
                PositiveCount(array, elem => elem > 0);
                stopWatch.Stop();
                times[i] = stopWatch.Elapsed.TotalMilliseconds;
            }
            Array.Sort(times);
            Console.WriteLine($"{times[count / 2]} time for lambda");

            for (int i = 0; i < count; i++)
            {
                stopWatch.Restart();
                var result = array.Where(item => item > 0).Count();
                stopWatch.Stop();

                times[i] = stopWatch.Elapsed.TotalMilliseconds;
            }
            Array.Sort(times);
            Console.WriteLine($"{times[count / 2]} time for linq");
        }
    }
}
