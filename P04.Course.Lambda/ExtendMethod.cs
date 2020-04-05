﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.Course.Lambda
{
    //Extend method: static method in static class, 
    public static class ExtendMethod
    {
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
        public static string ToStringCust<T>(this T t)
        {
            if (t is Guid)
            {
                return t.ToString().Replace("-","");
            }
            //else.....
            else
            {
                return t.ToString();
            }


        }


    }
}
