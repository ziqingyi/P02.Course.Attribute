using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P37.Course.Web.BLL;
using P37.Course.Web.Core.Models;
using P37.Course.Web.DAL.EF.DBFirst;

namespace P37.Course.Web.ServiceEF.DBFirst
{
    public class CompanyInfoService
    {
        CompanyInfoManager companyInfoManager = new CompanyInfoManager();
        public List<CompanyModel> GetCompanyList()
        {
            List<CompanyModel> res = companyInfoManager.GetCompanyBusinessModelList();
            return res;
        }

    }
}
