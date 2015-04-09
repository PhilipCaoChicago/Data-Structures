using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class HashTable<T> where T : IComparable<T>
    {
        private List<LinkedList<T>> Table { get; set; }
        private int tableSize = 1023;

        public HashTable()
        {
            this.Table = new List<LinkedList<T>>();
        }

        public void Add(T value)
        {
            int hash = Hash(value);

            if (!Table[hash].Contains(value))
            {
                Table[hash].Add(value);
            }
        }

        public void Remove(T value)
        {
            Table[Hash(value)].Remove(value);
        }

        public bool Contains(T value)
        {
            return Table[Hash(value)].Contains(value);
        }

        private int Hash(T value)
        {
            return value.GetHashCode() % this.tableSize;
        }
    }

}
