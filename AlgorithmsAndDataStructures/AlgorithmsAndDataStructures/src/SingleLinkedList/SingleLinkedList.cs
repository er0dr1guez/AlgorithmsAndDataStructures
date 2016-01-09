using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.src.SingleLinkedList
{
    /// <summary>
    /// A simple single linked list collection implementation
    /// capable of basic operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class SingleLinkedList<T> : System.Collections.Generic.ICollection<T>
    {
        /// <summary>
        /// The first node in the single linked list;
        /// null if empty
        /// </summary>
        public SingleLinkedListNode<T> Head { get; private set; }
        
        /// <summary>
        /// The last node in the single linked list;
        /// null if empty
        /// </summary>
        public SingleLinkedListNode<T> Tail { get; private set; }

        #region Add
        /// <summary>
        /// Adds the specified value to the beginning of the single linked list
        /// </summary>
        /// <param name="value">The value to add at the beginning of the  list</param>
        public void AddFirst(T value)
        {
            AddFirst(new SingleLinkedListNode<T>(value));
        }

        /// <summary>
        /// Adds the specified node to the beginning of the single linked list
        /// </summary>
        /// <param name="value">The node to add at the beginning of the single linked list</param>
        public void AddFirst(SingleLinkedListNode<T> node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }
            Count++;
        }

        public void AddLast(T value) { } //TODO
        public void AddLast(SingleLinkedListNode<T> node) { } //TODO
        #endregion

        #region Remove
        public void RemoveFirst() { } //TODO
        public void RemoveLast() { } //TODO
        #endregion

        #region ICollection
        /// <summary>
        /// Number of items currently in the single linked list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// True if the collection is readonly; false otherwise
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds the specified value to the beginning of the single linked list
        /// </summary>
        /// <param name="item">The value to add</param>
        public void Add(T item)
        {
            AddFirst(item);
        }

        /// <summary>
        /// Clears the single linked list
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Returns true if the single linked list contains the specified item;
        /// false otherwise
        /// </summary>
        /// <param name="item">The item to search for</param>
        /// <returns>True if the item is found; false otherwise</returns>
        public bool Contains(T item)
        {
            SingleLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Copies the node values into a specified array
        /// </summary>
        /// <param name="array">Array to copy the single linked list values to</param>
        /// <param name="arrayIndex">Index in the array to start copying at</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            SingleLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
