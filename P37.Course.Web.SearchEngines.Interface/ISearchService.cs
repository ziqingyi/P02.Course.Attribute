using P34.Course.Business.Interface;
using P37.Course.Web.SearchEngines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P37.Course.Web.SearchEngines.Interface
{
    public interface ISearchService
    {
        PageResult<CommodityModel> QueryCommodityPage(int pageIndex, int pageSize, string keyword, List<int> categoryIdList, string priceFilter, string priceOrderBy);
    }
}
