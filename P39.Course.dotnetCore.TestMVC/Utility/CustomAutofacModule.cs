using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using P34.Course.Business.Interface.TestCore;
using P34.Course.Business.Service.TestCore;
using P39.Course.dotnetCore.Interface;
using P39.Course.dotnetCore.Service;
using P39.Course.dotnetCore.TestMVC.Controllers;
using P39.Course.EntityFrameworkCore3;

namespace P39.Course.dotnetCore.TestMVC.Utility
{
    public class CustomAutofacModule:Module
    {
        
        //register services
        protected override void Load(ContainerBuilder containerBuilder )
        {
            #region register AOP

            containerBuilder.Register(c => new CustomAutofacAop());

            containerBuilder.RegisterType<A>().As<IA>().EnableInterfaceInterceptors();

            #endregion


            #region Register for IOC

            containerBuilder.RegisterType<TestServiceA>().As<ITestServiceA>()
                .SingleInstance();
            containerBuilder.RegisterType<TestServiceC>().As<ITestServiceC>();

            containerBuilder.RegisterType<TestServiceB>().As<ITestServiceB>();

            containerBuilder.RegisterType<TestServiceD>().As<ITestServiceD>();

            #endregion


            #region Register service for IOC for Entity Framework

            containerBuilder.RegisterType<JDDbContext>().As<DbContext>();//parameter used for service
            containerBuilder.RegisterType<UserService>().As<IUserService>();



            #endregion





        }


    }
}
