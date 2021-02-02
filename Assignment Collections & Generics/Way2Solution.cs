using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueWay2
{
    interface IPriority<T>
    {
        T Priority();
    }
    class PriorityQueue2<T> : IPriority<T> where T : IEquatable<T>
    {
        private IDictionary<int, IList<T>> Priority_Queue;

        public PriorityQueue2()
        {
            Priority_Queue = new Dictionary<int, IList<T>>();
        }

        public int Count()
        {
            return Priority_Queue.Count;
        }

        public bool Contains(T item)
        {
            foreach (var node in Priority_Queue)
            {
                IList<T> Datalist = Priority_Queue[node.Key];
                foreach (T data in Datalist)
                {
                    if (data.Equals(item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public void Enqueue(int priority, T ele)
        {
            if (Priority_Queue.ContainsKey(priority))
                Priority_Queue[priority].Add(ele);
            else
            {
                Priority_Queue[priority] = new List<T>() { ele };
            }
        }


        public T Peek()
        {
            return Priority_Queue[Priority_Queue.Keys.ElementAt(0)][0];
        }


        public int GetHighestPriority()
        {
            int HighestPriority = Priority_Queue.Keys.ElementAt(0);
            foreach (KeyValuePair<int, IList<T>> pair in Priority_Queue.ToList())
            {
                if (pair.Key < HighestPriority)
                {
                    HighestPriority = pair.Key;
                }
            }
            return HighestPriority;
        }


        // Removes an item from the queue.

        public T Dequeue()
        {

            Console.WriteLine();
            Console.WriteLine($"\t\t\t Dequeuing the {GetHighestPriority()} From The Priority Queue");
            Priority_Queue.Remove(GetHighestPriority());
            return (T)Convert.ChangeType(GetHighestPriority(), typeof(T));
        }


        // Shows the items in the queue.
        public void ShowPriorityQueue()
        {
            foreach (KeyValuePair<int, IList<T>> node in Priority_Queue)
            {
                Console.Write("\t\tPriority   :=>  {0} :", node.Key);
                Console.Write("\t\tData   :=> ");
                IList<T> Datalist = Priority_Queue[node.Key];
                foreach (T data in Datalist)
                {
                    Console.Write(data);
                }
                Console.WriteLine();
            }
        }
        public T Priority()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue2<int> PriorityQueue = new PriorityQueue2<int>();

            PriorityQueue.Enqueue(1001, 895);
            PriorityQueue.Enqueue(1002, 139);
            PriorityQueue.Enqueue(1003, 415);

            //Displaying elements of the queue
            Console.WriteLine("=====================================================================");
            Console.WriteLine("\t\tElements in priority queue");
            Console.WriteLine("=====================================================================");
            PriorityQueue.ShowPriorityQueue();
            
            //Performing dequeue operation on the queue
            PriorityQueue.Dequeue();
            Console.WriteLine("=====================================================================");
            Console.WriteLine("\t\tPerform Dequeue Operation on Priority Queue");
            Console.WriteLine("=====================================================================");
            PriorityQueue.ShowPriorityQueue();

            //Finding peek element in the queue
            Console.WriteLine("=====================================================================");
            Console.WriteLine("\t\tPeek element in the Priority Queue is {0} ", PriorityQueue.Peek());
            Console.WriteLine("=====================================================================");


            //Checking elements in the queue
            Console.WriteLine("=====================================================================");
            Console.WriteLine("\t\tIs 415 element in the Priority Queue :  {0} ", PriorityQueue.Contains(415));
            Console.WriteLine("=====================================================================");


            //Displaying the size of the queue
            Console.WriteLine("=====================================================================");
            Console.WriteLine("\t\tThere are {0} Element Present in  the Priority Queue.", PriorityQueue.Count());
            Console.WriteLine("=====================================================================");
             
            Console.ReadLine();
        }
    }
}
