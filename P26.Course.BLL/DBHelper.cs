using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P26.Course.BLL
{
    public class DBHelper
    {
        //1 task that takes some time to execute
        //2 same param with same result
        public static List<T> Query<T>(int index)
        {
            Console.WriteLine("This is {0} Query", typeof(DBHelper));
            long lResult = 0;
            for (int i = index; i < 1000000000; i++)
            {
                lResult += i;
            }

            List<T> tList = new List<T>();

            for (int i = 0; i < index%3; i++)
            {
                tList.Add(default(T));
            }

            return tList;
        }


    }
}
