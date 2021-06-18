using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZF_AuditoriaCalidad.Server.Data.Migrations
{
    public partial class EntidadesdeAuditorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAreas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 240, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAreas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblOperarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Auditor = table.Column<bool>(nullable: false),
                    Supervisor = table.Column<bool>(nullable: false),
                    Legajo = table.Column<string>(maxLength: 4, nullable: true),
                    Nombre = table.Column<string>(maxLength: 80, nullable: true),
                    Apellido = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOperarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblPuntosAuditoria",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPuntosAuditoria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblRespuestasDetalleAuditoria",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    ClaseHtml = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRespuestasDetalleAuditoria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblMaquinas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 240, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMaquinas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblMaquinas_tblAreas_AreaID",
                        column: x => x.AreaID,
                        principalTable: "tblAreas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tblAuditorias",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Mes = table.Column<int>(nullable: false),
                    Anio = table.Column<int>(nullable: false),
                    Hora = table.Column<string>(maxLength: 5, nullable: true),
                    MaquinaID = table.Column<int>(nullable: false),
                    NroOrden = table.Column<string>(nullable: true),
                    NroPieza = table.Column<string>(nullable: true),
                    OperarioID = table.Column<int>(nullable: false),
                    SupervisorID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    DeBaja = table.Column<bool>(nullable: false),
                    FechaBaja = table.Column<int>(nullable: false),
                    UserBajaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAuditorias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblAuditorias_tblMaquinas_MaquinaID",
                        column: x => x.MaquinaID,
                        principalTable: "tblMaquinas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tblAuditorias_tblOperarios_OperarioID",
                        column: x => x.OperarioID,
                        principalTable: "tblOperarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tblAuditorias_tblOperarios_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "tblOperarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tblDetallesAuditoria",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditoriaID = table.Column<int>(nullable: false),
                    RespuestaID = table.Column<int>(nullable: false),
                    PuntoAuditoriaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDetallesAuditoria", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblDetallesAuditoria_tblAuditorias_AuditoriaID",
                        column: x => x.AuditoriaID,
                        principalTable: "tblAuditorias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tblDetallesAuditoria_tblPuntosAuditoria_PuntoAuditoriaID",
                        column: x => x.PuntoAuditoriaID,
                        principalTable: "tblPuntosAuditoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tblDetallesAuditoria_tblRespuestasDetalleAuditoria_RespuestaID",
                        column: x => x.RespuestaID,
                        principalTable: "tblRespuestasDetalleAuditoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditorias_MaquinaID",
                table: "tblAuditorias",
                column: "MaquinaID");

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditorias_OperarioID",
                table: "tblAuditorias",
                column: "OperarioID");

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditorias_SupervisorID",
                table: "tblAuditorias",
                column: "SupervisorID");

            migrationBuilder.CreateIndex(
                name: "IX_tblDetallesAuditoria_AuditoriaID",
                table: "tblDetallesAuditoria",
                column: "AuditoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_tblDetallesAuditoria_PuntoAuditoriaID",
                table: "tblDetallesAuditoria",
                column: "PuntoAuditoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_tblDetallesAuditoria_RespuestaID",
                table: "tblDetallesAuditoria",
                column: "RespuestaID");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaquinas_AreaID",
                table: "tblMaquinas",
                column: "AreaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDetallesAuditoria");

            migrationBuilder.DropTable(
                name: "tblAuditorias");

            migrationBuilder.DropTable(
                name: "tblPuntosAuditoria");

            migrationBuilder.DropTable(
                name: "tblRespuestasDetalleAuditoria");

            migrationBuilder.DropTable(
                name: "tblMaquinas");

            migrationBuilder.DropTable(
                name: "tblOperarios");

            migrationBuilder.DropTable(
                name: "tblAreas");
        }
    }
}
