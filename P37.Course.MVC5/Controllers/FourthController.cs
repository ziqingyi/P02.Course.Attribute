using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using P33.Course.Model.Models;
using P34.Course.Business.Interface;
using PagedList;
using Expression = System.Linq.Expressions.Expression;

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
        private int pageSize = 20;
        private int pageIndex = 1;
        public ActionResult Index()
        {
            #region search condition
            string searchString = base.HttpContext.Request.Form["searchString"];
            Expression<Func<JD_Commodity_001, bool>> funcWhere = null;
            IQueryable<JD_Commodity_001> commodityList = this._commodityService.Query<JD_Commodity_001>(c => c.Id < 200);
            if (!string.IsNullOrEmpty(searchString))
            {
                return IndexPaging(searchString);
            }
            #endregion

            return View(commodityList);
        }

        public ActionResult IndexPaging(string searchString)
        {
            Expression<Func<JD_Commodity_001, bool>> funcWhere = null;
            if (!string.IsNullOrEmpty(searchString))
            {
                funcWhere = c => c.Title.Contains(searchString);

                base.ViewBag.SearchString = searchString;

                #region no paging and ranking

                //commodityList = this._commodityService.Query<JD_Commodity_001>(funcWhere);
                //return View(commodityList);
                #endregion


                #region paging and ranking

                Expression<Func<JD_Commodity_001, int>> funcOrderby = c => c.Id;

                PageResult<JD_Commodity_001> commodityPaging =
                    this._commodityService.QueryPage(funcWhere, pageSize, pageIndex, funcOrderby, true);

                StaticPagedList<JD_Commodity_001> pageList = new StaticPagedList<JD_Commodity_001>(commodityPaging.DataList, pageIndex, pageSize, commodityPaging.TotalCount);

                return View("~/Views/Fourth/IndexPaging.cshtml", pageList);
                #endregion

            }
            else
            {
                return Index();
            }

            
        }






    }
}