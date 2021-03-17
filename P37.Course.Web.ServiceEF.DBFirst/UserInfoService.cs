using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P37.Course.Web.BLL;
using P37.Course.Web.Core.Models;

namespace P37.Course.Web.ServiceEF.DBFirst
{
    public class UserInfoService
    {
        //use P37.Course.Web.BLL 

        UserInfoManager userInfoManager = new UserInfoManager();

        public bool Register(RegUser u)
        {
            //process some checking in RegUser(business model) fields.
            //call BLL logic
            return userInfoManager.AddUser(u);
        }



    }
}
