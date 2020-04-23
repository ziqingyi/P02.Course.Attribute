using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using P01.Course.DB.Interface;
using P01.Course.DB.MySql;

namespace P01.Course.Reflection
{
    public class SimpleFactory
    {
        //only read one time for this string.
        private static string IDBHelperConfig = ConfigurationManager.AppSettings["IDBHelperConfig"];
        private static string DllName = IDBHelperConfig.Split(',')[1];
        private static string TypeName = IDBHelperConfig.Split(',')[0];

        public static IDBHelper CreateInstance()
        {
            Assembly a1 = Assembly.Load(DllName); // 1 load with Assembly
            Type t = a1.GetType(TypeName); // 2 get type

            object oo = Activator.CreateInstance(t);    // 3 createInstance
            IDBHelper iDbHelper = oo as IDBHelper;  //4 transfer and call method

            return iDbHelper;
        }


    }
}
