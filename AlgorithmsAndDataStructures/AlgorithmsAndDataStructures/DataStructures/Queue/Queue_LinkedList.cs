using System;
using System.Collections;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.src.DoublyLinkedList;

namespace AlgorithmsAndDataStructures.src.Queue
{
    /// <summary>
    /// A First In First Out collection (FIFO) implemented as a linked list
    /// </summary>
    /// <typeparam name="T">
    /// The type of item contained in the Queue
    /// </typeparam>
    public sealed class Queue_LinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// The list used to implement the Queue
        /// </summary>
        private DoublyLinkedList<T> _items = new DoublyLinkedList<T>();

        /// <summary>
        /// Adds an item to the back of the Queue
        /// </summary>
        /// <param name="item">The item to place in the Queue</param>
        public void Enqueue(T item)
        {
            _items.AddLast(item);
        }

        /// <summary>
        /// Removes and returns the front item from the Queue
        /// </summary>
        /// <returns>The front item from the Queue</returns>
        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The Queue is EMPTY");
            }

            T value = _items.Head.Value;
            _items.RemoveFirst();
            return value;
        }

        /// <summary>
        /// Returns the front item from the Queue without removing it
        /// </summary>
        /// <returns>The front item from the Queue</returns>
        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The Queue is EMPTY");
            }

            return _items.Head.Value;
        }

        /// <summary>
        /// The number of items in the Queue
        /// </summary>
        public int Count => _items.Count;

        /// <summary>
        /// Remives all items from the Queue
        /// </summary>
        public void Clear() => _items.Clear();

        /// <summary>
        /// Returns an enumerator that enumerates the Queue
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

        /// <summary>
        /// Returns an enumerator that enumerates the Queue
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
    }
}
