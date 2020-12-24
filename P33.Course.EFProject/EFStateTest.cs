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

                {
                    User user5 = context.Users.Find(5);
                    user5.Name += "12";
                    user5.State += 1;
                    context.SaveChanges();
                    Console.WriteLine("State is 9 : " + context.Entry<User>(userNew).State);
                }
            }

            {
                User user = null;
                using (JDDbContext context = new JDDbContext())
                {
                    User user20 = context.Users.Find(20);
                    Console.WriteLine("State is 1 : " +context.Entry(user20).State);//unchanged
                    user = user20;

                }

                //EF monitor the object
                //user update and submit, then pass object to EF, change State to EntityState.Modified
                user.Name = "user20NewName";
                using (JDDbContext context = new JDDbContext())
                {
                    context.Users.Attach(user);// make context monitor the object
                    Console.WriteLine("State is 2 : " + context.Entry(user).State );//unchanged

                    user.Name = "xxxxxxx";//update
                    context.Entry(user).State = EntityState.Modified;//update all fields, otherwise only update one field
                    Console.WriteLine("State is 3 : " + context.Entry(user).State );//modified


                    context.SaveChanges();//update to database
                    Console.WriteLine("State is 4 : " + context.Entry(user).State);//unchanged
                }

                using (JDDbContext context = new JDDbContext())
                {
                    User userUpdate = new User(){Id = 22};
                    context.Users.Attach(userUpdate);

                    Console.WriteLine("State is 5 : " + context.Entry(userUpdate).State);//unchanged
                    userUpdate.Name = "xadfasd2222222222222222";
                    Console.WriteLine("State is 6 : " + context.Entry(userUpdate).State);//modified

                    //context.SaveChanges();//update to database, error, some fields value validation issue. 
                    Console.WriteLine("State is 7 : " + context.Entry(user).State);//detached
                }

                using (JDDbContext context = new JDDbContext())
                {
                    User userupdate = context.Users.Find(user.Id);
                    userupdate.Name = user.Name +"new";
                    Console.WriteLine("State is 8 : " + context.Entry(user).State);//detached
                    context.SaveChanges();
                    Console.WriteLine("State is 9 : " + context.Entry(user).State);//detached
                }

            }

            {
                Console.WriteLine("*********************************************");
                using (JDDbContext context = new JDDbContext())
                {
                    //AsNoTracking():  not catch in DbContext. will faster, search only, no updates. 
                    //List<User> userList = context.Users.Where(u => u.Id > 0).AsNoTracking().ToList();
                    List<User> userList = context.Users.Where(u => u.Id > 10).ToList();

                    Console.WriteLine("State is 9 : " + context.Entry<User>(userList[3]).State);//in memory: unchanged; noTracking(): detached

                    Console.WriteLine("*********************************************");
                    User user5 = context.Users.Find(30);

                    Console.WriteLine("*********************************************");
                    User user1 = context.Users.Find(30);//can find in cache if already searched before

                    Console.WriteLine("*********************************************");
                    User user2 = context.Users.FirstOrDefault(u => u.Id == 30);//linq will always go to database to search

                    Console.WriteLine("*********************************************");
                    User user3 = context.Users.Find(30);

                    Console.WriteLine("*********************************************");
                    User user4 = context.Users.FirstOrDefault(u => u.Id == 30);

                }




            }













        }
    }
}
