using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4390Project.Data.Migrations
{
    public partial class AddCapacity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Speaker",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Speaker");
        }
    }
}
