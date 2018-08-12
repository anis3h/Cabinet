using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Migrations
{
    public partial class TestMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Pregnancies_PreganancyId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pregnancies",
                table: "Pregnancies");

            migrationBuilder.RenameTable(
                name: "Pregnancies",
                newName: "c");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_c_PreganancyId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_c",
                table: "c");

            migrationBuilder.RenameTable(
                name: "c",
                newName: "Pregnancies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pregnancies",
                table: "Pregnancies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Pregnancies_PreganancyId",
                table: "Patients",
                column: "PreganancyId",
                principalTable: "Pregnancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
