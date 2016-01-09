using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsAndDataStructures.src.SingleLinkedList;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Test
{
    [TestClass]
    public class SingleLinkedListTest
    {
        [TestMethod]
        public void AddFirstTest()
        {
            var list = new SingleLinkedList<int>();

            //Empty list
            Assert.AreEqual(list.Head, null);
            Assert.AreEqual(list.Tail, null);

            //Non Empty list
            list.AddFirst(3);
            list.AddFirst(5);
            list.AddFirst(7);

            Assert.AreEqual(list.Head.Value, 7);
            Assert.AreEqual(list.Tail.Value, 3);
        }
    }
}
