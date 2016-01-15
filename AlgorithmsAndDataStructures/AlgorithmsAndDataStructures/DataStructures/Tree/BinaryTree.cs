using System;
using System.Collections;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.src.Stack;

namespace AlgorithmsAndDataStructures.src.Tree
{
    public sealed class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// The root of the binary tree
        /// </summary>
        private BinaryTreeNode<T> _root;

        /// <summary>
        /// The number of nodes in the binary tree
        /// </summary>
        private int _count;

        #region Add
        /// <summary>
        /// Adds the specified value to the binary tree
        /// </summary>
        /// <param name="value">The specified value</param>
        public void Add(T value)
        {
            // if the tree is empty, allocate the head
            if (_root == null)
            {
                _root = new BinaryTreeNode<T>(value);
            }
            // else the tree is not empty; find the right location
            else
            {
                AddTo(_root, value);
            }
            _count++;
        }

        /// <summary>
        /// Recursively adds the specified value to the binary tree
        /// </summary>
        /// <param name="node">The node that starts at</param>
        /// <param name="value">The specified value</param>
        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            // if value is less than the current node
            if (value.CompareTo(node.Value) < 0)
            {
                // if there is no left child make this the new left child
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                // else keep going down the tree
                else
                {
                    AddTo(node.Left, value);
                }
            }
            // else value is equal or greater than the current value
            else
            {
                // if there is no right child make this the new right child
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                // else keep going down the tree
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }
        #endregion

        /// <summary>
        /// Determines if the specified value exists in the binary tree
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <returns>True if the tree contains the value; false otherwise</returns>
        public bool Contains(T value)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        /// <summary>
        /// Finds and return the first node containing the specified value. 
        /// If the value is not found, returns null. Also returns the parent 
        /// of the found node (or null) which is used in Remove
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <param name="parent">The parent of the found node (or null)</param>
        /// <returns>The found node (or null)</returns>
        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> current = _root;
            parent = null;

            while (current != null)
            {
                // if the value is less than current, go left
                if (current.CompareTo(value) > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                // if the value is greater than current, go right
                else if (current.CompareTo(value) < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                // else the node was found
                else
                {
                    break;
                }
            }

            return current;
        }

        #region Remove
        /// <summary>
        /// Removes the first occurrence of the specified value from the tree
        /// </summary>
        /// <param name="value">The value to remove</param>
        /// <returns>True if the value was removed; false otherwise</returns>
        public bool Remove(T value)
        {
            BinaryTreeNode<T> parent;
            BinaryTreeNode<T> current = FindWithParent(value, out parent);

            // if the node was not found
            if (current == null)
            {
                return false;
            }

            // if current has no right child, then current's left replaces current
            if (current.Right == null)
            {
                // if removing the root node
                if (parent == null)
                {
                    _root = current.Left;
                }
                // if parent value is greater than the current value
                // make the current left child a left child of parent
                else if (parent.CompareTo(current.Value) > 0)
                {
                    parent.Left = current.Left;
                }
                // if parent value is less than the current value
                // make the current left child a right child of parent
                else if (parent.CompareTo(current.Value) < 0)
                {
                    parent.Right = current.Left;
                }
            }
            // if current's right child has no left child, 
            // then current's right child replaces current
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                // if removing the root node
                if (parent == null)
                {
                    _root = current.Right;
                }
                // if parent value is greater than current value
                // make the current right child a left child of parent
                else if (parent.CompareTo(current.Value) > 0)
                {
                    parent.Left = current.Right;
                }
                // if parent value is less than current value
                // make the current right child a right child of parent
                else if (parent.CompareTo(current.Value) < 0)
                {
                    parent.Right = current.Right;
                }
            }
            // if current's right child has a left child, replace current with
            // current's right child's left-most child
            else
            {
                BinaryTreeNode<T> leftmost = current.Right.Left;
                BinaryTreeNode<T> leftmostParent = current.Right;

                // find current's right left-most child
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                leftmostParent.Left = leftmost.Right;

                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                // if removing the root node
                if (parent == null)
                {
                    _root = leftmost;
                }
                // if parent value is greater than current value
                // make leftmost the parent's left child
                else if(parent.CompareTo(current.Value) > 0)
                {
                    parent.Left = leftmost;
                }
                // if parent value is less than current value
                // make leftmost the parent's right child
                else if(parent.CompareTo(current.Value) < 0)
                {
                    parent.Right = leftmost;
                }
            }
            
            _count--;
            return true;
        }
        #endregion

        #region Pre-Order Traversal
        /// <summary>
        /// Performs the provided action on each binary tree node
        /// value in pre-order traversal order
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, _root);
        }

        private void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }
        #endregion

        #region In-Order Traversal
        /// <summary>
        /// Performs the provided action on each binary tree node
        /// value in in-order traversal order
        /// </summary>
        /// <param name="action">The action performed</param>
        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, _root);
        }

        private void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(action, node.Left);
                action(node.Value);
                InOrderTraversal(action, node.Right);
            }
        }
        #endregion

        #region Post-Order Traversal
        /// <summary>
        /// Performs the provided action on each binary tree node
        /// in post-order traversal order
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, _root);
        }

        private void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }
        #endregion

        /// <summary>
        /// Enumerates the values contained in the binary tree 
        /// in in-order traversal order
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (_root != null)
            {
                Stack_Array<BinaryTreeNode<T>> stack =
                    new Stack_Array<BinaryTreeNode<T>>();

                BinaryTreeNode<T> current = _root;

                bool goLeftNext = true;

                stack.Push(current);

                while (stack.Count() > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current.Value;

                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        /// <summary>
        /// Enumerates the values contained in the binary tree 
        /// in in-order traversal order
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        /// <summary>
        /// Removes all items from the binary tree
        /// </summary>
        public void Clear()
        {
            _root = null;
            _count = 0;
        }

        /// <summary>
        /// Returns the umber of items currently contained in the binary tree
        /// </summary>
        public int Count => _count;
    }
}
