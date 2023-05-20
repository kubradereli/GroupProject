using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class create_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    AboutID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutDetails1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutDetails2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutBackgroundImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutSmallImage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutSmallImage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutStatus = table.Column<bool>(type: "bit", nullable: false),
                    CardTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardTitle3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardTitle4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardDescription1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardDescription3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardDescription4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.AboutID);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAbout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserStatus = table.Column<bool>(type: "bit", nullable: false),
                    RememberMe = table.Column<bool>(type: "bit", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookPageCount = table.Column<int>(type: "int", nullable: false),
                    BookPublishingHouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookCoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookBackCoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookStatus = table.Column<bool>(type: "bit", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactStatus = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                    table.ForeignKey(
                        name: "FK_Contacts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentStatus = table.Column<bool>(type: "bit", nullable: false),
                    ReadingActivityID = table.Column<int>(type: "int", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadBooks",
                columns: table => new
                {
                    ReadBookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ReadingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReadBookReviewPoint = table.Column<int>(type: "int", nullable: false),
                    BookReadStatus = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadBooks", x => x.ReadBookID);
                    table.ForeignKey(
                        name: "FK_ReadBooks_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReadBooks_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadingActivities",
                columns: table => new
                {
                    ReadingActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityFinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityStatus = table.Column<bool>(type: "bit", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    AdminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingActivities", x => x.ReadingActivityID);
                    table.ForeignKey(
                        name: "FK_ReadingActivities_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReadingActivities_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReadingActivities",
                columns: table => new
                {
                    UserReadingActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ReadingActivityID = table.Column<int>(type: "int", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    BookReviewScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReadingActivities", x => x.UserReadingActivityID);
                    table.ForeignKey(
                        name: "FK_UserReadingActivities_ReadingActivities_ReadingActivityID",
                        column: x => x.ReadingActivityID,
                        principalTable: "ReadingActivities",
                        principalColumn: "ReadingActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReadingActivities_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryID",
                table: "Books",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookID",
                table: "Comments",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserID",
                table: "Contacts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ReadBooks_BookID",
                table: "ReadBooks",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_ReadBooks_UserID",
                table: "ReadBooks",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingActivities_AdminID",
                table: "ReadingActivities",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingActivities_BookID",
                table: "ReadingActivities",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_UserReadingActivities_ReadingActivityID",
                table: "UserReadingActivities",
                column: "ReadingActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_UserReadingActivities_UserID",
                table: "UserReadingActivities",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ReadBooks");

            migrationBuilder.DropTable(
                name: "UserReadingActivities");

            migrationBuilder.DropTable(
                name: "ReadingActivities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
