using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
                options =>
                {
                    options.Filters.Add(typeof(CustomExceptionFilterAttribute));
                    options.Filters.Add(typeof(CustomGlobalActionFilterAttribute), 1);
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            #endregion

            #region for filter services, use framwork DI 

            services.AddScoped<CustomActionFilterAttribute>();

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
            /*
             * note: it's better to  do one thing in one middleware 
             *
             *
             */

            #region add 2 test middle ware

            ////build middleware first
            //Func<RequestDelegate, RequestDelegate> middleware1 = new Func<RequestDelegate, RequestDelegate>(
            //        next =>
            //{
            //    Console.WriteLine("this is middleware 1");

            //    RequestDelegate newRd = new RequestDelegate(async context =>
            //    {
            //        await context.Response.WriteAsync("<h3>This is Middleware1 start</h3>");
            //        await next.Invoke(context);// this will use next from the middleware Func. 
            //        await context.Response.WriteAsync("<h3>This is Middleware1 end</h3>");
            //    });

            //    return newRd;
            //}

            //);

            //// use the middleware in app
            //app.Use(middleware1);



            ////build middleware first
            //Func<RequestDelegate, RequestDelegate> middleware2 = new Func<RequestDelegate, RequestDelegate>(
            //    next =>
            //    {
            //        Console.WriteLine("this is middleware2");

            //        RequestDelegate newRd = new RequestDelegate(async context =>
            //        {
            //            await context.Response.WriteAsync("<h3>This is Middleware2 start</h3>");
            //            await next.Invoke(context);// this will use next from the middleware Func. 
            //            await context.Response.WriteAsync("<h3>This is Middleware2 end</h3>");
            //        });

            //        return newRd;
            //    }

            //);

            //// use the middleware in app
            //app.Use(middleware2);





            ////build middleware first
            //Func<RequestDelegate, RequestDelegate> middleware3 = new Func<RequestDelegate, RequestDelegate>(
            //    next =>
            //    {
            //        Console.WriteLine("this is middleware3");

            //        RequestDelegate newRd = new RequestDelegate(async context =>
            //        {
            //            await context.Response.WriteAsync("<h3>This is Middleware3 start</h3>");
            //            //comment out will blocking all following for app
            //            //await next.Invoke(context);// this will use next from the middleware Func. 
            //            await context.Response.WriteAsync("<h3>This is Middleware3 end</h3>");
            //        });

            //        return newRd;
            //    }

            //);

            //// use the middleware in app
            //app.Use(middleware3);

            /*
             * <h3>This is Middleware1 start</h3>
             * <h3>This is Middleware2 start</h3>
             * <h3>This is Middleware3 start</h3>
             * <h3>This is Middleware3 end</h3>
             * <h3>This is Middleware2 end</h3>
             * <h3>This is Middleware1 end</h3>
             */

            #endregion

            #region Middleware register in 3 ways

            //// 1 Run() method,  finish at this point. 
            //app.Run(async (HttpContext context) =>
            //{
            //    await context.Response.WriteAsync("Hello World Run");
            //});
            //    //will never execute
            //app.Run(async (HttpContext context) =>
            //{
            //    await context.Response.WriteAsync("Hello World Run Again");
            //});
            //// 2 app.Use(), another Extend method, execute order same to first Use()
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello World Use1 <br/>");
            //    await next();
            //    await context.Response.WriteAsync("Hello World Use1 End <br/>");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello World Use2 <br/>");
            //    await next();
            //    await context.Response.WriteAsync("Hello World Use2 End <br/>");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello World Use2 <br/>");
            //    //await next();//block here
            //    await context.Response.WriteAsync("Hello World Use2 End <br/>");
            //});

            ////// 3 UseWhen(), check HttpContext and process,if predicate is false, other process will not be affected. 
            //app.UseWhen(context => { return context.Request.Query.ContainsKey("name"); },
            //    appBuilder =>
            //    {
            //        appBuilder.Use(async (context, next) =>
            //        {
            //            await context.Response.WriteAsync("Hello World Use3 Again Again Again <br/>");
            //            await next();
            //        });
            //    });

            #endregion


            #region Test Map, execute and stop following process.
            ////https://localhost:44326/test
            //app.Map("/test", MapTest);

            ////https://localhost:44326/test2
            //app.Map("/test2", a => a.Run(
            //    async context =>
            //    {
            //        await context.Response.WriteAsync("This is Advanced Test Site");
            //        //
            //    }
            //));
            ////if true, the following steps will not be executed.eg:https://localhost:44326/?name=123
            //app.MapWhen(context =>
            //{
            //    bool result = context.Request.Query.ContainsKey("Name");
            //    return result;
            //    //check browser
            //    //language
            //    //ajax process
            //}, MapTest);

            #endregion


            #region Middleware Class

            app.UseMiddleware<>();
            


            #endregion







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



        private static void MapTest(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                //
                await context.Response.WriteAsync($"Url is {context.Request.Path.Value}");
            });
        }







    }
}
