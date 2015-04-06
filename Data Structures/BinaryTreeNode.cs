using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode<T> Left
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbors[0];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);

                base.Neighbors[0] = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbors[1];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);

                base.Neighbors[1] = value;
            }
        }

        public BinaryTreeNode() : base() { }
        public BinaryTreeNode(T value) : base(value) { }
        public BinaryTreeNode(T value, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            base.Value = value;

            NodeList<T> children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;

            base.Neighbors = children;
        }
    }
}
