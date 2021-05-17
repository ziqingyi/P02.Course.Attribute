using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using P37.Course.Web.Core.Utility;

namespace P39.Course.dotnetCore.TestMVC
{
    /*   Log4Net
     *   1 Nuget:  log4net +  Logging.Log4Net.AspNetCore
     *   2 config files
     *   3 configure in CreateHostBuilder
     *   4 ILoggerFactory and ILogger<BSecondController> can be sued to log.  DI and IOC. 
     */

    /* Autofac
     *
     * 1 install packages, Autofac, AutofacDI.
     * 2 .UseServiceProviderFactory(new AutofacServiceProviderFactory())  in CreateHostBuilder
     * 3 register interface and service in CustomAutofacModule based on Module.
     * 4 ConfigureContainer method in Startup class, RegisterModule<CustomAutofacModule>();
     *
     *
     *AOP:
     * 1 package: Autofac.Extras.DynamicProxy
     * 2 create class: CustomAutofacAop
     * 3 create test interface IA and class A.
     * 4 update CustomAutofacModule, for registering CustomAutofacAop and IA and A.
     *
     */


    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((context, loggingBuilder) =>
                    {
                        loggingBuilder.AddFilter("System", LogLevel.Warning);//remove low level system and Microsoft logging 
                        loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
                        loggingBuilder.AddLog4Net("CfgFiles\\log4net.config");
                        //Log4Extension.InitLog4(loggingBuilder);
                    }
                )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }
}
