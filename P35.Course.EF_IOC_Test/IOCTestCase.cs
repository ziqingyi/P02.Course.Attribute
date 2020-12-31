using P33.Course.Model.Models;
using P34.Course.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace P35.Course.EF_IOC_Test
{
    public class IOCTestCase
    {
        public static void Show()
        {
            IUnityContainer container = ContainerFactory.GetContainer();
            using (IUserCompanyService iUserCompanyService = container.Resolve<IUserCompanyService>())
            {
                User u = iUserCompanyService.Find<User>(12);


            }


        }


    }
}
