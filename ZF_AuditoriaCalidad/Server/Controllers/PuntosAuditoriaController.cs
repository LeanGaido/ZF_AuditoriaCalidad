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
            //var puntosAuditoria = context.PuntosAuditoria.Where(x => x.DeBaja == false).AsQueryable();
            //return await puntosAuditoria.Paginar(parametrosBusqueda.Paginacion).ToListAsync();

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

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<int> Post(PuntoAuditoria puntoAuditoria)
        {
            if (ModelState.IsValid)
            {
                context.Add(puntoAuditoria);
                context.SaveChanges();
            }

            return puntoAuditoria.ID;
        }

        //public class ParametrosBusquedaObservacion
        //{
        //    public int Pagina { get; set; } = 1;
        //    public int CantidadRegistros { get; set; } = 10;
        //    public Paginacion Paginacion
        //    {
        //        get { return new Paginacion() { Pagina = Pagina, CantidadRegistros = CantidadRegistros }; }
        //    }
        //}

    }
}
