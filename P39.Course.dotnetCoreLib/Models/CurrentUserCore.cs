using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P39.Course.dotnetCoreLib.Models
{

    //this is business model, not database model.
    [MappingClass("User")]
    public class CurrentUserCore
    {
        public int Id { get; set; }
        [DisplayName("User Name")]
        public string Name { get; set; }
        public string Account { get; set; }

        [DisplayName("User Password")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public bool State { get; set; }

        public DateTime LastLoginTime { get; set; }
        public DateTime CreateTime { get; set; }

        public List<Data> Datas { get; set; }
    }
    public class Data
    {
        public string CompanyID { get; set; }
        public string Company { get; set; }
    }
}
