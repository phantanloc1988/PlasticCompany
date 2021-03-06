using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlasticCompany.Areas.Admin.Services.BannerServices;
using PlasticCompany.Areas.Admin.Services.InformationServices;
using PlasticCompany.Areas.Admin.Services.ProductCategoriesServies;
using PlasticCompany.Areas.Admin.Services.ProductsServices;
using PlasticCompany.Common.MyServices;
using PlasticCompany.Models;

namespace PlasticCompany
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

            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddDbContext<PlasticCompanyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnectionString")));
            services.AddMvc().AddNewtonsoftJson();
            services.AddHttpContextAccessor();
            services.AddTransient<IMyServices,MyServices>();
            services.AddTransient<IProductCategories,ProductCategoriesServices>();
            services.AddTransient<IProduct,ProductServices>();
            services.AddTransient<IInformation, InformationServices>();
            services.AddTransient<IBanner, BannerServices>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
