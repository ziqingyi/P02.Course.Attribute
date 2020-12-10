using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P32.Course.LuceneProject.Model;
using P32.Course.LuceneProject.Utility;

namespace P32.Course.LuceneProject.DataService
{
    public class CommodityRespository
    {
        private Logger logger = new Logger(typeof(CommodityRespository));
        public void SaveList(List<Commodity> commodityList)
        {
            if (commodityList == null || commodityList.Count == 0) return;

            IEnumerable<IGrouping<string, Commodity>> group = commodityList.GroupBy<Commodity, string>(c => GetTableName(c));

            foreach (var data in group)
            {
                
            }




        }


        private string GetTableName(Commodity commodity)
        {
            string tbName = string.Format("JD_Commodity_{0}", (commodity.ProductId % 30 + 1).ToString("000"));
            return tbName;
        }

    }
}
