using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsAndDataStructures.src.SingleLinkedList;

namespace AlgorithmsAndDataStructures.Test
{
    [TestClass]
    public class SingleLinkedListTest
    {
        [TestMethod]
        public void AddFirstTest()
        {
            var list = new SingleLinkedList<int>();
            list.AddFirst(2);
            list.AddFirst(4);
            list.AddFirst(6);

            Assert.AreEqual(list.Head.Value, 6);
            Assert.AreEqual(list.Tail.Value, 2);
        }

        [TestMethod]
        public void AddLastTest()
        {
            var list = new SingleLinkedList<int>();
            list.AddLast(2);
            list.AddLast(4);
            list.AddLast(6);

            Assert.AreEqual(list.Head.Value, 2);
            Assert.AreEqual(list.Tail.Value, 6);
        }

        [TestMethod]
        public void RemoveFirstTest()
        {
            var list = new SingleLinkedList<int>();
            list.AddLast(2);
            list.AddLast(4);
            list.AddLast(6);

            Assert.AreEqual(list.Head.Value, 2);

            list.RemoveFirst();

            Assert.AreEqual(list.Head.Value, 4);
        }

        [TestMethod]
        public void RemoveLastTest()
        {
            var list = new SingleLinkedList<int>();
            list.AddLast(2);
            list.AddLast(4);
            list.AddLast(6);

            Assert.AreEqual(list.Tail.Value, 6);

            list.RemoveLast();

            Assert.AreEqual(list.Tail.Value, 4);
        }

        [TestMethod]
        public void ContainsTest()
        {
            var list = new SingleLinkedList<int>();
            list.AddLast(2);
            list.AddLast(4);
            list.AddLast(6);

            Assert.AreEqual(list.Contains(2), true);
            Assert.AreEqual(list.Contains(4), true);
            Assert.AreEqual(list.Contains(6), true);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var list = new SingleLinkedList<int>();
            list.AddLast(2);
            list.AddLast(4);
            list.AddLast(6);

            list.Remove(4);

            Assert.AreEqual(list.Contains(4), false);
        }

    }
}
