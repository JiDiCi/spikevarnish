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
                string test = "avant";
                BuildCacheResponse(context);
                await _next.Invoke(context);
                test = "apres";

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
                httpContext.Response.Headers.Add(HeaderNames.ETag, "Test");

                return Task.FromResult(0);
            }, context);
        }
    }
}
