using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using P33.Course.Model;
using P33.Course.Model.Models;

namespace P33.Course.EFProject
{
    public class EFQueryAdvancedTest
    {
        public static void Show()
        {
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


        }



    }
}
