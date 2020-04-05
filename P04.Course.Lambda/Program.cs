using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.Course.Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Lambda and linq");
            //{
            //    Console.WriteLine("***************Lambda*****************");
            //    LambdaShow lambdaShow = new LambdaShow();
            //    lambdaShow.Show();
            //}

            #region 3.0出了个匿名类 var

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
                Console.WriteLine(dModel.id+ dModel.Name +" " + dModel.ClassId);
                

                //.net 3.0 extend method. 



            }

            #endregion


        }
    }
}
