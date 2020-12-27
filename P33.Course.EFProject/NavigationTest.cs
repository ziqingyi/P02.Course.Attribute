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


            //navigate without reference keys
            using (JDDbContext dbContext = new JDDbContext())
            {
                var list = dbContext.Set<SysRoleMenuMapping>().Where(m => m.Id > 5);
                foreach (var mapping in list)
                {
                    Console.WriteLine($"{mapping.Id}----{mapping.SysRoleId}----{mapping.SysMenuId}");

                    Console.WriteLine(mapping.SysMenu.Text);

                    Console.WriteLine(mapping.SysRole.Text);

                    foreach (var m in mapping.SysMenu.SysRoleMenuMappingList)
                    {
                        Console.WriteLine($"{m.Id}----{m.SysRoleId}----{m.SysMenuId}");
                    }
                }
            }
        }

        public static void ShowInsert()
        {
            using (JDDbContext dbContext = new JDDbContext())
            {
                #region company and user data
                Company company = new Company()
                {
                    Name = "testCompany15",
                    CreateTime = DateTime.Now,
                    CreatorId = 1,
                    LastModifierId = 0,
                    LastModifyTime = DateTime.Now,
                };
                User userNew1 = new User()
                {
                    Account = "Admin",
                    State = 0,
                    CompanyId = company.Id,//new company's id, name
                    CompanyName = company.Name,
                    CreateTime = DateTime.Now,
                    CreatorId = 1,
                    Email = "57265177@qq.com",
                    LastLoginTime = null,
                    LastModifierId = 0,
                    LastModifyTime = DateTime.Now,
                    Mobile = "18664876671",
                    Name = "min gong",
                    Password = "12356789",
                    UserType = 1
                };
                User userNew2 = new User()
                {
                    Account = "Admin",
                    State = 0,
                    CompanyId = company.Id,//new company's id, name
                    CompanyName = company.Name,
                    CreateTime = DateTime.Now,
                    CreatorId = 1,
                    Email = "57265177@qq.com",
                    LastLoginTime = null,
                    LastModifierId = 0,
                    LastModifyTime = DateTime.Now,
                    Mobile = "18664876671",
                    Name = "dream1",
                    Password = "12356789",
                    UserType = 2
                };
                #endregion

                dbContext.Set<Company>().Add(company);
                dbContext.Set<User>().Add(userNew1);
                dbContext.Set<User>().Add(userNew2);

                //add successfully, even company don't exist before insert. 
                //id increase automatically
                dbContext.SaveChanges();
                

            }


        }













    }
}
