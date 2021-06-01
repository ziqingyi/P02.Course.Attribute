using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace P39.Course.dotnetCore.Interface
{
    public interface IUserCompanyService:IBaseService
    {
        bool RemoveCompanyAndUser(int companyId);
    }
}
