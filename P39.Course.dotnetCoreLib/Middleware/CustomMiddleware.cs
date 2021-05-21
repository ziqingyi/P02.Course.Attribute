using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace P39.Course.dotnetCoreLib.Middleware
{
    public class CustomMiddleware //:IMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"{nameof(CustomMiddleware)} CustomMiddleware <br/>");
            await _next(context);
            await context.Response.WriteAsync($"{nameof(CustomMiddleware)} CustomMiddleware <br/>");
        }

    }
}
