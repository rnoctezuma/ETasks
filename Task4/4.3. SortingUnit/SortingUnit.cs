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
        public event EventHandler<EventArgs> SortComplete;

        public static void SortFinished(object sender, EventArgs e)
        {
            Console.WriteLine("Sort Finished");
        }

        public int Partition<T>(T[] numbers, int left, int right, Func<T, T, bool> Predicate)
        {
            T pivot = numbers[left];

            while (true)
            {
                while (Predicate(pivot, numbers[left]))
                    left++;

                while (Predicate(numbers[right], pivot))
                    right--;

                if (left < right)
                {
                    T temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
            SortComplete?.Invoke(this, new EventArgs());
        }

        public void QuickSort<T>(T[] arr, int left, int right, Func<T, T, bool> Predicate)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right, Predicate);

                if (pivot > 1)
                    QuickSort(arr, left, pivot - 1, Predicate);

                if (pivot + 1 < right)
                    QuickSort(arr, pivot + 1, right, Predicate);
            }

            //   if (right >= left)
            //       SortComplete?.Invoke(this, new EventArgs());
        }

        public bool Predicate<T>(T first, T second)
            where T : IComparable<T>
        {
            return (first.CompareTo(second) > 0);
        }
    }
}