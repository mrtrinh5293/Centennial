using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoccerClubManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace SoccerClubManagement
{
    public class Startup
    {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public IConfiguration Configuration { get; }

            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:SoccerManagementClubs:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options =>
                 options.UseSqlServer(
                    Configuration["Data:SoccerClubIdentity:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IClubRepository, EFClubRepository>();
            //services.AddTransient<IClubRepository, FakeClubRepository>();
            services.AddMvc();
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseAuthentication();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "Page{homePage:int}",
                    defaults: new { controller = "Home", action = "Index" }
                    );
                //routes.MapRoute(
                //   name: null,
                //   template: "category",
                //   defaults: new { controller = "Home", action = "Index", productPage = 1 }
                //   );
                //routes.MapRoute(name: "Paging", template: "Product/Page{productPage}", defaults: new { Controller = "Product", Action = "List" }) ;
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");

            });
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
