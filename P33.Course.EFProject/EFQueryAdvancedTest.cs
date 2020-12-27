using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using P33.Course.Model;
using P33.Course.Model.Models;

namespace P33.Course.EFProject
{
    public class EFQueryAdvancedTest
    {
        public static void Show()
        {
            #region lazy loading and dbContext.
            IQueryable<User> source = null;
            using (JDDbContext dbContext = new JDDbContext())
            {
                source = dbContext.Set<User>().Where(u => u.Id > 20);//test scope

                // IQueryable implements IEnumerable, so when start to iterate, it will search in db. 
                var userList = dbContext.Set<User>().Where(u => u.Id > 0);
                userList = userList.Where(u => u.State < 3);
                userList = userList.OrderBy(u => u.Name);

                //1 LazyLoading.establish conn and get data when use,can filter out results efficiently ,occupy much resource. 
                //    so, if you use userList out of the scope, it will have error. 
                foreach (User u in userList)
                {
                    Console.WriteLine(u.Name);
                } //2 free up connection when finish

            }
            ////error
            //foreach (User u in source)
            //{
            //    Console.WriteLine(u.Name);
            //}
            #endregion


            #region  Lazy loading in  IEnumerable and IQueryable 
            {
                //1 data in memory 2 delegate (Func) 3 IEnumerator GetEnumerator();
                Console.WriteLine("*********IEnumerable************");

                List<int> intLIst = new List<int>(){ 123, 4354, 3, 23, 3, 4, 4, 34, 34, 3, 43, 43, 4, 34, 3 };
                var list = intLIst.Where(i =>
                {
                    Thread.Sleep(i);
                    return i > 10;
                });

                Console.WriteLine("**********IQueryable***********");
                //1 data in database 2 Expression tree  3 IQueryable has returned IQueryProvider Provider
                //this userList is a instance containing expression tree, result type, etc...
                //Expression tree can be assembled to sql and then execute. 
                using (JDDbContext dbContext = new JDDbContext())
                {
                    var userList = dbContext.Set<User>().Where(u => u.Id > 10);

                    foreach (var user in userList)
                    {
                        Console.WriteLine(user.Name);
                    }
                }

                Console.WriteLine("*********************");
            }
            #endregion

        }



    }
}
