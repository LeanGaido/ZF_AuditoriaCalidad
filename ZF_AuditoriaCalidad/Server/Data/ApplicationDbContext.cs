using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        //Zf
        public virtual DbSet<Operario> Operarios { get; set; }

        public virtual DbSet<Area> Areas { get; set; }

        public virtual DbSet<Maquina> Maquinas { get; set; }

        public virtual DbSet<Auditoria> Auditorias { get; set; }

        public virtual DbSet<DetalleAuditoria> DetallesAuditoria { get; set; }

        public virtual DbSet<PuntoAuditoria> PuntosAuditoria { get; set; }

        public virtual DbSet<RespuestaDetalleAuditoria> RespuestasDetalleAuditoria { get; set; }
    }
}
