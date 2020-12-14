using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P32.Course.LuceneProject.Lucene.Interface;
using P32.Course.LuceneProject.Model;
using P32.Course.LuceneProject.Utility;

namespace P32.Course.LuceneProject.Lucene.Service
{
    public class LuceneBuild:ILuceneBulid
    {
        #region Identity
        private Logger logger = new Logger(typeof(LuceneBuild));
        #endregion

        #region Build Index in batch and combine index

        public void BuidIndex(List<Commodity> ciLit, string pathSuffix = "", bool isCreate = false)
        {

        }

        /// <summary>
        /// combine index into upper directory
        /// </summary>
        /// <param name="childDirs"></param>
        public void MergeIndex(string[] childDirs)
        {

        }

        #endregion

        #region Index add, delete and update

        #endregion

        #region private method

        

        #endregion
    }
}
