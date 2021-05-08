using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P37.Course.Web.Core.Attributes;
using P37.Course.Web.Core.DAL;
using P37.Course.Web.Core.Models;

namespace P38.Course.LayUI.WebApi.Controllers
{
    public class UsersController : Controller
    {
        [CustomAllowAnonymous]
        [HttpGet]
        [Route("api/Users/GetAjaxUserPageList")]
        public string GetAjaxUserPageList(int page, int limit, string keyWord, string starDate)
        {

            List<CurrentUser> userlist = new List<CurrentUser>();
            string sql = @"SELECT  [Id],[Name],[Account] ,[CreateTime]
                            FROM [advanced7].[dbo].[User] 
                            --where [name] like @username";

            //SqlParameter[] param =
            //{
            //    new SqlParameter("@username", ""+username+"%")
            //};

            using (SqlDataReader reader = DBHelper.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    CurrentUser user = new CurrentUser();
                    user.Id = (int)reader["Id"];
                    user.Name = reader["Name"].ToString();
                    user.Account = reader["Account"].ToString();
                    user.LastLoginTime = Convert.ToDateTime(reader["CreateTime"]);
                    userlist.Add(user);
                }
            }

            if (!string.IsNullOrWhiteSpace(keyWord))
            {
                keyWord = keyWord.Trim();
                userlist = userlist.Where(u => u.Name.Contains(keyWord) || u.Account.Contains(keyWord)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(starDate))
            {
                var startTime = Convert.ToDateTime(starDate);
                userlist = userlist.Where(a => a.CreateTime > startTime).ToList();
            }

            var userData = userlist.OrderByDescending(a => a.CreateTime).Skip(limit * (page - 1)).Take(limit).ToList();

            var result = new
            {
                code = 0,
                msg = "",
                count = userlist.Count(),
                data = userData
            };

            string JsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return JsonResult;
        }



        [HttpGet]
        public string DeleteUser(Guid? userGuid)
        {
            //test delete
            var result = new
            {
                Success = true,
                Message = "delete successfully"
            };
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }



        public string UserDetail(Guid? userGuid)
        {
            string JsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(

                new CurrentUser()
                {
                    Id = 123,
                    Name = "test",
                    Account = "testaccount",
                    LastLoginTime = DateTime.Now
                }
            );

            return JsonResult;
        }






    }
}