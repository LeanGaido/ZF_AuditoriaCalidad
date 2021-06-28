using Microsoft.EntityFrameworkCore.Migrations;

namespace ZF_AuditoriaCalidad.Server.Data.Migrations
{
    public partial class CorreccionAuditorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "tblAuditorias");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "tblAuditorias",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserBajaID",
                table: "tblAuditorias",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "tblAuditorias",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserBajaID",
                table: "tblAuditorias",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FechaBaja",
                table: "tblAuditorias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
