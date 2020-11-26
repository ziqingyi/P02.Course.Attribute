using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace P31.Course.SOA.WebAPI.Models
{
    public class ProductEntity:DbContext
    {

        public DbSet<Product> Products { get; set; }

 

    }
}