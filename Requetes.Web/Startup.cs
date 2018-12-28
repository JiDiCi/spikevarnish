using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Requetes.Web.Middleware;

namespace Requetes.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:5000", "http://10.2.211.22:6081").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });
            app.UseStaticFiles();
            app.UseMiddleware<RessourceTagginMiddleware>();
            app.UseMvcWithDefaultRoute();
        }
    }
}
