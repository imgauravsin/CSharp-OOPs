using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersice_2
{
    class EventHandler
    {
        // Delegate
        public delegate void inventoryUpdateEventHandler(object source, InventoryUpdateEventArgs e);
        // Event Handler
        public event inventoryUpdateEventHandler valueChange;

        public void ForValueChange(float change)
        {
            InventoryUpdateEventArgs instruction = new InventoryUpdateEventArgs();
            instruction.totalValueChange = change;
            EventSubscriber priceUpdater = new EventSubscriber();
            valueChange += priceUpdater.onChangeRequest;
            if (valueChange != null)
            {
                valueChange(this, instruction);
            }
        }
    }
    //class for Product 
    class Product : IEquatable<Product>
    {
        public int Id;
        public float Price;
        public bool IsDefective;

        public Product(int id, float price, bool isDefective)
        {
            this.Id = id;
            this.Price = price;
            this.IsDefective = isDefective;
        }

        public bool Equals(Product p)
        {

            if (Id == p.Id)
            {
                return true;
            }
            return false;
        }
    }
    //Class Inventory 

    class Inventory
    {
        public static Dictionary<Product, int> inventoryDictionary = new Dictionary<Product, int>();
        public static float TotalValue;

        // Adds a product to the product inventory.

        public void AddProduct(Product product_)
        {
            bool found = false;
            foreach (var item in inventoryDictionary.ToList())
            {
                if (item.Key.Equals(product_))
                {
                    found = true;
                    if (item.Key.Price == product_.Price && item.Key.IsDefective == product_.IsDefective)
                    {
                        inventoryDictionary[item.Key] += 1;
                        Console.WriteLine("\t\tIncreased count of Already existing In Our List .....Now Update The first Value");
                        EventHandler change = new EventHandler();
                        change.ForValueChange(product_.Price);//fire event for total value update
                    }
                    else if (item.Key.Price != product_.Price)
                    {
                        //if price different then remove product key and add key with updated price
                        inventoryDictionary.Remove(item.Key);

                        Product ModifiedProduct = new Product(item.Key.Id, product_.Price, item.Key.IsDefective);


                        inventoryDictionary.Add(ModifiedProduct, item.Value + 1);
                        Console.WriteLine("\t\tPrice of Product Updated In List ......");
                        EventHandler change = new EventHandler();
                        change.ForValueChange((product_.Price - item.Key.Price) * item.Value + product_.Price);
                    }
                    else if (product_.IsDefective == true)
                    {

                        //if defective then remove
                        RemoveProduct(item.Key);
                    }
                }
            }
            if (!found)
            {   //if not in dictionary then add for the first time
                inventoryDictionary.Add(product_, 1);
                Console.WriteLine("\t\tThe Object Added to List First Time ...");
                EventHandler change = new EventHandler();
                change.ForValueChange(product_.Price);
            }

        }
        public void RemoveProduct(Product p)
        {
            Console.WriteLine("\t\t************Product is Removed ************ ");
            EventHandler change = new EventHandler();
            change.ForValueChange(-1 * (p.Price) * inventoryDictionary[p]);//reduce by price*quantity
            inventoryDictionary.Remove(p);

        }

        public void update(Product p, int quantity)
        {
            Console.WriteLine("\t\t*******Updated Product Quantity************");
            inventoryDictionary[p] += quantity;
            EventHandler change = new EventHandler();
            change.ForValueChange(p.Price * quantity);//increase by price*quantityIncreased
        }
    }
    class InventoryUpdateEventArgs
    {
        public float totalValueChange;
    }
    class EventSubscriber
    {
        public void onChangeRequest(object source, InventoryUpdateEventArgs e)
        {
            Inventory.TotalValue += e.totalValueChange;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Inventory sampleInventory = new Inventory();
            Product Product1 = new Product(101, 100, false);
            sampleInventory.AddProduct(Product1);
            Console.WriteLine($"\t\tNow Total value is : {Inventory.TotalValue}");
            Console.WriteLine("\t\t********************************************");
            Console.WriteLine();

            Product Product2 = new Product(102, 15, false);
            sampleInventory.AddProduct(Product2);
            Console.WriteLine($"\t\tNow Total value is : {Inventory.TotalValue}");
            Console.WriteLine("\t\t********************************************");
            Console.WriteLine();

            Product Product3 = new Product(101, 100, false);
            sampleInventory.AddProduct(Product3);//added same product again..total value  gets updated
            Console.WriteLine($"\t\tNow Total value is : {Inventory.TotalValue}");
            Console.WriteLine("\t\t********************************************");
            Console.WriteLine();

            Product Product4 = new Product(101, 160, false);
            sampleInventory.AddProduct(Product4);//added same product again..total value  gets updated
            Console.WriteLine($"\t\tNow Total value is : {Inventory.TotalValue}");
            Console.WriteLine("\t\t********************************************");
            Console.WriteLine();

            Product Product5 = new Product(101, 120, false);
            sampleInventory.AddProduct(Product5); //same id but different price..prod and total value get updated.
            Console.WriteLine($"\t\tNow Total value is : {Inventory.TotalValue}");
            Console.WriteLine("\t\t********************************************");
            Console.WriteLine();

            Product Product6 = new Product(101, 120, true);
            sampleInventory.AddProduct(Product6);//product is defective remove and update total value..
            Console.WriteLine($"\t\tNow Total value is : {Inventory.TotalValue}");
            Console.WriteLine();

            sampleInventory.update(Product2, 3); //quantity for p2 updated
            Console.WriteLine($"\t\tNow Total value is : {Inventory.TotalValue}");
            Console.WriteLine("\t\t********************************************");
            Console.WriteLine();

            sampleInventory.RemoveProduct(Product2);
            Console.WriteLine($"\t\tNow Total value is : {Inventory.TotalValue}");
            Console.WriteLine("\t\t********************************************");
            Console.ReadLine();
        }
        
    }
}
