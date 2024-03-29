﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using P34.Course.Business.Interface.TestCore;
using P39.Course.dotnetCoreLib.Filters;
using P39.Course.EntityFrameworkCore3.Model;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace P39.Course.dotnetCore.TestMVC.Controllers
{
    [Route("api/[controller]/[action]"), ApiController]
    public class FUsersApiController : ControllerBase
    {

        #region Data


        private List<User> _usersList = new List<User>()
        {
            new User() {Id = 1, Name = "Superman", Email = "Superman@google.com"},
            new User() {Id = 2, Name = "Spiderman", Email = "Spiderman@google.com"},
            new User() {Id = 3, Name = "Batman", Email = "Batman@google.com"}
        };

        #endregion

        #region Identity

        private ILoggerFactory _Factory = null;
        private ILogger<FUsersApiController> _logger = null;
        private ITestServiceA _ITestServiceA = null;
        private ITestServiceB _ITestServiceB = null;
        private ITestServiceC _ITestServiceC = null;
        private ITestServiceD _ITestServiceD = null;

        //test AOP
        private IA _IA = null;


        public FUsersApiController(ILoggerFactory loggerFactory,
            ILogger<FUsersApiController> logger
            ,
            ITestServiceA testServiceA,
            ITestServiceB testServiceB,
            ITestServiceC testServiceC,
            ITestServiceD testServiceD
            ,
            IA a
        )
        {
            this._Factory = loggerFactory;
            this._logger = logger;
            this._ITestServiceA = testServiceA;
            this._ITestServiceB = testServiceB;
            this._ITestServiceC = testServiceC;
            this._ITestServiceD = testServiceD;
            this._IA = a;
        }

        #endregion

        #region HttpGet

        // this is the rest way. but for test, we have multiple get names. 
        //GET api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {

            return _usersList;
        }

        [HttpGet]
        public User GetUserByID(int id)
        {
            //throw new Exception("23213131");
            string idParam = base.HttpContext.Request.Query["userId"];

            User u = _usersList.FirstOrDefault(user => user.Id == id);
            if (u == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return u;
        }

        [HttpGet]
        //[CustomBasicAuthorize] //if place on method, only works for this method. 
        public IEnumerable<User> GetUserByName(string username)
        {
            //throw new Exception("23213131");//test exception
            string userNameParam = base.HttpContext.Request.Query["userName"];

            return _usersList.Where(p => string.Equals(p.Name, username, StringComparison.OrdinalIgnoreCase));
        }

        [HttpGet]
        public IEnumerable<User> GetUserByNameId(string username, int id)
        {
            string idParam = base.HttpContext.Request.Query["userId"];
            string userNameParam = base.HttpContext.Request.Query["userName"];

            return _usersList.Where(p => string.Equals(p.Name, username, StringComparison.OrdinalIgnoreCase));
        }

        //btnGet5
        [HttpGet]
        public IEnumerable<User> GetUserByModel(User user)
        {
            string idParam = base.HttpContext.Request.Query["userId"];
            string userNameParam = base.HttpContext.Request.Query["userName"];
            string email = base.HttpContext.Request.Query["email"];

            return _usersList;
        }
        //btnGet6
        [HttpGet]
        public IEnumerable<User> GetUserByModelUri([FromUri] User user)
        {
            string idParam = base.HttpContext.Request.Query["userId"];
            string userNameParam = base.HttpContext.Request.Query["userName"];
            string email = base.HttpContext.Request.Query["email"];

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
        //
        [HttpPost]
        public User RegisterNone()
        {
            return _usersList.FirstOrDefault();
        }
        //btnPost1
        [HttpPost]
        public User RegisterNoKey([FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Query["UserID"];

            var user = _usersList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }
        //btnPost2
        [HttpPost]
        public User Register([FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Query["ID"];
            User user = _usersList.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }
        //btnPost3
        [HttpPost]
        public User RegisterUser(User user)
        {
            string idParam = base.HttpContext.Request.Query["UserID"];
            string nameParam = base.HttpContext.Request.Query["userName"];
            string emailParam = base.HttpContext.Request.Query["userEmail"];

            return user;
        }


        [HttpPost]
        public string RegisterObject(JObject jData)
        {
            string idParam = base.HttpContext.Request.Query["User[userId]"];
            string nameParam = base.HttpContext.Request.Query["User[userName]"];
            string emailParam = base.HttpContext.Request.Query["User[userEmail]"];
            string infoParam = base.HttpContext.Request.Query["info"];

            dynamic json = jData;
            JObject juser = json.User;
            string info = json.Info;

            var user = juser.ToObject<User>();

            string result = string.Format("{0}_{1}_{2}_{3}", user.Id, user.Name, user.Email, info);
            return result;
        }


        [HttpPost]
        public string RegisterObjectDynamic(dynamic dynamicData)
        {
            string idParam = base.HttpContext.Request.Query["User[userId]"];
            string nameParam = base.HttpContext.Request.Query["User[userName]"];
            string emailParam = base.HttpContext.Request.Query["User[userEmail]"];
            string infoParam = base.HttpContext.Request.Query["info"];

            dynamic json = dynamicData;
            JObject juser = json.User;
            string info = json.Info;

            User user = juser.ToObject<User>();
            string result = string.Format("{0}_{1}_{2}_{3}", user.Id, user.Name, user.Email, info);
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
        public User RegisterNoKeyPut([FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Query["userId"];

            User user = _usersList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }


        [HttpPut]
        public User RegisterPut([FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Query["userId"];

            User user = _usersList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }

        [HttpPut]
        public User RegisterUserPut(User user)
        {
            string idParam = base.HttpContext.Request.Query["userId"];
            string nameParam = base.HttpContext.Request.Query["userName"];
            string emailParam = base.HttpContext.Request.Query["userEmail"];

            return user;
        }

        [HttpPut]
        public string RegisterObjectPut(JObject jData)
        {
            string idParam = base.HttpContext.Request.Query["User[userId]"];
            string nameParam = base.HttpContext.Request.Query["User[userName]"];
            string emailParam = base.HttpContext.Request.Query["User[userEmail]"];
            string infoParam = base.HttpContext.Request.Query["info"];

            dynamic json = jData;
            JObject juser = json.User;
            string info = json.Info;

            User user = juser.ToObject<User>();

            string result = string.Format("{0}_{1}_{2}_{3}", user.Id, user.Name, user.Email, info);
            return result;
        }

        [HttpPut]
        public string RegisterObjectDynamicPut(dynamic dynamicData)
        {
            string idParam = base.HttpContext.Request.Query["User[userId]"];
            string nameParam = base.HttpContext.Request.Query["User[userName]"];
            string emailParam = base.HttpContext.Request.Query["User[userEmail]"];
            string infoParam = base.HttpContext.Request.Query["info"];

            dynamic json = dynamicData;
            JObject juser = json.User;
            string info = json.Info;

            User user = juser.ToObject<User>();

            string result = string.Format("{0}_{1}_{2}_{3}", user.Id, user.Name, user.Email, info);
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
            string idParam = base.HttpContext.Request.Query["userId"];
            User user = _usersList.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }

        [HttpDelete]
        public User RegisterDelete([FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Query["userId"];

            User user = _usersList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }

        [HttpDelete]
        public User RegisterUserDelete(User user)
        {
            string idParam = base.HttpContext.Request.Query["userId"];
            string nameParam = base.HttpContext.Request.Query["userName"];
            string emailParam = base.HttpContext.Request.Query["userEmail"];

            return user;
        }

        [HttpDelete]
        public string RegisterObjectDynamicDelete(dynamic dynamicData)
        {
            string idParam = base.HttpContext.Request.Query["User[userId]"];
            string nameParam = base.HttpContext.Request.Query["User[userName]"];
            string emailParam = base.HttpContext.Request.Query["info"];

            dynamic json = dynamicData;
            JObject juser = json.User;
            string info = json.Info;
            User user = juser.ToObject<User>();

            string result = string.Format("{0}_{1}_{2}_{3}", user.Id, user.Name, user.Email, info);
            return result;
        }




        #endregion


    }
}
