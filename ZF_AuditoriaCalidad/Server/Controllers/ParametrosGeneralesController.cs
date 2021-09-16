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
    public class ParametrosGeneralesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ParametrosGeneralesController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<ParametroGeneral>>> Get()
        {
            return await context.ParametrosGenerales.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParametroGeneral>> Get(int id)
        {
            var parametroGeneral = await context.ParametrosGenerales.FirstOrDefaultAsync(x => x.ID == id);

            if (parametroGeneral == null) { return NotFound(); }

            return parametroGeneral;
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<ParametroGeneral>>> Get(string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<ParametroGeneral>(); }

            return await context.ParametrosGenerales
                .Where(x => x.Key.Equals(textoBusqueda)).ToListAsync();
        }

        [HttpPut]
        public ActionResult Put(ParametroGeneral parametroGeneral)
        {
            //Obtengo el registro de auditoria a modificar
            context.Entry(parametroGeneral).State = EntityState.Modified;

            //Guarda Cambios
            context.SaveChanges();

            return NoContent();
        }
    }
}
