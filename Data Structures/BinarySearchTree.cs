using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable<T>
    {
        public BinarySearchTree() : base() { }

        public override bool Contains(T value)
        {
            BinaryTreeNode<T> current = this.Root;
            int result;

            while (current != null)
            {
                result = value.CompareTo(current.Value);

                if (result == 0)
                    return true;
                else if (result < 0)
                    current = current.Left;
                else if (result > 0)
                    current = current.Right;
            }

            return false;
        }

        public void Add(T value)
        {
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(value);
            int result;

            BinaryTreeNode<T> current = this.Root;
            BinaryTreeNode<T> parent = null;

            while (current != null)
            {
                result = value.CompareTo(current.Value);

                if (result == 0)
                {
                    return;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result > 0)
                {
                    parent = current;
                    current = current.Right;
                }
            }

            if (parent == null)
            {
                this.Root = newNode;
            }
            else
            {
                result = value.CompareTo(parent.Value);
                if (result < 0)
                {
                    parent.Left = newNode;
                }
                else
                {
                    parent.Right = newNode;
                }
            }
        }

        public void Remove(T value)
        {
            BinaryTreeNode<T> current = this.Root;
            BinaryTreeNode<T> parent = null;

            int result = value.CompareTo(current.Value);

            while (result != 0)
            {
                if (result < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result > 0)
                {
                    parent = current;
                    current = current.Right;
                }

                if (current == null)
                {
                    return;
                }
                else
                {
                    result = value.CompareTo(current.Value);
                }
            }

            if (current.Right == null)
            {
                if (parent == null)
                {
                    this.Root = current.Left;
                }
                else
                {
                    result = parent.Value.CompareTo(current.Value);

                    if (result > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    this.Root = current.Right;
                }
                else
                {
                    result = parent.Value.CompareTo(current.Value);

                    if (result > 0)
                    {
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                BinaryTreeNode<T> leftmost = current.Right.Left;
                BinaryTreeNode<T> leftmostParent = current.Right;

                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                leftmostParent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                {
                    this.Root.Value = leftmost.Value;
                    this.Root.Left = leftmost.Left;
                    this.Root.Right = leftmost.Right;
                }
                else
                {
                    result = parent.Value.CompareTo(current.Value);

                    if (result > 0)
                    {
                        parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftmost;
                    }
                }
            }
        }

        public void Clear()
        {
            this.Root = null;
        }

        public int Count()
        {
            return Count(this.Root);
        }

        public IEnumerable<T> PreOrder()
        {
            return PreOrder(this.Root);
        }

        public IEnumerable<T> InOrder()
        {
            return InOrder(this.Root);
        }

        public IEnumerable<T> PostOrder()
        {
            return PostOrder(this.Root);
        }

        private int Count(BinaryTreeNode<T> node, int count = 0)
        {
            if (node != null)
            {
                return 1 + Count(node.Left, count) + Count(node.Right, count);
            }
            else
            {
                return count;
            }
        }

        private IEnumerable<T> PreOrder(BinaryTreeNode<T> node)
        {
            return (new List<T> { node.Value }).Concat(PreOrder(node.Left)).Concat(PreOrder(node.Right));
        }

        private IEnumerable<T> InOrder(BinaryTreeNode<T> node)
        {
            return (new List<T> { node.Value }).Concat(InOrder(node.Left)).Concat(InOrder(node.Right));
        }

        private IEnumerable<T> PostOrder(BinaryTreeNode<T> node)
        {
            return (new List<T> { node.Value }).Concat(PostOrder(node.Left)).Concat(PostOrder(node.Right));
        }
    }
}
