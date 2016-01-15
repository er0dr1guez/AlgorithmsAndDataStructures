using System;

namespace AlgorithmsAndDataStructures.src.Tree
{
    /// <summary>
    /// A binary tree node class;
    /// encapsulates the value and left/right pointers
    /// </summary>
    /// <typeparam name="TNode">The type of node it holds</typeparam>
    public sealed class BinaryTreeNode<TNode> : IComparable<TNode>
        where TNode : IComparable<TNode>
    {
        /// <summary>
        /// Constructs a new binary tree node with the specified value
        /// </summary>
        /// <param name="value">The specified value</param>
        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }

        /// <summary>
        /// The left node in the binary tree;
        /// null if it is the bottom-most node
        /// </summary>
        public BinaryTreeNode<TNode> Left { get; set; }

        /// <summary>
        /// The right node in the binary tree;
        /// null if it is the bottom-most node
        /// </summary>
        public BinaryTreeNode<TNode> Right { get; set; }

        /// <summary>
        /// The value in the node
        /// </summary>
        public TNode Value { get; set; }

        /// <summary>
        /// Compares the current node to the provided value
        /// </summary>
        /// <param name="other">The node value to compare to</param>
        /// <returns>
        /// 1 if the instance value is greater than the provided value;
        /// -1 if the instance value is less than the provided value;
        /// 0 if the instance value is equal than the provided value
        /// </returns>
        public int CompareTo(TNode other) => Value.CompareTo(other);
    }
}
