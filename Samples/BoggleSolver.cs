using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace Samples
{
    public class BoggleSolver
    {
        private char[,] Board { get; set; }
        private Dictionary<Tuple<int, int>, GraphNode<char>> Translation { get; set; }

        public BoggleSolver() : this(5) { }

        public BoggleSolver(int size)
        {
            this.Board = new char[size, size];
            Random r = new Random();
            this.Translation = new Dictionary<Tuple<int, int>, GraphNode<char>>();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.Board[i, j] = (char)r.Next(65, 91);
                }
            }
        }

        public BoggleSolver(char[,] board)
        {
            this.Board = board;
        }

        public void PrintBoard()
        {
            for (int i = 0; i < this.Board.GetLength(0); i++)
            {
                for(int j = 0; j < this.Board.GetLength(1); j++)
                {
                    Console.Write(this.Board[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public List<string> FindAllWords()
        {
            Graph<char> g = this.CopyToGraph();
            return new List<string>();
        }

        private List<string> FindWords(Graph<char> g, GraphNode<char> node)
        {
            Queue<GraphNode<char>> queue = new Queue<GraphNode<char>>();
            HashSet<GraphNode<char>> visited = new HashSet<GraphNode<char>>();
            List<char> chars = new List<char> { node.Value };
            List<string> words = new List<string>();

            queue.Enqueue(node);
            visited.Add(node);

            while (queue.Count > 0)
            {
                GraphNode<char> newNode = queue.Dequeue();
                List<char> testChars = new List<char>(chars);
                testChars.Add(newNode.Value);

                foreach (GraphNode<char> neighbor in newNode.Neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
        }

        private IEnumerable<List<GraphNode<char>>> FindSubstrings(GraphNode<char> node, List<GraphNode<char>> current)
        {
            if (node == null)
            {
                yield return new List<GraphNode<char>>();
            }
            else
            {
                foreach (GraphNode<char> neighbor in node.Neighbors)
                {
                    foreach(List<GraphNode<char>> next in FindSubstrings(neighbor, current))
                    {
                        yield return current.Concat(new List<GraphNode<char>> { neighbor.Value }).Concat(next).ToList();
                    }
                }
            }
        }

        private Graph<char> CopyToGraph()
        {
            Graph<char> g = new Graph<char>();

            for(int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    GraphNode<char> newNode = new GraphNode<char>(this.Board[i, j]);
                    g.AddNode(newNode);
                    this.Translation.Add(Tuple.Create(i, j), newNode);
                }
            }

            for(int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (i > 0 && j > 0)
                    {
                        g.AddDirectedEdge(Translation[Tuple.Create(i, j)], Translation[Tuple.Create(i - 1, j - 1)]);
                    }
                    if (i > 0)
                    {
                        g.AddDirectedEdge(Translation[Tuple.Create(i, j)], Translation[Tuple.Create(i - 1, j)]);
                    }
                    if (i > 0 && j < this.Board.GetLength(1) - 2)
                    {
                        g.AddDirectedEdge(Translation[Tuple.Create(i, j)], Translation[Tuple.Create(i - 1, j + 1)]);
                    }
                    if (j > 0)
                    {
                        g.AddDirectedEdge(Translation[Tuple.Create(i, j)], Translation[Tuple.Create(i, j - 1)]);
                    }
                    if (j < this.Board.GetLength(1) - 2)
                    {
                        g.AddDirectedEdge(Translation[Tuple.Create(i, j)], Translation[Tuple.Create(i, j + 1)]);
                    }
                    if (i < this.Board.GetLength(0) - 2 && j > 0)
                    {
                        g.AddDirectedEdge(Translation[Tuple.Create(i, j)], Translation[Tuple.Create(i + 1, j - 1)]);
                    }
                    if (i < this.Board.GetLength(0) - 2)
                    {
                        g.AddDirectedEdge(Translation[Tuple.Create(i, j)], Translation[Tuple.Create(i + 1, j)]);
                    }
                    if (i < this.Board.GetLength(0) - 2 && j < this.Board.GetLength(1) - 2)
                    {
                        g.AddDirectedEdge(Translation[Tuple.Create(i, j)], Translation[Tuple.Create(i + 1, j + 1)]);
                    }
                }
            }

            return g;
        }
    }
}
