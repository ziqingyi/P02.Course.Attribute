using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P33.Course.Model;
using P33.Course.Model.Models;

namespace P33.Course.EFProject
{
    public class ContextLifetimeTest
    {
        public static void Show()
        {


            #region multi changes to data
            
            using (JDDbContext dbContext = new JDDbContext())
            {
                #region Set<T>() will return a instance of the give type.

                User user17 = dbContext.Users.FirstOrDefault(u => u.Id == 17);
                user17.Name += "aaa";

                User user18 = dbContext.Set<User>().Find(18);
                user18.Name += "bbb";

                //DbSet<User> dSet=  dbContext.Set<User>();
                //DbSet<User> d = dbContext.Users;

                //Execute and update all in database in one transaction
                //if error, roll over. Eg. the name length is too long for database.
                dbContext.SaveChanges();
                #endregion


                //1 db context use much memory, no cache
                //2 dbContext should not be shared by threads or whole process. 
                //3 cannot join different entities from different context. put in memory(list) first, then join.
                //4 each request/thread should use different context, and free up after use. 

                ////error
                //using (JDDbContext dbContext1 = new JDDbContext())
                //using (JDDbContext dbContext2 = new JDDbContext())
                //{
                //    var list = from u in dbContext1.Users
                //        join c in dbContext2.Companies on u.CompanyId equals c.Id
                //        where new int[] { 1, 2, 3, 4, 6, 7, 10 }.Contains(u.Id)
                //        select new
                //        {
                //            Account = u.Account,
                //            Pwd = u.Password,
                //            CompanyName = c.Name
                //        };
                //    foreach (var user in list)
                //    {
                //        Console.WriteLine("{0} {1}", user.Account, user.Pwd);
                //    }
                //}

                






            }





            #endregion




        }

    }
}
