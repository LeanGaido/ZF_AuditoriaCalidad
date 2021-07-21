using Microsoft.EntityFrameworkCore.Migrations;

namespace ZF_AuditoriaCalidad.Server.Data.Migrations
{
    public partial class PeriododeAudicion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NroPieza",
                table: "tblAuditorias",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NroOrden",
                table: "tblAuditorias",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tblParametrosGenerales",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblParametrosGenerales", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 1,
                column: "Descripcion",
                value: "GPS1");

            migrationBuilder.UpdateData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 2,
                column: "Descripcion",
                value: "GPS2");

            migrationBuilder.UpdateData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 3,
                column: "Descripcion",
                value: "HD");

            migrationBuilder.UpdateData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 4,
                column: "Descripcion",
                value: "Empaque");

            migrationBuilder.UpdateData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 5,
                column: "Descripcion",
                value: "Vástago");

            migrationBuilder.InsertData(
                table: "tblAreas",
                columns: new[] { "ID", "Descripcion", "Email" },
                values: new object[,]
                {
                    { 6, "Manual", "" },
                    { 7, "Tubos", "" }
                });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Apellido", "Auditor", "Legajo", "Nombre", "Supervisor" },
                values: new object[] { "NEGRO", false, "7", "RAUL SEBASTIAN", true });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Apellido", "Auditor", "Legajo", "Nombre", "Supervisor" },
                values: new object[] { "QUINTEROS", false, "11", "LORENZO JUAN", true });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Apellido", "Legajo", "Nombre" },
                values: new object[] { "VILLOSIO", "13", "DANTE ALBERTO" });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Apellido", "Legajo", "Nombre" },
                values: new object[] { "GARETTO", "20", "GERMAN SANTIAGO" });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Apellido", "Auditor", "Legajo", "Nombre" },
                values: new object[] { "GOMEZ", true, "286", "CRISTIAN GABRIEL" });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Apellido", "Auditor", "Legajo", "Nombre" },
                values: new object[] { "ALBARRACIN", true, "290", "JORGE ALBERTO" });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Apellido", "Auditor", "Legajo", "Nombre" },
                values: new object[] { "MINA", true, "102", "JAVIER EDUARDO" });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Apellido", "Auditor", "Legajo", "Nombre" },
                values: new object[] { "PASTORE", true, "211", "RUBEN JOSE DARIO" });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Apellido", "Legajo", "Nombre" },
                values: new object[] { "SEGHEZZI", "1107", "DAVID" });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Apellido", "Legajo", "Nombre" },
                values: new object[] { "PASCHIERO", "33", "NORBERTO RENATO" });

            migrationBuilder.InsertData(
                table: "tblOperarios",
                columns: new[] { "ID", "Apellido", "Auditor", "Legajo", "Nombre", "Supervisor" },
                values: new object[,]
                {
                    { 14, "PRIOTTI", false, "68", "OSCAR ALBERTO", false },
                    { 13, "ZAPATA", false, "65", "OMAR ENRIQUE", false },
                    { 15, "BURGOS", false, "70", "JORGE OMAR", false },
                    { 12, "JAIMES", false, "53", "OSCAR HONORIO", false },
                    { 11, "MORONE", false, "39", "MIGUEL ELIO", false },
                    { 20, "ZAPATA", false, "126", "EDGARDO JAVIER", false },
                    { 19, "ABBURRA", false, "118", "MARCELO FABIAN", false },
                    { 18, "PEREZ", false, "108", "ENRIQUE DOLORES", false },
                    { 17, "MINA", false, "102", "JAVIER EDUARDO", false },
                    { 16, "BUSATO", false, "85", "CLAUDIO RAMON", false }
                });

            migrationBuilder.InsertData(
                table: "tblParametrosGenerales",
                columns: new[] { "ID", "Key", "Value" },
                values: new object[] { 1, "Periodo de Audicion(Dias)", "30" });

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 1,
                column: "Descripcion",
                value: "Existe Pieza Puesta a Punto");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 2,
                column: "Descripcion",
                value: "Orden de Fabricación Disponible");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 3,
                column: "Descripcion",
                value: "Control de Frabr.  ¿Registros?");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 4,
                column: "Descripcion",
                value: "Documentación necesaria disponible");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 5,
                column: "Descripcion",
                value: "Dimensional Pieza en Proceso");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 6,
                column: "Descripcion",
                value: "Funciona caja NO CONFORME");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 7,
                column: "Descripcion",
                value: "Ins. de medición calibrado/apropiado/POKA YOKE");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 8,
                column: "Descripcion",
                value: "TPM");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 9,
                column: "Descripcion",
                value: "Seguridad");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 10,
                column: "Descripcion",
                value: "5S");

            migrationBuilder.InsertData(
                table: "tblPuntosAuditoria",
                columns: new[] { "ID", "Descripcion" },
                values: new object[,]
                {
                    { 13, "Polivalencia" },
                    { 12, "Identificación" },
                    { 11, "Mejoras" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblParametrosGenerales");

            migrationBuilder.DeleteData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.AlterColumn<string>(
                name: "NroPieza",
                table: "tblAuditorias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "NroOrden",
                table: "tblAuditorias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 1,
                column: "Descripcion",
                value: "Area de Produccion Nro 1");

            migrationBuilder.UpdateData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 2,
                column: "Descripcion",
                value: "Area de Produccion Nro 2");

            migrationBuilder.UpdateData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 3,
                column: "Descripcion",
                value: "Area de Produccion Nro 3");

            migrationBuilder.UpdateData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 4,
                column: "Descripcion",
                value: "Area de Produccion Nro 4");

            migrationBuilder.UpdateData(
                table: "tblAreas",
                keyColumn: "ID",
                keyValue: 5,
                column: "Descripcion",
                value: "Area de Produccion Nro 5");

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Apellido", "Auditor", "Legajo", "Nombre", "Supervisor" },
                values: new object[] { "Auditor 0001", true, "0001", "Operario", false });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Apellido", "Auditor", "Legajo", "Nombre", "Supervisor" },
                values: new object[] { "Auditor 0002", true, "0002", "Operario", false });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Apellido", "Legajo", "Nombre" },
                values: new object[] { "Supervisor 0003", "0003", "Operario" });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Apellido", "Legajo", "Nombre" },
                values: new object[] { "Supervisor 0004", "0004", "Operario" });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Apellido", "Auditor", "Legajo", "Nombre" },
                values: new object[] { "0005", false, "0005", "Operario" });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Apellido", "Auditor", "Legajo", "Nombre" },
                values: new object[] { "0006", false, "0006", "Operario" });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Apellido", "Auditor", "Legajo", "Nombre" },
                values: new object[] { "0007", false, "0007", "Operario" });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Apellido", "Auditor", "Legajo", "Nombre" },
                values: new object[] { "0008", false, "0008", "Operario" });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Apellido", "Legajo", "Nombre" },
                values: new object[] { "0009", "0009", "Operario" });

            migrationBuilder.UpdateData(
                table: "tblOperarios",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Apellido", "Legajo", "Nombre" },
                values: new object[] { "0010", "0010", "Operario" });

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 1,
                column: "Descripcion",
                value: "Punto de Auditoria Nro 1");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 2,
                column: "Descripcion",
                value: "Punto de Auditoria Nro 2");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 3,
                column: "Descripcion",
                value: "Punto de Auditoria Nro 3");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 4,
                column: "Descripcion",
                value: "Punto de Auditoria Nro 4");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 5,
                column: "Descripcion",
                value: "Punto de Auditoria Nro 5");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 6,
                column: "Descripcion",
                value: "Punto de Auditoria Nro 6");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 7,
                column: "Descripcion",
                value: "Punto de Auditoria Nro 7");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 8,
                column: "Descripcion",
                value: "Punto de Auditoria Nro 8");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 9,
                column: "Descripcion",
                value: "Punto de Auditoria Nro 9");

            migrationBuilder.UpdateData(
                table: "tblPuntosAuditoria",
                keyColumn: "ID",
                keyValue: 10,
                column: "Descripcion",
                value: "Punto de Auditoria Nro 10");
        }
    }
}
