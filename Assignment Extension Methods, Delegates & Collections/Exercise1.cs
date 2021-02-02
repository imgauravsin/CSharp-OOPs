using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersice_1
{
    public static class Math
    {
        public static bool IsOdd(this int number)
        {
            if (number % 2 == 0)
                return false;
            return true;
        }
        public static bool IsEven(this int number)
        {
            if (number % 2 != 0)
                return false;
            return true;
        }
        public static bool IsPrime(this int number)
        {
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        public static bool IsDivisibleBy(this int number, int divisor)
        {
            if ((number % divisor) == 0)
                return true;
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Number : ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Is Number is odd : {0}", number.IsOdd());
 
            Console.WriteLine("Is Number is even : {0}", number.IsEven());
 
            Console.WriteLine("Is Number is prime : {0}", number.IsPrime());
 
            Console.WriteLine("Is Number is divisible by : {0}", number.IsDivisibleBy(7));
            Console.ReadLine();

        }
    }
}
