using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class LinkedListNode<T> : Node<T>
    {
        public LinkedListNode<T> Child
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (LinkedListNode<T>)base.Neighbors[0];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(1);

                base.Neighbors[0] = value;
            }
        }

        public LinkedListNode() : base() { }
        public LinkedListNode(T value) : base(value) { }
        public LinkedListNode(T value, LinkedListNode<T> child)
        {
            base.Value = value;

            NodeList<T> children = new NodeList<T>(1);
            children[0] = child;

            base.Neighbors = children;
        }
    }
}
