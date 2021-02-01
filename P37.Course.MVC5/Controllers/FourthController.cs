using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using P33.Course.Model.Models;
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
            string searchString = base.HttpContext.Request.Form["searchString"];
            Expression<Func<JD_Commodity_001, bool>> funcWhere = null;
            var commodityList = this._commodityService.Query<JD_Commodity_001>(c => c.Id < 2);
            if (!string.IsNullOrEmpty(searchString))
            {
                funcWhere = c => c.Title.Contains(searchString);
                commodityList = this._commodityService.Query<JD_Commodity_001>(funcWhere);

                base.ViewBag.SearchString = searchString;
            }
           

            return View(commodityList);
        }




    }
}