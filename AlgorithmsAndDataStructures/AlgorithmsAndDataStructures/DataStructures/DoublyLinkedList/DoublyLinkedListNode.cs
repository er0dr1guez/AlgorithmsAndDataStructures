namespace AlgorithmsAndDataStructures.src.DoublyLinkedList
{
    /// <summary>
    /// A node in the DoublyLinkedList
    /// </summary>
    /// <typeparam name="T">Type of data it holds</typeparam>
    public sealed class DoublyLinkedListNode<T>
    {
        /// <summary>
        /// Constructs a new node with the specified value
        /// </summary>
        /// <param name="value">Value stored in the node</param>
        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Node value
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The previous node in the DoublyLinkedList;
        /// null if it is first node
        /// </summary>
        public DoublyLinkedListNode<T> Previous { get; set; }

        /// <summary>
        /// The next node in the DoublyLinkedList;
        /// null if it is the last node
        /// </summary>
        public DoublyLinkedListNode<T> Next { get; set; }
    }
}
