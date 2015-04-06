using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

        public virtual void Clear()
        {
            Root = null;
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(Root);
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(Root);
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(Root);
        }

        public BinaryTreeNode<T> FindNodeByValue(T value)
        {
            return FindNodeByValue(Root, value);
        }

        public virtual bool Contains(T value)
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

        private void PostOrderTraversal(BinaryTreeNode<T> node)
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

    public static class BinaryTreeExtensions
    {
        //static BinaryTree<T> FindNodeByValue<T>(this BinaryTree<T> tree, T value)
        //{
        //    if (tree == null || EqualityComparer<T>.Default.Equals(value, tree.Value))
        //    {
        //        return tree;
        //    }
        //    else
        //    {
        //        return FindNodeByValue(tree.Left, value) ?? FindNodeByValue(tree.Right, value);
        //    }
        //}
    }
}
