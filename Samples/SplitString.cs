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
            var wordArray = File.ReadAllLines(@"C:\Temp\words.txt");
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

        //public string SplitStringWithoutSpaces2(string input)
        //{
        //    var partitions = PartitionString(input, new List<string>()).ToList();
        //    return String.Join(" ", partitions
        //                           .Where(p => p.All(w => words.Contains(w)))
        //                           .Select(p => new { P = p, C = p.Select(w => frequencies[w]).Sum()})
        //                           .OrderBy(o => o.C)
        //                           .First()
        //                           .P);
        //}

        public void PartitionString(string input, List<List<string>> partitions)
        {
            if (input == "")
            {
                //yield return new List<string>();
                //partitions.Add(partition);
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    List<string> partition = new List<string>();
                    if (words.Contains(input.Substring(0, i)))
                    {
                        partition.Add(input.Substring(0, i));
                        //int k = i;
                        //for (int j = 0; j <= input.Length - i; j++, k++)
                        //{
                        //    if (words.Contains(input.Substring(k, j)))
                        //    {
                        //        partition.Add(input.Substring(k, j));
                        //        k += j;
                        //        j = 0;
                        //    }
                        //}
                    }

                    if (String.Join("", partition) == input)
                    {
                        partitions.Add(partition);
                    }

                    //foreach (List<string> tail in PartitionString(input.Substring(i), partition))
                    //{
                    //    if (words.Contains(input.Substring(0, i)))
                    //    {
                    //        yield return (new List<string> { input.Substring(0, i) }).Concat(tail).ToList();
                    //    }
                    //    else
                    //    {
                    //        yield return new List<string>();
                    //    }
                    //}
                }
            }
        }
    }
}
