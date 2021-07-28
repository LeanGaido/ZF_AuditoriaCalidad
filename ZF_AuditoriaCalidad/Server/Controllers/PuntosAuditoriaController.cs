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
            return await context.PuntosAuditoria.Where(x => x.DeBaja == false).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PuntoAuditoria>> Get(int id)
        {
            var PuntoAuditoria = await context.PuntosAuditoria.FirstOrDefaultAsync(x => x.ID == id);

            if (PuntoAuditoria == null) { return NotFound(); }

            return PuntoAuditoria;
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<PuntoAuditoria>>> Get(string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<PuntoAuditoria>(); }
            textoBusqueda = textoBusqueda.ToLower();
            return await context.PuntosAuditoria
                .Where(x => x.Descripcion.ToLower().Contains(textoBusqueda)).ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var puntoAuditoria = await context.PuntosAuditoria.FindAsync(id);

            if (puntoAuditoria == null) { return NotFound(); }

            puntoAuditoria.DeBaja = true;
            puntoAuditoria.FechaDeBaja = DateTime.Now;
            puntoAuditoria.UsuarioDeBaja = User.Identity.Name;

            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
