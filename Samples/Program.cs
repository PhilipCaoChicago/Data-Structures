using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            BoggleSolver bs = new BoggleSolver();
            bs.PrintBoard();

            List<string> words = bs.FindAllWords();
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
