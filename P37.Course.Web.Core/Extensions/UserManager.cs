using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Practices.Unity.Configuration;
using P37.Course.Web.Core.Attributes;
using P37.Course.Web.Core.DAL;
using P37.Course.Web.Core.IOC;
using P37.Course.Web.Core.Models;
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
                    Type type = typeof(T);
                    //log in success, write in cookie and session
                    CurrentUser currentUser= new CurrentUser()
                    {
                        Id = (int)(type.GetProperty("Id")?.GetValue(t)),
                        Name=(string)(type.GetProperty("Name")?.GetValue(t)),
                        Account = (string)(type.GetProperty("Account")?.GetValue(t)),
                        Email = (string)(type.GetProperty("Email")?.GetValue(t)),
                        Password = (string)(type.GetProperty("Password")?.GetValue(t)),
                        LastLoginTime  = DateTime.Now
                    };

                    #region Request
                   // context.Request
                   //Header, InputStream has upload file

                    #endregion

                    #region Response

                    //context.Response

                    #endregion

                    #region Server

                    string encode = context.Server.HtmlEncode("<home html>");
                    string decode = context.Server.HtmlDecode(encode);
                    string physicalPath = context.Server.MapPath("/home/index");
                    string encodeUrl = context.Server.UrlEncode("home url");
                    string decodeUrl = context.Server.UrlDecode(encodeUrl);

                    #endregion

                    #region Application

                    context.Application.Lock();
                    context.Application.Lock();

                    context.Application.Add("try","res-try");
                    context.Application.UnLock();

                    object aValue = context.Application.Get("try");
                    aValue = context.Application["try"];
                    context.Application.Remove("obj");
                    context.Application.RemoveAt(0);
                    context.Application.RemoveAll();
                    context.Application.Clear();
                    
                    #endregion

                    #region  context item

                    context.Items["123"] = "567";//single session

                    #endregion

                    
                    

                    #region Cookie
                    HttpCookie myCookie = new HttpCookie("CurrentUser");
                    myCookie.Value = JsonHelper.ObjectToString<CurrentUser>(currentUser);
                    //with expiry date, cookie saved in hard disk rather than save in memory
                    //myCookie.Expires = DateTime.Now.AddMinutes(5);

                    #endregion

                    #region Session

                    var sessionUser = context.Session["CurrentUser"];
                    context.Session["CurrentUser"] = currentUser;
                    context.Session.Timeout = 3;//3 minutes, session will be abandoned if "gap time" exceed 3 minutes
                    
                    #endregion

                    logger.Debug(string.Format("user id={0} Name={1} log in system", currentUser.Id,currentUser.Name));

                    return LoginResult.Success;
                }

            }
            else
            {
                return LoginResult.WrongCaptcha;
            }


        }

        public static void UserLogout(this HttpContextBase context)
        {
            #region Cookie

            HttpCookie myCookie = context.Request.Cookies["CurrentUser"];
            if (myCookie != null)
            {
                myCookie.Expires = DateTime.Now.AddMinutes(-1); //set expiry time
                context.Response.Cookies.Add(myCookie);
            }

            #endregion


            #region Session

            var sessionUser = context.Session["CurrentUser"];
            if (sessionUser != null && sessionUser is CurrentUser)
            {
                CurrentUser currentUser = (CurrentUser) context.Session["CurrentUser"];
                logger.Debug(string.Format("user id={0} Name={1} leave the system", currentUser.Id, currentUser.Name));
            }

            context.Session["CurrentUser"] = null;//clear and remove key
            context.Session.Remove("CurrentUser");

            context.Session.Clear();//session is kept  but all the keys are removed.
            context.Session.RemoveAll();
            context.Session.Abandon();//delete session object, next time will create a new Session.next time, new user

            #endregion
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
