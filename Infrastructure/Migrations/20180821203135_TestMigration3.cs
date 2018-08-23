using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class TestMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Parents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adenopathie",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Anamnèse",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Conjonctives",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CouleurPeau",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionCouleurPeau",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionOscultationPulmonaire",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EruptionsCutanees",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EtatGeneral",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Examen",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FID",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gorge",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Inspection",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Levre",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MassePalpable",
                table: "Consultations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Oedeme",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Oeil",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OscultationPulmonaire",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PalpationAbdomene",
                table: "Consultations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PalpationFoie",
                table: "Consultations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PalpationRate",
                table: "Consultations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RythmeRespiratoire",
                table: "Consultations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TailleMassePalpableAbdomene",
                table: "Consultations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TailleMassePalpableFoie",
                table: "Consultations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TailleMassePalpableRate",
                table: "Consultations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Torticollis",
                table: "Consultations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TorticollisDirection",
                table: "Consultations",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Adenopathie",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Anamnèse",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Conjonctives",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "CouleurPeau",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "DescriptionCouleurPeau",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "DescriptionOscultationPulmonaire",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "EruptionsCutanees",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "EtatGeneral",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Examen",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "FID",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Gorge",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Inspection",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Levre",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "MassePalpable",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Oedeme",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Oeil",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "OscultationPulmonaire",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "PalpationAbdomene",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "PalpationFoie",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "PalpationRate",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "RythmeRespiratoire",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "TailleMassePalpableAbdomene",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "TailleMassePalpableFoie",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "TailleMassePalpableRate",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Torticollis",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "TorticollisDirection",
                table: "Consultations");
        }
    }
}
