using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using P32.Course.LuceneProject.Lucene.Interface;
using P32.Course.LuceneProject.Model;
using P32.Course.LuceneProject.Utility;
using Version = Lucene.Net.Util.Version;

namespace P32.Course.LuceneProject.Lucene.Service
{
    public class LuceneQuery: ILuceneQuery
    {
        #region Identity

        private Logger logger = new Logger(typeof(LuceneQuery));

        #endregion

        #region QueryIndex
        /// <summary>
        /// Get commodity List
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public List<Commodity> QueryIndex(string queryString)
        {
            IndexSearcher searcher = null;
            try
            {
                List<Commodity> ciList = new List<Commodity>();
                Directory dir = FSDirectory.Open(StaticConstant.IndexPath);
                searcher = new IndexSearcher(dir);
                Analyzer analyzer = new PanGuAnalyzer();

                //---------------configure search condition
                QueryParser parser = new QueryParser(Version.LUCENE_30,"title", analyzer);
                Query query = parser.Parse(queryString);
                Console.WriteLine("the query is : {0}", query.ToString());
                TopDocs docs = searcher.Search(query, (Filter) null, 10000);

                foreach (ScoreDoc sd in docs.ScoreDocs)
                {
                    Document doc = searcher.Doc(sd.Doc);
                    ciList.Add(DocumentToCommodityInfo(doc));
                }
                return ciList;
            }
            finally
            {
                if (searcher != null)
                {
                    searcher.Dispose();
                }
            }
        }


        public List<Commodity> QueryIndexPage(string queryString, int pageIndex, int pageSize,
            out int totalCount, string priceFilter, string priceOrderBy)
        {
            totalCount = 0;
            IndexSearcher searcher = null;
            try
            {
                List<Commodity> ciList = new List<Commodity>();
                FSDirectory dir = FSDirectory.Open(StaticConstant.IndexPath);
                searcher = new IndexSearcher(dir);
                Analyzer analyzer = new PanGuAnalyzer();

                //--------------------config search index
                QueryParser parser = new QueryParser(Version.LUCENE_30, "title", analyzer);
                Query query = parser.Parse(queryString);

                pageIndex = Math.Max(1, pageIndex);
                int startIndex = (pageIndex - 1) * pageSize;
                int endIndex = pageIndex * pageSize;

                NumericRangeFilter<float> numPricefilter = null;
                if (!string.IsNullOrWhiteSpace(priceFilter))
                {
                    bool isContainStart = priceFilter.StartsWith("[");
                    bool isContainEnd = priceFilter.EndsWith("]");
                    string[] floatArray = priceFilter.Replace("", "")
                        .Replace("[", "")
                        .Replace("]", "")
                        .Replace("{", "")
                        .Replace("}", "")
                        .Split(',');

                    float start = 0;
                    float end = 0;
                    if (!float.TryParse(floatArray[0], out start) || !float.TryParse(floatArray[1], out end))
                    {
                        throw new Exception("Wrong PriceFilter");
                    }

                    numPricefilter = NumericRangeFilter.NewFloatRange("price", start, end, isContainStart, isContainEnd);
                }

                Sort sort = new Sort();
                if (!string.IsNullOrWhiteSpace(priceOrderBy))
                {
                    SortField sortField = new SortField("price", SortField.FLOAT,priceOrderBy.EndsWith("asc", StringComparison.CurrentCultureIgnoreCase));
                    sort.SetSort(sortField);
                }

                TopDocs docs = searcher.Search(query, numPricefilter, 10000, sort);

                totalCount = docs.TotalHits;

                for (int i = startIndex; i < endIndex && i < totalCount; i++)
                {
                    Document doc = searcher.Doc(docs.ScoreDocs[i].Doc);
                    ciList.Add(DocumentToCommodityInfo(doc));
                }
                return ciList;
            }
            finally
            {
                if (searcher != null)
                {
                    searcher.Dispose();
                }
            }
        }

        private void PrintScore(TopDocs docs, int startIndex, int endIndex, MultiSearcher searcher)
        {
            ScoreDoc[] scoreDocs = docs.ScoreDocs;
            for (int i = 0; i < endIndex && i < scoreDocs.Length; i++)
            {
                int docId = scoreDocs[i].Doc;
                Document doc = searcher.Doc(docId);
                logger.Info(string.Format("{0} has score: {1}", doc.Get("productId"), scoreDocs[i].Score));
            }

        }



        #endregion

        #region Private

        private Commodity DocumentToCommodityInfo(Document doc)
        {
            Commodity commodity = new Commodity();
            commodity.Id = int.Parse(doc.Get("id"));
            commodity.Title = doc.Get("title");
            commodity.ProductId = long.Parse(doc.Get("productId"));
            commodity.CategoryId = int.Parse(doc.Get("categoryId"));
            commodity.ImageUrl = doc.Get("ImageUrl");
            commodity.Price = decimal.Parse(doc.Get("Price"));
            commodity.Url = doc.Get("url");

            return commodity;
        }

        #endregion



    }
}
