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
using ZF_AuditoriaCalidad.Server.Models;
using ZF_AuditoriaCalidad.Shared;
using ZF_AuditoriaCalidad.Shared.DTOs;

namespace ZF_AuditoriaCalidad.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditoriasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AuditoriasController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Auditoria>>> Get([FromQuery] ParametrosBusquedaAuditorias parametrosBusqueda)
        {
            var queryable = context.Auditorias.Include(x => x.Maquina).ThenInclude(x => x.Proceso).ThenInclude(x => x.Area)
                                              .Include(x => x.Operario)
                                              .Include(x => x.Supervisor).ToList();

            if (!string.IsNullOrWhiteSpace(parametrosBusqueda.NroDeOrden))
            {
                queryable = queryable
                    .Where(x => x.NroOrden.ToLower() == parametrosBusqueda.NroDeOrden.ToLower()).ToList();
            }

            if (!string.IsNullOrWhiteSpace(parametrosBusqueda.NroDePieza))
            {
                queryable = queryable
                    .Where(x => x.NroPieza.ToLower() == parametrosBusqueda.NroDePieza.ToLower()).ToList();
            }

            if (parametrosBusqueda.Fecha != null)
            {
                queryable = queryable.Where(x => x.Fecha >= parametrosBusqueda.Fecha).ToList();
            }

            if (parametrosBusqueda.AreaID != null && parametrosBusqueda.AreaID != 0)
            {
                queryable = queryable.Where(x => x.Maquina.Proceso.AreaID == parametrosBusqueda.AreaID).ToList();
            }

            if (parametrosBusqueda.ProcesoID != null && parametrosBusqueda.ProcesoID != 0)
            {
                queryable = queryable.Where(x => x.Maquina.ProcesoID == parametrosBusqueda.ProcesoID).ToList();
            }

            if (parametrosBusqueda.MaquinaID != null && parametrosBusqueda.MaquinaID != 0)
            {
                queryable = queryable.Where(x => x.MaquinaID == parametrosBusqueda.MaquinaID).ToList();
            }

            if (parametrosBusqueda.OperarioID != null && parametrosBusqueda.OperarioID != 0)
            {
                queryable = queryable.Where(x => x.OperarioID == parametrosBusqueda.OperarioID).ToList();
            }

            if (parametrosBusqueda.SupervisorID != null && parametrosBusqueda.SupervisorID != 0)
            {
                queryable = queryable.Where(x => x.SupervisorID == parametrosBusqueda.SupervisorID).ToList();
            }

            //await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, parametrosBusqueda.CantidadRegistros);

            return queryable;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<AuditoriaDTO> Get(int id)
        {
            var Auditoria = context.Auditorias.Where(x => x.ID == id)
                                              .Include(x => x.Maquina).ThenInclude(x => x.Proceso).ThenInclude(x => x.Area)
                                              .Include(x => x.Operario)
                                              .Include(x => x.Supervisor).FirstOrDefault();

            if (Auditoria == null) { return NotFound(); }

            var AuditoriaDTO = new AuditoriaDTO();

            AuditoriaDTO.ID = Auditoria.ID;
            AuditoriaDTO.Fecha = Auditoria.Fecha;
            AuditoriaDTO.Mes = Auditoria.Mes;
            AuditoriaDTO.Anio = Auditoria.Anio;
            AuditoriaDTO.Hora = Auditoria.Hora;
            AuditoriaDTO.NroOrden = Auditoria.NroOrden;
            AuditoriaDTO.NroPieza = Auditoria.NroPieza;
            AuditoriaDTO.Area = Auditoria.Maquina.Proceso.Area;
            AuditoriaDTO.Proceso = Auditoria.Maquina.Proceso;
            AuditoriaDTO.MaquinaID = Auditoria.Maquina.ID;
            AuditoriaDTO.Maquina = Auditoria.Maquina;
            AuditoriaDTO.OperarioID = Auditoria.Operario.ID;
            AuditoriaDTO.Operario = Auditoria.Operario;
            AuditoriaDTO.SupervisorID = Auditoria.Supervisor.ID;
            AuditoriaDTO.Supervisor = Auditoria.Supervisor;
            AuditoriaDTO.UserID = Auditoria.UserID;
            AuditoriaDTO.DeBaja = Auditoria.DeBaja;
            AuditoriaDTO.FechaBaja = Auditoria.FechaBaja;
            AuditoriaDTO.UserBajaID = Auditoria.UserBajaID;

            AuditoriaDTO.DetallesAuditoria = new List<DetalleAuditoria>();

            return AuditoriaDTO;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<int> Post(Auditoria auditoria)
        {
            if (ModelState.IsValid)
            {
                context.Add(auditoria);
                context.SaveChanges();

                foreach (var detalleAuditoria in auditoria.DetallesAuditoria)
                {
                    if(detalleAuditoria.Observaciones != null && detalleAuditoria.Observaciones.Count > 0)
                    {
                        foreach (var obs in detalleAuditoria.Observaciones)
                        {
                            if (!obs.Contemplada)
                            {
                                ObservacionNoContemplada observacionNoContemplada = new ObservacionNoContemplada();
                                observacionNoContemplada.Descripcion = obs.Descripcion;
                                observacionNoContemplada.ParaLaLinea = obs.ParaLaLinea;
                                observacionNoContemplada.PuntoAuditoriaID = obs.PuntoAuditoriaID;
                                observacionNoContemplada.AreaResponsableID = obs.AreaResponsableID;

                                context.ObservacionesNoContempladas.Add(observacionNoContemplada);

                                context.SaveChanges();

                                obs.ID = observacionNoContemplada.ID;
                            }
                            ObservacionDetalleAuditoria observacionDetalleAuditoria = new ObservacionDetalleAuditoria();

                            observacionDetalleAuditoria.DetalleAuditoriaID = detalleAuditoria.ID;
                            observacionDetalleAuditoria.ObservacionID = obs.ID;
                            observacionDetalleAuditoria.Contemplada = obs.Contemplada;

                            context.ObservacionesDetalleAuditoria.Add(observacionDetalleAuditoria);
                            context.SaveChanges();
                        }
                    }
                }
            }

            return auditoria.ID;
        }

        [HttpPut]
        public ActionResult Put(Auditoria auditoria)
        {
            //Obtengo el registro de auditoria a modificar
            context.Entry(auditoria).State = EntityState.Modified;

            //Guarda Cambios
            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var auditoria = await context.Auditorias.FindAsync(id);
            if (auditoria == null) { return NotFound(); }

            List<DetalleAuditoria> detallesAuditoria = context.DetallesAuditoria.Where(x => x.AuditoriaID == id).ToList();

            foreach (var detalle in detallesAuditoria)
            {
                List<ObservacionDetalleAuditoria> observacionesDetalle = context.ObservacionesDetalleAuditoria.Where(x => x.DetalleAuditoriaID == detalle.ID).ToList();

                if(observacionesDetalle != null && observacionesDetalle.Count > 0)
                {
                    context.ObservacionesDetalleAuditoria.RemoveRange(observacionesDetalle);
                    await context.SaveChangesAsync();
                }
            }

            context.DetallesAuditoria.RemoveRange(detallesAuditoria);
            await context.SaveChangesAsync();

            context.Auditorias.Remove(auditoria);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }

    public class ParametrosBusquedaAuditorias
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistros { get; set; } = 10;
        public Paginacion Paginacion
        {
            get { return new Paginacion() { Pagina = Pagina, CantidadRegistros = CantidadRegistros }; }
        }
        public string NroDeOrden { get; set; }
        public string NroDePieza { get; set; }
        public DateTime? Fecha { get; set; }
        public int? AreaID { get; set; }
        public int? ProcesoID { get; set; }
        public int? MaquinaID { get; set; }
        public int? OperarioID { get; set; }
        public int? SupervisorID { get; set; }
    }
}
