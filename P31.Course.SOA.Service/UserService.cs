using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P31.Course.SOA.Interface;

namespace P31.Course.SOA.Service
{
    public class UserService : IUserService
    {
        public object Query(int id)
        {
            return new
            {
                Id = id,
                Name = "user" + id,
                Remark = "Lucky"
            };
        }
    }
}
