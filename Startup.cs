using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MyApp.Data;
using MyApp.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using MyApp.Models;

namespace MyApp
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) // dependencies injection
        {
            services.AddDbContext<MyAppContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("MyAppConnection"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6; // password length
            }).AddEntityFrameworkStores<MyAppContext>();

            services.AddTransient<DbSeeder>(); // once added, not remaining in cache
            services.AddScoped<ITeacherRepository, TeacherRepository>(); // service life cycle. create instance when http request. abandon instance when request finished.
            services.AddScoped<IStudentRepository, StudentRepository>(); // register services
            // services.AddSingleton(); // create once and use again
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbSeeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseRouting();

            app.UseStaticFiles(); // middle ware to use static files

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}"); // default page
            });

            seeder.SeedDatabase().Wait(); // seeding

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
