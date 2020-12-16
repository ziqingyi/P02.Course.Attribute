using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using P32.Course.LuceneProject.Lucene.Interface;
using P32.Course.LuceneProject.Lucene.Service;
using P32.Course.LuceneProject.Utility;

namespace P32.Course.LuceneProject.Processor
{
    public class IndexBuilder
    {
        private static Logger logger = new Logger(typeof(IndexBuilder));
        private static List<string> PathSuffixList = new List<string>();
        private static CancellationTokenSource CTS = null;

        public static void Build()
        {
            try
            {
                logger.Debug(string.Format("{0} build index start", DateTime.Now));

                List<Task> taskList = new List<Task>();
                TaskFactory taskFactory = new TaskFactory();
                CTS = new CancellationTokenSource();

                for (int i = 0; i < 31; i++)
                {
                    IndexBuilderPerThread thread = new IndexBuilderPerThread(i,i.ToString("000"), CTS);
                    PathSuffixList.Add(i.ToString("000"));
                    taskList.Add(taskFactory.StartNew(thread.Process));
                }
                taskList.Add(taskFactory.ContinueWhenAll(taskList.ToArray(), MergeIndex));
                Task.WaitAll(taskList.ToArray());
                logger.Debug(string.Format("build index is {0}", CTS.IsCancellationRequested? "failed": "success"));
            }
            catch (Exception ex)
            {
                logger.Error("Build Index error", ex);
            }
            finally
            {
                logger.Debug(string.Format("{0} build index end", DateTime.Now));
            }

        }

        private static void MergeIndex(Task[] tasks)
        {
            try
            {
                if (CTS.IsCancellationRequested)
                {
                    return;
                }
                ILuceneBuild   builder = new LuceneBuild();
                builder.MergeIndex(PathSuffixList.ToArray());
            }
            catch (Exception ex)
            {
                CTS.Cancel();
                logger.Error("merge index error", ex);
            }
        }

    }
}
