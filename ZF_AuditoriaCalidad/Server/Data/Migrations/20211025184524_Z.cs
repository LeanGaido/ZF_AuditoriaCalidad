using Microsoft.EntityFrameworkCore.Migrations;

namespace ZF_AuditoriaCalidad.Server.Data.Migrations
{
    public partial class Z : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Z",
                table: "tblOperarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Z",
                table: "tblOperarios");
        }
    }
}
