using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P34.Course.Business.Interface;
using P37.Course.Web.Core.Utility;
using Unity;

namespace P37.Course.MVC5.Controllers
{
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



        #endregion


        #region Exception Methods

        public ActionResult Exception()
        {
            int i = 0;
            int k = 10 / i;
            return View();
        }

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




        #endregion



        #region Other
        public ActionResult Index()
        {
            return View();
        }
        
        #endregion

    }
}