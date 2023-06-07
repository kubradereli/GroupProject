using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class statistis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Deger1 = table.Column<int>(type: "int", nullable: false),
                    Deger2 = table.Column<int>(type: "int", nullable: false),
                    Deger3 = table.Column<int>(type: "int", nullable: false),
                    Deger4 = table.Column<int>(type: "int", nullable: false),
                    Deger5 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");
        }
    }
}
