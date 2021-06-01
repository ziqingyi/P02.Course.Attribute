using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P39.Course.dotnetCore.Interface;

namespace P39.Course.dotnetCore.Service
{
    public class CompanyService:BaseService, ICompanyService
    {
        //construct super class first and then subclass.
        public CompanyService(DbContext context):base(context)
        {
           
        }

        public void TestCompanyServiceError()
        {
            throw new NotImplementedException();
        }


    }
}
