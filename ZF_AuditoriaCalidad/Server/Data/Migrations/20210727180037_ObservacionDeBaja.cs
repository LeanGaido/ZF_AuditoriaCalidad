using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZF_AuditoriaCalidad.Server.Data.Migrations
{
    public partial class ObservacionDeBaja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DeBaja",
                table: "tblObservaciones",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeBaja",
                table: "tblObservaciones",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioDeBaja",
                table: "tblObservaciones",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeBaja",
                table: "tblObservaciones");

            migrationBuilder.DropColumn(
                name: "FechaDeBaja",
                table: "tblObservaciones");

            migrationBuilder.DropColumn(
                name: "UsuarioDeBaja",
                table: "tblObservaciones");
        }
    }
}
