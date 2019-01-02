using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Requetes.Web.Middleware
{
    public class RessourceTagginMiddleware
    {
        private readonly RequestDelegate _next;

        public RessourceTagginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var test = 1;
                //BuildCacheResponse(context);
                await _next.Invoke(context);
                test = 2;
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            throw exception;
        }

        private void BuildCacheResponse(HttpContext context)
        {
            context.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext)state;

                //Cache Matching
                httpContext.Response.Headers.Add(HeaderNames.ETag, "123456");

                //Allowance
                //httpContext.Response.Headers.Add(HeaderNames.CacheControl, "proxy-revalidate");
                httpContext.Response.Headers.Add(HeaderNames.CacheControl, "max-age=60");

                //Freshness



                return Task.FromResult(0);
            }, context);
        }
    }

}
