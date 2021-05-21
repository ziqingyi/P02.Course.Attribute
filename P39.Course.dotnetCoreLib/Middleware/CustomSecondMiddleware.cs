using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace P39.Course.dotnetCoreLib.Middleware
{
    public class CustomSecondMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomSecondMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"{nameof(CustomMiddleware)} CustomSecondMiddleware <br/>");
            await _next(context);
            await context.Response.WriteAsync($"{nameof(CustomMiddleware)} CustomSecondMiddleware <br/>");
        }

    }
}
