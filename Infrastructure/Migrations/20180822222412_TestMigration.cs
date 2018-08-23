using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Patients_PatientId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_PatientId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Parents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Parents",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_PatientId",
                table: "Parents",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Patients_PatientId",
                table: "Parents",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
