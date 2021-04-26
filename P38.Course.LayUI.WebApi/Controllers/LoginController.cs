﻿using P37.Course.Web.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using P37.Course.Web.Core.IOC;
using P34.Course.Business.Interface;
using P33.Course.Model.Models;
using Unity;//DIFactory.GetContainer().Resolve error

namespace P38.Course.LayUI.WebApi.Controllers
{
    public class LoginController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Login/Sign")]
        public string Sign(string userName, string passWord)
        {
            LoginResult result  = UserManager.ApiLogin(userName, passWord, GetUser, CheckPass, CheckStatusActive);

            if (result == LoginResult.Success)
            {
                FormsAuthenticationTicket ticketObj = new FormsAuthenticationTicket(0, 
                    userName, 
                    DateTime.Now,
                    DateTime.Now.AddHours(1),
                    true,
                    $"{userName}&{passWord}",
                    FormsAuthentication.FormsCookiePath);

                string ticket = FormsAuthentication.Encrypt(ticketObj);
                var resultS = new
                {
                    Result = true,
                    Message = "Log in successful",
                    Ticket = ticket
                };
                return Newtonsoft.Json.JsonConvert.SerializeObject(resultS);

            }
            else
            {
                var resultF = new
                {
                    Result = false,
                    Message = "Log in Failed",
                    Ticket = string.Empty
                };

                return Newtonsoft.Json.JsonConvert.SerializeObject(resultF);
            }



        }




        #region user check methods
        [ChildActionOnly]
        public User GetUser(string name)
        {
            using (IUserCompanyService service = DIFactory.GetContainer().Resolve<IUserCompanyService>())
            {
                User user = service.Set<User>().FirstOrDefault(u => u.Name.Equals(name) || u.Account.Equals(name));

                return user;
            }
        }
        [ChildActionOnly]
        public bool CheckPass(User user, string password)
        {
            return user.Password == password;
        }
        [ChildActionOnly]
        public bool CheckStatusActive(User user)
        {
            return user.State == 1;
        }

        #endregion



    }
}