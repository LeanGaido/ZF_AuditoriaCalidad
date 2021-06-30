using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZF_AuditoriaCalidad.Server.Data.Migrations
{
    public partial class Observaciones_y_cambios_minimos_en_Area_y_DetalleAuditoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCorreccion",
                table: "tblDetallesAuditoria",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tblAreas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblObservaciones",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    ParaLaLinea = table.Column<bool>(nullable: false),
                    AreaResponsableID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblObservaciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblObservaciones_tblAreas_AreaResponsableID",
                        column: x => x.AreaResponsableID,
                        principalTable: "tblAreas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblObservacionesDetalleAuditoria",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetalleAuditoriaID = table.Column<int>(nullable: false),
                    ObservacionID = table.Column<int>(nullable: false),
                    Contemplada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblObservacionesDetalleAuditoria", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblObservacionesDetalleAuditoria_tblDetallesAuditoria_DetalleAuditoriaID",
                        column: x => x.DetalleAuditoriaID,
                        principalTable: "tblDetallesAuditoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblObservacionesNoContempladas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    ParaLaLinea = table.Column<bool>(nullable: false),
                    AreaResponsableID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblObservacionesNoContempladas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblObservacionesNoContempladas_tblAreas_AreaResponsableID",
                        column: x => x.AreaResponsableID,
                        principalTable: "tblAreas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblAreas",
                columns: new[] { "ID", "Descripcion", "Email" },
                values: new object[,]
                {
                    { 1, "Area de Produccion Nro 1", "" },
                    { 2, "Area de Produccion Nro 2", "" },
                    { 3, "Area de Produccion Nro 3", "" },
                    { 4, "Area de Produccion Nro 4", "" },
                    { 5, "Area de Produccion Nro 5", "" }
                });

            migrationBuilder.InsertData(
                table: "tblOperarios",
                columns: new[] { "ID", "Apellido", "Auditor", "Legajo", "Nombre", "Supervisor" },
                values: new object[,]
                {
                    { 9, "0009", false, "0009", "Operario", false },
                    { 8, "0008", false, "0008", "Operario", false },
                    { 7, "0007", false, "0007", "Operario", false },
                    { 6, "0006", false, "0006", "Operario", false },
                    { 10, "0010", false, "0010", "Operario", false },
                    { 4, "Supervisor 0004", false, "0004", "Operario", true },
                    { 3, "Supervisor 0003", false, "0003", "Operario", true },
                    { 2, "Auditor 0002", true, "0002", "Operario", false },
                    { 1, "Auditor 0001", true, "0001", "Operario", false },
                    { 5, "0005", false, "0005", "Operario", false }
                });

            migrationBuilder.InsertData(
                table: "tblPuntosAuditoria",
                columns: new[] { "ID", "Descripcion" },
                values: new object[,]
                {
                    { 10, "Punto de Auditoria Nro 10" },
                    { 9, "Punto de Auditoria Nro 9" },
                    { 8, "Punto de Auditoria Nro 8" },
                    { 7, "Punto de Auditoria Nro 7" },
                    { 6, "Punto de Auditoria Nro 6" },
                    { 5, "Punto de Auditoria Nro 5" },
                    { 3, "Punto de Auditoria Nro 3" },
                    { 2, "Punto de Auditoria Nro 2" },
                    { 1, "Punto de Auditoria Nro 1" },
                    { 4, "Punto de Auditoria Nro 4" }
                });

            migrationBuilder.InsertData(
                table: "tblRespuestasDetalleAuditoria",
                columns: new[] { "ID", "ClaseHtml", "Descripcion" },
                values: new object[,]
                {
                    { 3, "warning", "N/A" },
                    { 1, "success", "SI" },
                    { 2, "danger", "NO" },
                    { 4, "info", "Corregido" }
                });

            migrationBuilder.InsertData(
                table: "tblMaquinas",
                columns: new[] { "ID", "AreaID", "Descripcion" },
                values: new object[,]
                {
                    { 1, 1, "Maquina Nro 1 del Area de Produccion Nro 1" },
                    { 19, 4, "Maquina Nro 19 del Area de Produccion Nro 4" },
                    { 18, 4, "Maquina Nro 18 del Area de Produccion Nro 4" },
                    { 17, 4, "Maquina Nro 17 del Area de Produccion Nro 4" },
                    { 16, 4, "Maquina Nro 16 del Area de Produccion Nro 4" },
                    { 15, 4, "Maquina Nro 15 del Area de Produccion Nro 4" },
                    { 14, 4, "Maquina Nro 14 del Area de Produccion Nro 4" },
                    { 13, 3, "Maquina Nro 13 del Area de Produccion Nro 3" },
                    { 12, 3, "Maquina Nro 12 del Area de Produccion Nro 3" },
                    { 20, 5, "Maquina Nro 20 del Area de Produccion Nro 5" },
                    { 11, 3, "Maquina Nro 11 del Area de Produccion Nro 3" },
                    { 9, 2, "Maquina Nro 9 del Area de Produccion Nro 2" },
                    { 8, 2, "Maquina Nro 8 del Area de Produccion Nro 2" },
                    { 7, 2, "Maquina Nro 7 del Area de Produccion Nro 2" },
                    { 6, 2, "Maquina Nro 6 del Area de Produccion Nro 2" },
                    { 5, 1, "Maquina Nro 5 del Area de Produccion Nro 1" },
                    { 4, 1, "Maquina Nro 4 del Area de Produccion Nro 1" },
                    { 3, 1, "Maquina Nro 3 del Area de Produccion Nro 1" },
                    { 2, 1, "Maquina Nro 2 del Area de Produccion Nro 1" },
                    { 10, 2, "Maquina Nro 10 del Area de Produccion Nro 2" },
                    { 21, 5, "Maquina Nro 21 del Area de Produccion Nro 5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblObservaciones_AreaResponsableID",
                table: "tblObservaciones",
                column: "AreaResponsableID");

            migrationBuilder.CreateIndex(
                name: "IX_tblObservacionesDetalleAuditoria_DetalleAuditoriaID",
                table: "tblObservacionesDetalleAuditoria",
                column: "DetalleAuditoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_tblObservacionesNoContempladas_AreaResponsableID",
                table: "tblObservacionesNoContempladas",
                column: "AreaResponsableID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblObservaciones");

            migrationBuilder.DropTable(
                name: "tblObservacionesDetalleAuditoria");

            migrationBuilder.DropTable(
                name: "tblObservacionesNoContempladas");

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tblRespuestasDetalleAuditoria",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblRespuestasDetalleAuditoria",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblRespuestasDetalleAuditoria",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblRespuestasDetalleAuditoria",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "FechaCorreccion",
                table: "tblDetallesAuditoria");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "tblAreas");
        }
    }
}
