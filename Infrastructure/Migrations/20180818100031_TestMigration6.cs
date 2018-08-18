using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class TestMigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Parents_FatherId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Parents_MotherId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_FatherId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MotherId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "Patients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FatherId",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherId",
                table: "Patients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_FatherId",
                table: "Patients",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MotherId",
                table: "Patients",
                column: "MotherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Parents_FatherId",
                table: "Patients",
                column: "FatherId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Parents_MotherId",
                table: "Patients",
                column: "MotherId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
