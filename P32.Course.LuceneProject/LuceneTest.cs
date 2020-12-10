using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using P32.Course.LuceneProject.DataService;
using P32.Course.LuceneProject.Model;
using P32.Course.LuceneProject.Utility;

namespace P32.Course.LuceneProject
{
    public class LuceneTest
    {

        public static void Show()
        {
            

        }

        public static void InitIndex()
        {
            List<Commodity> commodityList = GetList();
            FSDirectory directory = FSDirectory.Open(StaticConstant.TestIndexPath);
            using (IndexWriter writer =
                new IndexWriter(directory, new PanGuAnalyzer(), true, IndexWriter.MaxFieldLength.LIMITED))
            {
                foreach (Commodity commodity in commodityList)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        Document doc = new Document();
                       // doc.Add(new Field("id", commdi));


                    }
                }
            }


        }


        private static List<Commodity> GetList()
        {
            CommodityRepository repository = new CommodityRepository();
            List<Commodity> commodityList = repository.QueryList(1, 1, 500);
            return commodityList;
        }







    }
}
