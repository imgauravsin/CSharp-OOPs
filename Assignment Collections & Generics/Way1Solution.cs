using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueWay1
{
    class PriorityQueue<T> where T : IEquatable<T>
    {
        private List<T> Values;
        private List<int> Priorities;
        private IDictionary<int, IList<T>> Elements;

        public PriorityQueue()
        {
            this.Values = new List<T>();
            this.Priorities = new List<int>();
        }
        public PriorityQueue(IDictionary<int, IList<T>> elements) : this()
        {
            this.Elements = elements;
        }
        public int Count()
        {
            return Values.Count;
        }
        public bool Contains(T item)
        {
            return Values.Contains(item);
        }
        public T Dequeue()
        {
            int index = 0;
            int highestPriority = Priorities[0];
            for (int i = 1; i < Priorities.Count; i++)
            {
                if (highestPriority < Priorities[i])
                {
                    highestPriority = Priorities[i];
                    index = i;
                }
            }
            T frontItem = Values[index];
            Values.RemoveAt(index);
            Priorities.RemoveAt(index);
            return frontItem;
        }
        public void Enqueue(int priority, T value)
        {
            Values.Add(value);
            Priorities.Add(priority);
        }
        public T Peek()
        {
            T frontItem = Values[0];
            return frontItem;
        }
        public int GetHighestPriority()
        {
            return Priorities[0];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();
            //Enqueue
            queue.Enqueue(1001, "Gaurav Singh");
            queue.Enqueue(1002, "Deepak kumar");
            queue.Enqueue(1003, "Rahul Murmu");
            queue.Enqueue(1004, "Aditya Thakur");
            queue.Enqueue(1005, "Sahil Nishal");

            //Dequeue
            string name = queue.Dequeue();
            Console.WriteLine("==================================================================================");
            Console.WriteLine("\t\tDequeue The Priority Queue And Dqueue Element is :{0} ",name);
            Console.WriteLine("==================================================================================");

            //Contain
            Console.WriteLine("==================================================================================");
            Console.WriteLine("\t\tIs Gaurav Singh Presence In List : {0}",queue.Contains("Gaurav Singh"));
            Console.WriteLine("==================================================================================");

            //Count Object
            Console.WriteLine("==================================================================================");
            Console.WriteLine("\t\tTotal Number of Object In Our Priority Queue is  : {0}",queue.Count());
            Console.WriteLine("==================================================================================");

            //Highest_Priority 
            Console.WriteLine("==================================================================================");
            Console.WriteLine("\t\tHigest Priority Object is : {0}",queue.GetHighestPriority());
            Console.WriteLine("==================================================================================");

            //Peek Element 
            Console.WriteLine("==================================================================================");
            Console.WriteLine("\t\tPeek of Priority Queue is  : {0}",queue.Peek());
            Console.WriteLine("==================================================================================");

            Console.ReadLine();


        }
    }
}
