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
        public ActionResult<List<DetalleAuditoriaDTO>> Get(int id)
        {
            List<DetalleAuditoriaDTO> detallesAuditoria = new List<DetalleAuditoriaDTO>();

            if (context.DetallesAuditoria.Any(x => x.AuditoriaID == id))
            {
                var detalles = context.DetallesAuditoria.Where(x => x.AuditoriaID == id)
                                                                   .ToList();

                Auditoria auditoria = new Auditoria();
                RespuestaDetalleAuditoria respuestaDetalleAuditoria = new RespuestaDetalleAuditoria();
                PuntoAuditoria puntoAuditoria = new PuntoAuditoria();

                foreach (var detalle in detalles)
                {
                    DetalleAuditoriaDTO detalleAuditoria = new DetalleAuditoriaDTO();

                    if (respuestaDetalleAuditoria.ID != detalle.RespuestaID)
                    {
                        respuestaDetalleAuditoria = context.RespuestasDetalleAuditoria.Where(x => x.ID == detalle.RespuestaID)
                                                                                            .FirstOrDefault();
                    }

                    if (puntoAuditoria.ID != detalle.PuntoAuditoriaID)
                    {
                        puntoAuditoria = context.PuntosAuditoria.Where(x => x.ID == detalle.PuntoAuditoriaID)
                                                                      .FirstOrDefault();
                    }

                    detalleAuditoria.ID = detalle.ID;
                    detalleAuditoria.AuditoriaID = detalle.AuditoriaID;
                    detalleAuditoria.RespuestaID = detalle.RespuestaID;
                    detalleAuditoria.PuntoAuditoriaID = detalle.PuntoAuditoriaID;
                    detalleAuditoria.RespuestaDetalleAuditoria = respuestaDetalleAuditoria;
                    detalleAuditoria.PuntoAuditoria = puntoAuditoria;

                    detallesAuditoria.Add(detalleAuditoria);
                }
            }

            return detallesAuditoria;
        }

        [HttpPut]
        public ActionResult Put(DetalleAuditoria detalleAuditoria)
        {
            //Obtengo el registro del detalle de auditoria a modificar
            //var detalleAuditoriaDB = context.DetallesAuditoria.FirstOrDefault(x => x.ID == detalleAuditoria.ID);

            ////Retorno NotFound si no existe el registro detalle de auditoria
            //if (detalleAuditoriaDB == null) { return NotFound(); }

            ////"implementa" cambios en el obejo auditoria en detalleAuditoriaDB, para asi guardarlo en la base de datos*
            //detalleAuditoriaDB = mapper.Map(detalleAuditoria, detalleAuditoriaDB);

            context.Entry(detalleAuditoria).State = EntityState.Modified;

            //Guarda Cambios
            context.SaveChanges();

            return NoContent();
        }
    }
}
