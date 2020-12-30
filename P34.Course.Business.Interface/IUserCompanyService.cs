using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P33.Course.Model.Models;

namespace P34.Course.Business.Interface
{
    public interface IUserCompanyService:IBaseService
    {
        bool RemoveCompanyAndUser(int companyId);
    }
}
