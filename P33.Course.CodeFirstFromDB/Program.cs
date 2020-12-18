using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P33.Course.CodeFirstFromDB
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                using (CodeFirstModel context = new CodeFirstModel())
                {
                    context.Database.Log += s => Console.WriteLine($"current running sql: {s}");


                    User user17 = context.Users.Find(17);

                    User user28 = context.Users.FirstOrDefault(u => u.Id == 28);

                    User userNew = new User()
                    {
                        Account = "Admin",
                        State = 0,
                        CompanyId = 4,
                        CompanyName = "CoCo",
                        CreateTime = DateTime.Now,
                        CreatorId = 1,
                        Email = "57265177@gmail.com",
                        LastLoginTime = null,
                        LastModifierId = 0,
                        LastModifyTime = DateTime.Now,
                        Mobile = "0256813881",
                        Name = "yoyo",
                        Password = "12356789",
                        UserType = 1
                    };

                    //add
                    context.Users.Add(userNew);
                    context.SaveChanges();//create a transaction and send query to db.

                    //change, change in object will go to database
                    userNew.Name = "CodeMan";
                    context.SaveChanges();

                    //remove
                    context.Users.Remove(userNew);
                    context.SaveChanges();




                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
