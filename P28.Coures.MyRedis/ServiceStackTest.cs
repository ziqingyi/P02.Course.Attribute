using P28.Course.Redis.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
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
                    service.Set<string>("student1", "Tom Hanks");
                    Console.WriteLine(service.Get("student1"));

                    service.Append("student1", "20201110");
                    Console.WriteLine(service.Get("student1"));

                    //set new value and return old value
                    string getAndSet = service.GetAndSetValue("student1", "new value");
                    Console.WriteLine(service.Get("student1"));

                    service.Set<string>("student2", "steven jobs", DateTime.Now.AddSeconds(3));
                    Thread.Sleep(3000);
                    Console.WriteLine("student2 has value: "+ service.Get("student2"));

                    service.Set<int>("Age", 32);
                    Console.WriteLine(service.Incr("Age"));
                    Console.WriteLine(service.IncrBy("Age",3));
                    Console.WriteLine(service.Decr("Age"));
                    Console.WriteLine(service.DecrBy("Age",5));
                }
            }
            #endregion

            #region Redis Hash service
            {
                Console.WriteLine("*****************Redis Hash service************************");
                using (RedisHashService service = new RedisHashService())
                {
                    service.SetEntryInHash("student3", "id", "123456");
                    service.SetEntryInHash("student3", "name", "Tim Cook");
                    service.SetEntryInHash("student3", "remark", "Apple CEO");

                    List<string> keys = service.GetHashKeys("student3");
                    List<string> values = service.GetHashValues("student3");
                    Dictionary<string,string> keyValues = service.GetAllEntriesFromHash("student3");

                    Console.WriteLine(service.GetValueFromHash("student3", "id"));

                    bool res1 = service.SetEntryInHashIfNotExists("student3", "name", "john brown");
                    bool res2 = service.SetEntryInHashIfNotExists("student3", "description", "experienced CEO");

                    Console.WriteLine(service.GetValueFromHash("student3","name"));
                    Console.WriteLine(service.GetValueFromHash("student3","description"));//empty

                    bool res3 =service.RemoveEntryFromHash("student3", "description");
                    Console.WriteLine(service.GetValueFromHash("student3", "description"));

                }
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
