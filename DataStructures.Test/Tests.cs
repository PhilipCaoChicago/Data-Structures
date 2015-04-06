using System;
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
            btree.Root = new BinaryTreeNode<int>(1);
            btree.Root.Left = new BinaryTreeNode<int>(2);
            btree.Root.Right = new BinaryTreeNode<int>(2);
        }
    }
}
