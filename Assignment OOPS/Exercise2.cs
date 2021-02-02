using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2_Duck
{
    public enum TypeOfDuck { Rubber, Mallard, Redhead }
    public abstract class Duck
    {
        public double Weight;
        public int NoOfWings;
        public IFlyBehaviour flyBehaviour;
        public IQuackBehaviour quackBehaviour;
        public void GetDetails(double weight, int noOfWings)
        {
            this.Weight = weight;
            this.NoOfWings = noOfWings;
        }
        public void PerformFly()
        {
            flyBehaviour.Fly();
        }
        public void PerformQuack()
        {
            quackBehaviour.Quack();
        }
        public abstract void ShowDetails();
    }
    public interface IFlyBehaviour
    {
        void Fly();
    }
    public class DontFly : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("I don't fly.");
        }
    }
    public class FlyFast : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("I fly fast.");
        }
    }
    public class FlySlow : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("I fly slow.");
        }
    }
    public interface IQuackBehaviour
    {
        void Quack();
    }
    public class Squeak : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("I squeak.");
        }
    }
    public class QuackLoud : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("I quack loud.");
        }
    }
    public class QuackMild : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("I quack mild.");
        }
    }
    public class RubberDuck : Duck
    {
        public RubberDuck()
        {
            flyBehaviour = new DontFly();
            quackBehaviour = new Squeak();
        }
        public override void ShowDetails()
        {
            Console.WriteLine("I am Rubber Duck and my traits are :");
            Console.WriteLine("I have {0} kgs of weight and {1} wings", Weight, NoOfWings);
        }
    }

    public class MallardDuck : Duck
    {

        public MallardDuck()
        {
            flyBehaviour = new FlyFast();
            quackBehaviour = new QuackLoud();
        }
        public override void ShowDetails()
        {
            Console.WriteLine("I am Mallard Duck and my traits are :");
            Console.WriteLine("I have {0} kgs of weight and {1} wings", Weight, NoOfWings);
        }
    }
    public class RedHeadDuck : Duck
    {
        public RedHeadDuck()
        {
            flyBehaviour = new FlySlow();
            quackBehaviour = new QuackMild();
        }
        public override void ShowDetails()
        {
            Console.WriteLine("I am Redhead Duck and my traits are :");
            Console.WriteLine("I have {0} kgs of weight and {1} wings", Weight, NoOfWings);
        }
    }
    class Program
    {
        public
            static void Main(string[] args)
        {
            Console.WriteLine("Enter the value of type of \nDuck Rubber : 0 \nDuck Mallard : 1 \nDuck Redhead : 2");
            int value = int.Parse(Console.ReadLine());
            if (value == (int)TypeOfDuck.Rubber)
            {
                Duck rubber = new RubberDuck();
                rubber.GetDetails(5.4, 4);
                rubber.ShowDetails();
                rubber.PerformFly();
                rubber.PerformQuack();
                Console.WriteLine();
            }
            else if (value == (int)TypeOfDuck.Mallard)
            {
                Duck mallard = new MallardDuck();
                mallard.GetDetails(4, 3);
                mallard.ShowDetails();
                mallard.PerformFly();
                mallard.PerformQuack();
                Console.WriteLine();
            }
            else if (value == (int)TypeOfDuck.Redhead)
            {
                Duck redHead = new RedHeadDuck();
                redHead.GetDetails(5, 2);
                redHead.ShowDetails();
                redHead.PerformFly();
                redHead.PerformQuack();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Wrong Value ! Please the Valid Input");
            }
            Console.ReadLine();
        }
    }
}
