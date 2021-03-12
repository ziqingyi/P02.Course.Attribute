using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P37.Course.Web.Core.DAL
{
    public class DBHelper
    {
        private static string connStr = StaticConstraint.DBconnection;

        //execute sql query
        public static int ExecuteNonQuery(string sql, params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql,conn);
                command.Parameters.AddRange(paras);
                int result = command.ExecuteNonQuery();
                return result;
            }
        }

        //return first row, first column
        public static object ExecuteScalar(string sql, params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql,conn);
                object obj = command.ExecuteScalar();
                return obj;
            }
        }

        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] paras)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddRange(paras);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //return a row
        public static DataRow GetDataRow(string sql, params SqlParameter[] paras)
        {
            DataTable dt = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddRange(paras);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
            }
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }
        //get datatable 
        public static DataTable GetDataTable(string sql, params SqlParameter[] paras)
        {
            DataTable dt = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(sql,conn))
                {
                    command.Parameters.AddRange(paras);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        //get dataset
        public static DataSet GetDataSet(string sql, params SqlParameter[] paras)
        {
            DataSet ds = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(sql,conn))
                {
                    command.Parameters.AddRange(paras);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    ds = new DataSet();
                    adapter.Fill(ds);
                }
            }

            return ds;
        }


        #region other
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

                if (columns.Contains(prop.Name) && !(reader[prop.Name] is DBNull))
                {
                    if (reader[prop.Name].GetType() == prop.PropertyType)
                    {
                        prop.SetValue(obj, reader[prop.Name]);
                    }
                }
            }
            return (T)obj;
        }


        #endregion

    }
}
