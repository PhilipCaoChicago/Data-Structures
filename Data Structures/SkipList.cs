using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class SkipList<T> where T : IComparable<T>
    {
        public int Height { get { return this.Head.Height; } }

        public int Count { get; set; }

        private SkipListNode<T> Head { get; set; }

        private Random RandomNumber { get; set; }

        protected readonly double probability = 0.5;

        public SkipList()
        {
            this.Head = new SkipListNode<T>(1);
            this.Count = 0;
            this.RandomNumber = new Random();
        }

        protected virtual int ChooseRandomHeight(int maxLevel)
        {
            int level = 1;

            while (this.RandomNumber.NextDouble() < this.probability && level < maxLevel)
            {
                level++;
            }

            return level;
        }

        protected SkipListNode<T>[] BuildUpdateList(T value)
        {
            SkipListNode<T>[] updates = new SkipListNode<T>[this.Height];
            SkipListNode<T> current = this.Head;

            for (int i = this.Height - 1; i >= 0; i--)
            {
                while (current[i] != null && current[i].Value.CompareTo(value) < 0)
                {
                    current = current[i];
                }

                updates[i] = current;
            }

            return updates;
        }

        public bool Contains(T value)
        {
            SkipListNode<T> curent = this.Head;

            for (int i = this.Height - 1; i >= 0; i--)
            {
                while (curent[i] != null)
                {
                    if (curent[i].Value.CompareTo(value) == 0)
                    {
                        return true;
                    }
                    else if (curent[i].Value.CompareTo(value) < 0)
                    {
                        curent = curent[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return false;
        }

        public void Add(T value)
        {
            SkipListNode<T>[] updates = this.BuildUpdateList(value);
            SkipListNode<T> current = updates[0];

            if (current[0] != null && current[0].Value.CompareTo(value) == 0)
            {
                return;
            }

            SkipListNode<T> n = new SkipListNode<T>(value, this.ChooseRandomHeight(this.Height + 1));
            this.Count++;

            if (n.Height > this.Height)
            {
                this.Head.IncrementHeight();
                this.Head[this.Head.Height - 1] = n;
            }

            for (int i = 0; i < n.Height; i++)
            {
                if (i < updates.Length)
                {
                    n[i] = updates[i][i];
                    updates[i][i] = n;
                }
            }
        }

        public bool Remove(T value)
        {
            SkipListNode<T>[] updates = this.BuildUpdateList(value);
            SkipListNode<T> current = updates[0][0];

            if (current != null && current.Value.CompareTo(value) == 0)
            {
                this.Count--;

                for (int i = 0; i < this.Head.Height; i++)
                {
                    if (updates[i][i] != current)
                    {
                        break;
                    }
                    else
                    {
                        updates[i][i] = current[i];
                    }
                }

                if (this.Head[this.Height - 1] == null)
                {
                    this.Head.DecrementHeight();
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
