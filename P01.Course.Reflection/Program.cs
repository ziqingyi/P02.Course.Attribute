using P01.Course.DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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
