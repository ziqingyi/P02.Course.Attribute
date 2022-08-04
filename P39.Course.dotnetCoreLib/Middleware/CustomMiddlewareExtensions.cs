using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace P39.Course.dotnetCoreLib.Middleware
{
    public static class CustomMiddlewareExtensions
    {

        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }


    }
}
