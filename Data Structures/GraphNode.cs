using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class GraphNode<T> : Node<T>
    {
        new public NodeList<T> Neighbors
        {
            get
            {
                if (base.Neighbors == null)
                {
                    base.Neighbors = new NodeList<T>();
                }

                return base.Neighbors;
            }
        }

        public GraphNode() : base() { }
        public GraphNode(T value) : base(value) { }
        public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }
    }
}
