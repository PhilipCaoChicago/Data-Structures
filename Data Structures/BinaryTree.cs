using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinaryTree<T> : BinaryTreeNode<T>
    {
        public BinaryTree() : base(){}

        public void PreOrderTraversal()
        {
            PreOrderTraversal(this);
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(this);
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(this);
        }

        public BinaryTreeNode<T> FindNodeByValue(T value)
        {
            return FindNodeByValue(this, value);
        }

        public bool Contains(T value)
        {
            return FindNodeByValue(value) == null;
        }

        private void PreOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Value);
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        private void InOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.WriteLine(node.Value);
                InOrderTraversal(node.Right);
            }
        }

        public void PostOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                Console.WriteLine(node.Value);
            }
        }

        private BinaryTreeNode<T> FindNodeByValue(BinaryTreeNode<T> node, T value)
        {
            if (node == null || EqualityComparer<T>.Default.Equals(value, node.Value))
            {
                return node;
            }
            else
            {
                return FindNodeByValue(node.Left, value) ?? FindNodeByValue(node.Right, value);
            }
        }
    }
}
