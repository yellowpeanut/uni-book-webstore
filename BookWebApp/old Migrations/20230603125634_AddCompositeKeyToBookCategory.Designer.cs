﻿// // <auto-generated />
// using System;
// using BookWebApp.Data;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Infrastructure;
// using Microsoft.EntityFrameworkCore.Metadata;
// using Microsoft.EntityFrameworkCore.Migrations;
// using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

// #nullable disable

// namespace BookWebApp.Migrations
// {
//     [DbContext(typeof(BookWebAppContext))]
//     [Migration("20230603125634_AddCompositeKeyToBookCategory")]
//     partial class AddCompositeKeyToBookCategory
//     {
//         protected override void BuildTargetModel(ModelBuilder modelBuilder)
//         {
// #pragma warning disable 612, 618
//             modelBuilder
//                 .HasAnnotation("ProductVersion", "6.0.16")
//                 .HasAnnotation("Relational:MaxIdentifierLength", 128);

//             SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

//             modelBuilder.Entity("BookWebApp.Models.Book", b =>
//                 {
//                     b.Property<int>("Id")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("int");

//                     SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

//                     b.Property<string>("Author")
//                         .IsRequired()
//                         .HasMaxLength(50)
//                         .HasColumnType("nvarchar(50)");

//                     b.Property<string>("Image")
//                         .HasColumnType("nvarchar(max)");

//                     b.Property<int>("Price")
//                         .HasColumnType("int");

//                     b.Property<int?>("Rating")
//                         .HasColumnType("int");

//                     b.Property<float?>("ReleaseYear")
//                         .HasColumnType("real");

//                     b.Property<int>("SoldQuantity")
//                         .HasColumnType("int");

//                     b.Property<int>("StorageQuantity")
//                         .HasColumnType("int");

//                     b.Property<string>("Title")
//                         .IsRequired()
//                         .HasMaxLength(255)
//                         .HasColumnType("nvarchar(255)");

//                     b.HasKey("Id");

//                     b.ToTable("Book");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.BookCategory", b =>
//                 {
//                     b.Property<int>("BookId")
//                         .HasColumnType("int");

//                     b.Property<int>("CategoryId")
//                         .HasColumnType("int");

//                     b.HasKey("BookId", "CategoryId");

//                     b.HasIndex("CategoryId");

//                     b.ToTable("BookCategory");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.CartItem", b =>
//                 {
//                     b.Property<int>("Id")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("int");

//                     SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

//                     b.Property<int>("BookId")
//                         .HasColumnType("int");

//                     b.Property<int>("CartId")
//                         .HasColumnType("int");

//                     b.Property<int>("Quantity")
//                         .HasColumnType("int");

//                     b.HasKey("Id");

//                     b.HasIndex("BookId");

//                     b.HasIndex("CartId");

//                     b.ToTable("CartItem");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.Category", b =>
//                 {
//                     b.Property<int>("Id")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("int");

//                     SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

//                     b.Property<string>("Value")
//                         .IsRequired()
//                         .HasMaxLength(50)
//                         .HasColumnType("nvarchar(50)");

//                     b.HasKey("Id");

//                     b.ToTable("Category");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.InventoryItem", b =>
//                 {
//                     b.Property<int>("Id")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("int");

//                     SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

//                     b.Property<int>("BookId")
//                         .HasColumnType("int");

//                     b.Property<int>("InventoryId")
//                         .HasColumnType("int");

//                     b.Property<int>("Quantity")
//                         .HasColumnType("int");

//                     b.Property<int?>("Rating")
//                         .HasColumnType("int");

//                     b.HasKey("Id");

//                     b.HasIndex("BookId");

//                     b.HasIndex("InventoryId");

//                     b.ToTable("InventoryItem");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.User", b =>
//                 {
//                     b.Property<int>("Id")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("int");

//                     SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

//                     b.Property<int>("Balance")
//                         .HasColumnType("int");

//                     b.Property<string>("Email")
//                         .IsRequired()
//                         .HasMaxLength(64)
//                         .HasColumnType("nvarchar(64)");

