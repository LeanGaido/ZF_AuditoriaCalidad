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
    public class ObservacionesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ObservacionesController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Observacion>>> Get([FromQuery] ParametrosBusquedaObservacion parametrosBusqueda)
        {
            var observaciones = context.Observaciones.Where(x => x.DeBaja == false)
                                                     .Include(t => t.AreaResponsable)
                                                     .Include(t => t.PuntoAuditoria).AsQueryable();

            if (!string.IsNullOrWhiteSpace(parametrosBusqueda.Descripcion))
            {
                observaciones = observaciones
                    .Where(x => x.Descripcion.ToLower().Contains(parametrosBusqueda.Descripcion.ToLower()));
            }

            if (parametrosBusqueda.PuntoAuditoriaID != null && parametrosBusqueda.PuntoAuditoriaID != 0)
            {
                observaciones = observaciones.Where(x => x.PuntoAuditoriaID == parametrosBusqueda.PuntoAuditoriaID);
            }

            if (parametrosBusqueda.ParaLaLinea != null)
            {
                observaciones = observaciones.Where(x => x.ParaLaLinea == parametrosBusqueda.ParaLaLinea);
            }

            if (parametrosBusqueda.AreaResponsableID != null && parametrosBusqueda.AreaResponsableID != 0)
            {
                observaciones = observaciones.Where(x => x.AreaResponsableID == parametrosBusqueda.AreaResponsableID);
            }

            await HttpContext.InsertarParametrosPaginacionEnRespuesta(observaciones, parametrosBusqueda.CantidadRegistros);

            return await observaciones.Paginar(parametrosBusqueda.Paginacion).ToListAsync();
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Observacion>> Get(int id)
        //{
        //    var observacion = await context.Observaciones.FirstOrDefaultAsync(x => x.ID == id);

        //    if (observacion == null) { return NotFound(); }

        //    return observacion;
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Observacion>>> Get(int Id)
        {
            if(Id != 0)
            {
                var observaciones = await context.Observaciones.Where(x => x.PuntoAuditoriaID == Id && x.DeBaja == false).ToListAsync();

                observaciones.ForEach(c => c.Contemplada = true);

                return observaciones;
            }
            else
            {
                return await context.Observaciones.ToListAsync();
            }
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<Observacion>>> Get(string textoBusqueda, int Id)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Observacion>(); }
            textoBusqueda = textoBusqueda.ToLower();

            var observaciones = await context.Observaciones.Where(x => x.Descripcion.ToLower().Contains(textoBusqueda) &&
                                                                       x.PuntoAuditoriaID == Id &&
                                                                       x.DeBaja == false).ToListAsync();

            observaciones.ForEach(c => c.Contemplada = true);

            return observaciones;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<int> Post(Observacion observacion)
        {
            if (ModelState.IsValid)
            {
                context.Add(observacion);
                context.SaveChanges();
            }

            return observacion.ID;
        }

        [HttpPut]
        public ActionResult Put(Observacion observacion)
        {
            //Obtengo el registro de auditoria a modificar
            context.Entry(observacion).State = EntityState.Modified;

            //Guarda Cambios
            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var observacion = await context.Observaciones.FindAsync(id);

            if (observacion == null) { return NotFound(); }

            observacion.DeBaja = true;
            observacion.FechaDeBaja = DateTime.Now;
            observacion.UsuarioDeBaja = User.Identity.Name;

            await context.SaveChangesAsync();

            return NoContent();
        }
    }

    public class ParametrosBusquedaObservacion
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistros { get; set; } = 10;
        public Paginacion Paginacion
        {
            get { return new Paginacion() { Pagina = Pagina, CantidadRegistros = CantidadRegistros }; }
        }
        public string Descripcion { get; set; }
        public bool? ParaLaLinea { get; set; }
        public int? AreaResponsableID { get; set; }
        public int? PuntoAuditoriaID { get; set; }
    }
}
