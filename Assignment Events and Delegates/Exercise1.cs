using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersice_1
{
    public delegate bool Multiple(int value);
    public class Delegate
    {
        // Find The Even Number using lambda expression
        public static void FindEven(List<int> numbers)
        {
            
            List<int> result = numbers.FindAll(i => i % 2 == 0);

            Console.WriteLine("The Even Numbers from the list are : ");
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
        }
        // Find The Odd Number Using anonymous delegate
        public static void FindOdd(List<int> numbers)
        {
            
            List<int> result = numbers.FindAll(delegate (int n)
            {
                return (n % 2 != 0);
            });

            Console.WriteLine("The Odd numbers from the list are : ");
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }

        }
        /// Finds the prime numbers from the list.
        public static void FindPrime(List<int> Numbers)
        {
            List<int> result = Numbers.FindAll(delegate (int n)
            {
                 
                int check = 0;
                for (int i = 2; i <= n / 2; i++)
                {
                    if (n % i == 0)
                    {
                        check++;
                        break;
                    }
                }
                return check == 0 ? true : false;
            });

            Console.WriteLine("Using Anonymous Delegate Methods : The prime numbers from the list are ->  ");
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
        }


        // Finds the numbers which are greater than 5 from the list using lambda expression
        public static void FindGreaterThan(List<int> numbers)
        {
            
            List<int> result = numbers.FindAll(i => i > 5);

            Console.WriteLine("The  Numbers greater than 5 from the list are :  ");
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
        }


        // Finds the numbers that are less than 5 from the list  Using lambda expression
        public static void FindLessThan(List<int> numbers)
        {
            
            List<int> result = numbers.FindAll(i => i < 5);

            Console.WriteLine("The  Numbers less than 5 from the list are :  ");
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
        }


        // Finds the numbers that are multiple of 3 from the list.

        public static void Find3k(List<int> numbers, Multiple Num)
        {
            Console.WriteLine("Multiples of three  from the list are : ");
            foreach (int i in numbers)
            {
                if (Num(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        //  Finds the numbers that are multiple of 3k+1 from the list.

        public static void Find3KPlus1(List<int> numbers, Multiple Num)
        {
            Console.WriteLine("Numbers in the form of 3k+1  from the list are : ");
            foreach (int i in numbers)
            {
                if (Num(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void Find3kPlus2(List<int> numbers, Multiple Num)
        {
            Console.WriteLine("Numbers in the form of 3k+2 from the list are : ");
            foreach (int i in numbers)
            {
                if (Num(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ListofNumbers = new List<int>();
            Console.WriteLine("Enter the Size of List : ");
            int Size = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter {0} numbers : ",Size);
            for (int i = 0; i < Size; i++)
            {
                int Value = int.Parse(Console.ReadLine());
                ListofNumbers.Add(Value);
            }

            Delegate.FindEven(ListofNumbers);
            Delegate.FindOdd(ListofNumbers);
            Delegate.FindPrime(ListofNumbers);
            Delegate.FindGreaterThan(ListofNumbers);
            Delegate.FindLessThan(ListofNumbers);
            Delegate.Find3k(ListofNumbers, i => i % 3 == 0);
            Multiple Num = delegate (int value)
            {
                return value % 3 == 1 ? true : false;
            };
            Delegate.Find3KPlus1(ListofNumbers, Num);
            Delegate.Find3kPlus2(ListofNumbers, i => i % 3 == 2);
            Console.ReadLine();
        }
    }
}
