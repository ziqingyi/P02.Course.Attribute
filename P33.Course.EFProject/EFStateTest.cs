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
                




            }






        }
    }
}
