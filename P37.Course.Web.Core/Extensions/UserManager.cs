using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using P37.Course.Web.Core.Attributes;
using P37.Course.Web.Core.Utility;

namespace P37.Course.Web.Core.Extensions
{
    public static class UserManager
    {
        private static Logger logger = new Logger(typeof(UserManager));


        public static LoginResult Login(this HttpContextBase context, string name,
            string password, string verifyCode)
        {





        }










    }


    public enum LoginResult
    {
       [Remark("Log in Successfully")]
        Success =0,

        [Remark("User not exists")]
        NoUser = 1,

        [Remark("Wrong Password")]
        WrongPwd = 2,

        [Remark("Captcha wrong")]
        WrongCaptcha = 3,

        [Remark("Account Frozen")]
        Frozen = 4


    }










}
