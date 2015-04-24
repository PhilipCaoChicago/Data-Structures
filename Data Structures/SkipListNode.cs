using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class SkipListNode<T> : Node<T>
    {
        public int Height
        {
            get { return base.Neighbors.Count; }
        }

        public SkipListNode<T> this[int index]
        {
            get { return (SkipListNode<T>)base.Neighbors[index]; }
            set { base.Neighbors[index] = value; }
        }

        public SkipListNode(int height)
        {
            base.Neighbors = new SkipListNodeList<T>(height);
        }

        public SkipListNode(T value, int height) : base(value)
        {
            base.Neighbors = new SkipListNodeList<T>(height);
        }

        internal void IncrementHeight()
        {
            base.Neighbors.Add(default(Node<T>));
        }

        internal void DecrementHeight()
        {
            base.Neighbors.RemoveAt(base.Neighbors.Count - 1);
        }
    }
}
