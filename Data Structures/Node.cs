using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node<T>
    {
        public T Value { get; set; }
        protected NodeList<T> Neighbors { get; set; }

        public Node() { }
        public Node(T value) : this(value, null) { }
        public Node(T value, NodeList<T> neighbors)
        {
            this.Value = value;
            this.Neighbors = neighbors;
        }
    }
}
