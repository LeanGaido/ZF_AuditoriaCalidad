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
        [AllowAnonymous]
        public async Task<ActionResult<List<Auditoria>>> Get([FromQuery] Paginacion paginacion)
        {
            var queryable = context.Auditorias.AsQueryable();

            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);

            return await queryable.Paginar(paginacion).ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<AuditoriaDTO> Get(int id)
        {
            var Auditoria = context.Auditorias.Where(x => x.ID == id)
                                                    .Include(x => x.Maquina).ThenInclude(x => x.Area)
                                                    .Include(x => x.Operario)
                                                    .Include(x => x.Supervisor)
                                                    .FirstOrDefault();

            if (Auditoria == null) { return NotFound(); }

            var AuditoriaDTO = new AuditoriaDTO();

            AuditoriaDTO.NroOrden = Auditoria.NroOrden;
            AuditoriaDTO.NroPieza = Auditoria.NroPieza;
            AuditoriaDTO.Area = Auditoria.Maquina.Area;
            AuditoriaDTO.Maquina = Auditoria.Maquina;
            AuditoriaDTO.Operario = Auditoria.Operario;
            AuditoriaDTO.Supervisor = Auditoria.Supervisor;
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
            }

            return auditoria.ID;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Auditoria auditoria)
        {
            //Obtengo el registro de auditoria a modificar
            var auditoriaDB = await context.Auditorias.FirstOrDefaultAsync(x => x.ID == auditoria.ID);

            //Retorno NotFound si no existe el registro de auditoria
            if (auditoriaDB == null) { return NotFound(); }

            //"implementa" cambios en el obejo auditoria en auditoriaDB, para asi guardarlo en la base de datos*
            auditoriaDB = mapper.Map(auditoria, auditoriaDB);

            //Guarda Cambios
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
