using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P27.Course.IteratorPattern.Show;

namespace P27.Course.IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {





            {
                Console.WriteLine("***********yield show***********");
                YieldShow ys = new YieldShow();
                ys.Show();
            }

            {
                Console.WriteLine("***********CustomCollection***********");
                CustomCollection collection = new CustomCollection();
                List<int> intList = collection.GetData();
                for (int i = 0; i < intList.Count(); i++)
                {
                    Console.WriteLine(intList[i]);
                }
                Console.WriteLine("***********CustomCollection yield return ***********");
                foreach (int item in collection)
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}
