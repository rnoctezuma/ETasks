using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4._3.SortingUnit
{
    public class SortingUnit
    {

        public event EventHandler <EventArgs> SortComplete;

        public static void SortFinished(object sender, EventArgs e)
        {
            Console.WriteLine("Sort Finished");
        }

        public void BubbleSort<T>(T[] array, Func<T, T, bool> Predicate)
        {
            if (Predicate == null)
                throw new ArgumentNullException(nameof(Predicate));
            T temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (Predicate(array[j], array[i]))
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            SortComplete?.Invoke(this, new EventArgs());
        }

        public bool Predicate<T>(T first, T second)
            where T : IComparable<T>
        {
            return (first.CompareTo(second) <= 0);
        }
    }
}

//Проверить на инженерную форму записи числа в 4.4