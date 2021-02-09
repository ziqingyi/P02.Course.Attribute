﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using P05.Course.ExpressionSty.Extend;
using P33.Course.Model.Models;
using P34.Course.Business.Interface;
using P37.Course.Web.SearchEngines.Interface;
using P37.Course.Web.SearchEngines.Model;
using PagedList;
using Expression = System.Linq.Expressions.Expression;

namespace P37.Course.MVC5.Controllers
{
    public class FourthController : Controller
    {
        #region Identity

        private ICommodityService _commodityService = null;
        private ICategoryService _categoryService = null;
        private ISearchService _searchService = null;
        public FourthController(ICommodityService commodityService, 
            ICategoryService categoryService, ISearchService searchService)
        {
            this._commodityService = commodityService;
            this._categoryService = categoryService;
            this._searchService = searchService;
        }
        #endregion


        #region Index :  Search in EF 

        // GET: Fourth
        private int pageSize = 20;
        //private int pageIndex = 1; no post/get label, so handle both
        public ActionResult Index()
        {
            #region search condition
            string searchString = base.HttpContext.Request.Form["searchString"];
            Expression<Func<JD_Commodity_001, bool>> funcWhere = null;
            IQueryable<JD_Commodity_001> commodityList = this._commodityService.Query<JD_Commodity_001>(c => c.Id < 200);
            if (!string.IsNullOrEmpty(searchString))
            {
                return IndexPaging(searchString,"",1);
            }
            #endregion

            return View(commodityList);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult IndexPaging(string searchString,string url, int? pageIndex)
        {
            Expression<Func<JD_Commodity_001, bool>> funcWhere = null;
            if (!string.IsNullOrEmpty(searchString))
            {
                funcWhere = c => c.Title.Contains(searchString);

                base.ViewBag.SearchString = searchString;

                //P05.Course.ExpressionSty.Extend, combine the expression tree
                //add filter for url column as well. 
                if (!string.IsNullOrEmpty(url))
                {
                    funcWhere = funcWhere.And(c => c.Url.Contains(url));
                    base.ViewBag.Url = url;
                }

                #region no paging and ranking

                //commodityList = this._commodityService.Query<JD_Commodity_001>(funcWhere);
                //return View(commodityList);
                #endregion


                #region paging and ranking

                Expression<Func<JD_Commodity_001, int>> funcOrderby = c => c.Id;
                int index = pageIndex??1;


                PageResult<JD_Commodity_001> commodityPaging =
                    this._commodityService.QueryPage(funcWhere, pageSize, index, funcOrderby, true);

                StaticPagedList<JD_Commodity_001> pageList = new StaticPagedList<JD_Commodity_001>(commodityPaging.DataList, index, pageSize, commodityPaging.TotalCount);

                return View("~/Views/Fourth/IndexPaging.cshtml", pageList);
                #endregion

            }
            else
            {
                return Index();
            }

        }

        #endregion







        #region Lucene Search

        //for using service in other proj, copy system.serviceModel in app.config to Web.config in MVC proj(not Views folder)
        public ActionResult Search()
        {
            PageResult<CommodityModel> result = this._searchService.QueryCommodityPage(1, 20, "3", null, "", "");

            return View();
        }


        #endregion



        #region Create

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.categoryList = BuildCategoryList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Represents an attribute that is used to prevent forgery of a request. Key should be same. 
        public ActionResult Create([Bind(Include = "ProductId, CategoryId, Title, Price, Url, ImageUrl")]JD_Commodity_001 commodity)
        {
            //Bind limited fields from frontend, otherwise some fields may be updated by front end users. 
            string title1 = this.HttpContext.Request.Params["title"];
            string title2 = this.HttpContext.Request.QueryString["title"];
            string title3 = this.HttpContext.Request.Form["title"];
            if (ModelState.IsValid)
            {
                JD_Commodity_001 newCommodity = this._commodityService.Insert(commodity);
                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception("ModelState is not correct ");
            }
        }


        #endregion



        #region Details, Edit and Delte

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new Exception("commodity id needed");
            }
            JD_Commodity_001 commodity = this._commodityService.Find<JD_Commodity_001>(id ?? -1);
            if (commodity == null)
            {
                throw new Exception("Commodity Not Found");
            }

            return View(commodity);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception("commodity id needed");
            }

            JD_Commodity_001 commodity = this._commodityService.Find<JD_Commodity_001>(id ?? -1);
            if (commodity == null)
            {
                throw new Exception("Commodity Not Found");
            }
            ViewBag.categoryList = BuildCategoryList();
            return View(commodity);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw  new Exception("Not Found");
            }

            JD_Commodity_001 commodity = this._commodityService.Find<JD_Commodity_001>(id ?? -1);

            if (commodity == null)
            {
                throw new Exception("Not Found");
            }
            else
            {
                this._commodityService.Delete(commodity);
            }

            return RedirectToAction("Index");
        }


        #endregion




        #region Private Method
        private IEnumerable<SelectListItem> BuildCategoryList()
        {
            var categoryList = this._categoryService.GetChildList();
            if (categoryList.Count() > 0)
            {
                return categoryList.Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = string.Format("{0}_{1}", c.Id, c.Code)
                });
            }
            else
            {
                return null;
            }
        }      

        #endregion




    }
}