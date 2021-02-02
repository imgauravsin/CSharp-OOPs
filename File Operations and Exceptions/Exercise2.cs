using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_2
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int count = 5;
            try
            {
                while (count >= 0)
                {
                    if (count == 0)
                    {
                        throw new CustomException("Limit Exceed ! You have played this game 5 times.");
                    }
                    Console.WriteLine("Enter Any number from 1 to 5");
                    int value = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        Validation(value);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    count--;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static bool Validation(int value)
        {
            switch (value)
            {
                case 1:
                    Console.WriteLine("Enter Even number");
                    int n1 = int.Parse(Console.ReadLine());
                    if (n1 % 2 != 0)
                    {
                        throw new CustomException("The Number is not even");
                    }
                    return true;
                case 2:
                    Console.WriteLine("Enter odd number");
                    int n2 = int.Parse(Console.ReadLine());
                    if (n2 % 2 == 0)
                    {
                        throw new CustomException("The Number is not odd");
                    }
                    return true;
                case 3:
                    Console.WriteLine("Enter a prime number");
                    int n3 = int.Parse(Console.ReadLine());
                    if (n3 == 1)
                        throw new CustomException("The Number is not prime");
                    if (n3 == 2)
                        return true;
                    // Find The Prime Number using the Square Root Concept
                    var limit = Math.Ceiling(Math.Sqrt(n3));  
                    for (int i = 2; i <= limit; ++i)
                    {
                        if (n3 % i == 0)
                            throw new CustomException("The Number is not prime");
                    }
                    return true;
                case 4:
                    Console.WriteLine("Enter a Negative number");
                    int n4 = int.Parse(Console.ReadLine());
                    if (n4 >= 0)
                    {
                        throw new CustomException("Entered number is not negative");
                    }
                    return true;
                case 5:
                    Console.WriteLine("Enter zero : ");
                    int n5 = int.Parse(Console.ReadLine());
                    if (n5 != 0)
                    {
                        throw new CustomException("The Number is not zero");
                    }
                    return true;
                default:
                    throw new CustomException("The Number is not in the range 1-5");
            }
        }
    } 
}
