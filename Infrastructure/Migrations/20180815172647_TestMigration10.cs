using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class TestMigration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Pregnanicies");

            migrationBuilder.AddColumn<string>(
                name: "TypPosition",
                table: "Pregnanicies",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypPosition",
                table: "Pregnanicies");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Pregnanicies",
                nullable: false,
                defaultValue: 0);
        }
    }
}
