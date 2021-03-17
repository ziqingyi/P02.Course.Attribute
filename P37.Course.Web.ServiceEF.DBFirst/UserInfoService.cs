using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P37.Course.Web.BLL;

namespace P37.Course.Web.ServiceEF.DBFirst
{
    public class UserInfoService
    {
        //use P37.Course.Web.BLL 

        UserInfoManager userInfoManager = new UserInfoManager();

        public bool Register()
        {
            return userInfoManager.AddUser();
        }



    }
}
