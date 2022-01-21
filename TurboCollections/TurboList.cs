using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TurboCollections
{
    public class TurboList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        
        private T[] items = Array.Empty<T>();
        
        /*public TurboList()
        {
            Console.WriteLine("Helloooo Turboooo!");
        }*/

        public void Add(T item)
        {
            EnsureSize(Count +1);
            items[Count++] = item;
        }

        /// <summary>
        /// This method ensures that the array is at least "size" big
        /// </summary>
        /// <param name="size">The size that your array should be</param>
        void EnsureSize(int size)
        {
            // if array is large enough return
            if (items.Length >= size)
                return;
            
            // how much to scale (buffering technique).
            // If new size is bigger than double the amount it's set directly
            // Double the array size or set to given size
            int newSize = Math.Max(size, items.Length * 2);
            
            // create new array
            T[] newArray = new T[Count + 1];
            
            // copy old items
            for (int i = 0; i < Count; i++)
            {
                newArray[i] = items[i];
            }

            // Assign the result to the field
            items = newArray;
        }

        public T Get(int index)
        {
            return items[index];
        }

        public void Set(int index, T item)
        {
            items[index] = item;
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                items[i] = default; // = default(T)
            }
            Count = 0;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count-1; i++)
            {
                items[i] = items[i + 1];
            }
            Count--;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }
        
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(items[i]))
                    return i;
            }
            return -1;
        }

        public void Remove(T item)
        {
            var index = IndexOf(item);
            if (index == -1)
                return;
            RemoveAt(index);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(items, Count);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct Enumerator : IEnumerator<T>
        {
            private readonly T[] _items;
            private readonly int _count;
            private int _index;
            
            public Enumerator(T[] items, int count)
            {
                _items = items;
                _count = count;
                // enumerator  always starts before first item
                _index = -1;
            }
            
            public bool MoveNext()
            {
                if (_index >= _count)
                    return false; // exception
                return ++_index < _count;
            }

            public void Reset()
            {
                _index = -1;
            }

            public T Current => _items[_index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                Reset();
            }
        }
    }
}
