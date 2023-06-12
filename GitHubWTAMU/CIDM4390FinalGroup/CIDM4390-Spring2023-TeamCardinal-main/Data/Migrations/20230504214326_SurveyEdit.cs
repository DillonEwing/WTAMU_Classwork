using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4390Project.Data.Migrations
{
    public partial class SurveyEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventID",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "SessionID",
                table: "Survey");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Survey",
                newName: "RegistrationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistrationID",
                table: "Survey",
                newName: "UserID");

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "Survey",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionID",
                table: "Survey",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
