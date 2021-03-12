using P37.Course.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using P37.Course.Web.Core.DAL;
using P37.Course.Web.Core.Extensions;

namespace P37.Course.Web.ServiceNonEF
{
    public class PagingService
    {

        public Page<T> GetPages<T>(int pageIndex, int pageSize)
        {
            //get total nums of records
            int count = GetCount<T>();

            //get records by page information 
            int start = (pageIndex - 1) * pageSize + 1;//start record index
            int end = pageIndex * pageSize;

            List<T> list = GetDataList<T>(start, end);
            Page<T> page = new Page<T>(pageIndex, pageSize, count, list);

            return page;

        }

        private int GetCount<T>()
        {
            object obj = Activator.CreateInstance(typeof(T));
            string tableName = obj.ClassMapping();
            
            string sql = "select count(1) from ["+ tableName + "]";
            int count = (int) DBHelper.ExecuteScalar(sql);
            return count;
        }

        private List<T> GetDataList<T>(int start, int end)
        {
            
            string tableName = Activator.CreateInstance(typeof(T)).ClassMapping();

            Type type = typeof(T);
            List<T> recList = new List<T>();
            string sql = @"
                SELECT*
                FROM(
                    select   row_number() over(order by id)  ng, *
                    from [" + tableName + @"]
                ) x
                where ng between @start and @end
            ";

            SqlParameter[] paras =
            {
                new SqlParameter("@start", start),
                new SqlParameter("@end", end),
            };

            using (SqlDataReader reader = DBHelper.ExecuteReader(sql, paras))
            {
                if (typeof(T).Name == typeof(CurrentUser).Name)
                {
                    while (reader.Read())
                    {
                        object obj = Activator.CreateInstance(type);
                        obj = DBHelper.CreateObjectFromSqlDataReader<T>(reader);
                        recList.Add((T)obj);
                    }
                }
            }

            return recList;
        }



    






    }
}
