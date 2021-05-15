using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace P39.Course.dotnetCore.TestMVC
{
    /*   Log4Net
     *   1 Nuget:  log4net +  Logging.Log4Net.AspNetCore
     *   2 config files
     *   3 configure in CreateHostBuilder
     *   4 ILoggerFactory and ILogger<BSecondController> can be sued to log.  DI and IOC. 
     */

    /* Autofac
     * 1 install packages
     * 2  .UseServiceProviderFactory(new AutofacServiceProviderFactory())  in CreateHostBuilder
     * 3 ConfigureContainer in Startup class
     *
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
                    }
                )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }
}
