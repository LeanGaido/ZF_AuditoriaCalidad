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
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProcesosController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Proceso>>> Get()
        {
            return await context.Procesos.Where(x => !x.DeBaja)
                                         .Include(x => x.Area).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Proceso>>> Get(int id)
        {
            var procesos = await context.Procesos.Where(x => x.AreaID == id &&
                                                             !x.DeBaja)
                                                 .Include(x => x.Area).ToListAsync();

            if (procesos == null) { return NotFound(); }

            return procesos;
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<Proceso>>> Get(string textoBusqueda, int Id)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Proceso>(); }
            textoBusqueda = textoBusqueda.ToLower();
            var procesos = await context.Procesos
                                        .Where(x => x.Descripcion.ToLower().Contains(textoBusqueda) &&
                                                    x.AreaID == Id &&
                                                    !x.DeBaja)
                                        .Include(x => x.Area).ToListAsync();

            return procesos;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var proceso = await context.Procesos.FindAsync(id);
            if (proceso == null) { return NotFound(); }

            var maquinas = await context.Maquinas.Where(x => x.ProcesoID == proceso.ID).ToListAsync();

            foreach (var maquina in maquinas)
            {
                maquina.DeBaja = true;
            }

            proceso.DeBaja = true;

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
