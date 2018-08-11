using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Migrations
{
    public partial class TestMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Krankheit",
                table: "Consultations");

            migrationBuilder.AddColumn<int>(
                name: "Cut",
                table: "Consultations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pc",
                table: "Consultations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Temperature",
                table: "Consultations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Consultations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Illness",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConsultationId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_Illness_ConsultationId",
                table: "Illness",
                column: "ConsultationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Illness");

            migrationBuilder.DropColumn(
                name: "Cut",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Pc",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Consultations");

            migrationBuilder.AddColumn<string>(
                name: "Krankheit",
                table: "Consultations",
                nullable: true);
        }
    }
}
