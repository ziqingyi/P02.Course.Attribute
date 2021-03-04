﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P37.Course.Web.Core.Models;

namespace P37.Course.MVC5.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }



        public ActionResult UsersLogin(string account, string pwd)
        {
            Session["users"] = new CurrentUser
            {
                Id = 100, Account = account, Password = pwd
            };


            return View();
        }

        public ActionResult Register(CurrentUser user)
        {

            if (Request["state"] != null)
            {
                string state = Request["state"].ToString();
            }

            return View();
        }


        public string CheckUserEmail(string email)
        {
            return "1";
        }

        public ActionResult UserLogin(CurrentUser user)
        {
            if (user.Account == "user1" && user.Password == "dafd")
            {
                Session["user"] = user;
                HttpCookie cookie = new HttpCookie("userstr");
                cookie.Expires = DateTime.Now.AddMinutes(3);
                Response.Cookies.Add(cookie);
                return View("../Users/Index");
            }
            else
            {
                return View("../Users/Login");
            }

        }





    }
}