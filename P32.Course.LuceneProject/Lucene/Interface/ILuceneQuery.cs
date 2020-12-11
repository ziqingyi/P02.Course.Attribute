using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P32.Course.LuceneProject.Model;

namespace P32.Course.LuceneProject.Lucene.Interface
{
    public interface ILuceneQuery
    {
        /// <summary>
        /// get commodity from query string
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        List<Commodity> QueryIndex(string queryString);

        /// <summary>
        /// get commodity data by page index
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="priceFilter"></param>
        /// <param name="priceOrderBy"></param>
        /// <returns></returns>
        List<Commodity> QueryIndexPage(string queryString, int pageIndex, int pageSize, out int totalCount,
            string priceFilter, string priceOrderBy);
    }
}
