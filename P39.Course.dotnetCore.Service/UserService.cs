using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P39.Course.dotnetCore.Interface;
using P39.Course.EntityFrameworkCore3.Model;

namespace P39.Course.dotnetCore.Service
{
    public class UserService : BaseService,IUserService
    {
        public UserService(DbContext context) : base(context)
        {

        }

        public void UpdateLastLogin(User user)
        {
            User userDB = base.Find<User>(user.Id);
            userDB.LastLoginTime = DateTime.Now;
            this.Commit();
        }

    }
}
