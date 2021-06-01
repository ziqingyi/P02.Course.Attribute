using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P39.Course.dotnetCore.Interface;

namespace P39.Course.dotnetCore.Service
{
    public class CommodityService:BaseService, ICommodityService
    {
        public CommodityService(DbContext context) : base(context)
        {

        }

    }
}
