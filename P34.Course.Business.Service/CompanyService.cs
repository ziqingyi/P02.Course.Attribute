using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P33.Course.Model.Models;
using P34.Course.Business.Interface;

namespace P34.Course.Business.Service
{
    public class CompanyService:BaseService, ICompanyService
    {
        //construct super class first and then subclass.
        public CompanyService(DbContext context):base(context)
        {
           
        }




    }
}
