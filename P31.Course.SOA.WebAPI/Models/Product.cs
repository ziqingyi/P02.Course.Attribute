//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace P31.Course.SOA.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int Id { get; set; }
        public string ProName { get; set; }
        public Nullable<System.DateTime> ProCreateOn { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Price { get; set; }
    }
}
