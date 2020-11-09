using System;

namespace Local.Collections
{
    internal static class CollectionUtils
    {
        public static void EnsureCapacity<T>(ref T[] array, int capacity)
        {
            if (array.Length < capacity)
            {
                Array.Resize(ref array, capacity);
            }
        }

        public static void Insert<T>(ref T[] array, int index, T element)
        {
            var arrayLength = array.Length;
            if ((uint) index < (uint) arrayLength)
            {
                array[index] = element;
            }
            else
            {
                var newLength = arrayLength == 0 ? 2 : arrayLength * 2;
                Array.Resize(ref array, newLength);
                array[index] = element;
            }
        }
    }
}