using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using P34.Course.Business.Interface.TestCore;
using P34.Course.Business.Service.TestCore;
using P39.Course.dotnetCore.TestMVC.Controllers;

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



            containerBuilder.RegisterType<TestServiceA>().As<ITestServiceA>()
                .SingleInstance();
            containerBuilder.RegisterType<TestServiceC>().As<ITestServiceC>();

            containerBuilder.RegisterType<TestServiceB>().As<ITestServiceB>();

            containerBuilder.RegisterType<TestServiceD>().As<ITestServiceD>();

        }


    }
}
