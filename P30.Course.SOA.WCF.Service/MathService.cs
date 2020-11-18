using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P30.Course.SOA.WCF.Interface;
using P30.Course.SOA.WCF.Model;

namespace P30.Course.SOA.WCF.Service
{
    public class MathService:IMathService
    {

        private List<WCFUser> uList = new List<WCFUser>()
        {
            new WCFUser()
            {
                Id = 1,
                Name = "user1",
                Sex = (int)WCFUserSex.Male,
                Age = 29,
                Description = "123456678990"
            },
            new WCFUser()
            {
                Id = 2,
                Name = "user2",
                Sex = (int)WCFUserSex.Male,
                Age = 22,
                Description = "123456678990"
            },
            new WCFUser()
            {
                Id = 3,
                Name = "user3",
                Sex = (int)WCFUserSex.Female,
                Age = 32,
                Description = "123456678990"
            }
        };
        public int PlusInt(int x, int y)
        {
            return x + y;
        }

        public int Minus(int x, int y)
        {
            return x - y;
        }

        public WCFUser GetUser(int x, int y)
        {
            int tid = x + y;
            WCFUser wcfUser = new WCFUser()
            {
                Id = tid,
                Name = "User_" + tid,
                Age = 22,
                Description = "WCF Service user " + tid,
                Sex = (int)WCFUserSex.Female
            };

            return wcfUser;
        }

        public List<WCFUser> UserList()
        {
            return uList;
        }





    }
}
