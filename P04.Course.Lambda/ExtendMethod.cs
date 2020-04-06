using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P04.Course.Lambda
{
    //Extend method: static method in static class, 
    public static class ExtendMethod
    {
        #region for Linq
        //condition should be passed by delegate 
        public static List<Student> ExtendWhere(this List<Student> resource,Func<Student,bool> func)
        {
            //normal way
            var list = new List<Student>();
            foreach (var item in resource)
            {
                //if (item.Age < 30
                 //   && item.Name.Length > 2)
                 if(func.Invoke(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }
        #endregion

        #region for Linq for generic
        //condition should be passed by delegate 
        public static List<T> ExtendWhereT<T>(this List<T> resource, Func<T, bool> func)
        {
            var list = new List<T>();
            foreach (var item in resource)
            {
                Console.WriteLine(" data check T-------------");
                Thread.Sleep(100);
                if (func.Invoke(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }
        #endregion

        #region for Linq for Iterator
        //condition should be passed by delegate 
        public static IEnumerable<T> ExtendWhereTIterator<T>(this IEnumerable<T> resource, Func<T, bool> func)
        {
            
            foreach (var item in resource)
            {
                Console.WriteLine(" data check Iterator-------------");
                Thread.Sleep(100);
                if (func.Invoke(item))
                {
                    yield return item;
                }
            }
            
        }
        #endregion




        #region for delegate
        //if first param has this, stu.StudyPractise() can be used. //
        public static void StudyPractise(this Student stu)
        {
            Console.WriteLine("{0} {1} is studying and practice.......extend method", stu.Id, stu.Name);
        }

        public static int ToInt(this int? i)
        {
            return i ?? 0;
        }

        public static string ToLength(this string text, int length = 15)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }
            else if (text.Length > length)
            {
                return $"{text.Substring(0, length)} .....";
            }
            else
            {
                return text;
            }
        }
        // for any object 
        public static string ToStringCustt<T>(this T t)
        {
            if (t is Guid)
            {
                return t.ToString().Replace("-", "");
            }
            //else.....
            else
            {
                return t.ToString();
            }
        }

        #endregion



    }
}
