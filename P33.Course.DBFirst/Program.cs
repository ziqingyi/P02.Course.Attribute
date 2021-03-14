using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P33.Course.DBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            BatchTest();

            CRUDtests();
            
        }

        public static void BatchTest()
        {
            using (advanced7Entities contextEntity = new advanced7Entities())
            {
                contextEntity.Database.Log += s => Console.WriteLine($"current running sql: {s}");

                #region Batch

                List<User> list = contextEntity.Users
                    .Where(m => m.UserType == 2)
                    .OrderByDescending(m=>m.Id)
                    .ToList();
                foreach (User u in list)
                {
                    u.UserType = u.Id % 3;
                }

                if (contextEntity.SaveChanges()>0)
                {
                    Console.WriteLine("update successfully");
                }


                #endregion






            }


        }


        public static void CRUDtests()
        {
            try
            {
                using (advanced7Entities context = new advanced7Entities())
                {
                    context.Database.Log += s => Console.WriteLine($"current running sql: {s}");

                    #region Search
                    User user17 = context.Users.Find(17);
                    User user28 = context.Users.FirstOrDefault(u => u.Id == 28);
                    #endregion

                    #region Add

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

                    //add by reference and save
                    var addU = context.Users.Add(userNew);//id is 0 at now

                    var AddRes = context.SaveChanges();//create a transaction and send query to db.

                    if (AddRes > 0)//user id is updated by dbcontext with new value
                    {
                        Console.WriteLine("add successfully..");
                    }

                    #endregion



                    #region update

                    //change, change in object will go to database
                    //search and find the reference first

                    User updateU = context.Users.FirstOrDefault(m => m.Id == userNew.Id);

                    updateU.Name = "CodeMan";

                    var updateRes = context.SaveChanges();

                    if (updateRes > 0)
                    {
                        Console.WriteLine("update successfully..");
                    }
                    #endregion



                    #region Remove

                    //1 remove by object reference
                    //search and find the reference first
                    User uToDelete = context.Users.Single(m => m.Id == userNew.Id);

                    var remU = context.Users.Remove(uToDelete);
                    var remRes = context.SaveChanges();

                    if (remRes > 0)
                    {
                        Console.WriteLine("remove successfully..");
                    }
                    #endregion




                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }





    }
}
