using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.src.SingleLinkedList
{
    public class SingleLinkedListNode<T>
    {
        T Data { get; set; }
        SingleLinkedListNode<T> Next { get; set; }

        public SingleLinkedListNode()
        {

        }

        public SingleLinkedListNode(T data, SingleLinkedListNode<T> next)
        {
            Data = data;
            Next = next;
        }
    }
}
