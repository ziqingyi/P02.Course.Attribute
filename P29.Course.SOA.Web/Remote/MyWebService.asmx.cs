using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace P29.Course.SOA.Web.Remote
{
    /// <summary>
    /// Summary description for MyWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyWebService : System.Web.Services.WebService
    {
        private List<UserInfo> userInfos = new List<UserInfo>()
        {
            new UserInfo()
            {
                Id = 1,
                Name = "User1",
                Age = 27
            },
            new UserInfo()
            {
                Id = 2,
                Name = "User2",
                Age = 20
            }, 
            new UserInfo()
            {
                Id = 3,
                Name = "User3",
                Age = 22
            },
            new UserInfo()
            {
                Id = 4,
                Name = "User4",
                Age = 25
            },
            new UserInfo()
            {
                Id = 5,
                Name = "User5",
                Age = 30
            },
            new UserInfo()
            {
                Id = 6,
                Name = "User6",
                Age = 36
            }
        };

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string HelloWorldWithAuth(string name_password)
        {
            if (true)
            {
              
            }

            return "Hello world Auth";
        }

        [WebMethod]
        public string GetNameById(int id)
        {
            UserInfo u = (UserInfo)userInfos.Where<UserInfo>(s => s.Id == id);
            
            return $"get name {u.Name} ";
        }

        [WebMethod]
        public UserInfo GetUserObjById(int id)
        {
            UserInfo u = (UserInfo)userInfos.Where<UserInfo>(s => s.Id == id);

            return u;
        }

        [WebMethod]
        public List<UserInfo> GetuserList()
        {
            return userInfos;
        }




        [WebMethod]
        public int Plus(int x, int y)
        {
            return x + y;
        }

        public string GetJsonInfo(int id, string name, int age)
        {
            string JsonSerialize = Newtonsoft.Json.JsonConvert.SerializeObject(new UserInfo()
            {
                Id =id, Name = name, Age = age
            });

            return JsonSerialize;
        }





    }
}
