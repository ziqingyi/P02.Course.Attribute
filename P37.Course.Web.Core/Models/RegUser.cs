using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace P37.Course.Web.Core.Models
{
    //business model is not same to database model
    public class RegUser
    {
        public int UserId { get; set; }

        [DisplayName("RegAccount")]
        [Required(ErrorMessage = "account( {0}  ) cannot be empty")]
        [StringLength(12, MinimumLength = 6,ErrorMessage = "{0} len [{2},{1}]")]
        public string Account { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "password ({0}) cannot be empty")]
        [Compare("Password2", ErrorMessage = "{0} are not same to Password1")]
        public string Password1 { get; set; }
        public string Password2 { get; set; }

        [Range(16,50,ErrorMessage = "{0} should be within {1} {2}")]
        public int Age { get; set; }

        //attribute error may lead to the data binding issue. eg. no reg.
        [RegularExpression(@"\w+@\w+.\w+", ErrorMessage = " {0} format is not correct ")]
        [Required(ErrorMessage = "Email ( {0}  ) cannot be empty")]
        public string Email { get; set; }

    }
}
