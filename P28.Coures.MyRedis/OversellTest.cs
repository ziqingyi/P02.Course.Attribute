using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using P28.Course.Redis.Service;

namespace P28.Coures.MyRedis
{
    public class OversellTestRedis
    {
        private static bool IsGoOn = true;
        public static void Show()
        {
            using (RedisStringService service = new RedisStringService())
            {
                service.Set<int>("Stock", 10);
            }

            for (int i = 0; i < 5000; i++)
            {
                int k = i;

                Action userRequestAction = () =>
                {
                    using (RedisStringService service = new RedisStringService())
                    {
                        if (IsGoOn)
                        {
                            //get-update-save stock in database. 
                            long index = service.Decr("Stock");//-1 and return result, stock left. 

                            if (index >= 0)
                            {
                                Console.WriteLine($"User {k.ToString("0000")} get the product with Index {index}");
                            }
                            else
                            {
                                if (IsGoOn)
                                {
                                    IsGoOn = false;
                                }

                                Console.WriteLine($"User {k.ToString("0000")} did not get the product, Index is {index}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"User {k.ToString("0000")} is late...");
                        }
                    }
                };

                //start the buy action 
                Task.Run(userRequestAction);
                
            }
            Console.Read();

        }
    }


    public class OversellTestWrong
    {
        private static bool IsGoOn = true;
        private static int Stock = 0;
        public static void Show()
        {
            Stock = 10;

            for (int i = 0; i < 5000; i++)
            {
                int k = i;

                Action userRequestAction = () =>
                {

                    if (IsGoOn)
                    {
                        #region simulate updaing in database, take some time.
                        //get-update-save stock in parameter, not thread safe . 
                        long index = Stock - 1;//-1 and return result, stock left. 
                        Thread.Sleep(100);
                        #endregion


                        if (index >= 0)
                        {
                            Stock = Stock - 1;
                            Console.WriteLine($"User {k.ToString("0000")} get the product with Index {index}");
                        }
                        else
                        {
                            if (IsGoOn)
                            {
                                IsGoOn = false;
                            }

                            Console.WriteLine($"User {k.ToString("0000")} did not get the product, Index is {index}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"User {k.ToString("0000")} is late...");
                    }

                };

                //start the buy action 
                Task.Run(userRequestAction);

            }
            Console.Read();

        }
    }





    public class OversellTestVolatile
    {
        private static bool IsGoOn = true;

        private static readonly object _lock = new object();

        private static volatile int Stock = 0;
        public static void Show()
        {
            Stock = 10; //initial stock

            for (int i = 0; i < 5000; i++)
            {
                int k = i;

                Action userRequestAction = () =>
                {
                    string tid = Thread.CurrentThread.ManagedThreadId.ToString();

                    long index = -2;
                    if (IsGoOn)
                    {
                        #region simulate updaing in database, take some time.
                        //get-update-save stock in parameter, using lock for thread safety . 
                        lock (_lock)
                        {
                            index = Stock - 1;//-1 and return result, stock left. 
                            Thread.Sleep(100);
                            
                            //only the thread who get 0 or positive index can update stock. 
                            //checking and updating should be locked otherwise no oversell but index will duplicate
                            if (index >= 0) 
                            {
                                Stock = Stock - 1;
                                Console.WriteLine($"User {k.ToString("0000")} get the product with Index {index} in thread: {tid}");
                            }

                        }
                        #endregion

                        if (index < 0) 
                        {
                            if (IsGoOn)
                            {
                                IsGoOn = false;
                            }
                            Console.WriteLine($"User {k.ToString("0000")} did not get the product, Index is {index} in thread: {tid}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"User {k.ToString("0000")} is late... in thread: {tid}");
                    }

                };

                //start the buy action 
                Task.Run(userRequestAction);

            }
            Console.Read();

        }
    }





}
