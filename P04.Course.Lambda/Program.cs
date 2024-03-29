﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace P04.Course.Lambda
{
    class Program
    {
        //lambda ---(shortcut)---> func ----extend method---->  linq (library)  -----enumerator(yield)---->
        static void Main(string[] args)
        {
            #region .net 3.0 anonymous class and delegate
            Console.WriteLine("Lambda and linq");
            {
                Console.WriteLine("***************Lambda*****************");
                LambdaShow lambdaShow = new LambdaShow();
                lambdaShow.Show();
            }

            {
                Console.WriteLine("****************anonymous class***************");
                Student student = new Student()
                {
                    Id = 1,
                    Name = "anonymous student",
                    Age = 25,
                    ClassId = 2
                };
                student.Study();

                //.net 3.0 strong type language need to determine the type when compile
                object mo = new
                {
                    Id = 1,
                    Name = "anonymous student",
                    Age = 25,
                    ClassId = 2
                    //teacher = "tom"
                };
                // Console.WriteLine(mo.Id); wrong 
                var vv = new
                {
                    Id = 1,
                    Name = "anonymous student",
                    Age = 25,
                    ClassId = 2
                };
                //local variable, `a , anonymous class. 
                //vv.Id = 2; //read only, cannot change after creation. 
                var tt = 1; //compiler will define the type of tt based on first assigned value. 
                            //var tti; //wrong  so it must have a value. 


                //.net 4.0  dynamic can avoid compiler. 
                dynamic dModel = new
                {
                    Id = 1,
                    Name = "anonymous student",
                    Age = 25,
                    ClassId = 2
                };
                //it doesn't have Study() method. 
                Console.WriteLine(dModel.Id + dModel.Name + " " + dModel.ClassId);


                //.net 3.0 extend method. 
                // 1 can be used in third party class, to add some method.
                // 2 if the class already have same name class, it will call the class's method. 
                // 3 So if the class is changed, it will has issue. 
                // 4 used for component in development, .netcore. the class is defined by min requirement.
                //   if you want to add more method, you can use extend method. 
                //    contex.Response.WriteAsync.   // middleware builder  use when 
                // 5 extend method which normally used. 
                ExtendMethod.StudyPractise(student);//normal way 
                student.StudyPractise();//because parameter has this

                int? i = 1;//test for 5 
                int ik = ExtendMethod.ToInt(i); //i.ToInt();
                ik = i.ToInt();

                string longtext = "adfakfkajflwjerjwqofjeqljldkfa".ToLength(20);//notice the 2nd param

                // 6 to Extend any class, but it will affect any type. 
                //   so normally don't USE extend method for T XXX without limitation in T. 
                i.ToStringCustt();
                student.ToStringCustt();
                object o = "";
                o.ToStringCustt();

                //test: Extend method used for object, not static class. 
                yyy yy = new yyy();
                Console.WriteLine(yy.ToStringCustt());

            }
            #endregion

            #region Linq
            LinqShow linq = new LinqShow();
            linq.Show();

            #endregion




        }
    }

    public static class iii
    {
        public static int Id { get; set; }
        public static string ClassName { get; set; }
    }
    public class yyy
    {
        public static int Id { get; set; }
        public static string ClassName { get; set; }
    }
}
