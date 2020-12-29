using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P34.Course.Business.Interface;
using P34.Course.Business.Service;

namespace P34.Course.EF_IOC_Project
{
    class IOCTest
    {
        public static void Show()
        {
            {
                #region must access service layer for data. 

                IUserService iUserService = new UserService();
                iUserService.Add();

                #endregion


            }




        }
    }
}
