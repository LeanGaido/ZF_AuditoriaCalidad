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
    public class ObservacionesNoContempladasController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ObservacionesNoContempladasController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<ObservacionNoContemplada>>> Get([FromQuery] ParametrosBusquedaObservacion parametrosBusqueda)
        {
            var observaciones = context.ObservacionesNoContempladas.Include(t => t.AreaResponsable)
                                                                   .Include(t => t.PuntoAuditoria).AsQueryable();

            if (!string.IsNullOrWhiteSpace(parametrosBusqueda.Descripcion))
            {
                observaciones = observaciones.Where(x => x.Descripcion.ToLower().Contains(parametrosBusqueda.Descripcion.ToLower()));
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

            return await observaciones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ObservacionNoContemplada>>> Get(int Id)
        {
            if (Id != 0)
            {
                var observaciones = await context.ObservacionesNoContempladas.Where(x => x.PuntoAuditoriaID == Id).ToListAsync();

                return observaciones;
            }
            else
            {
                return await context.ObservacionesNoContempladas.ToListAsync();
            }
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<ObservacionNoContemplada>>> Get(string textoBusqueda, int Id)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<ObservacionNoContemplada>(); }
            textoBusqueda = textoBusqueda.ToLower();

            var observaciones = await context.ObservacionesNoContempladas.Where(x => x.Descripcion.ToLower().Contains(textoBusqueda) &&
                                                                                     x.PuntoAuditoriaID == Id).ToListAsync();

            return observaciones;
        }
    }

    public class ParametrosBusquedaObservacionNoContemplada
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistros { get; set; } = 10;
        public Paginacion Paginacion
        {
            get { return new Paginacion() { Pagina = Pagina, CantidadRegistros = CantidadRegistros }; }
        }
        public string Descripcion { get; set; }
        public bool ParaLaLinea { get; set; }
        public int? AreaResponsableID { get; set; }
        public int? PuntoAuditoriaID { get; set; }
    }
}
