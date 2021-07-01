using Microsoft.EntityFrameworkCore.Migrations;

namespace ZF_AuditoriaCalidad.Server.Data.Migrations
{
    public partial class ObservacionPuntoAuditoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PuntoAuditoriaID",
                table: "tblObservacionesNoContempladas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PuntoAuditoriaID",
                table: "tblObservaciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblObservacionesNoContempladas_PuntoAuditoriaID",
                table: "tblObservacionesNoContempladas",
                column: "PuntoAuditoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_tblObservaciones_PuntoAuditoriaID",
                table: "tblObservaciones",
                column: "PuntoAuditoriaID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblObservaciones_tblPuntosAuditoria_PuntoAuditoriaID",
                table: "tblObservaciones",
                column: "PuntoAuditoriaID",
                principalTable: "tblPuntosAuditoria",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblObservacionesNoContempladas_tblPuntosAuditoria_PuntoAuditoriaID",
                table: "tblObservacionesNoContempladas",
                column: "PuntoAuditoriaID",
                principalTable: "tblPuntosAuditoria",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblObservaciones_tblPuntosAuditoria_PuntoAuditoriaID",
                table: "tblObservaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_tblObservacionesNoContempladas_tblPuntosAuditoria_PuntoAuditoriaID",
                table: "tblObservacionesNoContempladas");

            migrationBuilder.DropIndex(
                name: "IX_tblObservacionesNoContempladas_PuntoAuditoriaID",
                table: "tblObservacionesNoContempladas");

            migrationBuilder.DropIndex(
                name: "IX_tblObservaciones_PuntoAuditoriaID",
                table: "tblObservaciones");

            migrationBuilder.DropColumn(
                name: "PuntoAuditoriaID",
                table: "tblObservacionesNoContempladas");

            migrationBuilder.DropColumn(
                name: "PuntoAuditoriaID",
                table: "tblObservaciones");
        }
    }
}
