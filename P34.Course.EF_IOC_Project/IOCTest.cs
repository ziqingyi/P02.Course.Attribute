﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P33.Course.Model;
using P33.Course.Model.Models;
using P34.Course.Business.Interface;
using P34.Course.Business.Service;

namespace P34.Course.EF_IOC_Project
{
    class IOCTest
    {
        public static void Show()
        {
            {


                #region structure
                //1 must access service layer for data. not dbContext.Users.Find(1)
                //2 do not put crud in each service, use super class with T.
                //3 do not put crud in each interface, use base interface and implement it. 

                DbContext dbContext = new JDDbContext();
                //using: already implemented IDisposable.
                using (IUserService iUserService = new UserService(dbContext))
                {
                    User u= iUserService.Find<User>(1);
                }

                using (ICompanyService iCompanyService = new CompanyService(new JDDbContext()))
                {
                    Company c = iCompanyService.Find<Company>(1);
                }


                #endregion




            }




        }
    }
}
