using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ЛабРаб7
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string path = httpContext.Request.Path.Value.ToLower();
            if (path == "/test1")
            {
                await httpContext.Response.WriteAsync("You have opened the page test1");
            }
            else if (path == "/test2")
            {
                await httpContext.Response.WriteAsync("You have opened the page test2");
            }
            else
            {
                httpContext.Response.StatusCode = 404;
                await httpContext.Response.WriteAsync("Path not found");
            }  
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
