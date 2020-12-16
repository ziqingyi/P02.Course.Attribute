using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using P32.Course.LuceneProject.Lucene.AnalyzerCustom;
using P32.Course.LuceneProject.Lucene.Interface;
using P32.Course.LuceneProject.Model;
using P32.Course.LuceneProject.Utility;
using Version = Lucene.Net.Util.Version;
using LuceneIO = Lucene.Net.Store;

namespace P32.Course.LuceneProject.Lucene.Service
{
    public class LuceneBuild: ILuceneBuild
    {
        #region Identity
        private Logger logger = new Logger(typeof(LuceneBuild));
        #endregion

        #region Build Index in batch and combine index, for multi-threading.

        public void BuildIndex(List<Commodity> ciList, string pathSuffix = "", bool isCreate = false)
        {
            IndexWriter writer = null;
            try
            {
                if (ciList == null || ciList.Count == 0)
                {
                    return;
                }

                string rootIndexPath = StaticConstant.IndexPath;
                string indexPath = string.IsNullOrWhiteSpace(pathSuffix) ? rootIndexPath : string.Format("{0}\\{1}", rootIndexPath, pathSuffix);

                DirectoryInfo dirInfo = Directory.CreateDirectory(indexPath);
                LuceneIO.Directory directory = LuceneIO.FSDirectory.Open(dirInfo);
                writer = new IndexWriter(directory, new PanGuAnalyzer(), isCreate, IndexWriter.MaxFieldLength.LIMITED);
                //writer = new IndexWriter(directory, CreateAnalyzerWrapper(), isCreate, IndexWriter.MaxFieldLength.LIMITED);
                writer.SetMaxBufferedDocs(100);
                writer.MergeFactor = 100;
                writer.UseCompoundFile = true;

                ciList.ForEach(c => CreateCIIndex(writer, c));
            }
            finally
            {
                if (writer != null)
                {
                    //writer.Optimize(); 
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// combine index into upper directory
        /// </summary>
        /// <param name="childDirs"></param>
        public void MergeIndex(string[] childDirs)
        {
            Console.WriteLine("MergeIndex Start");
            IndexWriter writer = null;
            try
            {
                if (childDirs == null || childDirs.Length == 0) return;
                Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_30);
                string rootPath = StaticConstant.IndexPath;
                DirectoryInfo dirInfo = Directory.CreateDirectory(rootPath);
                LuceneIO.Directory directory = LuceneIO.FSDirectory.Open(dirInfo);
                writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED);
                LuceneIO.Directory[] dirNo = childDirs.Select(dir => LuceneIO.FSDirectory.Open(Directory.CreateDirectory(string.Format("{0}\\{1}", rootPath, dir)))).ToArray();
                writer.MergeFactor = 100;
                writer.UseCompoundFile = true;
                writer.AddIndexesNoOptimize(dirNo);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Optimize();
                    writer.Close();
                }
                Console.WriteLine("MergeIndex End");
            }
        }

        #endregion

        #region Index add, delete and update

        /// <summary>
        /// add a new index
        /// </summary>
        /// <param name="ci"></param>
        public void InsertIndex(Commodity ci)
        {
            IndexWriter writer = null;
            try
            {
                if (ci == null) return;
                string rootIndexPath = StaticConstant.IndexPath;
                DirectoryInfo dirInfo = Directory.CreateDirectory(rootIndexPath);

                bool isCreate = dirInfo.GetFiles().Count() == 0;
                LuceneIO.Directory directory = LuceneIO.FSDirectory.Open(dirInfo);
                writer = new IndexWriter(directory, CreateAnalyzerWrapper(), isCreate, IndexWriter.MaxFieldLength.LIMITED);
                writer.MergeFactor = 100;
                writer.UseCompoundFile = true;
                CreateCIIndex(writer, ci);
            }
            catch (Exception ex)
            {
                logger.Error("InsertIndex Exception", ex);
                throw ex;
            }
            finally
            {
                if (writer != null)
                {
                    //if (fileNum > 50)
                    //    writer.Optimize();
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// insert multiple indexes
        /// </summary>
        /// <param name="ciList"></param>
        public void InsertIndexMuti(List<Commodity> ciList)
        {
            BuildIndex(ciList, "", false);
        }

        /// <summary>
        /// delete multiple indexes
        /// </summary>
        /// <param name="ciList"></param>
        public void DeleteIndexMuti(List<Commodity> ciList)
        {
            IndexReader reader = null;
            try
            {
                if (ciList == null || ciList.Count == 0) return;
                Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_30);
                string rootIndexPath = StaticConstant.IndexPath;
                DirectoryInfo dirInfo = Directory.CreateDirectory(rootIndexPath);
                LuceneIO.Directory directory = LuceneIO.FSDirectory.Open(dirInfo);
                reader = IndexReader.Open(directory, false);
                foreach (Commodity ci in ciList)
                {
                    reader.DeleteDocuments(new Term("productid", ci.ProductId.ToString()));
                }
            }
            catch (Exception ex)
            {
                logger.Error("DeleteIndex Exception", ex);
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Dispose();
                }
            }
        }

        /// <summary>
        /// delete single index
        /// </summary>
        /// <param name="ci"></param>
        public void DeleteIndex(Commodity ci)
        {
            IndexReader reader = null;
            try
            {
                if (ci == null) return;
                Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_30);
                string rootIndexPath = StaticConstant.IndexPath;
                DirectoryInfo dirInfo = Directory.CreateDirectory(rootIndexPath);
                LuceneIO.Directory directory = LuceneIO.FSDirectory.Open(dirInfo);
                reader = IndexReader.Open(directory, false);
                reader.DeleteDocuments(new Term("productid", ci.ProductId.ToString()));
            }
            catch (Exception ex)
            {

                logger.Error("DeleteIndex Exception", ex);
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Dispose();
                }
            }
        }

