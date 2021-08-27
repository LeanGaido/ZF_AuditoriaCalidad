using Microsoft.EntityFrameworkCore.Migrations;

namespace ZF_AuditoriaCalidad.Server.Data.Migrations
{
    public partial class DebajaEmpleados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DeBaja",
                table: "tblOperarios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tblOperarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "tblOperarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeBaja",
                table: "tblOperarios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "tblOperarios");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "tblOperarios");
        }
    }
}
