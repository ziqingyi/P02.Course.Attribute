using P01.Course.DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using P01.Course.DB.MySql;
using P01.Course.DB.SqlServer;


namespace P01.Course.Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Console.WriteLine("------------reflection------read the metadata of the dll or exe--------------");
                // reflection is to read the metadata of the dll or exe
                // pdb program debug base : used for debug 
                //reference is to copy the project when debug. but you need to copy all project referred by the project. 
                //{
                //    Console.WriteLine("---------common--------------");
                //    IDBHelper iDbHelper = new MySqlHelper();
                //    iDbHelper.Query();
                //}
                //{
                //    Console.WriteLine("------------reflection 1--------------------");
                //    Assembly a1 =   Assembly.Load("P01.Course.DB.MySql");//just dll name, find dll first then exe
                //   Assembly a2 = Assembly.LoadFile(
                //       @"C:\Users\adrian_sun\Source\Repos\ziqingyi\P02.Course.Attribute\P01.Course.Reflection\bin\Debug\P01.Course.DB.MySql.dll");
                //   // full path

                //   // load from current folder 
                //   Assembly a3 = Assembly.LoadFrom("P01.Course.DB.SqlServer.dll"); 
                //   Assembly a4 = Assembly.LoadFrom(
                //       @"C:\Users\adrian_sun\Source\Repos\ziqingyi\P02.Course.Attribute\P01.Course.Reflection\bin\Debug\P01.Course.DB.SqlServer.dll");
                //   foreach (var type in a1.GetTypes())
                //   {
                //       Console.WriteLine(type.Name);
                //       type.IsGenericType()// check whether it is generic type
                //       foreach (var method in type.GetMethods())
                //       {
                //           Console.WriteLine(method.Name);
                //       }
                //   }
                //}
                //{
                //    Console.WriteLine("------------reflection with create object--------------------");
                //    Assembly a1 = Assembly.Load("P01.Course.DB.MySql"); // 1 load with Assembly
                //    Type t = a1.GetType("P01.Course.DB.MySql.MySqlHelper"); // 2 get type

                //    // create the object by the type, then three ways to call the query method. 

                //    object o = Activator.CreateInstance(t);  // 3 createInstance
                //    //((MySqlHelper2)o).Query();               //4 transfer and call method
                //    ////() if o is not that class, it will through error: Unable to cast object  

                //    dynamic odInstance = Activator.CreateInstance(t);  // 3 create Instance
                //    odInstance.Query(); // bypass the compiler's check  // 4 call method

                //    object oo= Activator.CreateInstance(t);    // 3 createInstance
                //    IDBHelper iDbHelper = oo as MySqlHelper;  //4 transfer and call method
                //    iDbHelper.Query();
                //    // as will return null if not available.
                //}
                //{
                //    Console.WriteLine("--------------Encapsulation----reflection + factory + config----------------");

                //    IDBHelper iDbHelper =SimpleFactory.CreateInstance();
                //    iDbHelper.Query();
                //}
                //{
                //    Console.WriteLine("--------------create singleton, only one object--------------------");
                //    Singleton s1 = Singleton.GetInstance();
                //    Singleton s2 = Singleton.GetInstance();
                //    Console.WriteLine(object.ReferenceEquals(s1, s2));
                //}
                //{
                //    Console.WriteLine("------reflection to use private constructor-----------------");
                //    Assembly a1 = Assembly.Load("P01.Course.DB.SqlServer");
                //    Type t = a1.GetType("P01.Course.DB.SqlServer.Singleton");
                //    Singleton s1 =  Activator.CreateInstance(t,true) as Singleton;//will call two times of private constructor

                //    Singleton s2 = Activator.CreateInstance(t, true) as Singleton;// call private constructor once 
                //}
                {
                    Console.WriteLine("------------reflection and generic--------------------------");
                    Assembly a1 = Assembly.Load("P01.Course.DB.SqlServer");
                    Type t = a1.GetType("P01.Course.DB.SqlServer.GenericClass`3");
                    //must notice `3
                    Type typeMake = t.MakeGenericType(new Type[]{typeof(String), typeof(int),typeof(DateTime)});
                    // make generic type first, then you can create object.
                    object oGeneric = Activator.CreateInstance(typeMake);

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
