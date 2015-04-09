using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Heap<T> : List<T> where T : IComparable<T>
    {
        public Heap() : base() { }

        public new void Add(T value)
        {
            this.Add(value);
            int position = this.Count;

            while (position > 1 && value.CompareTo(this[position / 2]) < 0)
            {
                this[position] = this[position / 2];
                position /= 2;
            }
        }

        private void Swap(int index1, int index2)
        {
            T temp = this[index1];
            this[index1] = this[index2];
            this[index2] = temp;
        }
    }

}
