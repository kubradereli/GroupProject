using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class about_add_files : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardDescription1",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardDescription2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardDescription3",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardDescription4",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardTitle1",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardTitle2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardTitle3",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardTitle4",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainTitle",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardDescription1",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CardDescription2",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CardDescription3",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CardDescription4",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CardTitle1",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CardTitle2",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CardTitle3",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CardTitle4",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "MainTitle",
                table: "Abouts");
        }
    }
}
