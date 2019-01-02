using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Threading.Tasks;

namespace Presentation.Web.Middleware
{
    public class RessourcePurgingMiddleware
    {
        private readonly RequestDelegate _next;

        public RessourcePurgingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                BuildCacheResponse(context);
                await _next.Invoke(context);
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
            //    context.Response.OnStarting(state =>
            //    {
            //        var httpContext = (HttpContext)state;

            //        //Cache Matching
            //        httpContext.Response.Headers.Add(HeaderNames.ETag, "123456");

            //        //Allowance
            //        //httpContext.Response.Headers.Add(HeaderNames.CacheControl, "proxy-revalidate");
            //        httpContext.Response.Headers.Add(HeaderNames.CacheControl, "max-age=60");

            //        //Freshness



            //        return Task.FromResult(0);
            //    }, context);
            //}
        }
    }
}
