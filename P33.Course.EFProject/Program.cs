using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P33.Course.Model;
using P33.Course.Model.Models;

namespace P33.Course.EFProject
{
    class Program
    {
        static void Main(string[] args)
        {
            #region how to use EF project
            ////must reference EF in current project for implementation of disposing. 
            ////must add connection string from model,as JDDbContext will use current proj's config. 
            //using (JDDbContext context = new JDDbContext())
            //{
            //    User user = context.Users.Find(2);
            //}
            #endregion


            #region Query Test

            //Console.WriteLine("************EFQueryTest******************");
            //EFQueryTest.Show();

            #endregion

            #region State Test

            //Console.WriteLine("*************EFStateTest*****************");
            //EFStateTest.Show();

            #endregion

            #region Context Lifetime Test

            //ContextLifetimeTest.Show();

            #endregion

            #region IQueryable and IEnumerable Query Test

            EFQueryAdvancedTest.Show();

            #endregion


        }
    }
}
