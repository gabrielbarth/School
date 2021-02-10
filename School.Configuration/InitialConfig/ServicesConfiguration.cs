using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using School.Repository.Data;

namespace School.Configuration.InitialConfig
{
    public static class ServicesConfiguration
    {
        public static void AddConfigurations(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<Context>(
                context => context.UseSqlServer(config.GetConnectionString("Default"))
            );

        }

        public static void SetConfigurations(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("AllowAnyOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
