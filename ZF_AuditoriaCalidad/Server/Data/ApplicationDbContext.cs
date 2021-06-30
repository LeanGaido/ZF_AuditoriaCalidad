using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ZF_AuditoriaCalidad.Server.Models;
using ZF_AuditoriaCalidad.Shared;

namespace ZF_AuditoriaCalidad.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Operario>().HasData(
                new Operario { ID = 1, Nombre = "Operario", Apellido = "Auditor 0001", Legajo = "0001", Auditor = true, Supervisor = false },
                new Operario { ID = 2, Nombre = "Operario", Apellido = "Auditor 0002", Legajo = "0002", Auditor = true, Supervisor = false },
                new Operario { ID = 3, Nombre = "Operario", Apellido = "Supervisor 0003", Legajo = "0003", Auditor = false, Supervisor = true },
                new Operario { ID = 4, Nombre = "Operario", Apellido = "Supervisor 0004", Legajo = "0004", Auditor = false, Supervisor = true },
                new Operario { ID = 5, Nombre = "Operario", Apellido = "0005", Legajo = "0005", Auditor = false, Supervisor = false },
                new Operario { ID = 6, Nombre = "Operario", Apellido = "0006", Legajo = "0006", Auditor = false, Supervisor = false },
                new Operario { ID = 7, Nombre = "Operario", Apellido = "0007", Legajo = "0007", Auditor = false, Supervisor = false },
                new Operario { ID = 8, Nombre = "Operario", Apellido = "0008", Legajo = "0008", Auditor = false, Supervisor = false },
                new Operario { ID = 9, Nombre = "Operario", Apellido = "0009", Legajo = "0009", Auditor = false, Supervisor = false },
                new Operario { ID = 10, Nombre = "Operario", Apellido = "0010", Legajo = "0010", Auditor = false, Supervisor = false }
            );

            modelBuilder.Entity<Area>().HasData(
                new Area { ID = 1, Descripcion = "Area de Produccion Nro 1", Email = "" },
                new Area { ID = 2, Descripcion = "Area de Produccion Nro 2", Email = "" },
                new Area { ID = 3, Descripcion = "Area de Produccion Nro 3", Email = "" },
                new Area { ID = 4, Descripcion = "Area de Produccion Nro 4", Email = "" },
                new Area { ID = 5, Descripcion = "Area de Produccion Nro 5", Email = "" }
            );

            modelBuilder.Entity<Maquina>().HasData(
                new Maquina { ID = 1, AreaID = 1, Descripcion = "Maquina Nro 1 del Area de Produccion Nro 1" },
                new Maquina { ID = 2, AreaID = 1, Descripcion = "Maquina Nro 2 del Area de Produccion Nro 1" },
                new Maquina { ID = 3, AreaID = 1, Descripcion = "Maquina Nro 3 del Area de Produccion Nro 1" },
                new Maquina { ID = 4, AreaID = 1, Descripcion = "Maquina Nro 4 del Area de Produccion Nro 1" },
                new Maquina { ID = 5, AreaID = 1, Descripcion = "Maquina Nro 5 del Area de Produccion Nro 1" },
                new Maquina { ID = 6, AreaID = 2, Descripcion = "Maquina Nro 6 del Area de Produccion Nro 2" },
                new Maquina { ID = 7, AreaID = 2, Descripcion = "Maquina Nro 7 del Area de Produccion Nro 2" },
                new Maquina { ID = 8, AreaID = 2, Descripcion = "Maquina Nro 8 del Area de Produccion Nro 2" },
                new Maquina { ID = 9, AreaID = 2, Descripcion = "Maquina Nro 9 del Area de Produccion Nro 2" },
                new Maquina { ID = 10, AreaID = 2, Descripcion = "Maquina Nro 10 del Area de Produccion Nro 2" },
                new Maquina { ID = 11, AreaID = 3, Descripcion = "Maquina Nro 11 del Area de Produccion Nro 3" },
                new Maquina { ID = 12, AreaID = 3, Descripcion = "Maquina Nro 12 del Area de Produccion Nro 3" },
                new Maquina { ID = 13, AreaID = 3, Descripcion = "Maquina Nro 13 del Area de Produccion Nro 3" },
                new Maquina { ID = 14, AreaID = 4, Descripcion = "Maquina Nro 14 del Area de Produccion Nro 4" },
                new Maquina { ID = 15, AreaID = 4, Descripcion = "Maquina Nro 15 del Area de Produccion Nro 4" },
                new Maquina { ID = 16, AreaID = 4, Descripcion = "Maquina Nro 16 del Area de Produccion Nro 4" },
                new Maquina { ID = 17, AreaID = 4, Descripcion = "Maquina Nro 17 del Area de Produccion Nro 4" },
                new Maquina { ID = 18, AreaID = 4, Descripcion = "Maquina Nro 18 del Area de Produccion Nro 4" },
                new Maquina { ID = 19, AreaID = 4, Descripcion = "Maquina Nro 19 del Area de Produccion Nro 4" },
                new Maquina { ID = 20, AreaID = 5, Descripcion = "Maquina Nro 20 del Area de Produccion Nro 5" },
                new Maquina { ID = 21, AreaID = 5, Descripcion = "Maquina Nro 21 del Area de Produccion Nro 5" }
            );


            modelBuilder.Entity<PuntoAuditoria>().HasData(
                new PuntoAuditoria { ID = 1, Descripcion = "Punto de Auditoria Nro 1" },
                new PuntoAuditoria { ID = 2, Descripcion = "Punto de Auditoria Nro 2" },
                new PuntoAuditoria { ID = 3, Descripcion = "Punto de Auditoria Nro 3" },
                new PuntoAuditoria { ID = 4, Descripcion = "Punto de Auditoria Nro 4" },
                new PuntoAuditoria { ID = 5, Descripcion = "Punto de Auditoria Nro 5" },
                new PuntoAuditoria { ID = 6, Descripcion = "Punto de Auditoria Nro 6" },
                new PuntoAuditoria { ID = 7, Descripcion = "Punto de Auditoria Nro 7" },
                new PuntoAuditoria { ID = 8, Descripcion = "Punto de Auditoria Nro 8" },
                new PuntoAuditoria { ID = 9, Descripcion = "Punto de Auditoria Nro 9" },
                new PuntoAuditoria { ID = 10, Descripcion = "Punto de Auditoria Nro 10" }
            );

            modelBuilder.Entity<RespuestaDetalleAuditoria>().HasData(
                new RespuestaDetalleAuditoria { ID = 1, Descripcion = "SI", ClaseHtml = "success" },
                new RespuestaDetalleAuditoria { ID = 2, Descripcion = "NO", ClaseHtml = "danger" },
                new RespuestaDetalleAuditoria { ID = 3, Descripcion = "N/A", ClaseHtml = "warning" },
                new RespuestaDetalleAuditoria { ID = 4, Descripcion = "Corregido", ClaseHtml = "info" }
            );
        }

        //Zf
        public virtual DbSet<Operario> Operarios { get; set; }

        public virtual DbSet<Area> Areas { get; set; }

        public virtual DbSet<Maquina> Maquinas { get; set; }

        public virtual DbSet<Auditoria> Auditorias { get; set; }

        public virtual DbSet<DetalleAuditoria> DetallesAuditoria { get; set; }

        public virtual DbSet<PuntoAuditoria> PuntosAuditoria { get; set; }

        public virtual DbSet<RespuestaDetalleAuditoria> RespuestasDetalleAuditoria { get; set; }

        public virtual DbSet<ObservacionDetalleAuditoria> ObservacionesDetalleAuditoria { get; set; }

        public virtual DbSet<Observacion> Observaciones { get; set; }

        public virtual DbSet<ObservacionNoContemplada> ObservacionesNoContempladas { get; set; }
    }
}
