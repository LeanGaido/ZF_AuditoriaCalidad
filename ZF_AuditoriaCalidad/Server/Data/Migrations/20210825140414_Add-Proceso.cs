using Microsoft.EntityFrameworkCore.Migrations;

namespace ZF_AuditoriaCalidad.Server.Data.Migrations
{
    public partial class AddProceso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMaquinas_tblAreas_AreaID",
                table: "tblMaquinas");

            migrationBuilder.DropIndex(
                name: "IX_tblMaquinas_AreaID",
                table: "tblMaquinas");

            migrationBuilder.DropColumn(
                name: "AreaID",
                table: "tblMaquinas");

            migrationBuilder.AddColumn<int>(
                name: "ProcesoID",
                table: "tblMaquinas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblProcesos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 240, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProcesos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblProcesos_tblAreas_AreaID",
                        column: x => x.AreaID,
                        principalTable: "tblAreas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblProcesos",
                columns: new[] { "ID", "AreaID", "Descripcion" },
                values: new object[,]
                {
                    { 1, 1, "Proceso 1 del Area de Produccion 1" },
                    { 2, 2, "Proceso 2 del Area de Produccion 2" },
                    { 3, 3, "Proceso 3 del Area de Produccion 3" },
                    { 4, 4, "Proceso 4 del Area de Produccion 4" },
                    { 5, 5, "Proceso 5 del Area de Produccion 5" },
                    { 6, 6, "Proceso 6 del Area de Produccion 6" },
                    { 7, 7, "Proceso 7 del Area de Produccion 7" }
                });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 1 del Proceso Nro 1", 1 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 2 del Proceso Nro 1", 1 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 3 del Proceso Nro 1", 1 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 4 del Proceso Nro 1", 1 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 5 del Proceso Nro 1", 1 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 6 del Proceso Nro 2", 2 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 7 del Proceso Nro 2", 2 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 8 del Proceso Nro 2", 2 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 9 del Proceso Nro 2", 2 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 10 del Proceso Nro 2", 2 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 11 del Proceso Nro 3", 3 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 12 del Proceso Nro 3", 3 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 13 del Proceso Nro 3", 3 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 14 del Proceso Nro 4", 4 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 15 del Proceso Nro 4", 4 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 16 del Proceso Nro 4", 4 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 17 del Proceso Nro 4", 4 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 18 del Proceso Nro 4", 4 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 19 del Proceso Nro 4", 4 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 20 del Proceso Nro 5", 5 });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "Descripcion", "ProcesoID" },
                values: new object[] { "Maquina Nro 21 del Proceso Nro 5", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_tblMaquinas_ProcesoID",
                table: "tblMaquinas",
                column: "ProcesoID");

            migrationBuilder.CreateIndex(
                name: "IX_tblProcesos_AreaID",
                table: "tblProcesos",
                column: "AreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMaquinas_tblProcesos_ProcesoID",
                table: "tblMaquinas",
                column: "ProcesoID",
                principalTable: "tblProcesos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMaquinas_tblProcesos_ProcesoID",
                table: "tblMaquinas");

            migrationBuilder.DropTable(
                name: "tblProcesos");

            migrationBuilder.DropIndex(
                name: "IX_tblMaquinas_ProcesoID",
                table: "tblMaquinas");

            migrationBuilder.DropColumn(
                name: "ProcesoID",
                table: "tblMaquinas");

            migrationBuilder.AddColumn<int>(
                name: "AreaID",
                table: "tblMaquinas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 1, "Maquina Nro 1 del Area de Produccion Nro 1" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 1, "Maquina Nro 2 del Area de Produccion Nro 1" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 1, "Maquina Nro 3 del Area de Produccion Nro 1" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 1, "Maquina Nro 4 del Area de Produccion Nro 1" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 1, "Maquina Nro 5 del Area de Produccion Nro 1" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 2, "Maquina Nro 6 del Area de Produccion Nro 2" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 2, "Maquina Nro 7 del Area de Produccion Nro 2" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 2, "Maquina Nro 8 del Area de Produccion Nro 2" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 2, "Maquina Nro 9 del Area de Produccion Nro 2" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 2, "Maquina Nro 10 del Area de Produccion Nro 2" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 3, "Maquina Nro 11 del Area de Produccion Nro 3" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 3, "Maquina Nro 12 del Area de Produccion Nro 3" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 3, "Maquina Nro 13 del Area de Produccion Nro 3" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 4, "Maquina Nro 14 del Area de Produccion Nro 4" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 4, "Maquina Nro 15 del Area de Produccion Nro 4" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 4, "Maquina Nro 16 del Area de Produccion Nro 4" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 4, "Maquina Nro 17 del Area de Produccion Nro 4" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 4, "Maquina Nro 18 del Area de Produccion Nro 4" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 4, "Maquina Nro 19 del Area de Produccion Nro 4" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 5, "Maquina Nro 20 del Area de Produccion Nro 5" });

            migrationBuilder.UpdateData(
                table: "tblMaquinas",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "AreaID", "Descripcion" },
                values: new object[] { 5, "Maquina Nro 21 del Area de Produccion Nro 5" });

            migrationBuilder.CreateIndex(
                name: "IX_tblMaquinas_AreaID",
                table: "tblMaquinas",
                column: "AreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMaquinas_tblAreas_AreaID",
                table: "tblMaquinas",
                column: "AreaID",
                principalTable: "tblAreas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
