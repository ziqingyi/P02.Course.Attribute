using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using P34.Course.Business.Interface.TestCore;
using P34.Course.Business.Service.TestCore;

namespace P39.Course.dotnetCore.TestMVC.Utility
{
    public class CustomAutofacModule:Module
    {
        
        //register services
        protected override void Load(ContainerBuilder containerBuilder )
        {
            containerBuilder.RegisterType<TestServiceA>().As<ITestServiceA>()
                .SingleInstance();
            containerBuilder.RegisterType<TestServiceC>().As<ITestServiceC>();

            containerBuilder.RegisterType<TestServiceB>().As<ITestServiceB>();

            containerBuilder.RegisterType<TestServiceD>().As<ITestServiceD>();

        }


    }
}
