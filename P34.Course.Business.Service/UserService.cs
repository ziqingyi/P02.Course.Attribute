using P34.Course.Business.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P33.Course.Model.Models;

namespace P34.Course.Business.Service
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
