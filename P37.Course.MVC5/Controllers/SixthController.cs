﻿using P34.Course.Business.Interface;
using P37.Course.Web.Core.Filters;
using P37.Course.Web.Core.FiltersTest;
using P37.Course.Web.Core.Utility;
using System;
using System.Web.Mvc;
using Unity;

namespace P37.Course.MVC5.Controllers
{
    [CustomControllerTestActionFilterAttribute]
    public class SixthController : Controller
    {
        #region Identity
        private Logger logger = new Logger(typeof(SixthController));

        private IUserService _iUserService = null;
        private ICompanyService _iCompanyService = null;
        private IUserCompanyService _iUserCompanyService = null;


        /// <summary>
        /// ctor function injection --controller is initialized by container
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="companyService"></param>
        /// <param name="userCompanyService"></param>
        [InjectionConstructor]//container will use this ctor
        public SixthController(IUserService userService, ICompanyService companyService,
            IUserCompanyService userCompanyService)
        {
            this._iUserService = userService;
            this._iCompanyService = companyService;
            this._iUserCompanyService = userCompanyService;
        }

        #endregion

        #region Index
        
        public ActionResult Index()
        {
            return View();
        }

        [CompressActionFilter]
        public ActionResult IndexCompressed()
        {
            return View();
        }

        //
        [CacheFilter]
        public ActionResult IndexCache()
        {
            return View();
        }

        #endregion


        #region Exception Condition
        /*   ---ControllerActionInvoker Execute InvokeAction, try and catch these
         * 1 error in action logic    ---T
         * 2 error in action logic but already being caught ---F
         * 3 error in Service   logic               T
         * 4 error in View                     T
         *
         *
         * 5 error in controller ctor  F   ---ControllerActionInvoker Execute InvokeAction after controller created.
         * 6 error in controller name    F
         * 7 error in wrong url address      F
         * 8 Authorization Filter error.    T   Inside try-catch
         */


        #endregion

        #region Exception Methods

        //1 test error in action
        //[CustomHandleErrorAttribute]
        public ActionResult Exception()
        {
            int i = 0;
            int k = 10 / i;
            return View();
        }
        //2 test browser cache, open new page, not refreshing. notes in evernote.
        public ActionResult ExceptionCatch()
        {
            try
            {
                int i = 0;
                int k = 10 / i;
            }
            catch (Exception e)
            {
                this.logger.Error(e.Message);
            }

            return View();

        }
        //3 test error in service 
        public ActionResult ExceptionService()
        {
            this._iCompanyService.TestCompanyServiceError();
            return View();
        }
        //4 error in view
        public ActionResult ExceptionView()
        {
            return View();
        }

        //test error in authorize attribute
        [CustomTestErrorAuthorizeAttribute]
        public ActionResult ExceptionAuthorize()
        {
            return View();
        }

        #endregion





        #region  tests in filters

        [CustomActionFilter]
        public ActionResult ShowActionFilter()
        {
            return View();
        }
        //                                                     OnException is global
        //1 IAuthorizationFilter  -> OnAuthorization()     
        //2 IActionFilter         -> OnActionExecuting()
        //3      Action
        //4 IActionFilter         -> OnActionExecuted() 

        //5 IResultFilter         -> OnResultExecuting()  //result will be executed event it's void,string.
        //6 View
        //7 IResultFilter         -> OnResultExecuted()

        //8    *IExceptionFilter    ->OnException  //happens when error
        //
        // just like: var result = Action.Invoke();
        //             result.ExecuteResult();


        //for authorize
        //Controller   ->  IAuthorizationFilter  ->  OnAuthorization
        //    Action   ->  IAuthorizationFilter  ->  OnAuthorization

        //action and result methods are same 
        /// Global OnActionExecuting
        /// Controller OnActionExecuting
        /// Action OnActionExecuting
        ///        Action Execute.....
        /// Action OnActionExecuted
        /// Controller OnActionExecuted
        /// Global OnActionExecuted

        //for result methods 
        //Controller->IResultFilter          ->OnResultExecuting
        //    Action     ->IResultFilter          ->OnActionExecuting
        //    Action     ->IResultFilter          ->OnActionExecuted
        //Controller->IResultFilter          ->OnActionExecuted



        //for attributes in same methods, execute from top to bottom, if there is no order
        //assign order: smaller, first: order by Order asc
        [CustomActionTestActionFilter(Order = 2)]
        [CustomActionFilter(Order=1)]
        public ActionResult ShowTestFilters()
        {
            return View();
        }


        #endregion

    }
}