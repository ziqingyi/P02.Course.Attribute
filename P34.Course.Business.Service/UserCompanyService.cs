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
    public class UserCompanyService : BaseService,IUserCompanyService
    {
        public UserCompanyService(DbContext context) : base(context)
        {

        }

        public bool RemoveCompanyAndUser(int companyId)
        {
            return true;
        }

        public override void Dispose()
        {
            Console.WriteLine("dispose sth else");
            base.Dispose();
        }
    }
}
