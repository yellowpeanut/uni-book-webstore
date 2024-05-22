using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using System.Linq;
using Application.Data.Services;
using System.IO;
using System;
using System.Threading.Tasks;
using Application.Models;
using Microsoft.AspNetCore.Identity;
using Application.Data.Enums;

namespace Application.Data
{
    public class DbInitializer
    {
        public static async Task SeedAsync(WebApplication app)
        {

            using (var serviceScope = app.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();
                context.Database.EnsureCreated();

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                Roles roleStruct = new Roles();
                var roles = roleStruct.GetType().GetFields();
                foreach(var r in roles)
                {
                    string role = r.GetValue(roleStruct).ToString();
                    if(!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }

                if (!context.Book.Any())
                {
                    Random rnd = new Random();
                    var bookService = serviceScope.ServiceProvider.GetService<BookService>();

                    /*                    var jsonString = File.ReadAllText("Data\\bookdata.json");
                                        if(jsonString != String.Empty)
                                        {
                                            *//*                        var options = new JsonSerializerOptions()
                                                                    {
                                                                        AllowTrailingCommas = true,
                                                                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                                                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                                                                    };
                                                                    var bdList = JsonSerializer.Deserialize<List<BookData>>(jsonString, options);
                                            *//*
                                            var bdList = DbSeedingData.GetList();
                                            foreach (var bd in bdList)
                                            {
                                                bd.Book.Price = rnd.Next(250, 1000);
                                                bd.Book.Rating = null;
                                                bd.Book.ReleaseYear = rnd.Next(1995, 2015);
                                                bd.Book.SoldQuantity = 0;
                                                bd.Book.StorageQuantity = rnd.Next(10, 100);

                                                await bServ.AddWithCategoriesAsync(bd.Book, bd.CategoryValues);
                                            }
                                            await context.SaveChangesAsync();
                                        }*/

                    var bdList = DbSeedingData.GetList();
                    foreach (var bd in bdList)
                    {
                        bd.Book.Price = (uint) rnd.Next(250, 1000);
                        bd.Book.Rating = null;
                        bd.Book.ReleaseYear = (ushort) rnd.Next(1995, 2015);
                        bd.Book.SoldQuantity = 0;

                        await bookService.AddWithCategoriesAsync(bd.Book, bd.CategoryValues);
                    }
                    await context.SaveChangesAsync();
                }
                // var ctest = context.BookCategory.ToList();
/*                if (!context.BookCategory.Any())
                {
                    var bServ = new BookService(context);
                    var bcServ = new BookCategoryService(context);
                    var bdList = DbSeedingData.GetList();
                    var bList = (await bServ.GetAllAsync()).ToList();
                    for (int i = 0; i < bList.Count()-1; i++)
                    {
                        await bcServ.AddAsync(new Models.BookCategory()
                        {
                            BookId = bList[i].Id,
                            Book = bList[i],
                            
                        });
                    }
                }*/
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                if(await userManager.FindByEmailAsync("admin@admin.com") == null)
                {
                    User user = new User(){
                        UserName = "admin",
                        Password = "admin12345",
                        Email = "admin@admin.com"
                    };


                    var userService = serviceScope.ServiceProvider.GetService<UserService>();
                    await userService.AddAsync(user, Roles.Admin, userManager);

                    if (userService is null)
                        System.Diagnostics.Debug.WriteLine("user service not exists");
                    else
                        System.Diagnostics.Debug.WriteLine("user service exists!!");
                }
                else { System.Diagnostics.Debug.WriteLine("admin exists!!"); }
            }
        }
    }
}
