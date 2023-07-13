using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BookWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookWebApp.Data
{
    public partial class BookWebAppContext : IdentityDbContext<Models.User>
    {
        public BookWebAppContext()
        {
        }

        public BookWebAppContext(DbContextOptions<BookWebAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookCategory> BookCategory { get; set; }
        //public virtual DbSet<BookInfo> BookInfo { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<InventoryItem> InventoryItem { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCart> UserCart { get; set; }
        public virtual DbSet<UserInventory> UserInventory { get; set; }
        // public virtual DbSet<Role> Role { get; set; }
        // public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LOCALHOST;Database=BookWebApp;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.HasKey(d => new {d.BookId, d.CategoryId});

                entity.HasOne(d => d.Book)
                    .WithMany()
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookCategory_Book");

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookCategory_Category");
            });

/*            modelBuilder.Entity<BookInfo>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Title).IsFixedLength();

                entity.HasOne(d => d.Book)
                    .WithOne()
                    .HasForeignKey<BookInfo>(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookInfo_Book");
            });*/

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.CartItem)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItem_Book");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItem)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItem_UserCart");
            });

            modelBuilder.Entity<InventoryItem>(entity =>
            {
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.InventoryItem)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryItem_Book");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.InventoryItem)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryItem_UserInventory");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(d => d.Email)
                    .IsUnique();
            });

            modelBuilder.Entity<UserCart>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCart)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCart_User");
            });

            modelBuilder.Entity<UserInventory>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInventory)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInventory_User");
            });

            // modelBuilder.Entity<UserRole>(entity =>
            // {
            //     // entity.HasOne(d => d.User)
            //     //     .WithMany()
            //     //     .HasForeignKey(d => d.UserId)
            //     //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     //     .HasConstraintName("FK_UserRole_User")
            //     //     .IsRequired();

            //     // entity.HasOne(d => d.Role)
            //     //     .WithMany()
            //     //     .HasForeignKey(d => d.RoleId)
            //     //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     //     .HasConstraintName("FK_UserRole_Role")
            //     //     .IsRequired();
            // });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
