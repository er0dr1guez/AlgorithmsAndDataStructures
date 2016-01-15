using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public static class SelectionSort<T> where T : IComparable<T>
    {
        public static void Sort(T[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int smallestIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (IsGreaterThan(array[smallestIndex], array[j]))
                    {
                        smallestIndex = j;
                    }
                }
                Swap(ref array[smallestIndex], ref array[i]);
            }
        }

        private static bool IsGreaterThan(T x, T y)
        {
            return x.CompareTo(y) > 0;
        }

        private static void Swap(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
    }
}
