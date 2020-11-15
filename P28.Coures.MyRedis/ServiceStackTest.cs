using P28.Course.Redis.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceStack.Redis;

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
                using (RedisSetService service = new RedisSetService())
                {
                    service.FlushAll();
                    service.Add("advanced", "111");
                    service.Add("advanced", "112");
                    service.Add("advanced", "113");
                    service.Add("advanced", "114");
                    service.Add("advanced", "115");
                    service.Add("advanced", "115");
                    service.Add("advanced", "113");

                    HashSet<string> result = service.GetAllItemsFromSet("advanced");

                    string random = service.GetRandomItemFromSet("advanced"); //random item

                    long total = service.GetCount("advanced");

                    service.RemoveItemFromSet("advanced","114");

                    {
                        service.Add("begin", "111");
                        service.Add("begin", "112");
                        service.Add("begin", "115");

                        service.Add("end", "111");
                        service.Add("end", "114");
                        service.Add("end", "113");

                        HashSet<string> res1 = service.GetIntersectFromSets("begin", "end");
                        HashSet<string> res2 = service.GetDifferencesFromSet("begin", "end");
                        HashSet<string> res3 = service.GetUnionFromSets("begin", "end");
                    }
                }
            }
            #endregion



            #region Redis ZSet service
            {
                Console.WriteLine("*****************Redis ZSet service************************");
                using (RedisZSetService service = new RedisZSetService())
                {
                    service.FlushAll();
                    service.Add("advanced", "1");
                    service.Add("advanced", "2");
                    service.Add("advanced", "5");
                    service.Add("advanced", "4");
                    service.Add("advanced", "7");
                    service.Add("advanced", "5");
                    service.Add("advanced", "9");

                    List<string> res1 = service.GetAll("advanced");
                    List<string> res2 = service.GetAllDesc("advanced");

                    service.AddItemToSortedSet("Sort", "stu1", 77);
                    service.AddItemToSortedSet("Sort", "stu2", 99);
                    service.AddItemToSortedSet("Sort", "stu3", 88);
                    service.AddItemToSortedSet("Sort", "stu4", 80);
                    service.AddItemToSortedSet("Sort", "stu5", 90);
                    //add multi with same store.
                    service.AddRangeToSortedSet("Sort", new List<string>() {"Gstu1", "Gstu2", "Gstu3" },98);


                    IDictionary<string, double> res3 = service.GetAllWithScoresFromSortedSet("Sort");
                }


            }

            #endregion



            #region Redis List service
            {
                Console.WriteLine("*****************Redis List service************************");
                using (RedisListService service = new RedisListService())
                {
                    service.FlushAll();

                    service.Add("author1","story1");
                    service.Add("author1","story2");
                    service.Add("author1","story3");
                    service.Add("author1","story4");
                    service.Add("author1","story5");
                    service.Add("author1","story6");
                    service.Add("author1","story6");


                    List<string> get1 = service.Get("author1");//get 7 items, list have same value
                    List<string> get2 = service.Get("author1", 0,3);//story 1,2,3,4
                    string popAtEnd1 = service.PopItemFromList("author1");//pop from end, story6

                    //lpush, like stack, FILO
                    service.LPush("author2", "story1");//begin, on left, on top
                    service.LPush("author2", "story2");
                    service.LPush("author2", "story3");
                    service.LPush("author2", "story4");
                    service.LPush("author2", "story5");
                    service.LPush("author2", "story6");
                    service.LPush("author2", "story6");// end, right

                    for (int i = 0; i < 6; i++)
                    { 
                        //this is lpop, pop out from end. so story6 is popped out, removed from list. 
                        string popAtEnd2 = service.PopItemFromList("author2");
                        Console.WriteLine(popAtEnd2);
                        List<string> tempAll = service.Get("author2");
                    }

                    //use rpush to simulate queue: producer and consumer, FIFO

                    service.RPush("author3", "story1");//at the end 
                    service.RPush("author3", "story2");
                    service.RPush("author3", "story3");
                    service.RPush("author3", "story4");
                    service.RPush("author3", "story5");
                    service.RPush("author3", "story6");
                    service.RPush("author3", "story6");//at the top

                    for (int i = 0; i < 5; i++)
                    {
                        string popAtEnd3 = service.PopItemFromList("author3");
                        Console.WriteLine(popAtEnd3);//lpop out story1, FIFO
                        List<string> tempAll = service.Get("author3");
                    }
                }
            }
            #endregion


            #region Producer-Consumer problem  
            {
                Console.WriteLine("*****************Producer-Consumer problem ************************");
                using (RedisListService service = new RedisListService())
                {
                    service.FlushAll();

                    List<string> stringList = new List<string>();
                    for (int i = 0; i < 10; i++)
                    {
                        stringList.Add(string.Format($"task number: {i}"));
                    }

                    service.Add("student","student_Add1");//after student_RPush1
                    service.Add("student","student_Add2");
                    service.Add("student","student_Add3");

                    service.LPush("student", "student_LPush1");
                    service.LPush("student", "student_LPush2");
                    service.LPush("student", "student_LPush3");
                    service.LPush("student", "student_LPush4");
                    service.LPush("student", "student_LPush5");
                    service.LPush("student", "student_LPush6");//last one

                    service.RPush("student", "student_RPush1");
                    service.RPush("student", "student_RPush2");
                    service.RPush("student", "student_RPush3");
                    service.RPush("student", "student_RPush4");
                    service.RPush("student", "student_RPush5");
                    service.RPush("student", "student_RPush6");//first one

                    service.Add("task", stringList);

                    Console.WriteLine(service.Count("student"));//15

                    Console.WriteLine(service.Count("task"));//10

                    Action act = new Action(() =>
                    {
                        while (true)
                        {
                            //add to 
                            Console.WriteLine("*******Please type in: *******");
                            string testTask = Console.ReadLine();
                            if (testTask != "exit")
                            {
                                service.LPush("test", testTask);
                            }
                            else
                            {
                                break;
                            }
                            
                        }
                    });

                    act.EndInvoke(act.BeginInvoke(null,null));



                    service.FlushAll();
                }
            }
            #endregion


            #region Publisher-Subscribers, one data source and multiple receivers. 
            {
                Console.WriteLine("*****************Publisher-Subscribers************************");

                Task.Run(() =>
                {
                    string id = Thread.CurrentThread.ManagedThreadId.ToString();

                    using (RedisListService service = new RedisListService())
                    {
                        Action<string, string, IRedisSubscription> registerAction = (c, message, iRedisSubscription) =>
                        {
                            Console.WriteLine($"register {1} channel: {c} message: {message}, doing something else in thread {id}");
                            if (message.Equals("exit"))
                            {
                                iRedisSubscription.UnSubscribeFromChannels("Eleven");
                            }
                        };

                        service.Subscribe("Eleven", registerAction);
                    }
                });

                Task.Run(() =>
                {
                    string id = Thread.CurrentThread.ManagedThreadId.ToString();
                    using (RedisListService service = new RedisListService())
                    {
                        Action<string, string, IRedisSubscription> registerAction = (c, message, iRedisSubscription) =>
                        {
                            Console.WriteLine($"register {2} channel: {c} message: {message}, doing something else in thread {id}");
                            if (message.Equals("exit"))
                            {
                                iRedisSubscription.UnSubscribeFromChannels("Eleven");
                            }
                        };

                        service.Subscribe("Eleven", registerAction);
                    }

                });

                Task.Run(() =>
                {
                    string id = Thread.CurrentThread.ManagedThreadId.ToString();
                    using (RedisListService service = new RedisListService())
                    {
                        Action<string, string, IRedisSubscription> registerAction = (c, message, iRedisSubscription) =>
                        {
                            Console.WriteLine($"register {3} channel: {c} message: {message}, doing something else in thread {id}");
                            if (message.Equals("exit"))
                            {
                                iRedisSubscription.UnSubscribeFromChannels("Twelve");
                            }
                        };

                        service.Subscribe("Twelve", registerAction);
                    }
                });

                using (RedisListService service = new RedisListService())
                {
                    
                    service.Publish("Eleven", "Eleven_Message1");
                    service.Publish("Eleven", "Eleven_Message2");
                    service.Publish("Eleven", "Eleven_Message3");
                    service.Publish("Eleven", "Eleven_Message4");

                    service.Publish("Twelve", "Twelve_Message1");
                    service.Publish("Twelve", "Twelve_Message2");
                    service.Publish("Twelve", "Twelve_Message3");
                    service.Publish("Twelve", "Twelve_Message4");

                    Console.WriteLine("**********************************************");

                    service.Publish("Eleven","exit");

                    service.Publish("Eleven", "Eleven_Message5");
                    service.Publish("Eleven", "Eleven_Message6");
                    service.Publish("Eleven", "Eleven_Message7");
                    service.Publish("Eleven", "Eleven_Message8");

                    service.Publish("Twelve","exit");
                    service.Publish("Twelve", "Twelve_Message5");
                    service.Publish("Twelve", "Twelve_Message6");
                    service.Publish("Twelve", "Twelve_Message7");
                    service.Publish("Twelve", "Twelve_Message8");

                }


            }
            #endregion
            
        }


    }
}
