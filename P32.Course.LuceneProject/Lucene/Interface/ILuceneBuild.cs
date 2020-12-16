using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P32.Course.LuceneProject.Model;

namespace P32.Course.LuceneProject.Lucene.Interface
{
    public interface ILuceneBuild
    {


        /// <summary>
        /// create index in batch
        /// </summary>
        /// <param name="cIList"></param>
        /// <param name="pathSuffix">index path's suffix</param>
        /// <param name="isCreate">false: increasement, true: delete old and create new</param>
        void BuildIndex(List<Commodity> cIList, string pathSuffix = "", bool isCreate = false);


        /// <summary>
        /// merge index to the parent directory
        /// </summary>
        /// <param name="sourceDirs"></param>
        void MergeIndex(string[] sourceDirs);

        /// <summary>
        /// add a new data index
        /// </summary>
        /// <param name="ci"></param>
        void InsertIndex(Commodity ci);


        /// <summary>
        /// insert batch of index
        /// </summary>
        /// <param name="ciList"></param>
        void InsertIndexMuti(List<Commodity> ciList);

        /// <summary>
        /// delete index of a data
        /// </summary>
        /// <param name="ci"></param>
        void DeleteIndex(Commodity ci);


        /// <summary>
        /// delete index in batch
        /// </summary>
        /// <param name="ci"></param>
        void DeleteIndexMuti(List<Commodity> ci);


        /// <summary>
        /// update index
        /// </summary>
        /// <param name="ci"></param>
        void UpdateIndex(Commodity ci);

        /// <summary>
        /// update index in batch
        /// </summary>
        /// <param name="ciList"></param>
        void UpdateIndexMuti(List<Commodity> ciList);
    }
}
