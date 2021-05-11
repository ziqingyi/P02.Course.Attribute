using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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


            base.TempData["User"] = new CurrentUser()
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
            };

            if (id == null)
            {
                return this.Redirect("~/AFirst/TempDataPage");
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
            base.ViewBag.User = base.TempData["User"];

            return View();
        }















    }
}
