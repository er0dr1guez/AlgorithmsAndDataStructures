using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsAndDataStructures.src.DoublyLinkedList;

namespace AlgorithmsAndDataStructures.Test
{
    [TestClass]
    public class DoublyLinkedListTest
    {
        [TestMethod]
        public void AddFirstTest()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(2);
            list.AddFirst(4);
            list.AddFirst(6);

            Assert.AreEqual(list.Head.Value, 6);
            Assert.AreEqual(list.Tail.Value, 2);
        }

        [TestMethod]
        public void AddLastTest()
        {
            var list = new DoublyLinkedList<int>();
            list.AddLast(2);
            list.AddLast(4);
            list.AddLast(6);

            Assert.AreEqual(list.Head.Value, 2);
            Assert.AreEqual(list.Tail.Value, 6);
        }

        [TestMethod]
        public void ClearTest()
        {
            var list = new DoublyLinkedList<int>();
            list.AddLast(2);
            list.AddLast(4);
            list.AddLast(6);

            list.Clear();

            Assert.AreEqual(list.Head, null);
        }
    }
}
