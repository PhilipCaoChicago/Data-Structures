using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    class BinaryTree<T>
    {
        public T Value { get; set; }

        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> Right { get; set; }

        public BinaryTree(BinaryTree<T> Left, BinaryTree<T> Right, T Value)
        {
            this.Value = Value;
            this.Left = Left;
            this.Right = Right;
        }
    }

    static class BinaryTreeExtensions
    {
        static BinaryTree<T> FindNodeByValue<T>(this BinaryTree<T> tree, T value)
        {
            if (tree == null || EqualityComparer<T>.Default.Equals(value, tree.Value))
            {
                return tree;
            }
            else
            {
                return FindNodeByValue(tree.Left, value) ?? FindNodeByValue(tree.Right, value);
            }
        }

        static void PrintTree<T>(this BinaryTree<T> tree)
        {
            if (tree != null)
            {
                Console.WriteLine(tree.Value);
                PrintTree(tree.Left);
                PrintTree(tree.Right);
            }
        }
    }
}
