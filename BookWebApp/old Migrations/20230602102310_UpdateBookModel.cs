// using Microsoft.EntityFrameworkCore.Migrations;

// #nullable disable

// namespace BookWebApp.Migrations
// {
//     public partial class UpdateBookModel : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_BookCategory_BookInfo",
//                 table: "BookCategory");

//             migrationBuilder.DropTable(
//                 name: "BookInfo");

//             migrationBuilder.AddColumn<string>(
//                 name: "Author",
//                 table: "Book",
//                 type: "nvarchar(50)",
//                 maxLength: 50,
//                 nullable: false,
//                 defaultValue: "");

//             migrationBuilder.AddColumn<string>(
//                 name: "Image",
//                 table: "Book",
//                 type: "nvarchar(max)",
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "ReleaseYear",
//                 table: "Book",
//                 type: "int",
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "Title",
//                 table: "Book",
//                 type: "nvarchar(255)",
//                 maxLength: 255,
//                 nullable: false,
//                 defaultValue: "");

//             migrationBuilder.AddForeignKey(
//                 name: "FK_BookCategory_Book",
//                 table: "BookCategory",
//                 column: "BookId",
//                 principalTable: "Book",
//                 principalColumn: "Id");
//         }

//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_BookCategory_Book",
//                 table: "BookCategory");

//             migrationBuilder.DropColumn(
//                 name: "Author",
//                 table: "Book");

//             migrationBuilder.DropColumn(
//                 name: "Image",
//                 table: "Book");

//             migrationBuilder.DropColumn(
//                 name: "ReleaseYear",
//                 table: "Book");

//             migrationBuilder.DropColumn(
//                 name: "Title",
//                 table: "Book");

//             migrationBuilder.CreateTable(
//                 name: "BookInfo",
//                 columns: table => new
//                 {
//                     BookId = table.Column<int>(type: "int", nullable: false),
//                     Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
//                     Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                     ReleaseYear = table.Column<int>(type: "int", nullable: true),
//                     Title = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.ForeignKey(
//                         name: "FK_BookInfo_Book",
//                         column: x => x.BookId,
//                         principalTable: "Book",
//                         principalColumn: "Id");
//                 });

//             migrationBuilder.CreateIndex(
//                 name: "IX_BookInfo_BookId",
//                 table: "BookInfo",
//                 column: "BookId",
//                 unique: true);

//             migrationBuilder.AddForeignKey(
//                 name: "FK_BookCategory_BookInfo",
//                 table: "BookCategory",
//                 column: "BookId",
//                 principalTable: "Book",
//                 principalColumn: "Id");
//         }
//     }
// }
