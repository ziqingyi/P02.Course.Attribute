using P28.Course.Redis.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P28.Coures.MyRedis
{
    public class ServiceStackTest
    {

        public static void Show()
        {
            Student student_1 = new Student()
            {
                Id = 1,
                Name = "S1",
                Description = "the student from USA",
                Remark = "7656577567"
            };
            Student student_2 = new Student()
            {
                Id = 2,
                Name = "S2",
                Description = "the student from Australia",
                Remark = "123423245"
            };

            #region Redis String service
            { 
                Console.WriteLine("*****************Redis String service************************");
                using (RedisStringService service = new RedisStringService())
                {
                    service.Set<string>("student1", "Tom Tom");
                    Console.WriteLine(service.Get("student1"));

                }


            }

            #endregion

            #region Redis Hash service
            {
                Console.WriteLine("*****************Redis Hash service************************");




            }

            #endregion


            #region Redis Set service
            {
                Console.WriteLine("*****************Redis Set service************************");




            }

            #endregion



            #region Redis ZSet service
            {
                Console.WriteLine("*****************Redis ZSet service************************");




            }

            #endregion



            #region Redis List service
            {
                Console.WriteLine("*****************Redis List service************************");




            }

            #endregion

        }












    }
}
