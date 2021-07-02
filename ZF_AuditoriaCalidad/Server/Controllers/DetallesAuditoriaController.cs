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
                List<Observacion> observaciones = new List<Observacion>();

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

                    List<int> observacionesContempladasId = context.ObservacionesDetalleAuditoria.Where(x => x.DetalleAuditoriaID == detalle.ID &&
                                                                                                             x.Contemplada)
                                                                                                 .Select(x => x.ObservacionID).ToList();

                    List<int> observacionesNoContempladasId = context.ObservacionesDetalleAuditoria.Where(x => x.DetalleAuditoriaID == detalle.ID &&
                                                                                                               !x.Contemplada)
                                                                                                 .Select(x => x.ObservacionID).ToList();

                    observaciones = (from oObsContempladas in context.Observaciones
                                                       where observacionesContempladasId.Contains(oObsContempladas.ID)
                                                       select new Observacion
                                                       {
                                                           ID = oObsContempladas.ID,
                                                           Descripcion = oObsContempladas.Descripcion,
                                                           ParaLaLinea = oObsContempladas.ParaLaLinea,
                                                           AreaResponsableID = oObsContempladas.AreaResponsableID,
                                                           PuntoAuditoriaID = oObsContempladas.PuntoAuditoriaID,
                                                           Contemplada = true
                                                       }).ToList();//context.Observaciones.Where(x => observacionesContempladasId.Contains(x.ID)).ToList();

                    List<Observacion> observacionesNoContempladas = (from oObsNoContempladas in context.ObservacionesNoContempladas
                                                                     where observacionesNoContempladasId.Contains(oObsNoContempladas.ID)
                                                                     select new Observacion
                                                                     {
                                                                         ID = oObsNoContempladas.ID,
                                                                         Descripcion = oObsNoContempladas.Descripcion,
                                                                         ParaLaLinea = oObsNoContempladas.ParaLaLinea,
                                                                         AreaResponsableID = oObsNoContempladas.AreaResponsableID,
                                                                         PuntoAuditoriaID = oObsNoContempladas.PuntoAuditoriaID,
                                                                         Contemplada = false
                                                                     }).ToList();

                    observaciones.AddRange(observacionesNoContempladas);

                    detalleAuditoria.ID = detalle.ID;
                    detalleAuditoria.AuditoriaID = detalle.AuditoriaID;
                    detalleAuditoria.RespuestaID = detalle.RespuestaID;
                    detalleAuditoria.PuntoAuditoriaID = detalle.PuntoAuditoriaID;
                    detalleAuditoria.RespuestaDetalleAuditoria = respuestaDetalleAuditoria;
                    detalleAuditoria.PuntoAuditoria = puntoAuditoria;
                    detalleAuditoria.Observaciones = observaciones;

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
