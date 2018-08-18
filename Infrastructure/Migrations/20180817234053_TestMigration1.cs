using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class TestMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Patients_PatientParentForeignKey",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Parents_FatherId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Parents_MotherId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Siblings_Patients_PatientId",
                table: "Siblings");

            migrationBuilder.DropForeignKey(
                name: "FK_Siblings_Patients_PatientSiblingForeignKey",
                table: "Siblings");

            migrationBuilder.DropForeignKey(
                name: "FK_Siblings_Patients_Sister_PatientId",
                table: "Siblings");

            migrationBuilder.DropIndex(
                name: "IX_Siblings_PatientSiblingForeignKey",
                table: "Siblings");

            migrationBuilder.DropIndex(
                name: "IX_Patients_FatherId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MotherId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientSiblingForeignKey",
                table: "Siblings");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "Sister_PatientId",
                table: "Siblings",
                newName: "Sister_PatientId1");

            migrationBuilder.RenameIndex(
                name: "IX_Siblings_Sister_PatientId",
                table: "Siblings",
                newName: "IX_Siblings_Sister_PatientId1");

            migrationBuilder.RenameColumn(
                name: "PatientParentForeignKey",
                table: "Parents",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_PatientParentForeignKey",
                table: "Parents",
                newName: "IX_Parents_PatientId");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Siblings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId1",
                table: "Siblings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Siblings_PatientId1",
                table: "Siblings",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Patients_PatientId",
                table: "Parents",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Siblings_Patients_PatientId1",
                table: "Siblings",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Siblings_Patients_PatientId",
                table: "Siblings",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Siblings_Patients_Sister_PatientId1",
                table: "Siblings",
                column: "Sister_PatientId1",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Patients_PatientId",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_Siblings_Patients_PatientId1",
                table: "Siblings");

            migrationBuilder.DropForeignKey(
                name: "FK_Siblings_Patients_PatientId",
                table: "Siblings");

            migrationBuilder.DropForeignKey(
                name: "FK_Siblings_Patients_Sister_PatientId1",
                table: "Siblings");

            migrationBuilder.DropIndex(
                name: "IX_Siblings_PatientId1",
                table: "Siblings");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Siblings");

            migrationBuilder.RenameColumn(
                name: "Sister_PatientId1",
                table: "Siblings",
                newName: "Sister_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Siblings_Sister_PatientId1",
                table: "Siblings",
                newName: "IX_Siblings_Sister_PatientId");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Parents",
                newName: "PatientParentForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_PatientId",
                table: "Parents",
                newName: "IX_Parents_PatientParentForeignKey");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Siblings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PatientSiblingForeignKey",
                table: "Siblings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FatherId",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherId",
                table: "Patients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Siblings_PatientSiblingForeignKey",
                table: "Siblings",
                column: "PatientSiblingForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_FatherId",
                table: "Patients",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MotherId",
                table: "Patients",
                column: "MotherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Patients_PatientParentForeignKey",
                table: "Parents",
                column: "PatientParentForeignKey",
                principalTable: "Patients",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Siblings_Patients_PatientId",
                table: "Siblings",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Siblings_Patients_PatientSiblingForeignKey",
                table: "Siblings",
                column: "PatientSiblingForeignKey",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Siblings_Patients_Sister_PatientId",
                table: "Siblings",
                column: "Sister_PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
