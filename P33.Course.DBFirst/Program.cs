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

            try
            {
                using (advanced7Entities context = new advanced7Entities())
                {
                    context.Database.Log += s => Console.WriteLine($"current running sql: {s}");

                    #region Search
                    User user17= context.Users.Find(17);
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
                    var addu = context.Users.Add(userNew);
                    
                    var AddRes = context.SaveChanges();//create a transaction and send query to db.


                    #endregion



                    #region update

                    //change, change in object will go to database
                    userNew.Name = "CodeMan";
                    var objChangeRes = context.SaveChanges();
                    
                    #endregion



                    #region Remove

                    //1 remove by object reference
                    //search and find the reference first
                    User uToDelete = context.Users.Single(m => m.Id == userNew.Id);

                    var remRes = context.Users.Remove(uToDelete);
                    context.SaveChanges();


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
