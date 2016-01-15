using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.src.Stack
{
    /// <summary>
    /// A Last In First Out (LIFO) collection implemented as an array
    /// </summary>
    /// <typeparam name="T">
    /// The type of item contained in the Stack
    /// </typeparam>
    public sealed class Stack_Array<T> : IEnumerable<T>
    {
        /// <summary>
        /// The array used to implement the Stack
        /// </summary>
        private T[] _items = new T[0];

        /// <summary>
        /// The current number of items in the Stack
        /// </summary>
        private int _size;

        /// <summary>
        /// Adds the specified item to the Stack
        /// </summary>
        /// <param name="item">The item</param>
        public void Push(T item)
        {
            if (_size == _items.Length)
            {
                int newLength = _size == 0 ? 4 : _size * 2;

                T[] newArray = new T[newLength];
                _items.CopyTo(newArray, 0);
                _items = newArray;
            }

            _items[_size++] = item;
        }

        /// <summary>
        /// Removes and returns the top item from the Stack
        /// </summary>
        /// <returns>The top-most item in the Stack</returns>
        public T Pop()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The Stack is EMPTY");
            }

            return _items[--_size];
        }

        /// <summary>
        /// Returns the top item from the Stack without removing it
        /// </summary>
        /// <returns>The top-most item in the Stack</returns>
        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The Stack is EMPTY");
            }

            return _items[_size - 1];
        }

        /// <summary>
        /// The current number of items in the Stack
        /// </summary>
        /// <returns></returns>
        public int Count() => _size;

        /// <summary>
        /// Removes all items from the Stack
        /// </summary>
        public void Clear() => _size = 0;

        /// <summary>
        /// Enumerates each item in the stack in LIFO order;
        /// The Stack remains unaltered
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _size-1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        /// <summary>
        /// Enumerates each item in the Stack in LIFO order;
        /// The Stack remains unaltered
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
