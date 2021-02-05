using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P37.Course.Web.SearchEngines.SearchService.AOP;

namespace P37.Course.Web.SearchEngines.SearchService
{
    public class Searcher: ISearcher
    {

        public string QueryCommodityPage(int pageIndex, int pageSize, string keyword, List<int> categoryIdList, string priceFilter, string priceOrderBy)
        {
            ISearcherAOP searcher = SearcherAOPFactory.CreateInstance();
            return searcher.QueryCommodityPage(pageIndex, pageSize, keyword, categoryIdList, priceFilter, priceOrderBy);
        }


    }
}
