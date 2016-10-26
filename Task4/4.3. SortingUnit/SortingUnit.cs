using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4._3.SortingUnit
{
    public class SortUnit<T>
    {
        private T[] array;
        private Func<T, T, int> predicate;
        public event EventHandler<EventArgs> SortComplete;

        public T[] Array
        {
            get { return this.array; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(array));
                this.array = value;
            }
        }

        public Func<T, T, int> Predicate
        {
            get { return this.predicate; }
            set
            {
                if (this.Predicate == null)
                    throw new ArgumentNullException(nameof(predicate));
                this.predicate = value;
            }
        }

        

        public SortUnit(T[] array, Func<T, T, int> Predicate)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (Predicate == null)
                throw new ArgumentNullException(nameof(Predicate));
            this.Array = array;
            this.Predicate = Predicate;
        }

        public void Sort()
        {
            T temp;
            for (int i = 0; i < this.Array.Length - 1; i++)
            {
                for (int j = i + 1; j < this.Array.Length; j++)
                {
                    if (this.Predicate(this.Array[j], this.Array[i]) < 0)
                    {
                        temp = this.Array[i];
                        this.Array[i] = this.Array[j];
                        this.Array[j] = temp;
                    }
                }
            }
            SortComplete?.Invoke(this, new EventArgs());
        }

        public void SortInSeparateThread()
        {
            Thread sortThread = new Thread(Sort);
            sortThread.Start();
            Thread.Sleep(200);
        }
    }
}