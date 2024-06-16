using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace uni_book_webstore.Migrations
{
    public partial class MoveColumnsFromBookToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Book");

            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "Post",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ReleaseYear",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Post");

            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "Book",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ReleaseYear",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
