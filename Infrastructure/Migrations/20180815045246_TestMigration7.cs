using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Migrations
{
    public partial class TestMigration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Pregnanicies_PreganancyId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PreganancyId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PreganancyId",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "PregnancyId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PregnancyId",
                table: "Patients",
                column: "PregnancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Pregnanicies_PregnancyId",
                table: "Patients",
                column: "PregnancyId",
                principalTable: "Pregnanicies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Pregnanicies_PregnancyId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PregnancyId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PregnancyId",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "PreganancyId",
                table: "Patients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PreganancyId",
                table: "Patients",
                column: "PreganancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Pregnanicies_PreganancyId",
                table: "Patients",
                column: "PreganancyId",
                principalTable: "Pregnanicies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
