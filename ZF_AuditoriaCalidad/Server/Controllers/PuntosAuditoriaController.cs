﻿using AutoMapper;
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

namespace ZF_AuditoriaCalidad.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuntosAuditoriaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PuntosAuditoriaController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<PuntoAuditoria>>> Get()
        {
            return await context.PuntosAuditoria.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PuntoAuditoria>> Get(int id)
        {
            var PuntoAuditoria = await context.PuntosAuditoria.FirstOrDefaultAsync(x => x.ID == id);

            if (PuntoAuditoria == null) { return NotFound(); }

            return PuntoAuditoria;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var puntoAuditoria = await context.PuntosAuditoria.FindAsync(id);
            if (puntoAuditoria == null) { return NotFound(); }

            //List<DetalleAuditoria> detallesAuditoria = context.DetallesAuditoria.Where(x => x.AuditoriaID == id).ToList();

            //foreach (var detalle in detallesAuditoria)
            //{
            //    List<ObservacionDetalleAuditoria> observacionesDetalle = context.ObservacionesDetalleAuditoria.Where(x => x.DetalleAuditoriaID == detalle.ID).ToList();

            //    if (observacionesDetalle != null && observacionesDetalle.Count > 0)
            //    {
            //        context.ObservacionesDetalleAuditoria.RemoveRange(observacionesDetalle);
            //        await context.SaveChangesAsync();
            //    }
            //}

            //context.DetallesAuditoria.RemoveRange(detallesAuditoria);
            //await context.SaveChangesAsync();

            context.PuntosAuditoria.Remove(puntoAuditoria);
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
