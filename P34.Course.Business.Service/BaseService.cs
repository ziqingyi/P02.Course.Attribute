using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using P34.Course.Business.Interface;

namespace P34.Course.Business.Service
{
    public class BaseService: IBaseService
    {
        //use base service to do all the service for different objects(tables), use T
        #region Identity
        //protected: only sub class can use. private: only base can set context value
        protected DbContext Context { get; private set; }
        /// <summary>
        /// share DbContext in one request, use one in a BaseService instance to curd.
        /// </summary>
        /// <param name="context"></param>
        public BaseService(DbContext context)//use super class: DbContext
        {
            this.Context = context;
        }
        #endregion

        #region Query

        public T Find<T>(int id) where T : class
        {
            return this.Context.Set<T>().Find(id);
        }

        [Obsolete("avoid using this,better to use query with Expression tree, using(...)")]
        public IQueryable<T> Set<T>() where T : class
        {
            return this.Context.Set<T>();
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            return this.Context.Set<T>().Where<T>(funcWhere);
        }

        public PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex,
            Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class
        {
            var list = this.Set<T>();
            if (funcWhere != null)
            {
                list = list.Where<T>(funcWhere);
            }

            if (isAsc)
            {
                list = list.OrderBy(funcOrderby);
            }
            else
            {
                list = list.OrderByDescending(funcOrderby);
            }
            PageResult<T> result = new PageResult<T>()
            {
                DataList =  list.Skip( (pageIndex-1)* pageSize ).Take(pageSize).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = this.Context.Set<T>().Count(funcWhere)
            };
            return result;
        }
        #endregion

        #region Insert

        public T Insert<T>(T t) where T : class
        {
            this.Context.Set<T>().Add(t);
            //commit here, otherwise commit manually
            this.Commit();
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            this.Context.Set<T>().AddRange(tList);
            //commit multiple sql
            this.Commit();
            return tList;
        }

        #endregion

        #region Update

        public void Update<T>(T t) where T : class
        {
            if(t == null) throw new Exception("t is null");

            //t is placed into the context in the unchanged state, like reading from db. 
            this.Context.Set<T>().Attach(t);
            this.Context.Entry<T>(t).State = EntityState.Modified;
            this.Commit();
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            foreach (T t in tList)
            {
                this.Context.Set<T>().Attach(t);
                this.Context.Entry<T>(t).State = EntityState.Modified;
            }
            this.Commit();//save and state changed to UnChanged
        }

        #endregion

        #region Delete

        



        #endregion


        #region other

        public void Commit()
        {
            this.Context.SaveChanges();
        }

        public IQueryable<T> ExecuteQuery<T>(string sql, SqlParameter[] parameters) where T : class
        {
            return this.Context.Database.SqlQuery<T>(sql, parameters).AsQueryable();
        }

        public void Execute<T>(string sql, SqlParameter[] parameters) where T : class
        {
            DbContextTransaction trans = null;
            try
            {
                trans = this.Context.Database.BeginTransaction();
                this.Context.Database.ExecuteSqlCommand(sql, parameters);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                }
                throw ex;
            }
        }

        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
        #endregion

    }
}
