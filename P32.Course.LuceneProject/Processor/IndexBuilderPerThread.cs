using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using P32.Course.LuceneProject.DataService;
using P32.Course.LuceneProject.Lucene.Interface;
using P32.Course.LuceneProject.Lucene.Service;
using P32.Course.LuceneProject.Model;
using P32.Course.LuceneProject.Utility;

namespace P32.Course.LuceneProject.Processor
{
    public class IndexBuilderPerThread
    {
        private Logger logger = new Logger(typeof(IndexBuilderPerThread));
        private int CurrentThreadNum = 0;
        private string PathSuffix = "";
        private CancellationTokenSource CTS = null;

        /// <summary>
        /// fix temp variable issue, pass the param in ctor
        /// </summary>
        /// <param name="threadNum"></param>
        /// <param name="pathSuffix"></param>
        /// <param name="cts"></param>
        public IndexBuilderPerThread(int threadNum, string pathSuffix, CancellationTokenSource cts)
        {
            this.CurrentThreadNum = threadNum;
            this.PathSuffix = pathSuffix;
            this.CTS = cts;
        }

        public void Process()
        {
            try
            {
                logger.Debug(string.Format("ThreadNum={0} start building", CurrentThreadNum));
                CommodityRepository commodityRepository = new CommodityRepository();
                ILuceneBuild builder = new LuceneBuild();
                bool isFirst = true;
                int pageIndex = 1;
                while (!CTS.IsCancellationRequested)
                {
                    List<Commodity> commodityList = commodityRepository.QueryList(CurrentThreadNum, pageIndex, 1000);
                    if (commodityList == null || commodityList.Count == 0)
                    {
                        break;
                    }
                    else if (pageIndex == 11) //test for 10000 items only
                    {
                        break;
                    }
                    else
                    {
                        builder.BuildIndex(commodityList, PathSuffix, isFirst);
                        logger.Debug(string.Format("ThreadNum ={0} complete {1} items ", CurrentThreadNum, 1000 * pageIndex++));
                        isFirst = false;
                    }

                }
            }
            catch (Exception ex)
            {
                CTS.Cancel();
                logger.Error(string.Format("ThreadNum={0} has error", CurrentThreadNum), ex);
            }
            finally
            {
                logger.Debug(string.Format("ThreadNum={0} finish building", CurrentThreadNum));
            }




        }




    }
}
