using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace uni_book_webstore.Migrations
{
    public partial class AddPostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "Book",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real(5)",
                oldPrecision: 5,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_BookId",
                table: "Post",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "Book",
                type: "real(5)",
                precision: 5,
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }
    }
}
