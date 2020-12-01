using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace P31.Course.SOA.WebAPI.Self
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                HttpSelfHostConfiguration config = new HttpSelfHostConfiguration("http://localhost:7077");
                config.Routes.MapHttpRoute("DefaultApi",
                    "api/{controller}/{id}",
                    new {id = RouteParameter.Optional});

                using (HttpSelfHostServer server = new HttpSelfHostServer(config))
                {
                    server.OpenAsync().Wait();
                    Console.WriteLine("Server started.....");
                    Console.WriteLine("Type in any character..");
                    Console.Read();
                    server.CloseAsync().Wait();
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }


    }
}
