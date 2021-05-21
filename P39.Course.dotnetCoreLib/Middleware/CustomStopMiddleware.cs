using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace P39.Course.dotnetCoreLib.Middleware
{
    public class CustomStopMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomStopMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.Contains("stop_point"))
            {
                await context.Response.WriteAsync($"{nameof(CustomMiddleware)} end of Custom Middleware <br/>",
                    System.Text.Encoding.UTF8);
            }


            await context.Response.WriteAsync($"{nameof(CustomMiddleware)} CustomStopMiddleware <br/>");
            await _next(context);
            await context.Response.WriteAsync($"{nameof(CustomMiddleware)} CustomStopMiddleware <br/>");



        }





    }
}
