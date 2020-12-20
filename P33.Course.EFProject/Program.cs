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
            //must reference EF in current project for implementation of disposing. 
            //must add connection string from model,as JDDbContext will use current proj's config. 
            using (JDDbContext context = new JDDbContext())
            {
                User user = context.Users.Find(2);


            }


        }
    }
}
