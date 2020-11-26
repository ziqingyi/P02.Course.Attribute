using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P31.Course.SOA.WebAPI.Models
{
    public class ProductDal
    {
        ProductEntity entity = new ProductEntity();
        /// <summary>
        /// get product list
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProduct()
        {
            List<Product> resList = entity.Products.ToList();
            return resList;
        }

    }
}