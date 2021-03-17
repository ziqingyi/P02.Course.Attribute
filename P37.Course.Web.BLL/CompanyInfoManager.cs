using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P37.Course.Web.Core.Models;
using P37.Course.Web.DAL.EF.DBFirst;

namespace P37.Course.Web.BLL
{
    public class CompanyInfoManager
    {


        //get company entity from business logic, convert database model to business model. 
        public List<CompanyModel> GetCompanyBusinessModelList()
        {
            List<CompanyModel> cmlist = new List<CompanyModel>();
            using (advanced7EntitiesDBF context = new advanced7EntitiesDBF())
            {
                var list = context.Company.ToList();
                foreach (var c in list)
                {
                    CompanyModel cm = new CompanyModel();
                    cm.Id = c.Id;
                    cm.Name = c.Name;
                    cmlist.Add(cm);
                }

            }

            return cmlist;
        }




    }
}
