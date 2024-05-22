using Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public class ApplicationContext : IdentityDbContext<User>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Book { get; set; }
    public virtual DbSet<BookCategory> BookCategory { get; set; }
    public virtual DbSet<CartItem> CartItem { get; set; }
    public virtual DbSet<Category> Category { get; set; }
    public virtual DbSet<InventoryItem> InventoryItem { get; set; }
    public virtual DbSet<Post> Post { get; set; }
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<UserCart> UserCart { get; set; }
    public virtual DbSet<UserInventory> UserInventory { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
