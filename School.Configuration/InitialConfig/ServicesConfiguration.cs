using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using School.Repository.Data;
using AutoMapper;
using System;
using System.IO;
using System.Reflection;
using School.Application.Helpers;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace School.Configuration.InitialConfig
{
    public static class ServicesConfiguration
    {
        public static void AddConfigurations(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<Context>(
                context => context.UseSqlServer(config.GetConnectionString("Default"))
            );
            
            services.AddControllers().AddNewtonsoftJson(
                option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(typeof(SchoolProfile));
            
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IRepository, Repository.Data.Repository>();

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            })
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            var apiProviderDescription = services.BuildServiceProvider()
                                                 .GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(options =>
            {
                foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                        description.GroupName,
                        new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = "Scholl API",
                            Version = description.ApiVersion.ToString(),
                            TermsOfService = new Uri("https://policies.google.com/terms?hl=pt-BR"),
                            Description = "Descrição dos termos de uso do SchoolAPI",
                            License = new Microsoft.OpenApi.Models.OpenApiLicense
                            {
                                Name = "School License",
                                Url = new Uri("https://policies.google.com/terms?hl=pt-BR")
                            },
                            Contact = new Microsoft.OpenApi.Models.OpenApiContact
                            {
                                Name = "Gabriel Barth",
                                Email = "",
                                Url = new Uri("https://gabrielbarth.com")
                            }
                        }
                    );
                }
                

                var xmlCommentsFile = "School.API.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                options.IncludeXmlComments(xmlCommentsFullPath);
            });
        }

        public static void SetConfigurations(this IApplicationBuilder app, 
                                             IWebHostEnvironment env,
                                             IApiVersionDescriptionProvider apiProviderDescription)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger().UseSwaggerUI(options =>
            {
                foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"swagger/{description.GroupName}/swagger.json", 
                                              description.GroupName.ToUpperInvariant());
                }

                options.RoutePrefix = "";
            });

            app.UseCors("AllowAnyOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
