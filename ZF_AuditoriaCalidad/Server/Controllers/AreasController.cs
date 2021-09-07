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
    public class AreasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AreasController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Area>>> Get([FromQuery] ParametrosBusquedaAreas parametrosBusqueda)
        {
            var queryable = await context.Areas.Where(x => !x.DeBaja).ToListAsync();

            if (!string.IsNullOrWhiteSpace(parametrosBusqueda.Descripcion))
            {
                queryable = queryable
                    .Where(x => x.Descripcion.ToLower().Contains(parametrosBusqueda.Descripcion.ToLower())).ToList();
            }

            return queryable;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> Get(int id)
        {
            var area = await context.Areas.FirstOrDefaultAsync(x => x.ID == id && !x.DeBaja);

            if (area == null) { return NotFound(); }

            return area;
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<Area>>> Get(string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Area>(); }
            textoBusqueda = textoBusqueda.ToLower();
            return await context.Areas
                .Where(x => x.Descripcion.ToLower().Contains(textoBusqueda) && 
                            !x.DeBaja).ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var area = await context.Areas.FindAsync(id);
            if (area == null) { return NotFound(); }

            var procesos = await context.Procesos.Where(x => x.AreaID == id).ToListAsync();

            foreach (var proceso in procesos)
            {
                var maquinas = await context.Maquinas.Where(x => x.ProcesoID == proceso.ID).ToListAsync();

                foreach (var maquina in maquinas)
                {
                    maquina.DeBaja = true;
                }

                proceso.DeBaja = true;
            }

            area.DeBaja = true;

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
    public class ParametrosBusquedaAreas
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistros { get; set; } = 10;
        public Paginacion Paginacion
        {
            get { return new Paginacion() { Pagina = Pagina, CantidadRegistros = CantidadRegistros }; }
        }
        public string Descripcion { get; set; }
    }
}
