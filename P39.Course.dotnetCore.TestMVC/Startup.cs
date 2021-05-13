using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace P39.Course.dotnetCore.TestMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            logger.LogError("This is start up logger ");

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
