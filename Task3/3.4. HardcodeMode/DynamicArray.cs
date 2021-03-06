﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._4.HardcodeMode
{
    public class DynamicArray<T> : IEnumerable<T>, IEnumerable, IList<T>, IList, ICollection<T>, ICollection, ICloneable
    {
        protected T[] array;
        public int Length { get; private set; }

        public int Capacity
        {
            get
            {
                return this.array.Length;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                if (value < this.array.Length)
                {
                    T[] temp = new T[value];
                    Array.Copy(this.array, temp, value);
                    this.array = temp;
                    this.Length = value;
                }
                Array.Resize(ref this.array, value);
            }
        }

        public int Count
        {
            get
            {
                return this.Length;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }
        public bool IsSynchronized
        {
            get
            {
                return this.array.IsSynchronized;
            }
        }
        public object SyncRoot
        {
            get
            {
                return this.array.SyncRoot;
            }
        }
        object IList.this[int index]          ////Как быть с индексатором?
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = (T)value;
            }
        }

        public DynamicArray()
            : this(8)
        {
        }

        public DynamicArray(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException("Capacity can't be less than 0");
            this.Length = 0;
            this.array = new T[capacity];
        }

        public DynamicArray(IEnumerable<T> sourceCollection)
        {
            this.Length = sourceCollection.Count();
            this.array = new T[this.Length];
            int count = 0;
            foreach (var item in sourceCollection)
            {
                this[count] = item;
                count++;
            }
        }

        public void Add(T value)
        {
            if (this.Capacity > this.Length)
            {
                this[this.Length++] = value;
            }
            else
            {
                Array.Resize(ref this.array, this.Capacity * 2);
                this[this.Length++] = value;
            }
        }

        int IList.Add(object value)
        {
            this.Add((T)value);
            return this.Length - 1;
        }

        public void AddRange(IEnumerable<T> sourceCollection)
        {
            int sourceLength = sourceCollection.Count();
            if (this.Length + sourceLength <= this.Capacity)
            {
                int i = this.Length;
                foreach (var item in sourceCollection)
                {
                    this.array[i] = item;
                    i++;
                }
                this.Length += sourceLength;
            }
            else
            {
                Array.Resize(ref this.array, this.Length + sourceLength);
                int i = this.Length;
                foreach (var item in sourceCollection)
                {
                    this.array[i] = item;
                    i++;
                }
                this.Length += sourceLength;
            }
        }

        public bool Remove(T item)  ////ICollection<T>
        {
            var itemNumber = this.IndexOf(item);
            if (itemNumber == -1)
            {
                return false;
            }

            for (int i = itemNumber; i < this.Length; i++)
            {
                if (i != this.Length - 1)
                {
                    this[i] = this[i + 1];
                }
                else
                {
                    this[i] = default(T);
                }
            }
            this.Length--;
            return true;
        }

        void IList.Remove(object item)
        {
            this.Remove((T)item);
        }

        public void RemoveAt(int index)  ////IList<T>
        {
            for (int i = index; i < this.Length; i++)
            {
                if (i != this.Length - 1)
                {
                    this[i] = this[i + 1];
                }
                else
                {
                    this[i] = default(T);
                }
            }
            this.Length--;
        }

        public void Insert(int index, T item)  ////IList <T>
        {
            if (this.Capacity > this.Length)
            {
                this.Length++;
                for (int i = this.Length - 1; i > index; i--)
                {
                    this[i] = this[i - 1];
                }
                this[index] = item;
            }
            else
            {
                Array.Resize(ref this.array, this.Capacity * 2);
                this.Length++;
                for (int i = this.Length - 1; i > index; i--)
                {
                    this[i] = this[i - 1];
                }
                this[index] = item;
            }
        }

        public bool Insert(T item, int index)  ////bool Insert
        {
            this.Insert(index, item);
            return true;
        }

        public T this[int index]
        {
            get
            {
                if (Math.Abs(index) > this.Length)
                    throw new IndexOutOfRangeException("out of range!");
                if (index<0)
                {
                    return this.array[this.Length + index];
                }
                return this.array[index];
            }
            set
            {
                if (Math.Abs(index) > this.Length)
                    throw new IndexOutOfRangeException("out of range!");
                if (index < 0)
                {
                    this.array[this.Length + index] = value;
                }
                else
                {
                    this.array[index] = value;
                }
            }
        }

        public void Clear()
        {
            for (int i = 0; i < this.Length; i++)
            {
                this[i] = default(T);
            }
        }

        public bool Contains(T item)
        {
            return (this.IndexOf(item) != -1);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex >= array.Length || arrayIndex < 0)
                throw new IndexOutOfRangeException();
            if (array.Length - arrayIndex <= this.Length)
                Array.Copy(this.array, 0, array, arrayIndex, array.Length - arrayIndex);
            else
                Array.Copy(this.array, 0, array, arrayIndex, this.Length);
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(this.array, item);
        }

        int IList.IndexOf(object value) => this.IndexOf((T)value);

        bool IList.Contains(object value) => this.Contains((T)value);

        void IList.Insert(int index, object value) => this.Insert(index, (T)value);

        void ICollection.CopyTo(Array array, int index) => this.CopyTo((T[])array, index);

        ///////////////////////////   IEnumerable<T>, IEnumerable   ///////////////////////////

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this.array, this.Length);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public T[] ToArray ()
        {
            T[] temp = new T[this.Length];
            Array.Copy(this.array, temp, this.Length);
            return temp;
        }

        /////////////////////////////////////////////   nested class Enumator
        public class Enumerator : IEnumerator<T>, IEnumerator
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
                return (++this.last < this.arrayLength);
            }

            public void Reset()
            {
                this.last = -1;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
