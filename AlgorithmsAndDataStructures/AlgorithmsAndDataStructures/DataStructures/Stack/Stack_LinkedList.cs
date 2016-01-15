using System;
using System.Collections;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.src.DoublyLinkedList;

namespace AlgorithmsAndDataStructures.src.Stack
{
    /// <summary>
    /// A Last In First Out (LIFO) collection implemented as a linked list
    /// </summary>
    /// <typeparam name="T">
    /// The type of item contained in the Stack
    /// </typeparam>
    public sealed class Stack_LinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// The list used to implement the Stack
        /// </summary>
        private DoublyLinkedList<T> _list = new DoublyLinkedList<T>();

        /// <summary>
        /// Adds the specified item to the Stack
        /// </summary>
        /// <param name="item">
        /// The item to push into the Stack
        /// </param>
        public void Push(T item) => _list.AddFirst(item);

        /// <summary>
        /// Removes and returns the top item from the Stack
        /// </summary>
        /// <returns>
        /// The top-most item in the Stack
        /// </returns>
        public T Pop()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("Stack is EMPTY");
            }

            T value = _list.Head.Value;
            _list.RemoveFirst();
            return value;
        }

        /// <summary>
        /// Returns the top item from the Stack without removing it
        /// </summary>
        /// <returns>
        /// The top-most item in the Stack
        /// </returns>
        public T Peek()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("Stack is EMPTY");
            }

            return _list.Head.Value;
        }

        /// <summary>
        /// The current number of items on the Stack
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// Removes all items from the Stack
        /// </summary>
        public void Clear() => _list.Clear();

        /// <summary>
        /// Enumerates each item in Stack in LIFO order;
        /// The Stack remains unaltered
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

        /// <summary>
        /// Enumerates each item in the Stack in LIFO order;
        /// The Stack remains unaltered
        /// </summary>
        /// <returns>The LIFO enumerato</returns>
        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    }
}
