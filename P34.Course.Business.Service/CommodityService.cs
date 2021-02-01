using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P34.Course.Business.Interface;

namespace P34.Course.Business.Service
{
    public class CommodityService:BaseService, IBaseService
    {
        public CommodityService(DbContext context) : base(context)
        {

        }

    }
}
