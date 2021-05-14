using System;
using Microsoft.Extensions.DependencyInjection;
using P34.Course.Business.Interface.TestCore;
using P34.Course.Business.Service.TestCore;

namespace P39.Course.dotnetCore.TestProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("**************Text IOC ***********************"); ;
            IServiceCollection container = new ServiceCollection();
            container.AddTransient<ITestServiceA,TestServiceA>();
            container.AddTransient<ITestServiceB, TestServiceB>();
            container.AddTransient<ITestServiceC, TestServiceC>();
            container.AddTransient<ITestServiceD, TestServiceD>();

            var provider = container.BuildServiceProvider();

            ITestServiceA testServiceA = provider.GetService<ITestServiceA>();
            ITestServiceB testServiceB = provider.GetService<ITestServiceB>();
            ITestServiceC testServiceC = provider.GetService<ITestServiceC>();
            ITestServiceD testServiceD = provider.GetService<ITestServiceD>();


            Console.WriteLine("**************Text C# 6************************"); ;
            CSharp6 six = new CSharp6();
            People peopleSix = new People()
            {
                Id=505,
                Name = "Test6"
            };
            six.Show(peopleSix);

            Console.WriteLine("**************Text C# 7************************"); ;

            CSharp7 seven = new CSharp7();
            seven.Show();


        }
    }
}
