using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P34.Course.Business.Interface;
using P37.Course.Web.Core.Filters;
using P37.Course.Web.Core.FiltersTest;
using P37.Course.Web.Core.Utility;
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
        //2 
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



        #region Other
        public ActionResult Index()
        {
            return View();
        }

        [CustomActionFilter]
        [CustomActionTestActionFilter]
        public ActionResult ShowActionFilter()
        {
            return View();
        }



        #endregion

    }
}