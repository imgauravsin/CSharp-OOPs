using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1_Equipment
{
    public enum TypeOfEquipment { mobile, immobile }
    public abstract class Equipment
    {
        public string Name;
        public string Description;
        public float DistanceMovedTillDate;
        public float MaintenanceCost;
        public Equipment()
        {
            DistanceMovedTillDate = 0;
            MaintenanceCost = 0;
        }

        public void GetDetails()
        {
            Console.WriteLine("Enter the Name of the Equipment");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Description of Equipment");
            Description = Console.ReadLine();
        }

        public virtual void MoveBy(int distanceToMove)
        {

        }

        public void ShowDetails()
        {
            Console.WriteLine("=============================================================================");
            Console.WriteLine("\t\tName : {0}",Name);
            Console.WriteLine("\t\tDescription : {0}",Description);
            Console.WriteLine("\t\tDistance moved till date : {0} KM", DistanceMovedTillDate);
            Console.WriteLine("\t\tMaintenance cost : {0}/-Rs.",MaintenanceCost);
        }
    }
    public class Mobile : Equipment
    {
        public int NoOfWheels;
        public void GetMobileDetails()
        {
            Console.WriteLine("Enter No. of Wheels of Equipment");
            NoOfWheels = Convert.ToInt32(Console.ReadLine());
        }

        public override void MoveBy(int distanceToMove)
        {
            DistanceMovedTillDate += distanceToMove;
            MaintenanceCost = NoOfWheels * DistanceMovedTillDate;
        }
    }
    public class Immobile : Equipment
    {
        public float Weight;
        public void GetImmobileDetails()
        {
            Console.WriteLine("Enter Weight of immobile equipment");
            Weight = Convert.ToInt32(Console.ReadLine());
        }

        public override void MoveBy(int distanceToMove)
        {
            DistanceMovedTillDate += distanceToMove;
            MaintenanceCost = Weight * DistanceMovedTillDate;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter The Value 0 For Mobile Or 1 For Immobile ");
            int value = int.Parse(Console.ReadLine());
            if (value == (int)TypeOfEquipment.mobile)
            {
                Mobile m = new Mobile();
                m.GetDetails();
                m.GetMobileDetails();
                m.MoveBy(5);
                m.ShowDetails();
                Console.WriteLine("\t\tType of Equipment  : Mobile Equipemnt ");
            }
            else if (value == (int)TypeOfEquipment.immobile)
            {
                Immobile m = new Immobile();
                m.GetDetails();
                m.GetImmobileDetails();
                m.MoveBy(10);
                m.ShowDetails();
                Console.WriteLine("\t\tType of Equipment  : Immobile Equipemnt ");
            }
            else
            {
                Console.WriteLine("=============================================================================");
                Console.WriteLine("\tWrong Value Entered : Please Type 0 For Mobile And 1 For Immobile ");
            }
            Console.WriteLine("=============================================================================");
            Console.ReadLine();
        }
    }
}
