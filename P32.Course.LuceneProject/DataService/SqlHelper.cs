using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using P32.Course.LuceneProject.Utility;

namespace P32.Course.LuceneProject.DataService
{
    public class SqlHelper
    {
        private static Logger logger = new Logger(typeof(SqlHelper));
        private static string ConnStr = StaticConstant.ConnStr;

        public static void ExecuteNonQuery(string sql)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }

        }

        public static List<T> QueryList<T>(string sql) where T: new ()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.CommandTimeout = 120;

                SqlDataReader sqldr = cmd.ExecuteReader();

                List<T> resultList = TransList<T>(sqldr);
                return resultList;
            }
        }

        public static void Insert<T>(T model, string tableName) where T : new()
        {
            string sql = GetInsertSql<T>(model, tableName);
            ExecuteNonQuery(sql);
        }

        public static void InsertList<T>(List<T> list, string tableName) where T : new()
        {
            string sql = string.Join(" ", list.Select(t => GetInsertSql<T>(t, tableName)));
            ExecuteNonQuery(sql);
        }




        private static string GetInsertSql<T>(T model, string tableName)
        {
            StringBuilder sbSql = new StringBuilder();

            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();

            Type type = model.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo p in properties)
            {
                string name = p.Name;
                if (!name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    sbFields.AppendFormat("[{0}],", name);
                    sbValues.AppendFormat("'{0}',", p.GetValue(model));
                }
            }
            string fields = sbFields.ToString().TrimEnd(',');
            string values = sbValues.ToString().TrimEnd(',');
            sbSql.AppendFormat("Insert into {0} ({1}) values ({2})", tableName, fields,values);
            return sbSql.ToString();
        }


        private static List<T> TransList<T>(SqlDataReader reader) where T : new()
        {
            List<T> tList= new List<T>();
            Type type = typeof(T);

            PropertyInfo[] properties = type.GetProperties();

            if (reader.Read())
            {
                do
                {
                    T t  = new T();
                    foreach (PropertyInfo p in properties)
                    {
                        object value = Convert.ChangeType(reader[p.Name], p.PropertyType);
                        p.SetValue(t, value);
                    }
                    tList.Add(t);
                } while (reader.Read());
            }
            return tList;
        }

        private static T TransModel<T>(SqlDataReader reader) where T : new()
        {
            T t= new T();
            if (reader.Read())
            {
                Type type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo p in properties)
                {
                    object value = Convert.ChangeType(reader[p.Name], p.PropertyType);
                    p.SetValue(t, value);
                }
            }
            return t;
        }


    }
}
