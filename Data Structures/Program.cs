using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var shuffled = Enumerable.Range(1, 100).Shuffle().ToList();
            var sorted = shuffled.MergeSort();
            sorted.ToList().ForEach(i => Console.WriteLine(i));
            Console.WriteLine(sorted.SequenceEqual(Enumerable.Range(1, 100)));
        }
    }
}
