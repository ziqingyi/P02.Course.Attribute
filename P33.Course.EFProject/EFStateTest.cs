using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using P33.Course.Model;
using P33.Course.Model.Models;

namespace P33.Course.EFProject
{
    public class EFStateTest
    {
        public static void Show()
        {
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

            using (JDDbContext context = new JDDbContext())
            {
                Console.WriteLine("State is 1 : " + context.Entry<User>(userNew).State);//detached
                userNew.Name = "fish fish";
                context.SaveChanges(); // nothing happens
                Console.WriteLine("State is 2 : " + context.Entry<User>(userNew).State);//detached

                context.Users.Add(userNew);
                Console.WriteLine("State is 3 : " + context.Entry<User>(userNew).State); //added 
                context.SaveChanges();// add to database,userNew's id value will be updated from database
                Console.WriteLine("State is 4 : " + context.Entry<User>(userNew).State);//unchanged


                userNew.Name = "Octopus";
                Console.WriteLine("State is 5 : " + context.Entry<User>(userNew).State);//modified
                context.SaveChanges();// update to database, due to state. 
                Console.WriteLine("State is 6 : " + context.Entry<User>(userNew).State);//unchanged

                context.Users.Remove(userNew);
                Console.WriteLine("State is 7 : " + context.Entry<User>(userNew).State);//deleted
                context.SaveChanges();
                Console.WriteLine("State is 8 : " + context.Entry<User>(userNew).State );//detached, remove from memory


            }






        }
    }
}
