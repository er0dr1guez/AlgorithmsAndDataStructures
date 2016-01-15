using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.src.Queue
{
    /// <summary>
    /// A First In First Out collection (FIFO) implemented as an array
    /// </summary>
    /// <typeparam name="T">
    /// The type of item contained in the Queue
    /// </typeparam>
    public sealed class Queue_Array<T> : IEnumerable<T>
    {
        /// <summary>
        /// The array used to implement the Queue
        /// </summary>
        private T[] _items = new T[0];

        /// <summary>
        /// The number of items in the Queue
        /// </summary>
        private int _size;

        /// <summary>
        /// The index of the first (oldest) item in the Queue
        /// </summary>
        private int _head;
        
        /// <summary>
        /// The index of the last (newest) item in the Queue
        /// </summary>
        private int _tail = -1;

        /// <summary>
        /// Adds an item to the back of the Queue
        /// </summary>
        /// <param name="item">The item to place in the Queue</param>
        public void Enqueue(T item)
        {
            if (_items.Length == _size)
            {
                int newLength = (_size == 0) ? 4 : _size * 2;
                T[] newArray = new T[newLength];

                if (_size > 0)
                {
                    int targetIndex = 0;

                    if (_tail < _head)
                    {
                        for (int index = _head; index < _items.Length; index++)
                        {
                            newArray[targetIndex++] = _items[index];
                        }

                        for (int index = 0; index <= _tail; index++)
                        {
                            newArray[targetIndex++] = _items[index];
                        }
                    }
                    else
                    {
                        for (int index = _head; index <= _tail; index++)
                        {
                            newArray[targetIndex++] = _items[index];
                        }
                    }

                    _head = 0;
                    _tail = targetIndex - 1;
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }

                _items = newArray;
            }

            if (_tail == _items.Length-1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }

            _items[_tail] = item;
            _size++;
        }

        /// <summary>
        /// Removes and returns the front item from the Queue
        /// </summary>
        /// <returns>
        /// The front item from the Queue
        /// </returns>
        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The Queue is Empty");
            }

            T value = _items[_head];

            if (_head == _items.Length-1)
            {
                _head = 0;
            }
            else
            {
                _head++;
            }

            _size--;

            return value;
        }

        /// <summary>
        /// Returns the front item from the Queue without removing it
        /// </summary>
        /// <returns>The front item in the Queue</returns>
        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The Queue is Empty");
            }

            return _items[_head];
        }

        /// <summary>
        /// The number of items in the Queue
        /// </summary>
        public int Count => _size;

        /// <summary>
        /// 
        /// </summary>
        public void Clear() => _size = 0;

        /// <summary>
        /// Returns an enumerator that enumerates the Queue
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (_size > 0)
            {
                if (_tail < _head)
                {
                    for (int index = _head; index < _items.Length; index++)
                    {
                        yield return _items[index];
                    }

                    for (int index = 0; index <= _tail; index++)
                    {
                        yield return _items[index];
                    }
                }
                else
                {
                    for (int index = _head; index <= _tail; index++)
                    {
                        yield return _items[index];
                    }
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that enumerates the Queue
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
