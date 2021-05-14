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
            container.AddTransient<ITestServiceA,TestServiceA>();//transient life cycle
            container.AddSingleton<ITestServiceB, TestServiceB>();
            container.AddScoped<ITestServiceC, TestServiceC>();//one instance for one scope,eg: in Web, each request.
            container.AddTransient<ITestServiceD, TestServiceD>();

            var provider = container.BuildServiceProvider();

            ITestServiceA testServiceA = provider.GetService<ITestServiceA>();
            ITestServiceA testServiceA2 = provider.GetService<ITestServiceA>();
            Console.WriteLine("for Transient: Equal? "+ object.ReferenceEquals(testServiceA,testServiceA2));

            ITestServiceB testServiceB = provider.GetService<ITestServiceB>();
            ITestServiceB testServiceB2 = provider.GetService<ITestServiceB>();
            Console.WriteLine("for Singleton: Equal? " + object.ReferenceEquals(testServiceB, testServiceB2));

            ITestServiceC testServiceC = provider.GetService<ITestServiceC>();
            ITestServiceC testServiceC2 = provider.GetService<ITestServiceC>();
            Console.WriteLine("for Scoped 1 2: Equal? " + object.ReferenceEquals(testServiceC, testServiceC2));

            var scope3 = provider.CreateScope();
            var scope4 = provider.CreateScope();
            ITestServiceC testServiceC3 = scope3.ServiceProvider.GetService<ITestServiceC>();
            ITestServiceC testServiceC4 = scope4.ServiceProvider.GetService<ITestServiceC>();
            Console.WriteLine("for Scoped 3 4: Equal? " + object.ReferenceEquals(testServiceC3, testServiceC4));//false, different scope




            ITestServiceD testServiceD = provider.GetService<ITestServiceD>();
            ITestServiceD testServiceD2 = provider.GetService<ITestServiceD>();
            Console.WriteLine("for Scoped: Equal? " + object.ReferenceEquals(testServiceD, testServiceD2));





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
