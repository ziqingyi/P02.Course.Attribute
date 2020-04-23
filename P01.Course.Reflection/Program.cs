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
                Console.WriteLine("------------reflection--------------------");
                {
                    Console.WriteLine("---------common--------------");
                    IDBHelper iDbHelper = new MySqlHelper();
                    iDbHelper.Query();
                }
                {
                   Assembly a1 =   Assembly.Load("P01.Course.DB.MySql");//just dll name, find dll first then exe
                   Assembly a2 = Assembly.LoadFile(
                       @"C:\Users\adrian_sun\Source\Repos\ziqingyi\P02.Course.Attribute\P01.Course.Reflection\bin\Debug\P01.Course.DB.MySql.dll");
                   // full path

                   // load from current folder 
                   Assembly a3 = Assembly.LoadFrom("P01.Course.DB.SqlServerHelper.dll"); 
                   Assembly a4 = Assembly.LoadFrom(
                       @"C:\Users\adrian_sun\Source\Repos\ziqingyi\P02.Course.Attribute\P01.Course.Reflection\bin\Debug\P01.Course.DB.SqlServerHelper.dll");
                   foreach (var type in a1.GetTypes())
                   {
                       Console.WriteLine(type.Name);
                       foreach (var method in type.GetMethods())
                       {
                           Console.WriteLine(method.Name);
                       }
                   }





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
