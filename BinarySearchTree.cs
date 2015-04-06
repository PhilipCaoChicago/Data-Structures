using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinarySearchTree<T> : BinaryTree<T>
    {
        private IComparer<T> comparer { get; set; }

        public BinarySearchTree() : base() { }

        public bool Contains(T value)
        {
            BinaryTreeNode<T> current = this;
            int result;

            while (current != null)
            {
                result = comparer.Compare(value, current.Value);

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

            BinaryTreeNode<T> current = this;
            BinaryTreeNode<T> parent = null;

            while (current != null)
            {
                result = comparer.Compare(value, current.Value);

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
                this.Value = value;
            }
            else
            {
                result = comparer.Compare(value, parent.Value);
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
            BinaryTreeNode<T> current = this;
            BinaryTreeNode<T> parent = null;

            int result = comparer.Compare(value, current.Value);

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
                    result = comparer.Compare(value, current.Value);
                }
            }

            if (current.Right == null)
            {
                if (parent == null)
                {
                    this.Value = current.Left.Value;
                    this.Left = current.Left.Left;
                    this.Right = current.Left.Right;
                }
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);

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
                    this.Value = current.Right.Value;
                    this.Left = current.Right.Left;
                    this.Right = current.Right.Right;
                }
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);

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
                    this.Value = leftmost.Value;
                    this.Left = leftmost.Left;
                    this.Right = leftmost.Right;
                }
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);

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
            this.Left = null;
            this.Right = null;
            this.Value = default(T);
        }

        public int Count()
        {
            return Count(this);
        }

        public IEnumerable<T> PreOrder()
        {
            return PreOrder(this);
        }

        public IEnumerable<T> InOrder()
        {
            return InOrder(this);
        }

        public IEnumerable<T> PostOrder()
        {
            return PostOrder(this);
        }

        private int Count(BinaryTreeNode<T> node, int count = 0)
        {
            if (node != null)
            {
                return 1 + Count(Left, count) + Count(Right, count);
            }
            else
            {
                return Count(Left, count) + Count(Right, count);
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
