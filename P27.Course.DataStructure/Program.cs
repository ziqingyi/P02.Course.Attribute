using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P27.Course.DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                {
                    Console.WriteLine("***************Collection**************");
                    //CollectionDemo.Show();
                }
                {
                    Console.WriteLine("***************Dynamic**************");
                    DynamicDemo.Show();
                }
                {
                    #region Yield Demo
                    Console.WriteLine("*******************Yield Demo********************");
                    YieldDemo yieldDemo = new YieldDemo();
                    foreach (int intItem in yieldDemo.Power())
                    {
                        Console.WriteLine(intItem); //get one by one 
                        if (intItem > 100)
                        {
                            Console.WriteLine(intItem + " is larger than 100");
                            break;
                        }
                    }

                    Console.WriteLine("----------------------");
                    foreach (int intItem in yieldDemo.Common())
                    {
                        Console.WriteLine(intItem);  //get all
                        if (intItem > 100)
                        {
                            Console.WriteLine(intItem + " is larger than 100");
                            break;
                        }
                    }
                    #endregion
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

            Console.ReadKey();

        }
    }
}
