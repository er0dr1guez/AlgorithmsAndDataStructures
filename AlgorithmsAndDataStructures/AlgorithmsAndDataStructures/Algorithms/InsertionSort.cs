using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public static class InsertionSort<T> where T : IComparable<T>
    {
        public static void Sort(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && IsGreaterThan(array[j - 1], array[j]))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }
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