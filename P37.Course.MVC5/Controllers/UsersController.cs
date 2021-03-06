﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P37.Course.Web.Core.Models;
using Newtonsoft.Json;

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
            #region test area
            if (Request["state"] != null)
            {
                string state = Request["state"].ToString();
            }
            #endregion


            return View();
        }

        public ActionResult Register1()
        {
            


            return View();
        }


        public ActionResult Register2(RegUser user)
        {
            #region test area
            if (Request["state"] != null)
            {
                string state = Request["state"].ToString();
            }
            #endregion


            //if all validation is passed, check in database
            //ModelState is Gets the model state dictionary object
            //         that contains the state of the model and of model-binding validation.
            if (ModelState.IsValid)
            {

                //check passed, go to log in page
                return View("Login");
            }

            ModelState.AddModelError("myNotification", "front end check passed, this is back end check");
            //validation or check not passed, go to register. 
            return View("Register1");
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

                //go to index page to show user's info
                return View("../Users/Index");
            }
            else
            {
                //go back to log in page
                return View("../Users/Login");
            }

        }

        //1 convert list/table to Json format manually
        //2 use JsonConvert
        //3 use JsonResult.Data
        public string ListToJsonTest()
        {
            List<RegUser> list = new List<RegUser>(){
                new RegUser(){Account = "user1", Password1 = "234234",Email = "dsafae@gmail.com"},
                new RegUser(){Account = "user2", Password1 = "jij7778",Email = "dsfafd@gmail.com"}
            };

            string json = JsonConvert.SerializeObject(list);
            return json;
        }

        public JsonResult GetAccounts(string account)
        {
            JsonResult jr = new JsonResult();
            jr.Data = ListToJsonTest();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            
            return jr;

        }




    }
}