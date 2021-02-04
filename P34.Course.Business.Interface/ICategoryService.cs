using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P33.Course.Model.Models;

namespace P34.Course.Business.Interface
{
    public interface ICategoryService:IBaseService
    {
        void Show();

        #region Query
        /// <summary>
        /// get all id in current category and descendant category
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        IEnumerable<int> GetDescendantsIdList(string code);

        /// <summary>
        /// get child list, default is root
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        IEnumerable<Category> GetChildList(string code = "root");


        /// <summary>
        /// catch all categories, no change in most cases.
        /// </summary>
        /// <returns></returns>
        List<Category> CacheAllCategory();

        #endregion



    }
}
