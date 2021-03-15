using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P37.Course.Web.Core.Models;
using Newtonsoft.Json;
using P37.Course.Web.Core.DAL;
using P37.Course.Web.Core.Filters;

namespace P37.Course.MVC5.Controllers
{
    //[UsersFilter]//every methods in the class need to pass the OnAuthorization method in the authorization attr check
    public class UsersController : Controller
    {
        #region User's Login and Users center page and Search page

        [UsersFilter]
        public ActionResult Search()
        {
            return View();
        }
        //[AllowAnonymous]//skip authorization
        public ActionResult Login()
        {
            return View();
        }

        [UsersFilter]
        public ActionResult UsersCentre(string account, string pwd)
        {
            Session["users"] = new CurrentUser
            {
                Id = 100, Account = account, Password = pwd
            };

            return View();
        }
        [AllowAnonymous]//skip all authorization
        public ActionResult UserLoginCheck(CurrentUser user)
        {
            //internal object: Request, Response, Application, Session, Server
            

            if (user.Account == "user1" && user.Password == "dafd")
            {
                Session["CurUser"] = user;
                HttpCookie cookie = new HttpCookie("userstr");
                cookie.Expires = DateTime.Now.AddMinutes(3);
                Response.Cookies.Add(cookie);

                //go to index page to show user's info
                return View("../Users/Search");
            }
            else
            {
                //go back to log in page
                return View("../Users/Login");
            }

        }
        #endregion




        #region Register

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

        #endregion


        #region Json test

        //1 convert list/table to Json format manually
        //2 use JsonConvert
        //3 use JsonResult.Data
        /*
         * [{"UserId":0,"Account":"user1","Password1":"234234","Password2":null,"Age":0,"Email":"dsafae@gmail.com"},
         * {"UserId":0,"Account":"user2","Password1":"jij7778","Password2":null,"Age":0,"Email":"dsfafd@gmail.com"}]
         */
        public JsonResult GetAccounts(string account)
        {
            JsonResult jr = new JsonResult();
            jr.Data = ListToJsonTest();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            
            return jr;
        }
        public string ListToJsonTest()
        {
            List<RegUser> list = new List<RegUser>(){
                new RegUser(){Account = "user1", Password1 = "234234",Email = "dsafae@gmail.com"},
                new RegUser(){Account = "user2", Password1 = "jij7778",Email = "dsfafd@gmail.com"}
            };

            string json = JsonConvert.SerializeObject(list);
            return json;
        }

        #endregion



        #region Ajax search

        public JsonResult GetUserNames(string username)
        {
            JsonResult jr= new JsonResult();
            List<CurrentUser> list = GetUserInfoByName(username);
            if (list.Count > 0)
            {
                jr.Data = list;// convert to json
            }
            else
            {
                jr.Data = "0";
            }
            return jr;
        }

        public List<CurrentUser> GetUserInfoByName(string username)
        {
            List<CurrentUser> list = new List<CurrentUser>();
            string sql = @"SELECT  [Id],[Name],[Account] 
                            FROM [advanced7].[dbo].[User] 
                            where [name] like @username";
            
            SqlParameter[] param =
            {
                new SqlParameter("@username", ""+username+"%")
            };

            using (SqlDataReader reader = DBHelper.ExecuteReader(sql,param))
            {
                while (reader.Read())
                {
                    CurrentUser user = new CurrentUser();
                    user.Id = (int)reader["Id"];
                    user.Name = reader["Name"].ToString();
                    user.Account = reader["Account"].ToString();
                    list.Add(user);
                }
            }
            return list;
        }




        #endregion













    }
}