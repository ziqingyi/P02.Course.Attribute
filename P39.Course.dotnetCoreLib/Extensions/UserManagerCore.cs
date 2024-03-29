﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using P39.Course.dotnetCoreLib.Models;
using Microsoft.AspNetCore.Http;

namespace P39.Course.dotnetCoreLib.Extensions
{
    public static class UserManagerCore
    {
        //copy from Framework version. 
        private static ILoggerFactory loggerFactory = new LoggerFactory();
        private static ILogger logger = new Logger<string>(loggerFactory);


        public static LoginResult Login<T>(this HttpContext context, string name,
            string password, //string CaptchaCode,
            Func<string, T> funcToGetT,
            Func<T, string, bool> checkPassFunc,
            Func<T, bool> checkStatusFunc)
        {
            //if (context.Session["CheckCode"] != null
            //   && !string.IsNullOrEmpty(context.Session["CheckCode"].ToString())
            //   && context.Session["CheckCode"].ToString().Equals(CaptchaCode, StringComparison.CurrentCultureIgnoreCase))
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
                    CurrentUserCore currentUser = new CurrentUserCore()
                    {
                        Id = (int)(type.GetProperty("Id")?.GetValue(t)),
                        Name = (string)(type.GetProperty("Name")?.GetValue(t)),
                        Account = (string)(type.GetProperty("Account")?.GetValue(t)),
                        Email = (string)(type.GetProperty("Email")?.GetValue(t)),
                        Password = (string)(type.GetProperty("Password")?.GetValue(t)),
                        Role = (string)(type.GetProperty("Role")?.GetValue(t)),
                        LastLoginTime = DateTime.Now
                    };

                    #region Request
                    // context.Request
                    //Header, InputStream has upload file

                    #endregion

                    #region Response

                    //context.Response

                    #endregion

                    #region Server

                    //string encode = context.Server.HtmlEncode("<home html>");
                    //string decode = context.Server.HtmlDecode(encode);
                    //string physicalPath = context.Server.MapPath("/home/index");
                    //string encodeUrl = context.Server.UrlEncode("home url");
                    //string decodeUrl = context.Server.UrlDecode(encodeUrl);

                    #endregion

                    #region Application

                    //context.Application.Lock();
                    //context.Application.Lock();

                    //context.Application.Add("try", "res-try");
                    //context.Application.UnLock();

                    //object aValue = context.Application.Get("try");
                    //aValue = context.Application["try"];
                    //context.Application.Remove("obj");
                    //context.Application.RemoveAt(0);
                    //context.Application.RemoveAll();
                    //context.Application.Clear();

                    #endregion

                    #region  context item

                    context.Items["123"] = "567";//single session

                    #endregion

                    /*
                     * Cookies store it directly on the client.
                     *
                     * Sessions use a cookie as a key of sorts, to associate with the data that is stored on the server side.
                     *
                     * It is preferred to use sessions because the actual values are hidden from the client, and you control when the data expires and becomes invalid.
                     *
                     * If it was all based on cookies, a user (or hacker) could manipulate their cookie data and then play requests to your site.
                     */


                    #region Cookie
                    //old MVC cookie use
                    //HttpCookie myCookie = new HttpCookie("CurrentUser");
                    //myCookie.Value = JsonHelper.ObjectToString<CurrentUser>(currentUser);
                    ////with expiry date, cookie saved in hard disk rather than save in memory
                    ////myCookie.Expires = DateTime.Now.AddMinutes(5);

                    ////cookie in core , use claimIdentity
                    {
                        var claimIdentity = new ClaimsIdentity("Cookie");
                        claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, currentUser.Id.ToString()));
                        claimIdentity.AddClaim(new Claim(ClaimTypes.Name, currentUser.Name));
                        claimIdentity.AddClaim(new Claim(ClaimTypes.Email, currentUser.Email));
                        //role is used for checking [Authorize(Roles = "Admin")]
                        claimIdentity.AddClaim(new Claim(ClaimTypes.Role,currentUser.Role ));

                        claimIdentity.AddClaim(new Claim(ClaimTypes.Sid, currentUser.Id.ToString()));

                        var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

                        context.SignInAsync(claimsPrincipal).Wait();//write into cookie. from //app.UseAuthentication(); in start up
                    }



                    #endregion

                    #region Session
                    ////set session in asp .net
                    //var sessionUser = context.Session["CurrentUser"];
                    //context.Session["CurrentUser"] = currentUser;
                    //context.Session.Timeout = 3;//3 minutes, session will be abandoned if "gap time" exceed 3 minutes

                    ////set session in core
                    //context.Session.SetString("CurrentUser",
                    //    Newtonsoft.Json.JsonConvert.SerializeObject(currentUser));

                    #endregion



                    logger.LogInformation(string.Format("user id={0} Name={1} log in system", currentUser.Id, currentUser.Name));

                    return LoginResult.Success;
                }

            }
            //else
            //{
            //    return LoginResult.WrongCaptcha;
            //}


        }


        public static void UserLogout(this HttpContext context)
        {
            #region Cookie

            //HttpCookie myCookie = context.Request.Cookies["CurrentUser"];
            //if (myCookie != null)
            //{
            //    myCookie.Expires = DateTime.Now.AddMinutes(-1); //set expiry time
            //    context.Response.Cookies.Add(myCookie);
            //}

            #endregion


            #region Session

            //var sessionUser = context.Session["CurrentUser"];
            //if (sessionUser != null && sessionUser is CurrentUserCore)
            //{
            //    CurrentUserCore currentUser = (CurrentUserCore)context.Session["CurrentUser"];
            //    logger.LogInformation(string.Format("user id={0} Name={1} leave the system", currentUser.Id, currentUser.Name));
            //}

            //context.Session["CurrentUser"] = null;//clear and remove key
            //context.Session.Remove("CurrentUser");

            //context.Session.Clear();//session is kept  but all the keys are removed.
            //context.Session.RemoveAll();
            //context.Session.Abandon();//delete session object, next time will create a new Session.next time, new user

            #endregion
        }

        public static LoginResult ApiLogin<T>(string name, string password,
            Func<string, T> funcToGetT,
            Func<T, string, bool> checkPassFunc,
            Func<T, bool> checkStatusFunc)
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
                CurrentUserCore currentUser = new CurrentUserCore()
                {
                    Id = (int)(type.GetProperty("Id")?.GetValue(t)),
                    Name = (string)(type.GetProperty("Name")?.GetValue(t)),
                    Account = (string)(type.GetProperty("Account")?.GetValue(t)),
                    Email = (string)(type.GetProperty("Email")?.GetValue(t)),
                    Password = (string)(type.GetProperty("Password")?.GetValue(t)),
                    LastLoginTime = DateTime.Now
                };

                logger.LogInformation(string.Format("user id={0} Name={1} log in system", currentUser.Id, currentUser.Name));

                return LoginResult.Success;
            }

        }

    }



    public enum LoginResult
    {
        [Remark("Log in Successfully")]
        Success = 0,

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
