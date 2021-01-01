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
        public static void ShowIOCinNewProjStructure()
        {
            //since the reference to the service project is removed. 
            //you need to copy the UserCompanyService to this project's debug folder, 
            //need to compile the UserCompanyService project before copy. other wise error.
            //install ef and unity packages, config database connection strings.
            IUnityContainer container = ContainerFactory.GetContainer();
            using (IUserCompanyService iUserCompanyService = container.Resolve<IUserCompanyService>())
            {
                User u = iUserCompanyService.Find<User>(12);


            }


        }


    }
}
