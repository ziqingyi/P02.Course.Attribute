using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P29.Course.SOA.UnitTestProject
{

    public class HttpClientFactory
    {
        private static HttpClient _httpClient = null;

        //TCP may not free up immediately when high volume of request. so need singleton.  
        static HttpClientFactory()
        {
            _httpClient = new HttpClient(new HttpClientHandler());
        }

        public static HttpClient GetHttpClient()
        {
            return _httpClient;
        }
    }


    [TestClass]
    public class UnitTestWebapi
    {
        [TestMethod]
        public void TestMethod()
        {
            this.AuthorizationDemo();

            var result1 = this.GetClient();
            var result2 = this.GetWebRequest();

            var result3 = this.PostClient();
            var result4 = this.PostWebRequest();

            var result5 = this.PutClient();
            var result6 = this.PutWebRequest();

            var result7 = this.DeleteClient();
            var result8 = this.DeleteWebRequest();

            Console.WriteLine();
        }

        #region HttpClient Get
        private string GetClient()
        {
            //string url = "https://localhost:44355/api/users/GetUserByName?username=Superman";
            string url = "https://localhost:44355/api/users/GetUserByID?id=1";
            //string url = "https://localhost:44355/api/users/GetUserByNameId?userName=Superman&id=1";
            //string url = "https://localhost:44355/api/users/Get";
            //string url = "https://localhost:44355/api/users/GetUserByModel?UserID=11&UserName=Eleven&UserEmail=57265177%40qq.com";
            //string url = "https://localhost:44355/api/users/GetUserByModelUri?UserID=11&UserName=Eleven&UserEmail=57265177%40qq.com";
            //string url = "https://localhost:44355/api/users/GetUserByModelSerialize?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            //string url = "https://localhost:44355/api/users/GetUserByModelSerializeWithoutGet?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            //string url = "https://localhost:44355/api/users/NoGetUserByModelSerializeWithoutGet?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            
            HttpClientHandler handler = new HttpClientHandler();

            using (HttpClient http = new HttpClient(handler))
            {
                HttpResponseMessage response = http.GetAsync(url).Result;//get async result
                Console.WriteLine("Status Code is: "+ response.StatusCode);//get status code
                string res = response.Content.ReadAsStringAsync().Result;
                return res;
            }
        }

        #endregion


        #region HttpWebRequest

        private string GetWebRequest()
        {
            //string url = "https://localhost:44355/api/users/GetUserByName?username=Superman";
            string url = "https://localhost:44355/api/users/GetUserByID?id=1";
            //string url = "https://localhost:44355/api/users/GetUserByNameId?userName=Superman&id=1";
            //string url = "https://localhost:44355/api/users/Get";
            //string url = "https://localhost:44355/api/users/GetUserByModel?UserID=11&UserName=Eleven&UserEmail=57265177%40qq.com";
            //string url = "https://localhost:44355/api/users/GetUserByModelUri?UserID=11&UserName=Eleven&UserEmail=57265177%40qq.com";
            //string url = "https://localhost:44355/api/users/GetUserByModelSerialize?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            //string url = "https://localhost:44355/api/users/GetUserByModelSerializeWithoutGet?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            //string url = "https://localhost:44355/api/users/NoGetUserByModelSerializeWithoutGet?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";

            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.Timeout = 30*1000;
            //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
            //request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            string result = "";
            using (HttpWebResponse res = (request.GetResponse() as HttpWebResponse)  )
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        #endregion

        #region HttpClient and Post

        private string PostClient()
        {

            //string url = "http://localhost:44355/api/users/register";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"","1" }
            //};

            //string url = "http://localhost:44355/api/users/RegisterNoKey";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"","1" }
            //};

            //string url = "https://localhost:44355/api/users/RegisterUser";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"UserID","11" },
            //    {"UserName","Anne" },
            //    {"UserEmail","afdasfsdaf@gmail.com" },
            //};

            string url = "https://localhost:44355/api/users/RegisterObject";
            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
                {"User[UserID]","6" },
                {"User[UserName]","Anne" },
                {"User[UserEmail]","afdasfsdaf@gmail.com" },
                {"Info","this is info model" }
            };

            HttpClientHandler handler = new HttpClientHandler();
            using (HttpClient http = new HttpClient(handler))
            {
                FormUrlEncodedContent content = new FormUrlEncodedContent(dic);
                HttpResponseMessage response = http.PostAsync(url, content).Result;
                Console.WriteLine("Status Code is: " + response.StatusCode);//get status code
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }


        }


        #endregion


        #region HttpWebRequest with Post

        private string PostWebRequest()
        {

            //string url = "https://localhost:44355/api/users/register";
            //var postData = "1";

            //string url = "https://localhost:44355/api/users/RegisterNoKey";
            //var postData = "1";

            var user = new
            {
                UserID = "12",
                UserName = "Tom",
                UserEmail = "afdaaee6576@gmail.com"
            };
            //string url = "https://localhost:44355/api/users/RegisterUser";
            //var postData = JsonHelper.ObjectToString(user);

            var userOther = new
            {
                User = user,
                Info = "this is info model"
            };

            string url = "http://localhost:44355/api/users/RegisterObject";

            string postData = Newtonsoft.Json.JsonConvert.SerializeObject(userOther);

            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30 * 1000;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.183 Safari/537.36";
            request.ContentType = "application/json";
            request.Method = "POST";
            byte[] data = Encoding.UTF8.GetBytes(postData);

            request.ContentLength = data.Length;
            Stream postStream = request.GetRequestStream();
            postStream.Write(data,0,data.Length);

            postStream.Close();

            string result = "";
            using (HttpWebResponse res = (request.GetResponse() as HttpWebResponse))
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }
        #endregion


        #region HttpClient and Put
        private string PutClient()
        {
            string url = "https://localhost:44355/api/users/RegisterPut";
            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
                {"","1" }
            };

            //string url = "https://localhost:44355/api/users/RegisterNoKeyPut";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"","1" }
            //};

            //string url = "https://localhost:44355/api/users/RegisterUserPut";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"UserID","11" },
            //    {"UserName","Anne" },
            //    {"UserEmail","afdasfsdaf@gmail.com" }
            //};

            //string url = "https://localhost:44355/api/users/RegisterObjectPut";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"User[UserID]","12" },
            //    {"User[UserName]","Tom" },
            //    {"User[UserEmail]","fasfdaf@gmail.com" },
            //    {"Info","this is muti model" }
            //};


            HttpClientHandler handler = new HttpClientHandler();
            using (HttpClient http = new HttpClient(handler))
            {
                FormUrlEncodedContent content = new FormUrlEncodedContent(dic);
                HttpResponseMessage response = http.PutAsync(url, content).Result;
                Console.WriteLine("Status Code is: " + response.StatusCode);
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }

        }

        #endregion


        #region HttpWebRequest and put

        private string PutWebRequest()
        {
            //string url = "https://localhost:44355/api/users/registerPut";
            //var postData = "1";

            //string url = "https://localhost:44355/api/users/RegisterNoKeyPut";
            //var postData = "1";

            var user = new
            {
                UserID = "12",
                UserName = "Tom",
                UserEmail = "afdaaee6576@gmail.com"
            };
            //string url = "http://localhost:44355/api/users/RegisterUserPut";
            //var postData = JsonHelper.ObjectToString(user);

            var userOther = new
            {
                User = user,
                Info = "this is muti model"
            };
            string url = "https://localhost:44355/api/users/RegisterObjectPut";
            var postData = Newtonsoft.Json.JsonConvert.SerializeObject(userOther);

            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30 * 1000;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.183 Safari/537.36";
            request.ContentType = "application/json";
            request.Method = "PUT";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = data.Length;

            Stream postStream = request.GetRequestStream();
            postStream.Write(data,0,data.Length);
            postStream.Close();

            string result = "";
            using (HttpWebResponse res = (request.GetResponse() as HttpWebResponse))
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        #endregion

        #region HttpClient and Delete

        private string DeleteClient()
        {
            string url = "https://localhost:44355/api/users/RegisterDelete/1";
            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
                {"","1" }
            };

            //string url = "https://localhost:44355/api/users/RegisterNoKeyDelete";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"","1" }
            //};

            //string url = "https://localhost:44355/api/users/RegisterUserDelete";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"UserID","11" },
            //    {"UserName","Anne" },
            //    {"UserEmail","afdasfsdaf@gmail.com" }
            //};

            //string url = "https://localhost:44355/api/users/RegisterObjectDelete";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"User[UserID]","11" },
            //    {"User[UserName]","Tom" },
            //    {"User[UserEmail]","afdasfsdaf@gmail.com" },
            //    {"Info","this is muti model" }
            //};

            HttpClientHandler handler = new HttpClientHandler();
            using (HttpClient http = new HttpClient(handler))
            {
                FormUrlEncodedContent content = new FormUrlEncodedContent(dic);
                HttpResponseMessage response = http.DeleteAsync(url).Result;
                Console.WriteLine("Status Code is: " + response.StatusCode);
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }

        #endregion


        #region HttpWebRequest and Delete

        private string DeleteWebRequest()
        {
            //string url = "https://localhost:44355/api/users/registerDelete";
            //var postData = "1";

            //string url = "https://localhost:44355/api/users/RegisterNoKeyDelete";
            //var postData = "1";

            var user = new
            {
                UserID = "12",
                UserName = "Tom",
                UserEmail = "afdaaee6576@gmail.com"
            };
            //string url = "https://localhost:44355/api/users/RegisterUserDelete";
            //var postData = JsonHelper.ObjectToString(user);

            var userOther = new
            {
                User = user,
                Info = "this is muti model"
            };
            string url = "https://localhost:44355/api/users/RegisterObjectDelete";
            string postData = Newtonsoft.Json.JsonConvert.SerializeObject(userOther);

            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30 * 1000;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.183 Safari/537.36";
            request.ContentType = "application/json";
            request.Method = "Delete";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = data.Length;
            Stream postStream = request.GetRequestStream();
            postStream.Write(data,0,data.Length);
            postStream.Close();

            string result = "";
            using (HttpWebResponse res = (request.GetResponse() as HttpWebResponse))
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(),Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }



        #endregion

        #region after logging on and get ticket

        private void AuthorizationDemo()
        {
            string ticket = "";
            {
                string loginUrl = "https://localhost:44355/api/users/Login?Account=Admin&Password=password213";
                HttpClientHandler handler = new HttpClientHandler();

                using (HttpClient http = new HttpClient(handler))
                {
                    HttpResponseMessage response = http.GetAsync(loginUrl).Result;
                    Console.WriteLine("Status Code is: " + response.StatusCode);
                    ticket = response.Content.ReadAsStringAsync().Result
                        .Replace("\"{\\\"Result\\\":true,\\\"Ticket\\\":\\\"", "").Replace("\\\"}\"", "");

                    //string ticket2 = JsonHelper
                }
            }
            {
                string loginUrl = "https://localhost:44355/api/users/GetUserByName?username=superman";
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(loginUrl);
                request.Timeout = 300 * 1000;
                request.Headers.Add(HttpRequestHeader.Authorization, "BasicAuth " + ticket);
                //request.UserAgent = "";
                //request.ContentType = "";
                string result = "";
                using (HttpWebResponse res = request.GetResponse() as HttpWebResponse)
                {
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                        result = reader.ReadToEnd();
                    }
                }
            }


            {
                string loginUrl = "https://localhost:44355/api/users/GetUserByName?username=superman";
                HttpClientHandler handler = new HttpClientHandler();

                using (HttpClient http = new HttpClient(handler))
                {
                    http.DefaultRequestHeaders.Add("Authorization","BasicAuth "+ ticket);
                    HttpResponseMessage response = http.GetAsync(loginUrl).Result;
                    Console.WriteLine("Status Code is: " + response.StatusCode);
                    string result = response.Content.ReadAsStringAsync().Result;
                }
            }


        }
        #endregion












    }
}
