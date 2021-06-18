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
        public async Task<ActionResult<List<Area>>> Get()
        {
            return await context.Areas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> Get(int id)
        {
            var area = await context.Areas.FirstOrDefaultAsync(x => x.ID == id);

            if (area == null) { return NotFound(); }

            return area;
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<Area>>> Get(string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Area>(); }
            textoBusqueda = textoBusqueda.ToLower();
            return await context.Areas
                .Where(x => x.Descripcion.ToLower().Contains(textoBusqueda)).ToListAsync();
        }
    }
}
