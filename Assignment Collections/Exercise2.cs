using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2_Duck
{
    public class Duck
    {
        public string Name;
        public double Weight;
        public int NoOfWings;
        public void GetDetails(string name, double weight, int noOfWings)
        {
            this.Name = name;
            this.Weight = weight;
            this.NoOfWings = noOfWings;
        }

        public void ShowDetails()
        {
            Console.WriteLine("\nName : {0}, \nWeight : {1}, \nNo. of wings : {2}", Name, Weight, NoOfWings);
        }
    }

    class Program
    {
        public static void Main(string[] args)

        {
            List<Duck> duckList = new List<Duck>();

            //1. Adding ducks
            Duck d1 = new Duck();
            d1.GetDetails("Rubber", 2, 8);
            duckList.Add(d1);
            Duck d2 = new Duck();
            d2.GetDetails("Mallard", 3, 4);
            duckList.Add(d2);
            Duck d3 = new Duck();
            d3.GetDetails("Rubber", 4, 2);
            duckList.Add(d3);
            Duck d4 = new Duck();
            d4.GetDetails("Redhead", 5, 2);
            duckList.Add(d4);
            Duck d5 = new Duck();
            d5.GetDetails("Mallard", 4.5, 6);
            duckList.Add(d5);
            Console.WriteLine("Duck list after adding ducks :");
            foreach (var duck in duckList)
            {
                duck.ShowDetails();
            }
            Console.WriteLine();

            // 2. Removing a duck
            duckList.Remove(d2);
            Console.WriteLine("Duck list after removing a duck :");
            foreach (var duck in duckList)
            {
                duck.ShowDetails();
            }
            Console.WriteLine();

            // 3. Ordering ducks in increasing order of weight
            var orderByWeight = from duck in duckList
                                orderby duck.Weight
                                select duck;
            Console.WriteLine("Duck list increasing order of Weight  :");
            foreach (var duck in orderByWeight)
            {
                duck.ShowDetails();
                Console.ReadLine();
            }
            Console.WriteLine();

            //4. ordering ducks in increasing order of No. of wings
            var orderByWings = from duck in duckList
                               orderby duck.NoOfWings
                               select duck;
            Console.WriteLine("Duck list Increasing order of Wings :");
            foreach (var duck in orderByWings)
            {
                duck.ShowDetails();
            }
            Console.WriteLine();

            //5. Removing all ducks
            duckList.Clear();
        }
         
    }
}
