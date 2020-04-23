using P01.Course.DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using P01.Course.DB.MySql;



namespace P01.Course.Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //{
                //    Console.WriteLine("------------reflection--------------------");
                //    Console.WriteLine("---------common--------------");
                //    IDBHelper iDbHelper = new MySqlHelper();
                //    iDbHelper.Query();
                //}
                //{
                //    Console.WriteLine("------------reflection 1--------------------");
                //    Assembly a1 =   Assembly.Load("P01.Course.DB.MySql");//just dll name, find dll first then exe
                //    Assembly a2 = Assembly.LoadFile(
                //       @"C:\Users\adrian_sun\Source\Repos\ziqingyi\P02.Course.Attribute\P01.Course.Reflection\bin\Debug\P01.Course.DB.MySql.dll");
                //   // full path

                //   // load from current folder 
                //   Assembly a3 = Assembly.LoadFrom("P01.Course.DB.SqlServerHelper.dll"); 
                //   Assembly a4 = Assembly.LoadFrom(
                //       @"C:\Users\adrian_sun\Source\Repos\ziqingyi\P02.Course.Attribute\P01.Course.Reflection\bin\Debug\P01.Course.DB.SqlServerHelper.dll");
                //   foreach (var type in a1.GetTypes())
                //   {
                //       Console.WriteLine(type.Name);
                //       foreach (var method in type.GetMethods())
                //       {
                //           Console.WriteLine(method.Name);
                //       }
                //   }
                //}
                {
                    Console.WriteLine("------------reflection with create object--------------------");
                    Assembly a1 = Assembly.Load("P01.Course.DB.MySql"); // 1 load with Assembly
                    Type t = a1.GetType("P01.Course.DB.MySql.MySqlHelper"); // 2 get type

                    // create the object by the type, then three ways to call the query method. 

                    object o = Activator.CreateInstance(t);  // 3 createInstance
                    //((MySqlHelper2)o).Query();               //4 transfer and call method
                    ////() if o is not that class, it will through error: Unable to cast object  

                    dynamic odInstance = Activator.CreateInstance(t);  // 3 create Instance
                    odInstance.Query(); // bypass the compiler's check  // 4 call method

                    object oo= Activator.CreateInstance(t);    // 3 createInstance
                    IDBHelper iDbHelper = oo as MySqlHelper;  //4 transfer and call method
                    iDbHelper.Query();
                    // as will return null if not available.
                }
                {
                    Console.WriteLine("--------------Encapsulation----reflection + factory + config----------------");

                    IDBHelper iDbHelper =SimpleFactory.CreateInstance();
                    iDbHelper.Query();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            Console.ReadKey();
        }
    }
}
