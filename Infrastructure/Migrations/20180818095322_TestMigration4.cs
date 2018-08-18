using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class TestMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientParent_Parents_ParentId",
                table: "PatientParent");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Parents_FatherId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Parents_MotherId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parents",
                table: "Parents");

            migrationBuilder.RenameTable(
                name: "Parents",
                newName: "Parent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parent",
                table: "Parent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientParent_Parent_ParentId",
                table: "PatientParent",
                column: "ParentId",
                principalTable: "Parent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Parent_FatherId",
                table: "Patients",
                column: "FatherId",
                principalTable: "Parent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Parent_MotherId",
                table: "Patients",
                column: "MotherId",
                principalTable: "Parent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientParent_Parent_ParentId",
                table: "PatientParent");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Parent_FatherId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Parent_MotherId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parent",
                table: "Parent");

            migrationBuilder.RenameTable(
                name: "Parent",
                newName: "Parents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parents",
                table: "Parents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientParent_Parents_ParentId",
                table: "PatientParent",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
