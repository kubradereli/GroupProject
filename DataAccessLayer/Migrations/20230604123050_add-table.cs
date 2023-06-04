using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Books_BookID",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "Comments",
                newName: "ReadingActivityID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BookID",
                table: "Comments",
                newName: "IX_Comments_ReadingActivityID");

            migrationBuilder.CreateTable(
                name: "BookQuotes",
                columns: table => new
                {
                    BookQuoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookQuoteContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookQuoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookQuoteStatus = table.Column<bool>(type: "bit", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookQuotes", x => x.BookQuoteID);
                    table.ForeignKey(
                        name: "FK_BookQuotes_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookQuotes_BookID",
                table: "BookQuotes",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ReadingActivities_ReadingActivityID",
                table: "Comments",
                column: "ReadingActivityID",
                principalTable: "ReadingActivities",
                principalColumn: "ReadingActivityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ReadingActivities_ReadingActivityID",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "BookQuotes");

            migrationBuilder.RenameColumn(
                name: "ReadingActivityID",
                table: "Comments",
                newName: "BookID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ReadingActivityID",
                table: "Comments",
                newName: "IX_Comments_BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Books_BookID",
                table: "Comments",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
