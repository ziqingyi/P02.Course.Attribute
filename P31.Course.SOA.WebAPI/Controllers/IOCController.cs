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
        public object Get(int id)
        {
            //old way
            //IUserService service = new UserService();
            //return service.Query(id);

            //Container
            IUserService service = ContainerFactory.Container.Resolve<IUserService>();
            object res = service.Query(id);
            return res;

        }






    }
}
