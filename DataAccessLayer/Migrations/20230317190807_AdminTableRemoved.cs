using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AdminTableRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadingActivities_Admins_AdminID",
                table: "ReadingActivities");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingActivities_Users_AdminID",
                table: "ReadingActivities",
                column: "AdminID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadingActivities_Users_AdminID",
                table: "ReadingActivities");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminUsername = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingActivities_Admins_AdminID",
                table: "ReadingActivities",
                column: "AdminID",
                principalTable: "Admins",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
