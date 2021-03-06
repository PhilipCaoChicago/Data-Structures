﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Graph<T>
    {
        public NodeList<T> NodeSet { get; private set; }

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

        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to)
        {
            AddNode(from);
            AddNode(to);
            from.Neighbors.Add(to);
        }

        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to)
        {
            AddDirectedEdge(from, to);
            AddDirectedEdge(to, from);
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
                }
            }

            return true;
        }

        public void BreadthFirstSearch(GraphNode<T> node)
        {
            Queue<GraphNode<T>> queue = new Queue<GraphNode<T>>();
            HashSet<GraphNode<T>> visited = new HashSet<GraphNode<T>>();

            queue.Enqueue(node);
            visited.Add(node);

            while (queue.Count > 0)
            {
                GraphNode<T> newNode = queue.Dequeue();

                foreach (GraphNode<T> neighbor in newNode.Neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
        }

        public void DepthFirstSearch(GraphNode<T> node, bool useRecursion = true)
        {
            if (useRecursion)
            {
                DepthFirstSearchRecursive(this, node, new HashSet<GraphNode<T>>());
            }
            else
            {
                DepthFirstSearchNonRecursive(this, node, new HashSet<GraphNode<T>>());
            }
        }

        private void DepthFirstSearchRecursive(Graph<T> graph, GraphNode<T> node, HashSet<GraphNode<T>> visited)
        {
            visited.Add(node);

            foreach (GraphNode<T> neighbor in node.Neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    DepthFirstSearchRecursive(graph, neighbor, visited);
                }
            }
        }

        private void DepthFirstSearchNonRecursive(Graph<T> graph, GraphNode<T> node, HashSet<GraphNode<T>> visited)
        {
            Stack<GraphNode<T>> stack = new Stack<GraphNode<T>>();
            stack.Push(node);

            while(stack.Count > 0)
            {
                GraphNode<T> newNode = stack.Pop();

                if (!visited.Contains(newNode))
                {
                    visited.Add(newNode);

                    foreach (GraphNode<T> neighbor in newNode.Neighbors)
                    {
                        stack.Push(neighbor);
                    }
                }
            }
        }

        public GraphNode<T> FindByValue(T value)
        {
            if (this.NodeSet == null)
            {
                return null;
            }
            else
            {
                return FindByValue(value, (GraphNode<T>)this.NodeSet.First(), new HashSet<GraphNode<T>>());
            }
        }

        private GraphNode<T> FindByValue(T value, GraphNode<T> node, HashSet<GraphNode<T>> visited)
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

        public IEnumerable<GraphNode<T>> FindShortestPath(GraphNode<T> source, GraphNode<T> target)
        {
            Dictionary<GraphNode<T>, int> distances = new Dictionary<GraphNode<T>, int>();
            Dictionary<GraphNode<T>, GraphNode<T>> previousNodes = new Dictionary<GraphNode<T>, GraphNode<T>>();
            List<GraphNode<T>> nodeList = new List<GraphNode<T>>();

            distances[source] = 0;
            previousNodes[source] = null;

            foreach (GraphNode<T> node in this.NodeSet)
            {
                if (node != source)
                {
                    distances[node] = Int32.MaxValue;
                    previousNodes[node] = null;
                }

                nodeList.Add(node);
            }

            while (nodeList.Count > 0)
            {
                GraphNode<T> node = nodeList.Select(n => new { Node = n, Distance = distances[n] }).OrderBy(n => n.Distance).First().Node;
                nodeList.Remove(node);

                foreach (GraphNode<T> neighbor in node.Neighbors)
                {
                    int alternate = distances[node] + 1;

                    if (alternate < distances[neighbor])
                    {
                        distances[neighbor] = alternate;
                        previousNodes[neighbor] = node;
                    }
                }
            }

            GraphNode<T> current = target;

            do
            {
                yield return previousNodes[current];
                current = previousNodes[current];
            }
            while (current != source);
        }
    }
}
