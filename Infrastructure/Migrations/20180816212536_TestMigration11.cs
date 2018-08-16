using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class TestMigration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BornId",
                table: "Patients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BornId",
                table: "Patients",
                column: "BornId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Borns_BornId",
                table: "Patients",
                column: "BornId",
                principalTable: "Borns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Borns_BornId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_BornId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "BornId",
                table: "Patients");
        }
    }
}
