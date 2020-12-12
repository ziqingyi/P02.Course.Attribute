using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Documents;
using P32.Course.LuceneProject.Lucene.Interface;
using P32.Course.LuceneProject.Model;
using P32.Course.LuceneProject.Utility;

namespace P32.Course.LuceneProject.Lucene.Service
{
    public class LuceneQuery: ILuceneQuery
    {
        #region Identity

        private Logger logger = new Logger(typeof(LuceneQuery));

        #endregion

        #region QueryIndex


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
