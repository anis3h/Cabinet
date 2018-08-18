using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class TestMigration3 : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "FatherId",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherId",
                table: "Patients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PatientParent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientParent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientParent_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientParent_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_FatherId",
                table: "Patients",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MotherId",
                table: "Patients",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientParent_ParentId",
                table: "PatientParent",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientParent_PatientId",
                table: "PatientParent",
                column: "PatientId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Parents_FatherId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Parents_MotherId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "PatientParent");

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

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Parents",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
