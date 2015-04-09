using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class LinkedList<T> where T : IComparable<T>
    {
        private LinkedListNode<T> Head { get; set; }

        public LinkedList(T value)
        {
            this.Head = new LinkedListNode<T>(value);
        }

        public void Add(T value)
        {
            if (this.Head == null)
            {
                this.Head = new LinkedListNode<T>(value);
            }
            else
            {
                this.Add(value, this.Head);
            }
        }

        public void Remove(T value)
        {
            this.Remove(value, this.Head);
        }

        public bool Contains(T value)
        {
            return this.Contains(value, this.Head);
        }

        private void Add(T value, LinkedListNode<T> node)
        {
            if (node.Child == null)
            {
                node.Child = new LinkedListNode<T>(value);
            }
            else
            {
                Add(value, node.Child);
            }
        }

        private void Remove(T value, LinkedListNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            if (node.Value.CompareTo(value) == 0)
            {
                if (node.Child == null)
                {
                    node = null;
                }
                else
                {
                    node.Value = node.Child.Value;
                    node.Child = node.Child.Child;
                }
            }
            else
            {
                Remove(value, node.Child);
            }
        }

        private bool Contains(T value, LinkedListNode<T> node)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value.CompareTo(value) == 0)
            {
                return true;
            }
            else
            {
                return Contains(value, node.Child);
            }
        }
    }
}
