using Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Application.Data;
using Application.Data.Services;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationContextConnection' not found.");

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<BookCategoryService>();
builder.Services.AddScoped<BookDataService>();
builder.Services.AddScoped<InventoryItemService>();
builder.Services.AddScoped<CartItemService>();
builder.Services.AddScoped<UserInventoryService>();
builder.Services.AddScoped<UserCartService>();

builder.Services.AddDefaultIdentity<User>(options =>
{ 
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddScoped<UserService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await DbInitializer.SeedAsync(app);

app.Run();
