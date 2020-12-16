using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P32.Course.LuceneProject.Lucene.Interface;
using P32.Course.LuceneProject.Lucene.Service;
using P32.Course.LuceneProject.Model;
using P32.Course.LuceneProject.Utility;

namespace P32.Course.LuceneProject.DataService
{
    public class CommodityLucene
    {
        private static Logger logger = new Logger(typeof(CommodityLucene));

        #region query commodity

        public static List<Commodity> QueryCommodity(int pageIndex, int pageSize, out int totalCount, string keyword, List<int> categoryIdList, string priceFilter, string priceOrderBy)
        {
            totalCount = 0;
            try
            {
                if (string.IsNullOrWhiteSpace(keyword) && (categoryIdList == null || categoryIdList.Count == 0)) return null;
                ILuceneQuery luceneQuery = new LuceneQuery();
                string queryString = string.Format(" {0} {1}",
                    string.IsNullOrWhiteSpace(keyword) ? "" : string.Format(" +{0}", AnalyzerKeyword(keyword)),
                    categoryIdList == null || categoryIdList.Count == 0 ? "" : string.Format(" +{0}", AnalyzerCategory(categoryIdList)));

                return luceneQuery.QueryIndexPage(queryString, pageIndex, pageSize, out totalCount, priceFilter, priceOrderBy);
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("QueryCommodity with keyword: {0} has exception", keyword), ex);
                return null;
            }
        }

        #endregion

        /// <summary>
        /// analyze key word using LuceneAnalyze(Pan gu)
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        private static string AnalyzerKeyword(string keyword)
        {
            StringBuilder queryStringBuilder = new StringBuilder();
            ILuceneAnalyze analyzer = new LuceneAnalyze();
            string[] words = analyzer.AnalyzerKey(keyword);
            if (words.Length == 1)
            {
                queryStringBuilder.AppendFormat("{0}:{1}* ", "title", words[0]);
            }
            else
            {
                StringBuilder fieldQueryStringBuilder = new StringBuilder();
                foreach (string word in words)
                {
                    queryStringBuilder.AppendFormat("{0}:{1} ", "title", word);
                }
            }
            string result = queryStringBuilder.ToString().TrimEnd();
            logger.Info(string.Format("AnalyzerKeyword 将 keyword={0}转换为{1}", keyword, result));
            return result;
        }


        /// <summary>
        /// analyze by category
        /// </summary>
        /// <param name="categoryIdList"></param>
        /// <returns></returns>
        private static string AnalyzerCategory(List<int> categoryIdList)
        {
            return string.Join(" ", categoryIdList.Select(c => string.Format("{0}:{1}", "categoryid", c)));
        }


    }
}
