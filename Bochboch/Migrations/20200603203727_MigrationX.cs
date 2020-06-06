using Microsoft.EntityFrameworkCore.Migrations;

namespace Bochboch.Migrations
{
    public partial class MigrationX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "x",
                table: "Rectangles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "x",
                table: "Rectangles");
        }
    }
}
