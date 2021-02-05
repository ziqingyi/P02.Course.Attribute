using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P37.Course.Web.SearchEngines.SearchService.AOP.Attribute;

namespace P37.Course.Web.SearchEngines.SearchService.AOP
{
    public interface ISearcherAOP
    {
        /// <summary>
        /// get commodity info by page
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyword"></param>
        /// <param name="categoryIdList">category id list, can be null</param>
        /// <param name="priceFilter">[13,50]  13,50 include 13 and 50   {13,50}  13,50 exclude 13 to 50</param>
        /// <param name="priceOrderBy">price desc   price asc</param>
        /// <returns>PageResult Commodity to json</returns>
        [LogHandlerAttribute(Order = 2)]
        [ExceptionHandler(Order = 3)]
        [AfterLogHandlerAttribute(Order = 5)]
        string QueryCommodityPage(int pageIndex, int pageSize, string keyword, List<int> categoryIdList, string priceFilter, string priceOrderBy);
    }
}
