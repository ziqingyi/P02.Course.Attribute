using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P37.Course.Web.Core.Models
{
    public class CompanyModel
    {
        [DisplayName("company id")]
        public int Id { get; set; }
        [DisplayName("company name")]
        public string Name { get; set; }
    }
}
