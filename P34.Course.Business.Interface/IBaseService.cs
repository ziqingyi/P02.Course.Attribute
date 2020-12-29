using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P34.Course.Business.Interface
{
    public interface IBaseService: IDisposable
    {
        #region Query
        /// <summary>
        /// find T based on id (this project's id is int)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find<T>(int id) where T : class;


        /// <summary>
        /// will return whole table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IQueryable type</returns>
        [Obsolete("avoid using this,better to use query with Expression tree, using(...)")]
        IQueryable<T> Set<T>() where T : class;

        /// <summary>
        /// query with Expression tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class;




        #endregion




    }
}
