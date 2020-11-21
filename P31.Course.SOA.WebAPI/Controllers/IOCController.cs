using P31.Course.SOA.Interface;
using P31.Course.SOA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using P31.Course.SOA.WebAPI.Utility;
using Unity;

namespace P31.Course.SOA.WebAPI.Controllers
{
    public class IOCController : ApiController
    {
        private IUserService _userService = null;

        public IOCController(IUserService userService)
        {
            this._userService = userService;
        }

        public string Get(int id)
        {
            //// 1 old way
            //IUserService service = new UserService();
            //return service.Query(id);

            ////2 Container
            //IUserService service1 = ContainerFactory.Container.Resolve<IUserService>();
            //object res1 = service1.Query(id);
            //return res1;

            //3 if use container, then all objects should be created with Container. 
            object obj = this._userService.Query(id);
            //must be able to serialize, otherwise will not be displayed in web browser. 
            string SerializedObj = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            return SerializedObj;
        }






    }
}
