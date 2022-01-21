using System;

namespace TurboCollections
{
    public static class CollectionUtil
    {
        /// <summary>
        /// This method ensures that the array is at least "size" big
        /// </summary>
        /// <param name="size">The size that your array should be</param>
        
        
        public static void EnsureSize<T>(ref T[] items, int size)
        {
            // if array is large enough return
            if (items.Length >= size)
                return;
            
            // how much to scale (buffering technique).
            // If new size is bigger than double the amount it's set directly
            // Double the array size or set to given size
            int newSize = Math.Max(size, items.Length * 2);
            
            // create new array
            T[] newArray = new T[newSize];
            
            // copy old items
            for (int i = 0; i < items.Length; i++)
            {
                newArray[i] = items[i];
            }

            // Assign the result to the field
            items = newArray;
        }
    }
}