using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P27.Course.IteratorPattern.Iterator;
using P27.Course.IteratorPattern.Menu;
using P27.Course.IteratorPattern.Show;

namespace P27.Course.IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            {
                PersonShow.Show();
            }

            {
                //KFC Menu is Array
                Console.WriteLine("**************kfc Show*************");
                KFCMenu kfcMenu = new KFCMenu();
                Food[] foodCollection = kfcMenu.GetFoods();

                for (int i = 0; i < foodCollection.Length; i++)
                {
                    Console.WriteLine("KFC: Id={0} Name={1} Price={2}", foodCollection[i].Id, foodCollection[i].Name, foodCollection[i].Price);
                }

                foreach (Food fd in foodCollection)
                {
                    Console.WriteLine("KFC: Id={0} Name={1} Price={2}", fd.Id, fd.Name, fd.Price);
                }

                Iiterator<Food> foodIterator = kfcMenu.GetEnumerator();

                while (foodIterator.MoveNext())
                {
                    Food food = foodIterator.Current;
                    Console.WriteLine("KFC: Id={0} Name={1} Price={2}", food.Id, food.Name, food.Price);
                }
            }

            {
                //MacDonald Menu is food List
                Console.WriteLine("**************MacDonald Show*************");
                MacDonaldMenu macDonaldMenu = new MacDonaldMenu();
                List<Food> foodCollection = macDonaldMenu.Getfoods();


                for (int i = 0; i < foodCollection.Count; i++)
                {
                    Console.WriteLine("MacDonald: Id={0} Name={1} Price={2}", foodCollection[i].Id, foodCollection[i].Name,foodCollection[i].Price);
                }


                foreach (Food item in foodCollection)
                {
                    Console.WriteLine("MacDonald: Id={0} Name={1} Price={2}", item.Id, item.Name, item.Price);
                }

                Iiterator<Food> foodIterator = macDonaldMenu.GetEnumerator();


                while (foodIterator.MoveNext())
                {
                    Food food = foodIterator.Current;
                    Console.WriteLine("MacDonald: Id={0} Name={1} Price={2}", food.Id, food.Name, food.Price);
                }


            }


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
