using System;
using System.Collections;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.src.DoublyLinkedList;

namespace AlgorithmsAndDataStructures.src.Queue
{
    /// <summary>
    /// A collection that returns the highest priority
    /// item first and lowest priority item last
    /// </summary>
    /// <typeparam name="T">
    /// The type of data stored in the collection
    /// </typeparam>
    public sealed class PriorityQueue<T> : IEnumerable<T> 
        where T : IComparable<T>
    {
        DoublyLinkedList<T> _items = new DoublyLinkedList<T>();

        /// <summary>
        /// Adds an item to the Queue in priority order
        /// </summary>
        /// <param name="item">The item to place in the Queue</param>
        public void Enqueue(T item)
        {
            if (_items.Count == 0)
            {
                _items.AddLast(item);
            }
            else
            {
                DoublyLinkedListNode<T> current = _items.Head;

                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }
                
                if (current == null)
                {
                    _items.AddLast(item);
                }
                else
                {
                    _items.AddBefore(current, item);
                }
            }
        }

        /// <summary>
        /// Removes and returns the highest priority item from the Queue
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
        /// Returns the highest priority item from the Queue without removing it
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
        /// Removes all items in the Queue
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
