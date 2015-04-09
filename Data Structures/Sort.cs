using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class Sort
    {
        public static IEnumerable<T> MergeSort<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            int count = collection.Count();
            if (count <= 1)
            {
                return collection;
            }

            var left = collection.Where((e, i) => i < count / 2).MergeSort();
            var right = collection.Where((e, i) => i >= count / 2).MergeSort();
            return Merge(left, right);
        }

        private static IEnumerable<T> Merge<T>(IEnumerable<T> left, IEnumerable<T> right) where T : IComparable<T>
        {
            List<T> result = new List<T>();

            while (left.Count() > 0 && right.Count() > 0)
            {
                if (left.First().CompareTo(right.First()) <= 0)
                {
                    result.Add(left.First());
                    left = left.Where((e, i) => i > 0);
                }
                else
                {
                    result.Add(right.First());
                    right = right.Where((e, i) => i > 0);
                }
            }

            while (left.Count() > 0)
            {
                result.Add(left.First());
                left = left.Where((e, i) => i > 0);
            }

            while (right.Count() > 0)
            {
                result.Add(right.First());
                right = right.Where((e, i) => i > 0);
            }

            return result;
        }

        public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            if (collection.Count() <= 1)
            {
                return collection;
            }

            T pivot = collection.ElementAt(1);
            IEnumerable<T> left = collection.Where(element => element.CompareTo(pivot) < 0);
            IEnumerable<T> right = collection.Where(element => element.CompareTo(pivot) > 0);

            return left.QuickSort().Concat(new List<T> { pivot }).Concat(right.QuickSort());
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
        {
            Random rng = new Random();
            T[] array = collection.ToArray();
            int n = array.Count();

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = array[k];
                array[k] = array[n];
                array[n] = value;
            }

            foreach (T element in array)
            {
                yield return element;
            }
        }
    }
}
