using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.src.DoublyLinkedList
{
    /// <summary>
    /// A simple doubly linked list collection implementation
    /// capable of basic operations
    /// </summary>
    /// <typeparam name="T">Type of data it holds</typeparam>
    public sealed class DoublyLinkedList<T> : ICollection<T>
    {
        /// <summary>
        /// The first node in the doubly linked list;
        /// null if empty
        /// </summary>
        public DoublyLinkedListNode<T> Head { get; private set; }

        /// <summary>
        /// The last node in the doubly linked list;
        /// null if empty
        /// </summary>
        public DoublyLinkedListNode<T> Tail { get; private set; }

        #region Add
        /// <summary>
        /// Adds the specified value to the beginning of the doubly linked list
        /// </summary>
        /// <param name="value">
        /// The value to add at the beginning of the doubly linked list
        /// </param>
        public void AddFirst(T value) => AddFirst(new DoublyLinkedListNode<T>(value));

        /// <summary>
        /// Adds the specified node to the beginning of the doubly linked list
        /// </summary>
        /// <param name="value">
        /// The node to add at the beginning of the doubly linked list
        /// </param>
        public void AddFirst(DoublyLinkedListNode<T> node)
        {
            if (Head == null)
            {
                InsertNodeToEmptyList(node);
            }
            else
            {
                node.Next = Head;
                Head.Previous = node;
                Head = node;
            }
            Count++;
        }

        /// <summary>
        /// Adds the specified value to the end of the doubly linked list
        /// </summary>
        /// <param name="value">The value to add to the end of the doubly linked list</param>
        public void AddLast(T value) => AddLast(new DoublyLinkedListNode<T>(value));

        /// <summary>
        /// Adds the specified node to the end of the doubly linked list
        /// </summary>
        /// <param name="node">
        /// The node to add at the end of the doubly linked list
        /// </param>
        public void AddLast(DoublyLinkedListNode<T> node)
        {
            if (Head == null)
            {
                InsertNodeToEmptyList(node);
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
                Tail = node;
            }
            Count++;
        }

        /// <summary>
        /// Adds the specified node to the empty doubly linked list
        /// </summary>
        /// <param name="node">
        /// The node to add at to the empty doubly linked list
        /// </param>
        private void InsertNodeToEmptyList(DoublyLinkedListNode<T> node)
        {
            Head = node;
            Tail = node;
        }
        #endregion

        #region Remove
        /// <summary>
        /// Removes the first node on the doubly linked list
        /// </summary>
        public void RemoveFirst()
        {
            if (Head != null)
            {
                Head = Head.Next;

                if (Head == null)
                {
                    Tail = null;
                }
                else
                {
                    Head.Previous = null;
                }
                Count--;
            }
        }

        /// <summary>
        /// Removes the last node on the doubly linked list
        /// </summary>
        public void RemoveLast()
        {
            if (Head != null)
            {
                if (Head.Next == null)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Tail = Tail.Previous;
                    Tail.Next = null;
                }
                Count--;
            }
        }
        #endregion

        #region ICollection
        /// <summary>
        /// Number of items currently in the doubly linked list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// True if the collection is readonly; false otherwise
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds the specified value to the end of the doubly linked list
        /// </summary>
        /// <param name="item">The value to add</param>
        public void Add(T item)
        {
            AddLast(item);
        }

        /// <summary>
        /// Clears the doubly linked list
        /// </summary>
        public void Clear()
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                DoublyLinkedListNode<T> temp = current;
                current = current.Next;
                temp.Previous = null;
                temp.Next = null;
            }

            Head = null;
            Count = 0;
        }

        /// <summary>
        /// Returns true if the doubly linked list contains the specified item;
        /// false otherwise
        /// </summary>
        /// <param name="item">The item to search for</param>
        /// <returns>True if the item is found; false otherwise</returns>
        public bool Contains(T item)
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Copies the node values into a specified array
        /// </summary>
        /// <param name="array">Array to copy the doubly linked list values to</param>
        /// <param name="arrayIndex">Index in the array to start copying at</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Enumerates over the doubly linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Removes the first occurrence of the item from the doubly linked list;
        /// searching from Head to Tail
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <returns>True if the item was found and removed; false otherwise</returns>
        public bool Remove(T item)
        {
            DoublyLinkedListNode<T> previous = null;
            DoublyLinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous == null)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            Tail = previous;
                        }
                        else
                        {
                            current.Next.Previous = previous;
                        }

                        Count--;
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Enumerates over the doubly linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
