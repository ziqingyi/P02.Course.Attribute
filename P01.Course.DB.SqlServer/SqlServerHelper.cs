using P01.Course.DB.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using P01.Course.Model;

namespace P01.Course.DB.SqlServer
{
    public class SqlServerHelper: IDBHelper
    {
        private static string ConnectionStringCustomers =
            ConfigurationManager.ConnectionStrings["Customers"].ConnectionString;


        public SqlServerHelper()
        {
            Console.WriteLine("{0} is being initialized ", this.GetType().Name);
        }
        public void Query()
        {
            Console.WriteLine("{0}.Query is being called", this.GetType().Name);
        }

        public Company Find(int id)
        {
            string sql = "select * from atesCompany where id = " + id;
            using (SqlConnection conn = new SqlConnection(ConnectionStringCustomers))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine(reader[1]);

                }
                return new Company();
                
            }
        }

    }
}
