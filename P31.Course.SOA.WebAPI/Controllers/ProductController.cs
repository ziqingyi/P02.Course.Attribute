using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using P31.Course.SOA.WebAPI.Models;

namespace P31.Course.SOA.WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        ProductBll bll = new ProductBll();

        public List<Product> GetAllProducts()
        {
            return bll.GetAllProduct();
        }

    }
}
