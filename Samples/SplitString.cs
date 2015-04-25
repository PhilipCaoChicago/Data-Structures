using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    public class SplitString
    {
        List<string> words { get; set; }
        Dictionary<string, int> frequencies { get; set; }

        public SplitString()
        {
            var wordArray = File.ReadAllLines("words.txt");
            words = new List<string>(wordArray);
            frequencies = new Dictionary<string, int>();

            for (int i = 0; i < words.Count; i++)
            {
                frequencies.Add(words[i], i);
            }
        }

        public string SplitStringWithoutSpaces(string input)
        {
            for (int i = 1; i <= input.Length; i++)
            {
                string a = input.Substring(0, i);
                string b = input.Substring(i);

                if (words.Contains(a) && words.Contains(b))
                {
                    return a + " " + b;
                }
            }

            return null;
        }

        public string SplitStringWithoutSpaces2(string input)
        {
            var partitions = PartitionString(input).ToList();
            return String.Join(" ", partitions
                                   .Where(p => p.All(w => words.Contains(w)))
                                   .Select(p => new { P = p, C = p.Select(w => frequencies[w]).Sum() })
                                   .OrderBy(o => o.C)
                                   .First()
                                   .P);
        }

        public IEnumerable<List<string>> PartitionString(string input)
        {
            if (input == "")
            {
                yield return new List<string>();
            }
            else
            {
                for (int i = 1; i <= input.Length; i++)
                {
                    foreach (List<string> tail in PartitionString(input.Substring(i)))
                    {
                        yield return (new List<string> { input.Substring(0, i) }).Concat(tail).ToList();
                    }
                }
            }
        }
    }
}
