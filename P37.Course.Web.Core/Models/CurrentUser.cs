using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace P37.Course.Web.Core.Models
{
    //this is business model, not database model.
    public class CurrentUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public bool State { get; set; }

        public DateTime LoginTime { get; set; }
        public DateTime CreateTime { get; set; }

        public List<Data> Datas { get; set; }
    }

    public class Data
    {
        public string CompanyID { get; set; }
        public string Company { get; set; }
    }
}