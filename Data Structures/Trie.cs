using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Trie<T>
    {
        public GraphNode<T> Root { get; set; }

        public Trie()
        {
            this.Root = new GraphNode<T>();
        }

        public Trie(IEnumerable<T> value) : this()
        {
            this.Add(value);
        }

        public bool Contains(IEnumerable<T> value)
        {
            return this.Contains(value, this.Root);
        }

        public void Add(IEnumerable<T> value)
        {
            this.Add(value, this.Root);
        }

        public bool Remove(IEnumerable<T> value)
        {
            if (value.Count() == 0 || value == null)
            {
                return true;
            }
            else
            {
                List<GraphNode<T>> path = new List<GraphNode<T>> { this.Root };
                GraphNode<T> current = this.Root;

                for (int i = 0; i < value.Count(); i++)
                {
                    GraphNode<T> next = (GraphNode<T>)current.Neighbors.FindByValue(value.ElementAt(i));

                    if (next == null)
                    {
                        return false;
                    }
                    else
                    {
                        path.Add(next);
                        current = next;
                    }
                }

                if (current.Neighbors.Count > 0)
                {
                    return true;
                }

                for (int i = path.Count - 2; i >= 0; i++)
                {
                    if (path[i].Neighbors.Count == 1)
                    {
                        path[i].Neighbors.Clear();
                    }
                    else
                    {
                        return true;
                    }
                }

                return true;
            }
        }

        private bool Contains(IEnumerable<T> value, GraphNode<T> node)
        {
            if (value.Count() == 0)
            {
                return true;
            }
            else
            {
                T first = value.First();
                GraphNode<T> child = (GraphNode<T>)node.Neighbors.FindByValue(first);


                if (child == null)
                {
                    return false;
                }
                else
                {
                    return this.Contains(value.Skip(1), child);
                }
            }
        }

        private void Add(IEnumerable<T> value, GraphNode<T> node)
        {
            if (value.Count() == 0 || value == null)
            {
                return;
            }
            else
            {
                T first = value.First();

                if (node.Neighbors.FindByValue(first) == null)
                {
                    node.Neighbors.Add(new GraphNode<T>(first));
                }

                this.Add(value.Skip(1), (GraphNode<T>)node.Neighbors.FindByValue(first));
            }
        }
    }
}
