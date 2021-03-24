using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using P37.Course.Web.Core.Attributes;
using P37.Course.Web.Core.IOC;
using P37.Course.Web.Core.Utility;

namespace P37.Course.Web.Core.Extensions
{
    public static class UserManager
    {
        private static Logger logger = new Logger(typeof(UserManager));


        public static LoginResult Login<T>(this HttpContextBase context, string name,
            string password, string CaptchaCode, 
            Func<string,T > funcToGetT, 
            Func<T,string, bool> checkPassFunc, 
            Func<T, bool> checkStatusFunc)
        {
            if(context.Session["CheckCode"] != null
               && !string.IsNullOrEmpty(context.Session["CheckCode"].ToString())
               &&context.Session["CheckCode"].ToString().Equals(CaptchaCode, StringComparison.CurrentCultureIgnoreCase))
            {
                T t = funcToGetT.Invoke(name);
                if (t == null)
                {
                    return LoginResult.NoUser;
                }
                else if (!checkPassFunc(t, password))
                {
                    return LoginResult.WrongPwd;
                }
                else if (!checkStatusFunc(t))
                {
                    return LoginResult.Frozen;
                }
                else
                {
                    return LoginResult.Success;
                }

            }
            else
            {
                return LoginResult.WrongCaptcha;
            }


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
