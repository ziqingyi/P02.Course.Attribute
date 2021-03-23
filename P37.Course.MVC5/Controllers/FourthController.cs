using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Microsoft.Ajax.Utilities;
using P05.Course.ExpressionSty.Extend;
using P33.Course.Model.Models;
using P34.Course.Business.Interface;
using P37.Course.Web.Core.Models;
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
            // search by expression, no search string , default 
            Expression<Func<JD_Commodity_001, bool>> funcWhere = c => c.Id < 200;
            IQueryable<JD_Commodity_001> commodityList = this._commodityService.Query<JD_Commodity_001>(funcWhere); 
            
            //search by search string from [form], and make pages if there search string is not empty
            string searchStringFromForm = base.HttpContext.Request.Form["searchString"];//null

            string searchStringFromUrl = base.HttpContext.Request["searchString"];//null


            if (!string.IsNullOrEmpty(searchStringFromForm))
            {
                return IndexPaging(searchStringFromForm, "",1);
            }
            #endregion

            return View(commodityList);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult IndexPaging(string searchString,string url, int? pageIndex)
        {
            string searchStringFromForm = base.HttpContext.Request.Form["searchString"];//

            string searchStringFromUrl = base.HttpContext.Request["searchString"];//

            Expression<Func<JD_Commodity_001, bool>> funcWhere = null;
            if (!string.IsNullOrEmpty(searchString)|| !string.IsNullOrEmpty(url))
            {
                #region get search string and prepare expression tree for filtering data

                //P05.Course.ExpressionSty.Extend, combine the expression tree for filtering 
                // can also have a separate project to assemble the expression tree
                if (!string.IsNullOrEmpty(searchString))
                {
                    funcWhere= c => c.Title.Contains(searchString);
                    //put search string back to ViewBag, will pass to form text box again.
                    base.ViewBag.SearchString = searchString;
                }

                //can also add filter for url column as well. 
                if (!string.IsNullOrEmpty(url))
                {
                    funcWhere = funcWhere.And(c => c.Url.Contains(url));
                    //put search string back to ViewBag, will pass to form text box again.
                    base.ViewBag.Url = url;
                }

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

                #region no paging and ranking

                funcWhere = c => c.Id < 2000;
                Expression<Func<JD_Commodity_001, int>> funcOrderby = c => c.Id;
                int index = pageIndex ?? 1;

                PageResult<JD_Commodity_001> commodityList = this._commodityService.QueryPage(funcWhere,pageSize,index, funcOrderby, true);

                StaticPagedList<JD_Commodity_001> pageList = new StaticPagedList<JD_Commodity_001>(commodityList.DataList,index,pageSize,commodityList.TotalCount);

                return View(pageList);
                #endregion

            }

        }

        #endregion



        #region Lucene Search

        //for using service in other proj, copy system.serviceModel in app.config to Web.config in MVC proj(not Views folder)
        public ActionResult Search()
        {
            //key word should not be a number eg.3
            PageResult<CommodityModel> result = this._searchService.QueryCommodityPage(1, 20, "book", null, "", "");

            return View();
        }

        public ActionResult SearchIndex()
        {
            ViewBag.FirstCategory = BuildCategoryList(this._categoryService.CacheAllCategory().Where(c =>c.CategoryLevel == 1));
            ViewBag.SecondCategory = BuildCategoryList(null);
            ViewBag.ThirdCategory = BuildCategoryList(null);
            return View();
        }


        //[ChildActionOnly]//ajax is independent request, so this method should be accessible outside. 
        public ActionResult SearchPartialList(string searchString, int pageIndex = 1, int firstCategory = -1,
            int secondCategory = -1, int thirdCategory = -1)
        {
            int id = thirdCategory == -1
                ? secondCategory == -1 ? firstCategory == -1 ? -1 : firstCategory : secondCategory
                : thirdCategory;
            if (id == -1 && string.IsNullOrWhiteSpace(searchString))
            {
                searchString = "1";
            }

            List<int> categoryIdList = null;
            if (id != -1)
            {
                Category category = this._categoryService.CacheAllCategory().FirstOrDefault(c => c.Id == id);
                if (category != null)
                    categoryIdList = this._categoryService.CacheAllCategory()
                        .Where(c => (c.ParentCode.StartsWith(category.Code) || c.Id == category.Id))
                        .Select(c => c.Id).ToList();
            }

            PageResult<CommodityModel> remoteCommodityList = this._searchService.QueryCommodityPage(pageIndex, pageSize, searchString, categoryIdList, null, null);
            StaticPagedList<CommodityModel> pageList = new StaticPagedList<CommodityModel>(remoteCommodityList.DataList, pageIndex, pageSize, remoteCommodityList.TotalCount);

            return View(pageList);
        }

        #endregion



        #region Create, two request: 1 HTTP Get 2 HTTP Post
        //the parameters may come from url or form submit, so MVC cannot use parameter to distinguish methods WITH same name.
        //must use HttpVerbs. 

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.categoryList = BuildCategoryList();

            return View(new JD_Commodity_001());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Represents an attribute that is used to prevent forgery of a request. Key in the session should be same. 
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
        //Bind: only accept these fields from front end. 
        [HttpPost]
        public ActionResult AjaxCreate([Bind(Include = "ProductId, CategoryId, Title, Price, Url, ImageUrl")]
            JD_Commodity_001 commodity)
        {
            JD_Commodity_001 newCommodity = this._commodityService.Insert(commodity);
            AjaxResult ajaxResult = new AjaxResult()
            {
                Result = DoResult.Success,
                PromptMsg = "Insert Successfully"
            };
            return Json(ajaxResult);
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


        [HttpPost]
        public JsonResult AjaxDelete(int id)
        {
            this._commodityService.Delete<JD_Commodity_001>(id);
            AjaxResult ajaxResult = new AjaxResult()
            {
                Result = DoResult.Success,
                PromptMsg = "delete successfully"
            };
            return Json(ajaxResult);
        }


        #endregion


        #region Ajax request
        public JsonResult CategoryDropdown(int id = -1)
        {
            Category category = this._categoryService.CacheAllCategory().FirstOrDefault(c => c.Id == id);
            AjaxResult ajaxResult = new AjaxResult();
            if (category != null)
            {
                var categoryList = this._categoryService.CacheAllCategory()
                    .Where(c => c.ParentCode.Equals(category.Code));

                ajaxResult.RetValue = BuildCategoryList(categoryList);
                ajaxResult.Result = DoResult.Success;
            }
            else
            {
                ajaxResult.Result = DoResult.Failed;
                ajaxResult.PromptMsg = "Search category failed";
            }

            return Json(ajaxResult);
        }

        #endregion


        #region Private Method

        private IEnumerable<SelectListItem> BuildCategoryList(IEnumerable<Category> categoryList)
        {
            List<SelectListItem> selectList = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Selected = true,
                    Text = "--Please Select--",
                    Value="-1"
                }
            };
            if (categoryList != null && categoryList.Count() > 0)
            {
                selectList.AddRange(
                    categoryList.Select(c => new SelectListItem()
                    {
                        Selected = false,
                        Text = c.Name,
                        Value = c.Id.ToString()
                    })
                );
            }
            return selectList;
        }


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



        #region test return
        //content type is application/json
        public JsonResult JsonResultIn()
        {
            return Json(new AjaxResult()
            {
                Result = DoResult.Success,
                DebugMessage =  "this is JsonResult"
            }, JsonRequestBehavior.AllowGet);
        }

        public NewtonJsonResult JsonResultNewton()
        {
            return new NewtonJsonResult(new AjaxResult()
            {
                Result = DoResult.Success,
                DebugMessage = "this is Newton JsonResult"
            });
        }

        //content type is empty. so return default format HTML 
        //string don't have ExecuteResult method, so framework will pass it to stream for browser automatically. 
        public string JsonResultString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new AjaxResult()
            {
                Result = DoResult.Success,
                DebugMessage = "this is Json Result String"
            });
        }

        public void JsonResultVoid()
        {
            string res = Newtonsoft.Json.JsonConvert.SerializeObject(new AjaxResult()
            {
                Result = DoResult.Success,
                DebugMessage = "this is Json Result Void"
            });
            HttpResponseBase response = base.HttpContext.Response;
            response.ContentType = "application/json";
            response.Write(res);
        }

        public XmlResultXML XmlResult()
        {

            return new XmlResultXML(new AjaxResult()
            {
                Result = DoResult.Success,
                DebugMessage = "This is Xml Result"
            });

        }



        #endregion





    }
}
//test some new return type
//if the return type is a derived class from ActionResult, MVC will execute the ExecuteResult method, 
//and write serialized data to HttpResponseBase. and assign the content type
//if the return type is not from ActionResult, then return the data as HTML

public class NewtonJsonResult : ActionResult
{
    private object _data = null;

    public NewtonJsonResult(object data)
    {
        this._data = data;
    }
    //Newtonsoft's JsonConvert has better performance than JavaScriptSerializer
    public override void ExecuteResult(ControllerContext context)
    {
        HttpResponseBase response = context.HttpContext.Response;
        response.ContentType = "application/json";
        response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(this._data));
    }

}

public class XmlResultXML : ActionResult
{
    private object _data = null;
    public XmlResultXML(object data)
    {
        this._data = data;
    }

    public override void ExecuteResult(ControllerContext context)
    {
        HttpResponseBase response = context.HttpContext.Response;
        response.ContentType = "application/xml";
        
        XmlSerializer serializer = new XmlSerializer(_data.GetType());
        serializer.Serialize(response.Output, _data);


    }


}




























