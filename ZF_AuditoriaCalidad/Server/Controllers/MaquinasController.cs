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
    public class MaquinasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MaquinasController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Maquina>>> Get([FromQuery] ParametrosBusquedaMaquinas parametrosBusqueda)
        {
            var maquinas = await context.Maquinas.Where(x => !x.DeBaja)
                                         .Include(x => x.Proceso)
                                         .ThenInclude(x => x.Area).ToListAsync();


            if (!string.IsNullOrWhiteSpace(parametrosBusqueda.Descripcion))
            {
                maquinas = maquinas.Where(x => x.Descripcion.ToLower().Contains(parametrosBusqueda.Descripcion.ToLower())).ToList();
            }

            if (parametrosBusqueda.AreaID != null && parametrosBusqueda.AreaID != 0)
            {
                maquinas = maquinas.Where(x => x.Proceso.AreaID == parametrosBusqueda.AreaID).ToList();
            }

            if (parametrosBusqueda.ProcesoID != null && parametrosBusqueda.ProcesoID != 0)
            {
                maquinas = maquinas.Where(x => x.ProcesoID == parametrosBusqueda.ProcesoID).ToList();
            }


            return maquinas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Maquina>>> Get(int id)
        {
            var maquinas = await context.Maquinas.Where(x => x.ProcesoID == id && !x.DeBaja)
                                                 .Include(x => x.Proceso)
                                                 .ThenInclude(x => x.Area).ToListAsync();

            if (maquinas == null) { return NotFound(); }

            return maquinas;
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<Maquina>>> Get(string textoBusqueda, int Id)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Maquina>(); }
            textoBusqueda = textoBusqueda.ToLower();
            var maquinas = await context.Maquinas
                                        .Where(x => x.Descripcion.ToLower().Contains(textoBusqueda)  &&
                                                    x.ProcesoID == Id &&
                                                    !x.DeBaja)
                                        .Include(x => x.Proceso)
                                        .ThenInclude(x => x.Area).ToListAsync();

            var periodoDeAudicion = context.ParametrosGenerales.Where(x => x.Key == "Periodo de Audicion(Dias)").FirstOrDefault();
            if(periodoDeAudicion == null)
            {
                periodoDeAudicion = new ParametroGeneral();

                periodoDeAudicion.Key = "Periodo de Audicion(Dias)";
                periodoDeAudicion.Value = "30";

                context.ParametrosGenerales.Add(periodoDeAudicion);
                context.SaveChanges();
            }

            DateTime hoy = DateTime.Today;

            int Dias = int.Parse(periodoDeAudicion.Value);

            hoy = hoy.AddDays(-Dias);

            foreach (var maquina in maquinas)
            {
                var cantDeAudiciones = context.Auditorias.Where(x => x.MaquinaID == maquina.ID && x.Fecha >= hoy).ToList().Count;

                maquina.CantDeVecesAuditada = "Esta maquina ha sido auditada " + cantDeAudiciones + " veces en los ultimos " + Dias;
            }

            return maquinas;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var maquina = await context.Maquinas.FindAsync(id);
            if (maquina == null) { return NotFound(); }

            maquina.DeBaja = true;

            await context.SaveChangesAsync();

            return NoContent();
        }
    }

    public class ParametrosBusquedaMaquinas
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistros { get; set; } = 10;
        public Paginacion Paginacion
        {
            get { return new Paginacion() { Pagina = Pagina, CantidadRegistros = CantidadRegistros }; }
        }
        public string Descripcion { get; set; }
        public int? AreaID { get; set; }
        public int? ProcesoID { get; set; }
    }
}
