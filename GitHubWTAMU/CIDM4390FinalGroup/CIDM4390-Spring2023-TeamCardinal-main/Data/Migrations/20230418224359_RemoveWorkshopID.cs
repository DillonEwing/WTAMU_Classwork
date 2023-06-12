using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4390Project.Data.Migrations
{
    public partial class RemoveWorkshopID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkshopID",
                table: "Session");

            migrationBuilder.RenameColumn(
                name: "WorkshopID",
                table: "Registration",
                newName: "SessionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionID",
                table: "Registration",
                newName: "WorkshopID");

            migrationBuilder.AddColumn<int>(
                name: "WorkshopID",
                table: "Session",
                type: "INTEGER",
                nullable: true);
        }
    }
}
