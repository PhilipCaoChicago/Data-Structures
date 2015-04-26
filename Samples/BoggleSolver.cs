using System;
using System.Collections.Generic;
using System.IO;
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
        public Trie<char> Words { get; set; }
        public HashSet<string> WordSet { get; set; }

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

            var wordArray = File.ReadAllLines("words.txt");
            this.Words = new Trie<char>();
            this.WordSet = new HashSet<string>();

            foreach(string word in wordArray)
            {
                this.Words.Add(word.ToUpper());
                this.WordSet.Add(word.ToUpper());
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
            IEnumerable<string> results = Enumerable.Empty<string>();

            foreach (GraphNode<char> node in g.NodeSet)
            {
                IEnumerable<string> words = this.FindWords(node, new List<GraphNode<char>> { node }).ToList();
                results = results.Concat(words);
            }

            return results.Intersect(this.WordSet).ToList();
        }

        private IEnumerable<string> FindWords(GraphNode<char> node, List<GraphNode<char>> path)
        {
            foreach (GraphNode<char> neighbor in node.Neighbors)
            {
                if (!path.Contains(neighbor))
                {
                    List<GraphNode<char>> testPath = path.Concat(new List<GraphNode<char>> { neighbor }).ToList();
                    char[] testChars = testPath.Select(n => n.Value).ToArray();

                    if (this.Words.Contains(testChars))
                    {
                        foreach (string word in (new[] { new String(testChars) }).Concat(this.FindWords(neighbor, testPath)))
                        {
                            yield return word;
                        }
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
                    if (i > 0 && j < this.Board.GetLength(1) - 1)
                    {
                        g.AddDirectedEdge(Translation[Tuple.Create(i, j)], Translation[Tuple.Create(i - 1, j + 1)]);
                    }
                    if (j > 0)
                    {
                        g.AddDirectedEdge(Translation[Tuple.Create(i, j)], Translation[Tuple.Create(i, j - 1)]);
                    }
                    if (j < this.Board.GetLength(1) - 1)
                    {
                        g.AddDirectedEdge(Translation[Tuple.Create(i, j)], Translation[Tuple.Create(i, j + 1)]);
                    }
                    if (i < this.Board.GetLength(0) - 1 && j > 0)
                    {
                        g.AddDirectedEdge(Translation[Tuple.Create(i, j)], Translation[Tuple.Create(i + 1, j - 1)]);
                    }
                    if (i < this.Board.GetLength(0) - 1)
                    {
                        g.AddDirectedEdge(Translation[Tuple.Create(i, j)], Translation[Tuple.Create(i + 1, j)]);
                    }
                    if (i < this.Board.GetLength(0) - 1 && j < this.Board.GetLength(1) - 1)
                    {
                        g.AddDirectedEdge(Translation[Tuple.Create(i, j)], Translation[Tuple.Create(i + 1, j + 1)]);
                    }
                }
            }

            return g;
        }
    }
}
