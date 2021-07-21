using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
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

            //Datos correctos
            modelBuilder.Entity<Operario>().HasData(
                new Operario { ID = 1, Nombre = "RAUL SEBASTIAN", Apellido = "NEGRO", Legajo = "7", Auditor = false, Supervisor = true },
                new Operario { ID = 2, Nombre = "LORENZO JUAN", Apellido = "QUINTEROS", Legajo = "11", Auditor = false, Supervisor = true },
                new Operario { ID = 3, Nombre = "DANTE ALBERTO", Apellido = "VILLOSIO", Legajo = "13", Auditor = false, Supervisor = true },
                new Operario { ID = 4, Nombre = "GERMAN SANTIAGO", Apellido = "GARETTO", Legajo = "20", Auditor = false, Supervisor = true },
                new Operario { ID = 5, Nombre = "CRISTIAN GABRIEL", Apellido = "GOMEZ", Legajo = "286", Auditor = true, Supervisor = false },
                new Operario { ID = 6, Nombre = "JORGE ALBERTO", Apellido = "ALBARRACIN", Legajo = "290", Auditor = true, Supervisor = false },
                new Operario { ID = 7, Nombre = "JAVIER EDUARDO", Apellido = "MINA", Legajo = "102", Auditor = true, Supervisor = false },
                new Operario { ID = 8, Nombre = "RUBEN JOSE DARIO", Apellido = "PASTORE", Legajo = "211", Auditor = true, Supervisor = false },
                new Operario { ID = 9, Nombre = "DAVID", Apellido = "SEGHEZZI", Legajo = "1107", Auditor = false, Supervisor = false },
                new Operario { ID = 10, Nombre = "NORBERTO RENATO", Apellido = "PASCHIERO", Legajo = "33", Auditor = false, Supervisor = false },
                new Operario { ID = 11, Nombre = "MIGUEL ELIO", Apellido = "MORONE", Legajo = "39", Auditor = false, Supervisor = false },
                new Operario { ID = 12, Nombre = "OSCAR HONORIO", Apellido = "JAIMES", Legajo = "53", Auditor = false, Supervisor = false },
                new Operario { ID = 13, Nombre = "OMAR ENRIQUE", Apellido = "ZAPATA", Legajo = "65", Auditor = false, Supervisor = false },
                new Operario { ID = 14, Nombre = "OSCAR ALBERTO", Apellido = "PRIOTTI", Legajo = "68", Auditor = false, Supervisor = false },
                new Operario { ID = 15, Nombre = "JORGE OMAR", Apellido = "BURGOS", Legajo = "70", Auditor = false, Supervisor = false },
                new Operario { ID = 16, Nombre = "CLAUDIO RAMON", Apellido = "BUSATO", Legajo = "85", Auditor = false, Supervisor = false },
                new Operario { ID = 17, Nombre = "JAVIER EDUARDO", Apellido = "MINA", Legajo = "102", Auditor = false, Supervisor = false },
                new Operario { ID = 18, Nombre = "ENRIQUE DOLORES", Apellido = "PEREZ", Legajo = "108", Auditor = false, Supervisor = false },
                new Operario { ID = 19, Nombre = "MARCELO FABIAN", Apellido = "ABBURRA", Legajo = "118", Auditor = false, Supervisor = false },
                new Operario { ID = 20, Nombre = "EDGARDO JAVIER", Apellido = "ZAPATA", Legajo = "126", Auditor = false, Supervisor = false }
            );

            modelBuilder.Entity<Area>().HasData(
               new Area { ID = 1, Descripcion = "GPS1", Email = "" },
               new Area { ID = 2, Descripcion = "GPS2", Email = "" },
               new Area { ID = 3, Descripcion = "HD", Email = "" },
               new Area { ID = 4, Descripcion = "Empaque", Email = "" },
               new Area { ID = 5, Descripcion = "Vástago", Email = "" },
               new Area { ID = 6, Descripcion = "Manual", Email = "" },
               new Area { ID = 7, Descripcion = "Tubos", Email = "" }
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

            //Datos correctos
            modelBuilder.Entity<PuntoAuditoria>().HasData(
                new PuntoAuditoria { ID = 1, Descripcion = "Existe Pieza Puesta a Punto" },
                new PuntoAuditoria { ID = 2, Descripcion = "Orden de Fabricación Disponible" },
                new PuntoAuditoria { ID = 3, Descripcion = "Control de Frabr.  ¿Registros?" },
                new PuntoAuditoria { ID = 4, Descripcion = "Documentación necesaria disponible" },
                new PuntoAuditoria { ID = 5, Descripcion = "Dimensional Pieza en Proceso" },
                new PuntoAuditoria { ID = 6, Descripcion = "Funciona caja NO CONFORME" },
                new PuntoAuditoria { ID = 7, Descripcion = "Ins. de medición calibrado/apropiado/POKA YOKE" },
                new PuntoAuditoria { ID = 8, Descripcion = "TPM" },
                new PuntoAuditoria { ID = 9, Descripcion = "Seguridad" },
                new PuntoAuditoria { ID = 10, Descripcion = "5S" },
                new PuntoAuditoria { ID = 11, Descripcion = "Mejoras" },
                new PuntoAuditoria { ID = 12, Descripcion = "Identificación" },
                new PuntoAuditoria { ID = 13, Descripcion = "Polivalencia" }
            );

            modelBuilder.Entity<ParametroGeneral>().HasData(
                new ParametroGeneral { ID = 1, Key = "Periodo de Audicion(Dias)", Value = "30" }
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

        public virtual DbSet<ParametroGeneral> ParametrosGenerales { get; set; }
    }
}
