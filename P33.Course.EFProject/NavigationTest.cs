using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P33.Course.Model;
using P33.Course.Model.Models;

namespace P33.Course.EFProject
{
    public class NavigationTest
    {
        public static void ShowQuery()
        {
            //navigation attribute: 1 main table has sub table's collection
            // 2 sub table has one instance of main table
            using (JDDbContext dbContext = new JDDbContext())
            {
                var companyList = dbContext.Set<Company>().Where(c => c.Id < 20);
                foreach (Company cp in companyList) //find company only
                {
                    Console.WriteLine(cp.Name);
                    foreach (var user in cp.Users) //find users independently, so affect performance.
                    {
                        Console.WriteLine(user.Name);
                    }
                }
            }

            //disable lazy loading but load tables with Include() 
            using (JDDbContext dbContext = new JDDbContext())
            {
                //disable lazy loading, then cp cannot get users. cp.User will cause error.
                // so need to use Include to include users. the sql will get all one time, together.
                dbContext.Configuration.LazyLoadingEnabled = false;

                var companyList = dbContext.Set<Company>().Include("Users").Where(c => c.Id < 20);
                foreach (Company cp in companyList) //find company only
                {
                    Console.WriteLine(cp.Name);
                    foreach (var user in cp.Users) //find users
                    {
                        Console.WriteLine(user.Name);
                    }
                }
            }

            //disable lazy loading but load tables with Load(), this way can include table when you use it.
            using (JDDbContext dbContext = new JDDbContext())
            {

                dbContext.Configuration.LazyLoadingEnabled = false;

                var companyList = dbContext.Set<Company>().Where(c => c.Id < 20);
                foreach (Company cp in companyList) //find company only
                {
                    Console.WriteLine(cp.Name);

                    dbContext.Entry<Company>(cp).Collection(c => c.Users).Load();

                    foreach (var user in cp.Users) //find users
                    {
                        Console.WriteLine(user.Name);
                    }
                }
            }






        }
    }
}
