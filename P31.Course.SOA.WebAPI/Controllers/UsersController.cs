﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using P31.Course.SOA.Interface;
using P31.Course.SOA.Model;

namespace P31.Course.SOA.WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private IUserService _userService = null;

        private List<User> _usersList = new List<User>()
        {
            new User() {userId = 1, userName = "Superman", userEmail = "Superman@google.com"},
            new User() {userId = 2, userName = "Spiderman", userEmail = "Spiderman@google.com"},
            new User() {userId = 3, userName = "Batman", userEmail = "Batman@google.com"}
        };

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }


        #region user log in


        #endregion



        #region HttpGet

        //GET api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _usersList;
        }

        [HttpGet]
        public User GetUserByID(int id)
        {
            string idParam = HttpContext.Current.Request.QueryString["userId"];

            User u = _usersList.FirstOrDefault(user => user.userId == id);
            if(u ==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return u;
        }

        [HttpGet]
        public IEnumerable<User> GetUserByName(string username)
        {
            string userNameParam = HttpContext.Current.Request.QueryString["userName"];

            return _usersList.Where(p => string.Equals(p.userName, username, StringComparison.OrdinalIgnoreCase));
        }

        [HttpGet]
        public IEnumerable<User> GetUserByNameId(string username, int id)
        {
            string idParam = HttpContext.Current.Request.QueryString["userId"];
            string userNameParam = HttpContext.Current.Request.QueryString["userName"];

            return _usersList.Where(p => string.Equals(p.userName, username, StringComparison.OrdinalIgnoreCase));
        }

        //btnGet5
        [HttpGet]
        public IEnumerable<User> GetUserByModel(User user)
        {
            string idParam = HttpContext.Current.Request.QueryString["userId"];
            string userNameParam = HttpContext.Current.Request.QueryString["userName"];
            string email = HttpContext.Current.Request.QueryString["email"];

            return _usersList;
        }
        //btnGet6
        [HttpGet]
        public IEnumerable<User> GetUserByModelUri([FromUri]User user)
        {
            string idParam = HttpContext.Current.Request.QueryString["userId"];
            string userNameParam = HttpContext.Current.Request.QueryString["userName"];
            string email = HttpContext.Current.Request.QueryString["email"];

            return _usersList;
        }
        //btnGet7
        [HttpGet]
        public IEnumerable<User> GetUserByModelSerialize(string userstring)
        {
            User user = JsonConvert.DeserializeObject<User>(userstring);
            return _usersList;
        }
        //btnGet8
        public IEnumerable<User> GetUserByModelSerializeWithoutGet(string userstring)
        {
            User user = JsonConvert.DeserializeObject<User>(userstring);
            return _usersList;
        }
        //not begin with Get and no attribute([HttpGet]/[HttpPost]/[HttpPut]/[HttpDelete]), will return 405, not sure which request.
        public IEnumerable<User> NoGetUserByModelSerializeWithoutGet(string userstring)
        {
            User user = JsonConvert.DeserializeObject<User>(userstring);
            return _usersList;
        }

        #endregion


        #region HttpPost
        //btnPost1
        [HttpPost]
        public User RegisterNone()
        {
            return _usersList.FirstOrDefault();
        }
        //btnPost2
        [HttpPost]
        public User RegisterNoKey([FromBody] int id)
        {
            string idParam = HttpContext.Current.Request.Form["userId"];

            var user = _usersList.FirstOrDefault(u => u.userId == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }
        //btnPost3
        [HttpPost]
        public User Register([FromBody]int id)
        {
            string idParam = HttpContext.Current.Request.Form["id"];
            User user = _usersList.FirstOrDefault(u => u.userId == id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }

        [HttpPost]
        public User RegisterUser(User user)
        {
            string idParam = HttpContext.Current.Request.Form["userId"];
            string nameParam = HttpContext.Current.Request.Form["userName"];
            string emailParam = HttpContext.Current.Request.Form["userEmail"];

            var stringContent = base.ControllerContext.Request.Content.ReadAsStringAsync().Result;
            return user;
        }


        [HttpPost]
        public string RegisterObject(JObject jData)
        {
            string idParam = HttpContext.Current.Request.Form["User[userId]"];
            string nameParam = HttpContext.Current.Request.Form["User[userName]"];
            string emailParam = HttpContext.Current.Request.Form["User[userEmail]"];
            string infoParam = HttpContext.Current.Request.Form["info"];

            dynamic json = jData;
            JObject juser = json.User;
            string info = json.Info;

            var user = juser.ToObject<User>();

            string result = string.Format("{0}_{1}_{2}_{3}", user.userId, user.userName, user.userEmail, info);
            return result;
        }


        [HttpPost]
        public string RegisterObjectDynamic(dynamic dynamicData)
        {
            string idParam = HttpContext.Current.Request.Form["User[userId]"];
            string nameParam = HttpContext.Current.Request.Form["User[userName]"];
            string emailParam = HttpContext.Current.Request.Form["User[userEmail]"];
            string infoParam = HttpContext.Current.Request.Form["info"];

            dynamic json = dynamicData;
            JObject juser = json.User;
            string info = json.Info;

            User user = juser.ToObject<User>();
            string result = string.Format("{0}_{1}_{2}_{3}", user.userId, user.userName, user.userEmail, info);
            return result;
        }

        #endregion



        #region HttpPut

        [HttpPut]
        public User RegisterNonPut()
        {
            User u = _usersList.FirstOrDefault();
            return u;
        }


        [HttpPut]
        public User RegisterNoKeyPut([FromBody]int id)
        {
            string idParam = HttpContext.Current.Request.Form["userId"];

            User user = _usersList.FirstOrDefault(u => u.userId == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }


        [HttpPut]
        public User RegisterPut([FromBody] int id)
        {
            string idParam = HttpContext.Current.Request.Form["userId"];

            User user = _usersList.FirstOrDefault(u => u.userId == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }

        [HttpPut]
        public User RegisterUserPut(User user)
        {
            string idParam = HttpContext.Current.Request.Form["userId"];
            string nameParam = HttpContext.Current.Request.Form["userName"];
            string emailParam = HttpContext.Current.Request.Form["userEmail"];

            string stringContent = base.ControllerContext.Request.Content.ReadAsStringAsync().Result;

            return user;
        }

        [HttpPut]
        public string RegisterObjectPut(JObject jData)
        {
            string idParam = HttpContext.Current.Request.Form["User[userId]"];
            string nameParam = HttpContext.Current.Request.Form["User[userName]"];
            string emailParam = HttpContext.Current.Request.Form["User[userEmail]"];
            string infoParam = HttpContext.Current.Request.Form["info"];

            dynamic json = jData;
            JObject juser = json.User;
            string info = json.Info;

            User user = juser.ToObject<User>();

            string result = string.Format("{0}_{1}_{2}_{3}", user.userId, user.userName, user.userEmail, info);
            return result;
        }

        [HttpPut]
        public string RegisterObjectDynamicPut(dynamic dynamicData)
        {
            string idParam = HttpContext.Current.Request.Form["User[userId]"];
            string nameParam = HttpContext.Current.Request.Form["User[userName]"];
            string emailParam = HttpContext.Current.Request.Form["User[userEmail]"];
            string infoParam = HttpContext.Current.Request.Form["info"];

            dynamic json = dynamicData;
            JObject juser = json.User;
            string info = json.Info;

            User user = juser.ToObject<User>();

            string result = string.Format("{0}_{1}_{2}_{3}", user.userId, user.userName, user.userEmail, info);
            return result;
        }


        #endregion


        #region HttpDelete

        [HttpDelete]
        public User RegisterNoneDelete()
        {
            User u = _usersList.FirstOrDefault();
            return u;
        }

        [HttpDelete]
        public User RegisterNoKeyDelete([FromBody] int id)
        {
            string idParam = HttpContext.Current.Request.Form["userId"];
            User user = _usersList.FirstOrDefault(u => u.userId == id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }

        [HttpDelete]
        public User RegisterDelete([FromBody] int id)
        {
            string idParam = HttpContext.Current.Request.Form["userId"];

            User user = _usersList.FirstOrDefault(u => u.userId == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }

        [HttpDelete]
        public User RegisterUserDelete(User user)
        {
            string idParam = HttpContext.Current.Request.Form["userId"];
            string nameParam = HttpContext.Current.Request.Form["userName"];
            string emailParam = HttpContext.Current.Request.Form["userEmail"];

            string stringcontent = base.ControllerContext.Request.Content.ReadAsStringAsync().Result;
            return user;
        }

        [HttpDelete]
        public string RegisterObjectDynamicDelete(dynamic dynamicData)
        {
            string idParam = HttpContext.Current.Request.Form["User[userId]"];
            string nameParam = HttpContext.Current.Request.Form["User[userName]"];
            string emailParam = HttpContext.Current.Request.Form["info"];

            dynamic json = dynamicData;
            JObject juser = json.User;
            string info = json.Info;
            User user = juser.ToObject<User>();

            string result = string.Format("{0}_{1}_{2}_{3}", user.userId, user.userName, user.userEmail, info);
            return result;
        }




        #endregion








    }
}
