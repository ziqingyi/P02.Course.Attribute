using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P28.Course.Redis.Service;

namespace P28.Coures.MyRedis
{
    public class OversellTest
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
}
