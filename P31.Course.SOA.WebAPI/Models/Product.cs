using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P31.Course.SOA.WebAPI.Models
{
    public class Product
    {
        public int ProId { get; set; }
        public string ProName { get; set; }
        public DateTime ProCreateOn { get; set; }
        public string CategoryId { get; set; }
        public string Price { get; set; }
    }
}