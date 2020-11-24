using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P29.Course.SOA.UnitTestProject
{

    public class HttpClientFactory
    {
        private static HttpClient _httpClient = null;

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
            var result = this.GetClient();

            //var result2 = this.GetWebRequest();

        }

        #region HttpClient Get
        private string GetClient()
        {
            string url = "https://localhost:44355/api/users/GetUserByName?username=Superman";
            //string url = "https://localhost:44355/api/users/GetUserByID?id=1";
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

        

        #endregion



    }
}
