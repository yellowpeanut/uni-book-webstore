﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using System.Linq;
using BookWebApp.Data.Services;
using System.IO;
using System;
using System.Threading.Tasks;


namespace BookWebApp.Data
{
    public class DbInitializer
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BookWebAppContext>();
                context.Database.EnsureCreated();

                if (!context.Book.Any())
                {
                    Random rnd = new Random();
                    //var catServ = serviceScope.ServiceProvider.GetService<CategoryService>();
                    //var bdServ = serviceScope.ServiceProvider.GetService<BookDataService>();
                    var bServ = new BookService(context);

                    var jsonString = File.ReadAllText("Data\\bookdata.json");
                    if(jsonString != String.Empty)
                    {
                        /*                        var options = new JsonSerializerOptions()
                                                {
                                                    AllowTrailingCommas = true,
                                                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                                                };
                                                var bdList = JsonSerializer.Deserialize<List<BookData>>(jsonString, options);
                        */
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
                    }
                }
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
            }
        }
    }
}