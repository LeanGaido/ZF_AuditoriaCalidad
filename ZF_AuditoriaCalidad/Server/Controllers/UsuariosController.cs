using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZF_AuditoriaCalidad.Server.Data;
using ZF_AuditoriaCalidad.Server.Models;

namespace ZF_AuditoriaCalidad.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UsuariosController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<ApplicationUser>>> Get()
        {
            var usuarios = context.Users.Where(x => !x.DeBaja).ToList();

            return usuarios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> Get(string id)
        {
            var usuario = context.Users.Where(x => x.Id == id && !x.DeBaja).FirstOrDefault();

            if (usuario == null) { return NotFound(); }

            return usuario;
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<ApplicationUser>>> Get(string textoBusqueda, int? tipoFiltro)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<ApplicationUser>(); }

            textoBusqueda = textoBusqueda.ToLower();

            return context.Users
                .Where(x => x.NormalizedUserName.Contains(textoBusqueda.ToUpper()) && 
                            !x.DeBaja).ToList();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var operario = context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (operario == null) { return NotFound(); }

            operario.DeBaja = true;

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
