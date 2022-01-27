using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookshop.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    PublishedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "BooksAuthors",
                columns: table => new
                {
                    BookGuid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuthorGuid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksAuthors", x => new { x.BookGuid, x.AuthorGuid });
                    table.ForeignKey(
                        name: "FK_BooksAuthors_Authors_AuthorGuid",
                        column: x => x.AuthorGuid,
                        principalTable: "Authors",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksAuthors_Books_BookGuid",
                        column: x => x.BookGuid,
                        principalTable: "Books",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooksAuthors_AuthorGuid",
                table: "BooksAuthors",
                column: "AuthorGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksAuthors");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
