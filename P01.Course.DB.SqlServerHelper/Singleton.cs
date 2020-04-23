using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Course.DB.SqlServer
{
    public sealed class Singleton
    {
        private static Singleton _singleton = null;

        private Singleton()
        {
            Console.WriteLine("private ");
        }
         static Singleton()//only call one time
        {
            _singleton = new Singleton();
        }


        public static Singleton GetInstance()
        {
            return _singleton;
        }



    }
}
