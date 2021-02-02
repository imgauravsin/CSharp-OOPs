using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo info = new DirectoryInfo(@"C:\Users\gauravsingh03\Desktop\Nagarro");
            FileInfo[] files = info.GetFiles("*"); //Getting all files

            //Getting text files
            FileInfo[] textFiles = info.GetFiles("*.txt");
            Console.WriteLine($"\ttext files in Directory :{textFiles.Length}");

            // Getting number of files each extension type
            Dictionary<string, int> fileDictionary = new Dictionary<string, int>();
            foreach (FileInfo file in files)
            {
                string[] arr = file.Name.Split('.');
                try
                {
                    fileDictionary[arr[1]] += 1;
                }
                catch (Exception e)
                {
                    fileDictionary.Add(arr[1], 1);
                }
            }
            foreach (var i in fileDictionary)
            {
                Console.WriteLine($"\tNumber of files per extension type: {i.Key} :  {i.Value}");

            }

            // Getting 5 largest files
            var sizeofArray = from a in files
                              orderby a.Length descending
                              select a;
            int j = 0;
            foreach (var file in sizeofArray)
            {
                j++;
                if (j > 5)
                {
                    break;
                }
                Console.WriteLine($"\n\tFile Name : {file.Name} \n\tFile Size : {file.Length}");
            }

            // Getting file with maximum length
            foreach (var file in sizeofArray)
            {
                Console.WriteLine($"\tFile : {file.Name} s with maximum length  : {file.Length}");
                break;
            }
            Console.ReadLine();
        }
    }
}
