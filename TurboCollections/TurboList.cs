﻿using System;
using System.Runtime.CompilerServices;

namespace TurboCollections
{
    public class TurboList<T>
    {
        public int Count { get; private set; }
        
        private T[] items = Array.Empty<T>();
        public TurboList()
        {
            Console.WriteLine("Helloooo, Turboooo!");
        }

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
    }
}
