using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Migrations
{
    public partial class TestMigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Borns_BornId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_BornId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "BornId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Fraternity",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Siblings",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Tel",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Tel",
                table: "Parents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Siblings_PatientId",
                table: "Siblings",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Siblings_Patients_PatientId",
                table: "Siblings",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siblings_Patients_PatientId",
                table: "Siblings");

            migrationBuilder.DropIndex(
                name: "IX_Siblings_PatientId",
                table: "Siblings");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Siblings");

            migrationBuilder.AlterColumn<int>(
                name: "Tel",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BornId",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fraternity",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Tel",
                table: "Parents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
        }
    }
}
