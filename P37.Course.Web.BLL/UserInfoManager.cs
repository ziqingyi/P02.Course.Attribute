using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P37.Course.Web.Core.Models;
using P37.Course.Web.DAL.EF.DBFirst;

namespace P37.Course.Web.BLL
{
    public class UserInfoManager
    {
        // use P37.Course.Web.DAL.EF.DBFirst to create business logic


        //get business model and save in database
        public bool AddUser(RegUser bmodel)
        {
            using (advanced7EntitiesDBF context = new advanced7EntitiesDBF())
            {
                User newU = new User()
                {
                    Account = bmodel.Account,
                    Password= bmodel.Password1,
                    CompanyId = bmodel.CompanyId
                    //some other fields not same to db
                    ,LastLoginTime = DateTime.Now
                    ,CreateTime = DateTime.Now
                    ,LastModifyTime = DateTime.Now
                };

                context.User.Add(newU);

                bool result = context.SaveChanges() > 0; 
                return result;
            }

           
        }


    }
}
