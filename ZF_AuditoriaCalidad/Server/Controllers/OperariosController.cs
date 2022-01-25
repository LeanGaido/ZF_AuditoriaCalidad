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
    public class OperariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public OperariosController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Operario>>> Get([FromQuery] ParametrosBusquedaOperarios parametrosBusqueda)
        {
            var operarios = await context.Operarios.Where(x => (parametrosBusqueda.Auditor == null || x.Auditor == parametrosBusqueda.Auditor) &&
                                                               (parametrosBusqueda.Supervisor == null || x.Supervisor == parametrosBusqueda.Supervisor) &&
                                                               (x.DeBaja == parametrosBusqueda.Bajas)).ToListAsync();


            if (!string.IsNullOrWhiteSpace(parametrosBusqueda.Legajo))
            {
                operarios = operarios
                    .Where(x => x.Legajo.ToLower().Contains(parametrosBusqueda.Legajo.ToLower())).ToList();
            }

            if (!string.IsNullOrWhiteSpace(parametrosBusqueda.Apellido))
            {
                operarios = operarios
                    .Where(x => x.Apellido.ToLower().Contains(parametrosBusqueda.Apellido.ToLower())).ToList();
            }

            if (!string.IsNullOrWhiteSpace(parametrosBusqueda.Nombre))
            {
                operarios = operarios
                    .Where(x => x.Nombre.ToLower().Contains(parametrosBusqueda.Nombre.ToLower())).ToList();
            }



            return operarios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Operario>> Get(int id)
        {
            var operario = await context.Operarios.FirstOrDefaultAsync(x => x.ID == id);

            if (operario == null) { return NotFound(); }

            return operario;
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<Operario>>> Get(string textoBusqueda, int? tipoFiltro)
        {
            bool supervisor = false, auditor = false;

            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Operario>(); }

            textoBusqueda = textoBusqueda.ToLower();

            switch (tipoFiltro)
            {
                //Si *tipoFiltro* es 1 estoy buscando un operario que sea supervisor
                case 1:
                    supervisor = true;
                    break;
                //Si *tipoFiltro* es 2 estoy buscando un operario que sea auditor
                case 2:
                    auditor = true;
                    break;
                //Si *tipoFiltro* es null estoy buscando un operario que no sea auditor ni supervisor
                default:
                    break;
            }

            return await context.Operarios
                .Where(x => x.Auditor == auditor &&
                            x.Supervisor == supervisor &&
                            x.Legajo.ToLower().Contains(textoBusqueda)).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Operario>> Post(Operario Operario)
        {
            Operario operario = context.Operarios.Where(x => x.ID == Operario.ID).FirstOrDefault();
            if (operario == null)
            {
                return BadRequest("Ya existe otro Operario con este Z");
            }

            operario.DeBaja = false;

            await context.SaveChangesAsync();

            return Operario;
        }

        [HttpPut]
        public async Task<ActionResult<Operario>> Put(Operario operario)
        {
            if(context.Operarios.Where(x => x.ID != operario.ID && x.Z == operario.Z).FirstOrDefault() != null)
            {
                return BadRequest("Ya existe otro Operario con este Z");
            }

            if (context.Operarios.Where(x => x.ID != operario.ID && x.Legajo == operario.Legajo).FirstOrDefault() != null)
            {
                return BadRequest("Ya existe otro Operario con este Legajo");
            }

            context.Entry(operario).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return operario;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var operario = await context.Operarios.FindAsync(id);
            if (operario == null) { return NotFound(); }

            operario.DeBaja = true;

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
    public class ParametrosBusquedaOperarios
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistros { get; set; } = 10;
        public Paginacion Paginacion
        {
            get { return new Paginacion() { Pagina = Pagina, CantidadRegistros = CantidadRegistros }; }
        }
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool? Auditor { get; set; }
        public bool? Supervisor { get; set; }
        public bool? Bajas { get; set; }
    }
}
