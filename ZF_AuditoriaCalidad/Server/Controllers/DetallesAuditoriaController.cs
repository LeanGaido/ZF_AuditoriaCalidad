using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZF_AuditoriaCalidad.Server.Data;
using ZF_AuditoriaCalidad.Shared;
using ZF_AuditoriaCalidad.Shared.DTOs;

namespace ZF_AuditoriaCalidad.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DetallesAuditoriaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DetallesAuditoriaController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<DetalleAuditoriaDTO>>> Get(int id)
        {
            List<DetalleAuditoriaDTO> detallesAuditoria = new List<DetalleAuditoriaDTO>();

            if (await context.DetallesAuditoria.AnyAsync(x => x.AuditoriaID == id))
            {
                var detalles = await context.DetallesAuditoria.Where(x => x.AuditoriaID == id)
                                                                   .ToListAsync();

                Auditoria auditoria = new Auditoria();
                RespuestaDetalleAuditoria respuestaDetalleAuditoria = new RespuestaDetalleAuditoria();
                PuntoAuditoria puntoAuditoria = new PuntoAuditoria();

                foreach (var detalle in detalles)
                {
                    DetalleAuditoriaDTO detalleAuditoria = new DetalleAuditoriaDTO();

                    if(auditoria.ID != detalle.AuditoriaID)
                    {
                        auditoria = await context.Auditorias.Where(x => x.ID == detalle.AuditoriaID)
                                                            .FirstOrDefaultAsync();
                    }

                    if (respuestaDetalleAuditoria.ID != detalle.RespuestaID)
                    {
                        respuestaDetalleAuditoria = await context.RespuestasDetalleAuditoria.Where(x => x.ID == detalle.RespuestaID)
                                                                                            .FirstOrDefaultAsync();
                    }

                    if (puntoAuditoria.ID != detalle.PuntoAuditoriaID)
                    {
                        puntoAuditoria = await context.PuntosAuditoria.Where(x => x.ID == detalle.PuntoAuditoriaID)
                                                                      .FirstOrDefaultAsync();
                    }

                    detalleAuditoria.ID = detalle.ID;
                    detalleAuditoria.AuditoriaID = detalle.AuditoriaID;
                    detalleAuditoria.RespuestaID = detalle.RespuestaID;
                    detalleAuditoria.PuntoAuditoriaID = detalle.PuntoAuditoriaID;
                    detalleAuditoria.Auditoria = auditoria;
                    detalleAuditoria.RespuestaDetalleAuditoria = respuestaDetalleAuditoria;
                    detalleAuditoria.PuntoAuditoria = puntoAuditoria;

                    detallesAuditoria.Add(detalleAuditoria);
                }
            }

            return detallesAuditoria;
        }

        [HttpPut]
        public async Task<ActionResult> Put(DetalleAuditoria detalleAuditoria)
        {
            context.Attach(detalleAuditoria).State = EntityState.Modified;
            //Obtengo el registro del detalle de auditoria a modificar
            var detalleAuditoriaDB = await context.DetallesAuditoria.FirstOrDefaultAsync(x => x.ID == detalleAuditoria.ID);

            //Retorno NotFound si no existe el registro detalle de auditoria
            if (detalleAuditoriaDB == null) { return NotFound(); }

            //"implementa" cambios en el obejo auditoria en detalleAuditoriaDB, para asi guardarlo en la base de datos*
            detalleAuditoriaDB = mapper.Map(detalleAuditoria, detalleAuditoriaDB);

            //Guarda Cambios
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