        ///// <summary>
        ///// update one index
        ///// </summary>
        //public void UpdateIndex(Commodity ci)
        //{
        //    DeleteIndex(ci);
        //    InsertIndex(ci);
        //}

        /// <summary>
        /// update one index
        /// </summary>
        /// <param name="ci"></param>
        public void UpdateIndex(Commodity ci)
        {
            IndexWriter writer = null;
            try
            {
                if (ci == null) return;
                string rootIndexPath = StaticConstant.IndexPath;
                DirectoryInfo dirInfo = Directory.CreateDirectory(rootIndexPath);

                bool isCreate = dirInfo.GetFiles().Count() == 0;//create new index if none
                LuceneIO.Directory directory = LuceneIO.FSDirectory.Open(dirInfo);
                writer = new IndexWriter(directory, CreateAnalyzerWrapper(), isCreate, IndexWriter.MaxFieldLength.LIMITED);
                writer.MergeFactor = 100;
                writer.UseCompoundFile = true;
                writer.UpdateDocument(new Term("productid", ci.ProductId.ToString()), ParseCItoDoc(ci));
            }
            catch (Exception ex)
            {
                logger.Error("InsertIndex Exception", ex);
                throw ex;
            }
            finally
            {
                if (writer != null)
                {
                    //if (fileNum > 50)
                    //    writer.Optimize();
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// update index in batch
        /// </summary>
        /// <param name="ciList">sourceflag</param>
        public void UpdateIndexMuti(List<Commodity> ciList)
        {
            IndexWriter writer = null;
            try
            {
                if (ciList == null || ciList.Count == 0) return;
                string rootIndexPath = StaticConstant.IndexPath;
                DirectoryInfo dirInfo = Directory.CreateDirectory(rootIndexPath);

                bool isCreate = dirInfo.GetFiles().Count() == 0;
                LuceneIO.Directory directory = LuceneIO.FSDirectory.Open(dirInfo);
                writer = new IndexWriter(directory, CreateAnalyzerWrapper(), isCreate, IndexWriter.MaxFieldLength.LIMITED);
                writer.MergeFactor = 50;
                writer.UseCompoundFile = true;
                foreach (Commodity ci in ciList)
                {
                    writer.UpdateDocument(new Term("productid", ci.ProductId.ToString()), ParseCItoDoc(ci));
                }
            }
            catch (Exception ex)
            {
                logger.Error("InsertIndex Exception", ex);
                throw ex;
            }
            finally
            {
                if (writer != null)
                {
                    //if (fileNum > 50)
                    //    writer.Optimize();
                    writer.Close();
                }
            }
        }



        #endregion

        #region private method

        private PerFieldAnalyzerWrapper CreateAnalyzerWrapper()
        {
            Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_30);

            PerFieldAnalyzerWrapper analyzerWrapper = new PerFieldAnalyzerWrapper(analyzer);
            analyzerWrapper.AddAnalyzer("title", new PanGuAnalyzer());
            analyzerWrapper.AddAnalyzer("categoryid", new StandardAnalyzer(Version.LUCENE_30));

            analyzerWrapper.AddAnalyzer("XXXX", new BlankAnalyzer());
            return analyzerWrapper;

        }

        /// <summary>
        /// create index
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="ci"></param>
        private void CreateCIIndex(IndexWriter writer, Commodity ci)
        {
            try
            {
                writer.AddDocument(ParseCItoDoc(ci));
            }
            catch (Exception ex)
            {
                logger.Error("CreateCIIndex  exception", ex);
                throw ex;
            }
        }
        /// <summary>
        /// transfer commodity to doc
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        private Document ParseCItoDoc(Commodity ci)
        {
            Document doc = new Document();

            doc.Add(new Field("id", ci.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("title", ci.Title, Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("productid", ci.ProductId.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("categoryid", ci.CategoryId.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("imageurl", ci.ImageUrl, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("url", ci.Url, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new NumericField("price", Field.Store.YES, true).SetFloatValue((float)ci.Price));
            return doc;

        }


        #endregion
    }
}
