using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueWay3
{
    public class PriorityQueue3<T> where T : IEquatable<T>
    {
 
        private class PriorityNode
        {
            public int Priority { get; set; }
            public T Data { get; set; }
        }

        private List<PriorityNode> elements;

        public PriorityQueue3()
        {
            this.elements = new List<PriorityNode>();
        }

        public PriorityQueue3(IDictionary<int, IList<T>> elements) : this()
        {

        }

        public int count()
        {
            return elements.Count;
        }

        public bool contains(T item)
        {
            if (elements.Count == 0)
            {
                return false;
            }

            foreach (PriorityNode priority_node in elements)
            {
                if (priority_node.Data.Equals(item))
                {
                    return true;


                }
            }
            return false;
        }
        public T Dequeue()
        {
            PriorityNode node = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            return node.Data;
        }
        public void Enqueue(int priority, T item)
        {
            PriorityNode node = new PriorityNode();
            node.Data = item;
            node.Priority = priority;
            elements.Add(node);
            elements.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        }
        public T peek()
        {
            PriorityNode node = elements[elements.Count - 1];
            return node.Data;
        }
        public int GetHighestPriority()
        {
            PriorityNode node = elements[elements.Count - 1];
            return node.Priority;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue3<string> queue = new PriorityQueue3<string>();
            queue.Enqueue(2001, "Gaurav Singh");
            queue.Enqueue(2002, "Rahul Murmu");
            queue.Enqueue(2003, "Aditya Thakur");
            queue.Enqueue(2004, "Sahil Nishal");
            queue.Enqueue(2003, "Deepak Kumar");
            Console.WriteLine("=============================================================================");
            Console.WriteLine("\t\tThe Size of Priority Queue is {0} .",queue.count());
            Console.WriteLine("=============================================================================");
            Console.WriteLine("\t\tIs The Aditya Thakur Contain The Priority Queue : {0} ",queue.contains("Aditya Thakur"));
            Console.WriteLine("=============================================================================");
            Console.WriteLine("\t\tIs The Deepak Contain The Priority Queue : {0}",queue.contains("Deepak"));
            Console.WriteLine("=============================================================================");
            Console.WriteLine("\t\tDequeu The Priority Queue And Element is : {0}",queue.Dequeue());
            Console.WriteLine("=============================================================================");
            Console.ReadLine();
        }
    }
}
