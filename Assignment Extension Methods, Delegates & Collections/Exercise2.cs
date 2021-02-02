using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    public static class Extension_All_Operation
    {
        public static bool CustomAll<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var i in source)
            {
                if (!predicate(i))
                {
                    return false;
                }

            }
            return true;

        }
        public static bool CustomAny<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var i in source)
            {
                if (predicate(i))
                {
                    return true;
                }

            }
            return false;

        }
        public static int CustomMax(this System.Collections.Generic.IEnumerable<int> source)
        {
            int MaximumNumber = 0;
            foreach (var i in source)
            {
                if (i > MaximumNumber)
                {
                    MaximumNumber = i;
                }

            }
            return MaximumNumber;
        }
        public static int CustomMin(this System.Collections.Generic.IEnumerable<int> source)
        {
            int MinimumNumber = source.Max();
            foreach (var i in source)
            {
                if (i < MinimumNumber)
                {
                    MinimumNumber = i;
                }

            }
            return MinimumNumber;
        }
        public static System.Collections.Generic.IEnumerable<TSource> CustomWhere<TSource>(this System.Collections.Generic.IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            List<TSource> List = new List<TSource>();
            foreach (var i in source)
            {
                if (predicate(i))
                {
                    List.Add(i);
                }
            }
            return List;
        }
        public static System.Collections.Generic.IEnumerable<TResult> CustomSelect<TSource, TResult>(this System.Collections.Generic.IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            List<TResult> finalList = new List<TResult>();
            int index = 0;

            foreach (var i in source)
            {   //work in progress..
                TResult obj = selector(i, index);
                finalList.Add(obj);
                index++;
            }
            return finalList;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            

            List<int> Object1 = new List<int>();
            Object1.Add(10);
            Object1.Add(9);
            Object1.Add(12);
            Object1.Add(15);

            bool ans = Object1.All(e => e >= 7);
            Console.WriteLine(ans);

            bool ans1 = Object1.CustomAll(e => e >= 7);
            Console.WriteLine(ans1);

            ans = Object1.Any(e => e == 8);
            Console.WriteLine(ans);

            ans1 = Object1.CustomAny(e => e == 8);
            Console.WriteLine(ans1);

            Console.WriteLine(Object1.Max());
            Console.WriteLine(Object1.CustomMax());

            Console.WriteLine(Object1.Min());
            Console.WriteLine(Object1.CustomMin());

            var item = Object1.Where(e => e % 2 == 0);
            foreach (var i in item)
            {
                Console.WriteLine(i);
            }

            item = Object1.CustomWhere(e => e % 2 == 0);
            foreach (var i in item)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
        
    }
}
