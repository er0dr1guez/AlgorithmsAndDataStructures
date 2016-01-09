using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsAndDataStructures.src.SingleLinkedList;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Test
{
    [TestClass]
    public class SingleLinkedListTest
    {
        [TestMethod]
        public void DefaultCtorValues()
        {
            var node = new LinkedListNode<int>();
            Assert.AreEqual(node.Value, 0);
            Assert.AreEqual(node.Next, null);
        }
    }
}
