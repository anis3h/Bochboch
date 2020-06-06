using Microsoft.EntityFrameworkCore.Migrations;

namespace Bochboch.Migrations
{
    public partial class MigrationY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "y",
                table: "Rectangles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "y",
                table: "Rectangles");
        }
    }
}
