using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._4.HardcodeMode
{
    public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable
    {
        public CycledDynamicArray() : base() { }
        public CycledDynamicArray(int capacity) : base(capacity) { }
        public CycledDynamicArray(IEnumerable<T> collection) : base(collection) { }

        public new IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this.array, this.Length);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public new class Enumerator : IEnumerator<T>, IEnumerator
        {
            private T[] array;
            private int last = -1;
            private int arrayLength;

            internal Enumerator(T[] array, int arrayLength)
            {
                this.array = array;
                this.arrayLength = arrayLength;
            }

            public T Current
            {
                get
                {
                    if (this.last < 0 || this.last >= this.arrayLength)
                        throw new InvalidOperationException();
                    return this.array[last];
                }
            }

            object IEnumerator.Current => this.Current;

            void IDisposable.Dispose()
            {
            }

            public bool MoveNext()
            {
                if (this.arrayLength == 0)
                {
                    return false;
                }
                if (this.arrayLength == 1)
                {
                    this.last = 0;
                    return true;
                }
                if (this.last + 1 >= this.arrayLength)
                {
                    this.last++;
                    this.last = this.last % this.arrayLength - 1;
                }
                return (++this.last < this.arrayLength);
            }

            public void Reset()
            {
                this.last = -1;
            }
        }
    }
}
