using AlgorithmsAndDataStructures.src.SingleLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new SingleLinkedList<int>();

            list.AddLast(3);
            list.AddLast(5);
            list.AddLast(7);

        }

        static void Print(SingleLinkedListNode<int> node)
        {
            while (node != null)
            {
                Console.Write("|"+node.Value+"| ");
                node = node.Next;
            }
            Console.WriteLine();
        }
    }
}
