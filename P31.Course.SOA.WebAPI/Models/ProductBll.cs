using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P31.Course.SOA.WebAPI.Models
{
    public class ProductBll
    {
        ProductDal dal = new ProductDal();

        public List<Product> GetAllProduct()
        {
            List<Product> productList = dal.GetAllProduct();
            return productList;
        }

    }
}