using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace P37.Course.Web.SearchEngines.SearchService
{
    [ServiceContract]
    public interface ISearcher
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
        [OperationContract]
        string QueryCommodityPage(int pageIndex, int pageSize, string keyword, List<int> categoryIdList, string priceFilter, string priceOrderBy);
    }
}
