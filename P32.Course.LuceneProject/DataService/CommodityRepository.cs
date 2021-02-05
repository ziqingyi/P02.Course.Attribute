using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P32.Course.LuceneProject.Model;
using P32.Course.LuceneProject.Utility;

namespace P32.Course.LuceneProject.DataService
{
    public class CommodityRepository
    {
        private Logger logger = new Logger(typeof(CommodityRepository));
        public void SaveList(List<Commodity> commodityList)
        {
            if (commodityList == null || commodityList.Count == 0) return;

            IEnumerable<IGrouping<string, Commodity>> group = commodityList.GroupBy<Commodity, string>(c => GetTableName(c));

            foreach (var data in group)
            {
                SqlHelper.InsertList<Commodity>(data.ToList(), data.Key);
            }
        }

        private string GetTableName(Commodity commodity)
        {
            string tbName = string.Format("JD_Commodity_{0}", (commodity.ProductId % 30 + 1).ToString("000"));
            return tbName;
        }

        /// <summary>
        /// paging
        /// </summary>
        /// <param name="tableNum"></param>
        /// <param name="pageIndex"> from page 1 </param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Commodity> QueryList(int tableNum, int pageIndex, int pageSize)
        {
            string num = tableNum.ToString("000");

            int StartId = pageSize * Math.Max(0, pageIndex - 1) + 1;

            string sql = string.Format("SELECT top {1} * FROM JD_Commodity_001 WHERE ProductId >={0};", StartId, pageSize);

            List<Commodity> resultList = SqlHelper.QueryList<Commodity>(sql);
            return resultList;
        }


    }
}
