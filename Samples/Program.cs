using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            //SplitString ss = new SplitString();
            //string output = ss.SplitStringWithoutSpaces2("ilikecheese");
            //Console.WriteLine(output);
            //var partitions = new List<List<string>>();
            //ss.PartitionString("ilikecheese");
            //foreach (var p in partitions)
            //{
            //    foreach (var e in p)
            //    {
            //        Console.Write(e);
            //        Console.Write(" ");
            //    }
            //    Console.WriteLine();
            //}
            BoggleSolver bs = new BoggleSolver();
            bs.PrintBoard();
            bs.FindAllWords();
        }
    }
}
