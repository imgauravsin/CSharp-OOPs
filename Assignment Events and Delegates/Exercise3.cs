using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Exersice_3
{
    class Handler
    {
        public ObservableCollection<int> Collection;

        public Handler()
        {
            Collection = new ObservableCollection<int>();
            Collection.CollectionChanged += HandleChange;
        }
        private void HandleChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine($"\t\t\t{Collection[Collection.Count - 1]} is Added to Our Collection");
                Console.WriteLine("\t\t**************************************************");
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine($"\t\t\t{e.OldItems[0]} is removed from Our Collection");
                Console.WriteLine("\t\t**************************************************");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Handler handler = new Handler();
            Console.WriteLine();
            Console.WriteLine("\t\t**************************************************");
            handler.Collection.Add(101);
            handler.Collection.Add(102);
            handler.Collection.Add(103);
            handler.Collection.Remove(102);
            handler.Collection.Remove(101);
            Console.WriteLine("\t\t**************************************************");
            Console.ReadLine();
        }
    }
}
