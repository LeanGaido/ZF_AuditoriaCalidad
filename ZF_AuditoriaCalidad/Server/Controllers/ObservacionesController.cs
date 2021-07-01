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
        public async Task<ActionResult<List<Observacion>>> Get()
        {
            var observaciones = await context.Observaciones.ToListAsync();

            observaciones.ForEach(c => c.Contemplada = true);

            return observaciones;
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
                var observaciones = await context.Observaciones.Where(x => x.PuntoAuditoriaID == Id).ToListAsync();

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
                                                                       x.PuntoAuditoriaID == Id).ToListAsync();

            observaciones.ForEach(c => c.Contemplada = true);

            return observaciones;
        }
    }
}
