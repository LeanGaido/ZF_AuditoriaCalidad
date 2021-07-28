using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZF_AuditoriaCalidad.Server.Data.Migrations
{
    public partial class AddCamposPA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DeBaja",
                table: "tblPuntosAuditoria",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeBaja",
                table: "tblPuntosAuditoria",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioDeBaja",
                table: "tblPuntosAuditoria",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeBaja",
                table: "tblPuntosAuditoria");

            migrationBuilder.DropColumn(
                name: "FechaDeBaja",
                table: "tblPuntosAuditoria");

            migrationBuilder.DropColumn(
                name: "UsuarioDeBaja",
                table: "tblPuntosAuditoria");
        }
    }
}
