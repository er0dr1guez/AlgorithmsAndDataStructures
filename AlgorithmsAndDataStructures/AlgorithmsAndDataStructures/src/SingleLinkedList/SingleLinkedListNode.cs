namespace AlgorithmsAndDataStructures.src.SingleLinkedList
{
    /// <summary>
    /// A node in the SingleLinkedList
    /// </summary>
    /// <typeparam name="T">Type of data it holds</typeparam>
    public sealed class SingleLinkedListNode<T>
    {
        /// <summary>
        /// Constructs a new node with the specified value
        /// </summary>
        /// <param name="value">Value stored in the node</param>
        public SingleLinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Node value
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Next node in the SingleLinkedList;
        /// null if it is the last node
        /// </summary>
        public SingleLinkedListNode<T> Next { get; set; }
    }
}
