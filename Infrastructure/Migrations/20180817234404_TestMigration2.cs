using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class TestMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siblings_Patients_PatientId1",
                table: "Siblings");

            migrationBuilder.DropForeignKey(
                name: "FK_Siblings_Patients_Sister_PatientId1",
                table: "Siblings");

            migrationBuilder.DropIndex(
                name: "IX_Siblings_PatientId1",
                table: "Siblings");

            migrationBuilder.DropIndex(
                name: "IX_Siblings_Sister_PatientId1",
                table: "Siblings");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Siblings");

            migrationBuilder.DropColumn(
                name: "Sister_PatientId1",
                table: "Siblings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId1",
                table: "Siblings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sister_PatientId1",
                table: "Siblings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Siblings_PatientId1",
                table: "Siblings",
                column: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Siblings_Sister_PatientId1",
                table: "Siblings",
                column: "Sister_PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Siblings_Patients_PatientId1",
                table: "Siblings",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Siblings_Patients_Sister_PatientId1",
                table: "Siblings",
                column: "Sister_PatientId1",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
