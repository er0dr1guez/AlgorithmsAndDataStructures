namespace AlgorithmsAndDataStructures.src.SingleLinkedList
{
    /// <summary>
    /// A node in the SingleLinkedList
    /// </summary>
    /// <typeparam name="T">Type of data it holds</typeparam>
    public class SingleLinkedListNode<T>
    {
        public SingleLinkedListNode()
        {

        }

        /// <summary>
        /// Constructs a new node with the specified value
        /// </summary>
        /// <param name="value">Value stored in the node</param>
        public SingleLinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Constructs a new node with the specified value
        /// and the node it points to
        /// </summary>
        /// <param name="value">Value stored in the node</param>
        /// <param name="next">Node it points to</param>
        public SingleLinkedListNode(T value, SingleLinkedListNode<T> next)
        {
            Value = value;
            Next = next;
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

        public override string ToString()
        {
            return $"Value:{Value}, Next:{Next}";
        }
    }
}
