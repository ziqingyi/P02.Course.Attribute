using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P37.Course.Web.Core.Models;

namespace P39.Course.dotnetCore.TestMVC.Controllers
{
    public class AFirstController : Controller
    {
        public IActionResult Index(int? id)
        {
            base.ViewData["User1"] = new CurrentUser
            {
                Id = 1,
                Name = "User1",
                Account = "User1Administrator",
                Email = "111111@qq.com",
                LastLoginTime = DateTime.Now,
                Password = "123drd",
                Datas = new List<Data>()
                {
                    new Data() {Company = "company1"},
                    new Data() {Company = "company_a"}
                }
            };
            base.ViewData["Something"] = 12345;

            base.ViewBag.Name = "Admin";
            base.ViewBag.Description = "Teacher";
            base.ViewBag.User = new CurrentUser()
            {
                Id = 2,
                Name = "User2",
                Account = "User2Administrator",
                Email = "222222@qq.com",
                LastLoginTime = DateTime.Now.AddMonths(-2),
                Password = "123ljlji",
                Datas = new List<Data>()
                {
                    new Data() {Company = "company2"},
                    new Data() {Company = "company_b"}
                }
            };


            //TempData uses Session, which itself uses IDistributedCache.
            //IDistributedCache doesn't have the capability to accept objects or to serialize objects.
            //As a result, you need to do this yourself
            //Then, of course, after redirecting, you'll need to deserialize it back into the object you need
            string SerializedUser = JsonConvert.SerializeObject(
                new CurrentUser()
            {
                Id = 3,
                Name = "User3",
                Account = "User3Administrator",
                Email = "33333@qq.com",
                LastLoginTime = DateTime.Now.AddDays(-5),
                Password = "1ljkll56",
                Datas = new List<Data>()
                {
                    new Data() {Company = "company3"},
                    new Data() {Company = "company_c"}
                }
            }
                );

            base.TempData["User"] = SerializedUser;

            if (id == null)
            {
                return base.RedirectToAction("TempDataPage");
            }
            else
            {

                CurrentUser user5 = new CurrentUser(){

                    Id = 3,
                    Name = "User5",
                    Account = "User5Administrator",
                    Email = "55555@gmail.com",
                    LastLoginTime = DateTime.Now.AddDays(-1),
                    Password = "1ljkll56",
                    Datas = new List<Data>()
                    {
                        new Data() {Company = "company5"},
                        new Data() {Company = "company_c"}
                    }

                };


                return View(user5);
            }


        }



        public ActionResult TempDataPage()
        {
            base.ViewBag.User = JsonConvert.DeserializeObject<CurrentUser>(base.TempData["User"].ToString());

            return View();
        }




        /*
         *
         1 This changed totally from asp.net to asp.net core ? – BrilBroeder Jun 13 '19 at 6:24
         
2  Yes and no. The difference is that MVC would default to in-memory session storage, 
which just happens to not require serialization, 
and then you'd get an exception when you tried to switch to a different session store.

While Core defaults to in-memory backing as well, 
the IDistributedCache interface ensures that all session stores behave the same, 
i.e. requiring serialization of complex objects. 

In short, you only don't have to serialize when using in-memory sessions, 
but in-memory sessions should never be used in production.
As such, Core actually prepares you for the real world, whereas MVC did not. – Chris Pratt Jun 13 '19 at 10:18

          3 What's wrong with using InMemory sessions in production? – NickG Jun 12 '20 at 12:58

4 Memory is RAM, which is volatile. If the app stops or the server it's running on restarts, then everything stored there is gone. 

Additionally, memory is process restricted. 

If you run multiple instances of your app such a with containers or a web farm in IIS, 
then each instance has its own memory allocation, and thus its own session storage. – Chris Pratt Jun 12 '20 at 13:04 

If you use in memory sessions in production, you'll have both volatile sessions and no ability to scale, 
both of which are not good for production. – Chris Pratt Jun 12 '20 at 13:07
         *
         *
         */










    }
}
