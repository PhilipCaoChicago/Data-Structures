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

        public override bool Contains(T value)
        {
            BinaryTreeNode<T> current = Root;
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
    }
}
