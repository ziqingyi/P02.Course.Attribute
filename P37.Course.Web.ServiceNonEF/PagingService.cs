using P37.Course.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
            Page<T> page = new Page<T>(pageIndex, pageSize, count, null);

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
                        obj = CreateObjectFromSqlDataReader<T>(reader);
                        recList.Add((T)obj);
                    }
                }
            }

            return recList;
        }



        public static T CreateObjectFromSqlDataReader<T>(SqlDataReader reader) 
        {
            #region get object instance
            Type type = typeof(T);
            PropertyInfo[] propListAllPub = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            //Use X because the generic type in static method can be different from class generic type
            // can also use T but there will be a warning. 
            object obj = Activator.CreateInstance(typeof(T));
            #endregion

            #region Get column names from data reader
            var columns = new List<string>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                columns.Add(reader.GetName(i));
            }

            #endregion



            foreach (var prop in propListAllPub)
            {
                // notice the null from database //prop.GetColumnName() is to get/check database name in attribute
                //since sql uses alias, so still use prop.Name. 
               
                if ( columns.Contains(prop.Name) && !(reader[prop.Name] is DBNull)  )
                {
                    if (reader[prop.Name].GetType() == prop.PropertyType)
                    {
                        prop.SetValue(obj,  reader[prop.Name]);
                    }
                }
            }
            return (T)obj;
        }






    }
}
