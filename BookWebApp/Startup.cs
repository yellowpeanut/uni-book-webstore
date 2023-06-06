using BookWebApp.Data;
using BookWebApp.Data.Services;
using BookWebApp.Data.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp
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
            services.AddDbContext<BookWebAppContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            //Configure services
            services.AddScoped<IBookCategoryService, BookCategoryService>();
            services.AddScoped<IBookCategoryService, BookCategoryService>();
            services.AddScoped<IBookDataService, BookDataService>();
            //services.AddScoped<IBookInfoService, BookInfoService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IInventoryItemService, InventoryItemService>();
            services.AddScoped<IUserCartService, UserCartService>();
            services.AddScoped<IUserInventoryService, UserInventoryService>();
            services.AddScoped<IUserService, UserService>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(12);
/*                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;*/
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            await DbInitializer.SeedAsync(app);
        }
    }
}
