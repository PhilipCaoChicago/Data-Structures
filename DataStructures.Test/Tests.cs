using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void BinaryTreeTest()
        {
            BinaryTree<int> btree = new BinaryTree<int>();
        }

        [TestMethod]
        public void MergeSortTest()
        {
            Assert.IsTrue(Enumerable.Range(1, 100).Shuffle().MergeSort().SequenceEqual(Enumerable.Range(1, 100)));
            Assert.IsTrue(Enumerable.SequenceEqual(Enumerable.Range(1, 1).Shuffle().MergeSort(), Enumerable.Range(1, 1)));
            Assert.IsTrue(Enumerable.SequenceEqual(Enumerable.Empty<int>().MergeSort(), Enumerable.Empty<int>()));
        }

        [TestMethod]
        public void QuickSortTest()
        {
            Assert.IsTrue(Enumerable.SequenceEqual(Enumerable.Range(1, 100).Shuffle().QuickSort(), Enumerable.Range(1, 100)));
            Assert.IsTrue(Enumerable.SequenceEqual(Enumerable.Range(1, 1).Shuffle().QuickSort(), Enumerable.Range(1, 1)));
            Assert.IsTrue(Enumerable.SequenceEqual(Enumerable.Empty<int>().QuickSort(), Enumerable.Empty<int>()));
        }

        [TestMethod]
        public void ShuffleTest()
        {
            var shuffled = Enumerable.Range(1, 100).Shuffle();
            Assert.IsFalse(Enumerable.SequenceEqual(shuffled, Enumerable.Range(1, 100)));
        }
    }
}
