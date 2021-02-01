﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P34.Course.Business.Interface;

namespace P37.Course.MVC5.Controllers
{
    public class FourthController : Controller
    {
        private ICommodityService _commodityService = null;
        public FourthController(ICommodityService commodityService)
        {
            this._commodityService = commodityService;
        }



        // GET: Fourth
        public ActionResult Index()
        {
            return View();
        }




    }
}