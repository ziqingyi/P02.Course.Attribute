using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P32.Course.LuceneProject.DataService;
using P32.Course.LuceneProject.Model;
using P32.Course.LuceneProject.Processor;

namespace P32.Course.LuceneProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************Lucene InitIndex*********************");
            LuceneTest.InitIndex();

            Console.WriteLine("*************Lucene Show*********************");
            LuceneTest.Show();

            #region Lucene Project
            IndexBuilder.Build();



            int total = 0;
            string pricefilter = "[1,100]";
            string priceorderby = "price desc";
            List<Commodity> commoditylist = CommodityLucene.QueryCommodity(1, 30, out total, "book", null, pricefilter, priceorderby);

            foreach (Commodity commodity in commoditylist)
            {
                Console.WriteLine("title={0},price={1}", commodity.Title, commodity.Price);
            }


            #endregion




        }
    }
}
