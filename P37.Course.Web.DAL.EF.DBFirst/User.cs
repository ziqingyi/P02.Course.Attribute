//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace P37.Course.Web.DAL.EF.DBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int State { get; set; }
        public int UserType { get; set; }
        public Nullable<System.DateTime> LastLoginTime { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public Nullable<int> LastModifierId { get; set; }
        public Nullable<System.DateTime> LastModifyTime { get; set; }
    }
}
