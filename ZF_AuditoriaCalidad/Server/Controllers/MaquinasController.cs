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
        public async Task<ActionResult<List<Maquina>>> Get()
        {
            return await context.Maquinas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Maquina>> Get(int id)
        {
            var maquina = await context.Maquinas.FirstOrDefaultAsync(x => x.ID == id);

            if (maquina == null) { return NotFound(); }

            return maquina;
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<Maquina>>> Get(string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Maquina>(); }
            textoBusqueda = textoBusqueda.ToLower();
            return await context.Maquinas
                .Where(x => x.Descripcion.ToLower().Contains(textoBusqueda)).ToListAsync();
        }
    }
}
