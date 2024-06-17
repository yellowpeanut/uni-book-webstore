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
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public class DbInitializer
    {
        public static async Task SeedAsync(WebApplication app)
        {

            using (var serviceScope = app.Services.CreateScope())
            {
                Random rnd = new Random();
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();
                context.Database.EnsureCreated();

                // ROLES //
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                Roles roleStruct = new Roles();
                var roles = roleStruct.GetType().GetFields();
                foreach(var r in roles)
                {
                    string role = r.GetValue(roleStruct).ToString();
                    if(!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }

                // BOOKS //
                if (!context.Book.Any())
                {
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
                        bd.Book.Rating = null;
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

                // ADMIN USER //
                var userService = serviceScope.ServiceProvider.GetService<UserService>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                if(await userManager.FindByEmailAsync("admin@admin.com") == null)
                {
                    User user = new User(){
                        UserName = "admin",
                        Password = "admin12345",
                        Email = "admin@admin.com"
                    };

                    await userService.AddAsync(user, Roles.Admin, userManager);

                    if (userService is null)
                        System.Diagnostics.Debug.WriteLine("user service not exists");
                    else
                        System.Diagnostics.Debug.WriteLine("user service exists!!");
                }
                else { System.Diagnostics.Debug.WriteLine("admin exists!!"); }

                // OTHER USERS //

                var userList = new List<User>() {
                    new User()
                    {
                        UserName = "Владимир",
                        Password = "vladimir12345",
                        Email = "vladimir@mail.com"
                    },
                    new User()
                    {
                        UserName = "Петр",
                        Password = "petr12345",
                        Email = "petr@mail.com"
                    },
                    new User()
                    {
                        UserName = "Иван",
                        Password = "ivan12345",
                        Email = "ivan@mail.com"
                    }
                };

                foreach (var u in userList)
                {
                    if (await userManager.FindByEmailAsync(u.Email) == null)
                    {
                        await userService.AddAsync(u, Roles.User, userManager);
                    }
                }

                // POSTS //
                /*context.Database.ExecuteSqlRaw("TRUNCATE TABLE [Post]");
                context.SaveChanges();*/
                var postService = serviceScope.ServiceProvider.GetService<PostService>();
                if ((await postService.GetAllAsync()).Count() < 1)
                {
                    var admin = await userManager.FindByEmailAsync("admin@admin.com");
                    if (admin != null)
                    {
                        var bookService = serviceScope.ServiceProvider.GetService<BookService>();
                        var bookList = await bookService.GetAllAsync();
                        foreach (var book in bookList)
                        {
                            var post = new Post()
                            {
                                UserId = admin.Id,
                                BookId = book.Id,
                                Price = (uint)rnd.Next(250, 1000),
                                ReleaseYear = (ushort)rnd.Next(1995, 2015)
                            };
                            await postService.AddAsync(post);
                        }

                        foreach (var u in userList)
                        {
                            var currentUser = await userManager.FindByEmailAsync(u.Email);
                            if (currentUser != null)
                            {
                                var bookChunk = bookList.OrderBy(x => rnd.Next()).Take(rnd.Next(3, 15));
                                foreach (var book in bookChunk)
                                {
                                    var post = new Post()
                                    {
                                        UserId = currentUser.Id,
                                        BookId = book.Id,
                                        Price = (uint)rnd.Next(250, 1000),
                                        ReleaseYear = (ushort)rnd.Next(1995, 2015)
                                    };
                                    await postService.AddAsync(post);
                                }
                            }
                        }
                    }

                }

                // USER ITEMS IN INVENTORY AND CART //
                var userCartService = serviceScope.ServiceProvider.GetService<UserCartService>();
                var userInventoryService = serviceScope.ServiceProvider.GetService<UserInventoryService>();
                var cartItemService = serviceScope.ServiceProvider.GetService<CartItemService>();
                var inventoryItemService = serviceScope.ServiceProvider.GetService<InventoryItemService>();
                if ((await cartItemService.GetByCartIdAsync(
                    (await userCartService.GetByUserIdAsync(
                        (await userManager.FindByEmailAsync(userList.First().Email)).Id
                        )).Id
                    )).Count() < 1)
                {
                    var bookService = serviceScope.ServiceProvider.GetService<BookService>();
                    var bookList = await bookService.GetAllAsync();
                    foreach (var u in userList)
                    {
                        var currentUser = await userManager.FindByEmailAsync(u.Email);
                        if (currentUser != null)
                        {
                            var userCart = await userCartService.GetByUserIdAsync(currentUser.Id);
                            var bookChunk = bookList.OrderBy(x => rnd.Next()).Take(rnd.Next(3, 15));
                            foreach (var book in bookChunk)
                            {
                                var cartItem = new CartItem()
                                {
                                    CartId = userCart.Id,
                                    BookId = book.Id,
                                    Quantity = 1
                                };
                                await cartItemService.AddAsync(cartItem);
                            }
                            var userInventory = await userInventoryService.GetByUserIdAsync(currentUser.Id);
                            bookChunk = bookList.OrderBy(x => rnd.Next()).Take(rnd.Next(3, 15));
                            foreach (var book in bookChunk)
                            {
                                var inventoryItem = new InventoryItem()
                                {
                                    InventoryId = userCart.Id,
                                    BookId = book.Id,
                                    Quantity = 1
                                };
                                await inventoryItemService.AddAsync(inventoryItem);
                            }
                        }
                    }
                }

            }
        }
    }
}
