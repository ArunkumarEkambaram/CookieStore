using AutoMapper;
using CookieStore.Interfaces;
using CookieStore.Models;
using CookieStore.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieStore
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)//This is used for DI
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContextPool<ApplicationDbContext>(db => db.UseSqlServer(_configuration.GetConnectionString("CookieStoreConnection")));
            services.AddMvc();
            services.AddScoped<IRepository<Customer>, CustomerRepository>();
            services.AddScoped<IDoctor, DoctorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //DeveloperExceptionPageOptions developerExceptionPage = new DeveloperExceptionPageOptions
            //{
            //    SourceCodeLineCount = 10
            //};

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //app.UseFileServer();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(route =>
            {
                route.MapRoute(
                    name: "StartupRoute",
                    template: "/",
                    defaults: new { controller = "Home", action = "Index" }
                    );

                route.MapRoute(
                    name: "MyRoute",
                    template: "MyCompany/{controller=Home}/{action=Index}/{id?}"
                    );
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(System.AppDomain.CurrentDomain.FriendlyName);
            //});


            //app.Run(async (context) =>
            //{
            //    // throw new Exception("Unable to process your request");
            //    await context.Response.WriteAsync("Hello World!\n");
            //    //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);//dotnet             
            //    //await context.Response.WriteAsync(_configuration["MyKey"]);
            //});

        }


    }
}
