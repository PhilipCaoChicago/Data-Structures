using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Graph<T>
    {
        private NodeList<T> NodeSet { get; set; }

        public Graph() : this(null) { }
        public Graph(NodeList<T> nodeSet)
        {
            if (nodeSet == null)
            {
                this.NodeSet = new NodeList<T>();
            }
            else
            {
                this.NodeSet = nodeSet;
            }
        }

        public void AddNode(GraphNode<T> node)
        {
            if (this.NodeSet.Contains(node))
            {
                return;
            }

            NodeSet.Add(node);
        }

        public void AddNode(T value)
        {
            NodeSet.Add(new GraphNode<T>(value));
        }

        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            AddNode(from);
            AddNode(to);
            from.Neighbors.Add(to);
            from.Costs.Add(cost);
        }

        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            AddDirectedEdge(from, to, cost);
            AddDirectedEdge(to, from, cost);
        }

        public bool Contains(T value)
        {
            return this.NodeSet.FindByValue(value) != null;
        }

        public bool Remove(T value)
        {
            GraphNode<T> nodeToRemove = (GraphNode<T>)this.NodeSet.FindByValue(value);

            if (nodeToRemove == null)
            {
                return false;
            }

            this.NodeSet.Remove(nodeToRemove);

            foreach (GraphNode<T> node in NodeSet)
            {
                int index = node.Neighbors.IndexOf(nodeToRemove);

                if(index != 1)
                {
                    node.Neighbors.RemoveAt(index);
                    node.Costs.RemoveAt(index);
                }
            }

            return true;
        }

        public GraphNode<T> FindByValue(T value)
        {
            if (this.NodeSet == null)
            {
                return null;
            }
            else
            {
                return FindByValue(value, (GraphNode<T>)this.NodeSet.First(), new List<GraphNode<T>>());
            }
        }

        private GraphNode<T> FindByValue(T value, GraphNode<T> node, List<GraphNode<T>> visited)
        {
            if (EqualityComparer<T>.Default.Equals(value, node.Value))
            {
                return node;
            }
            else
            {
                visited.Add(node);

                foreach (GraphNode<T> neighbor in node.Neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        return FindByValue(value, neighbor, visited);
                    }
                }

                return null;
            }
        }
    }
}
