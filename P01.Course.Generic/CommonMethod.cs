using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Course.Generic
{
    public class CommonMethod
    {


        public static void Show<T>(T tParam)//, T t = default(T)
        {
            Console.WriteLine("This is {0}, parameter = {1}, type = {2}",
                typeof(CommonMethod), tParam.GetType().Name, tParam);
        }

    }
}
