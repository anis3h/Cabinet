using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Migrations
{
    public partial class TestMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_c_PreganancyId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_c",
                table: "c");

            migrationBuilder.DropColumn(
                name: "BirthWeight",
                table: "c");

            migrationBuilder.RenameTable(
                name: "c",
                newName: "Pregnanicies");

            migrationBuilder.AddColumn<int>(
                name: "BornId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Pregnanicies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pregnanicies",
                table: "Pregnanicies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Borns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Allaitement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apgar1mn = table.Column<int>(type: "int", nullable: false),
                    Apgar5mn = table.Column<int>(type: "int", nullable: false),
                    BirthWeight = table.Column<int>(type: "int", nullable: false),
                    Cry = table.Column<bool>(type: "bit", nullable: false),
                    RemarqueAllaitement = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borns", x => x.Id);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Pregnanicies_PreganancyId",
                table: "Patients",
                column: "PreganancyId",
                principalTable: "Pregnanicies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Borns_BornId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Pregnanicies_PreganancyId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Borns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pregnanicies",
                table: "Pregnanicies");

            migrationBuilder.DropIndex(
                name: "IX_Patients_BornId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Pregnanicies");

            migrationBuilder.DropColumn(
                name: "BornId",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Pregnanicies",
                newName: "c");

            migrationBuilder.AddColumn<int>(
                name: "BirthWeight",
                table: "c",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_c",
                table: "c",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_c_PreganancyId",
                table: "Patients",
                column: "PreganancyId",
                principalTable: "c",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
