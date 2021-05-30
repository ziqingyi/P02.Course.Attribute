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
     * 1 install packages, Autofac, AutofacDependencyInjection(integrate with core).
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
     *
     *Filters: add in Startup, ConfigureServices method for Global filters, can inject automatically.
     *         (for old mvc, not by injecting, as it's attribute and fix by ctor)
     *
     * Execute Order: global filter executing, controller filter executing, action filter executing,
     *               action filter executed, controller  filter executed, global  filter executed,
     *               result  filter executing,  filter executed. 
     * Add filter: for parameter-less filters, add directly to controller, action, etc, test with CustomResultFilter
     *             for filter attribute with parameter, add globally
     *                  or (ServiceFilter with addScope, test with CustomActionFilterAttribute.)
     *                  or (use TypeFilter, test with CustomControllerActionFilterAttribute)
     *
     *  Order: smaller, executed first.
     *
     *
     *  Asp.net MVC: initialise controller first, then authentication, exception filters etc .
     *  Core MVC: initialise authentication, exception filters etc, then  controller first.
     *  So resource filter can be used for caching. 
     *
     * Execute Sequence: 
     *  Resource Filter --> initialize controller class --> global ->..........->global -> Result Executing -> Result Executed    -->Resource Filter --> result
     *
     *
     * Check Session :
     * 1 startup Configure--> add  app.UseSession();
     * 2 startup  ConfigureServices --> add session.
     *
     *
     *
     * Area:
     * 1 MapAreaControllerRoute in Startup Configure method
     * 2 Add area folders, add Area and Route attributes in controllers.
     *    (So can have base area controller class for all controllers, then do not write every time)
     *
     *
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
                        #region config logging builder directly

                        //loggingBuilder.AddFilter("System", LogLevel.Warning);//remove low level system and Microsoft logging 
                        //loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
                        //loggingBuilder.AddLog4Net("CfgFiles\\log4net.config");

                        #endregion

                        #region Use extend method to config logging builder

                        Log4Extension.InitLog4(loggingBuilder);

                        #endregion

                        
                    }
                )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }
}
