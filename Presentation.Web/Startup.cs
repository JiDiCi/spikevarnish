using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Web.Middleware;

namespace Presentation.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();



            //Cache profiles
            //options.CacheProfiles.Add("Default",
            //    new CacheProfile()
            //    {
            //        Duration = 60
            //    });
            //options.CacheProfiles.Add("Never",
            //    new CacheProfile()
            //    {
            //        Location = ResponseCacheLocation.None,
            //        NoStore = true
            //    });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMiddleware<RessourcePurgingMiddleware>();



            app.UseMvcWithDefaultRoute();
        }
    }
}
