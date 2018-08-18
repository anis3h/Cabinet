using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Borns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthWeight = table.Column<int>(nullable: false),
                    Cry = table.Column<bool>(nullable: false),
                    Apgar1mn = table.Column<int>(nullable: false),
                    Apgar5mn = table.Column<int>(nullable: false),
                    Allaitement = table.Column<string>(nullable: true),
                    RemarqueAllaitement = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pregnanicies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypPregnancy = table.Column<string>(nullable: false),
                    Week = table.Column<int>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    TypPosition = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregnanicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Tel = table.Column<int>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    BornId = table.Column<int>(nullable: true),
                    PregnancyId = table.Column<int>(nullable: true),
                    FatherId = table.Column<int>(nullable: true),
                    MotherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Borns_BornId",
                        column: x => x.BornId,
                        principalTable: "Borns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patients_Pregnanicies_PregnancyId",
                        column: x => x.PregnancyId,
                        principalTable: "Pregnanicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    Temperature = table.Column<int>(nullable: false),
                    Pc = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Cut = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Tel = table.Column<int>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Profession = table.Column<string>(nullable: true),
                    PatientParentForeignKey = table.Column<int>(nullable: false),
                    ParentsType = table.Column<string>(nullable: false),
                    MaidenName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parents_Patients_PatientParentForeignKey",
                        column: x => x.PatientParentForeignKey,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siblings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Health = table.Column<bool>(nullable: true),
                    Information = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    PatientSiblingForeignKey = table.Column<int>(nullable: false),
                    SiblingType = table.Column<string>(nullable: false),
                    PatientId = table.Column<int>(nullable: true),
                    Sister_PatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siblings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siblings_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Siblings_Patients_PatientSiblingForeignKey",
                        column: x => x.PatientSiblingForeignKey,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Siblings_Patients_Sister_PatientId",
                        column: x => x.Sister_PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Illness",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ConsultationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Illness_Consultations_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PatientId",
                table: "Consultations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Illness_ConsultationId",
                table: "Illness",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_PatientParentForeignKey",
                table: "Parents",
                column: "PatientParentForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BornId",
                table: "Patients",
                column: "BornId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_FatherId",
                table: "Patients",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MotherId",
                table: "Patients",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PregnancyId",
                table: "Patients",
                column: "PregnancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Siblings_PatientId",
                table: "Siblings",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Siblings_PatientSiblingForeignKey",
                table: "Siblings",
                column: "PatientSiblingForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Siblings_Sister_PatientId",
                table: "Siblings",
                column: "Sister_PatientId");

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
                name: "FK_Parents_Patients_PatientParentForeignKey",
                table: "Parents");

            migrationBuilder.DropTable(
                name: "Illness");

            migrationBuilder.DropTable(
                name: "Siblings");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Borns");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Pregnanicies");
        }
    }
}
