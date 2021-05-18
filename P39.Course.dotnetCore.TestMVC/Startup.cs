using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using P39.Course.dotnetCore.TestMVC.Utility;
using P39.Course.dotnetCoreLib.Filters;

namespace P39.Course.dotnetCore.TestMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // ConfigureServices method gets called by the runtime. Use this method to add services to the container.
        // //DI and IOC. 

        #region 1 Core default way of ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            #region set up the in-memory session provider with a default in-memory implementation of IDistributedCache:

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            #endregion

            services.AddControllersWithViews();

            #region add filters globally 

            services.AddControllers(
                o => o.Filters.Add(typeof(CustomExceptionFilterAttribute))
            )
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
  

            #endregion
    
        }

        #endregion

        #region 2 ConfigureServices with Autofac
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
           
            #region autofac container

            containerBuilder.RegisterModule<CustomAutofacModule>();

            #endregion

        }

        #endregion




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //DI and IOC. 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory factory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            #region read configuration file

            string option1 = this.Configuration["option1"];
            string option2 = this.Configuration["option2"];

            string suboption1 = this.Configuration["subsection:suboption1"];

            //test wizards
            string wName1 = this.Configuration["wizards:0:Name"];
            string age1 = this.Configuration["wizards:0:Age"];

            string wName2 = this.Configuration["wizards:1:Name"];
            string age2 = this.Configuration["wizards:1:Age"];
            #endregion

            #region Configure Log

            ILogger<Startup> logger = factory.CreateLogger<Startup>();
            logger.LogInformation("This is start up logger ");

            #endregion



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            #region add session
            //app.UseSession() must be added after UseRouting() and before app.UseEndpoints()
            app.UseSession();

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                ////same to old format
                //endpoints.MapControllerRoute(
                //    name: "old_default",
                //    pattern: "{controller}/{action}/{id}",
                //    defaults: new { controller = "Home", action = "Index", Id = -1 }
                //    );

            });



        }
    }
}