//                     b.Property<string>("Password")
//                         .IsRequired()
//                         .HasMaxLength(32)
//                         .HasColumnType("nvarchar(32)");

//                     b.Property<string>("Username")
//                         .IsRequired()
//                         .HasMaxLength(64)
//                         .HasColumnType("nvarchar(64)");

//                     b.HasKey("Id");

//                     b.HasIndex("Email")
//                         .IsUnique();

//                     b.ToTable("User");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.UserCart", b =>
//                 {
//                     b.Property<int>("Id")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("int");

//                     SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

//                     b.Property<int>("UserId")
//                         .HasColumnType("int");

//                     b.HasKey("Id");

//                     b.HasIndex("UserId");

//                     b.ToTable("UserCart");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.UserInventory", b =>
//                 {
//                     b.Property<int>("Id")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("int");

//                     SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

//                     b.Property<int>("UserId")
//                         .HasColumnType("int");

//                     b.HasKey("Id");

//                     b.HasIndex("UserId");

//                     b.ToTable("UserInventory");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.BookCategory", b =>
//                 {
//                     b.HasOne("BookWebApp.Models.Book", "Book")
//                         .WithMany()
//                         .HasForeignKey("BookId")
//                         .IsRequired()
//                         .HasConstraintName("FK_BookCategory_Book");

//                     b.HasOne("BookWebApp.Models.Category", "Category")
//                         .WithMany()
//                         .HasForeignKey("CategoryId")
//                         .IsRequired()
//                         .HasConstraintName("FK_BookCategory_Category");

//                     b.Navigation("Book");

//                     b.Navigation("Category");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.CartItem", b =>
//                 {
//                     b.HasOne("BookWebApp.Models.Book", "Book")
//                         .WithMany("CartItem")
//                         .HasForeignKey("BookId")
//                         .IsRequired()
//                         .HasConstraintName("FK_CartItem_Book");

//                     b.HasOne("BookWebApp.Models.UserCart", "Cart")
//                         .WithMany("CartItem")
//                         .HasForeignKey("CartId")
//                         .IsRequired()
//                         .HasConstraintName("FK_CartItem_UserCart");

//                     b.Navigation("Book");

//                     b.Navigation("Cart");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.InventoryItem", b =>
//                 {
//                     b.HasOne("BookWebApp.Models.Book", "Book")
//                         .WithMany("InventoryItem")
//                         .HasForeignKey("BookId")
//                         .IsRequired()
//                         .HasConstraintName("FK_InventoryItem_Book");

//                     b.HasOne("BookWebApp.Models.UserInventory", "Inventory")
//                         .WithMany("InventoryItem")
//                         .HasForeignKey("InventoryId")
//                         .IsRequired()
//                         .HasConstraintName("FK_InventoryItem_UserInventory");

//                     b.Navigation("Book");

//                     b.Navigation("Inventory");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.UserCart", b =>
//                 {
//                     b.HasOne("BookWebApp.Models.User", "User")
//                         .WithMany("UserCart")
//                         .HasForeignKey("UserId")
//                         .IsRequired()
//                         .HasConstraintName("FK_UserCart_User");

//                     b.Navigation("User");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.UserInventory", b =>
//                 {
//                     b.HasOne("BookWebApp.Models.User", "User")
//                         .WithMany("UserInventory")
//                         .HasForeignKey("UserId")
//                         .IsRequired()
//                         .HasConstraintName("FK_UserInventory_User");

//                     b.Navigation("User");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.Book", b =>
//                 {
//                     b.Navigation("CartItem");

//                     b.Navigation("InventoryItem");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.User", b =>
//                 {
//                     b.Navigation("UserCart");

//                     b.Navigation("UserInventory");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.UserCart", b =>
//                 {
//                     b.Navigation("CartItem");
//                 });

//             modelBuilder.Entity("BookWebApp.Models.UserInventory", b =>
//                 {
//                     b.Navigation("InventoryItem");
//                 });
// #pragma warning restore 612, 618
//         }
//     }
// }
