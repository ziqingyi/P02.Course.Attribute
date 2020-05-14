using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Data.SqlClient;


namespace P05.Course.ExpressionSty.DBExtend
{
    public static class ObjectQueryExtension
    {
        //batch delete with ado.net
        public static int Delete<TEntity>(this ObjectQuery<TEntity> source, Expression<Func<TEntity, bool>> predicate)
            where TEntity : System.Data.Objects.DataClasses.EntityObject
        {
            var selectSql = (source.Where(predicate) as ObjectQuery).ToTraceString();

            int startIndex = selectSql.IndexOf(",");
            int endIndex = selectSql.IndexOf(".");
            string tableAlias = selectSql.Substring(startIndex + 1, endIndex - startIndex - 1);
            startIndex = selectSql.IndexOf("FROM");
            String deleteSql = "DELETE " + tableAlias + " " + selectSql.Substring(startIndex);

            string connectionString = ((source as ObjectQuery).Context.Connection as EntityConnection).StoreConnection
                .ConnectionString;
            return ExecuteNonQuery(connectionString,deleteSql);
        }

        // run query to show how many lines are being affected. 
        private static int ExecuteNonQuery(string connectionString, string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.Parameters.AddRange(parameters);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
