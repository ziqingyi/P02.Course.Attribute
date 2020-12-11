using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
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
            FSDirectory dir = FSDirectory.Open(StaticConstant.TestIndexPath);
            IndexSearcher searcher = new IndexSearcher(dir); // searcher

            Console.WriteLine("***************Search  1************************");
            {
                TermQuery query = new TermQuery(new Term("title","book")); //contains
                TopDocs docs = searcher.Search(query, null, 1000); //find the data
                foreach (ScoreDoc sd in docs.ScoreDocs)
                {
                    Document doc = searcher.Doc(sd.Doc);
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("id={0}", doc.Get("id"));
                    Console.WriteLine("title={0}", doc.Get("title"));
                    Console.WriteLine("price={0}", doc.Get("price"));
                    Console.WriteLine("url={0}", doc.Get("url"));
                    Console.WriteLine("content={0}", doc.Get("content"));
                }
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("total hits : {0}", docs.TotalHits);
            }


            Console.WriteLine("***************Search  2************************");
            QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "title", new PanGuAnalyzer());
            {
                string keyword = "book computer desk ";
                {
                    Query query = parser.Parse(keyword);
                    TopDocs docs = searcher.Search(query, null, 10000);
                    int i = 0;
                    foreach (ScoreDoc sd in docs.ScoreDocs)
                    {
                        if (i++ < 1000)
                        {
                            Document doc = searcher.Doc(sd.Doc);
                            Console.WriteLine("---------------------------");
                            Console.WriteLine("id={0}", doc.Get("id"));
                            Console.WriteLine("title={0}", doc.Get("title"));
                            Console.WriteLine("price={0}", doc.Get("price"));
                            Console.WriteLine("url={0}", doc.Get("url"));
                            Console.WriteLine("content={0}", doc.Get("content"));
                        }
                    }
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("total hits : {0}", docs.TotalHits);
                }









            }





















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
                    //for (int k = 0; k < 10; k++)
                    {
                        Document doc = new Document();
                        doc.Add(new Field("id", commodity.Id.ToString(), Field.Store.YES,Field.Index.NOT_ANALYZED ));
                        doc.Add(new Field("title", commodity.Title, Field.Store.YES, Field.Index.ANALYZED));
                        doc.Add(new Field("url", commodity.Url, Field.Store.NO, Field.Index.NOT_ANALYZED));
                        doc.Add(new Field("imageurl",commodity.ImageUrl, Field.Store.NO,Field.Index.NOT_ANALYZED));
                        doc.Add(new Field("content", "this is lucene working,powerful tool " + commodity.Id, Field.Store.YES, Field.Index.NOT_ANALYZED));
                        doc.Add(new NumericField("price", Field.Store.YES,true).SetDoubleValue((double)(commodity.Price+ commodity.Id)));
                        //doc.Add(new NumericField("time", Field.Store.YES,true).SetIntValue(int.Parse(DateTime.Now.ToString("yyyyMMdd" ))  + k ));

                        writer.AddDocument(doc);// write to the local folder
                    }
                }

                writer.Optimize();

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
