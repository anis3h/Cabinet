using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Migrations
{
    public partial class TestMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tel",
                table: "Patients",
                newName: "Tel");

            migrationBuilder.RenameColumn(
                name: "tel",
                table: "Parents",
                newName: "Tel");

            migrationBuilder.RenameColumn(
                name: "maidenName",
                table: "Parents",
                newName: "MaidenName");

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profession",
                table: "Parents");

            migrationBuilder.RenameColumn(
                name: "Tel",
                table: "Patients",
                newName: "tel");

            migrationBuilder.RenameColumn(
                name: "Tel",
                table: "Parents",
                newName: "tel");

            migrationBuilder.RenameColumn(
                name: "MaidenName",
                table: "Parents",
                newName: "maidenName");
        }
    }
}
