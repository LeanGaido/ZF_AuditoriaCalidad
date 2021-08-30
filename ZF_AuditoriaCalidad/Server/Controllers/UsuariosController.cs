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
using ZF_AuditoriaCalidad.Shared.DTOs;

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
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            var usuarios = (from oUsuarios in context.Users
                            where !oUsuarios.DeBaja
                            select new UserDto
                            {
                                UserId = oUsuarios.Id,
                                email = oUsuarios.Email,
                                UserName = oUsuarios.UserName,
                                DeBaja = oUsuarios.DeBaja
                            }).ToList();

            return usuarios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(string id)
        {
            var usuario = (from oUsuarios in context.Users
                           where !oUsuarios.DeBaja
                           select new UserDto
                           {
                               UserId = oUsuarios.Id,
                               email = oUsuarios.Email,
                               UserName = oUsuarios.UserName,
                               DeBaja = oUsuarios.DeBaja
                           }).FirstOrDefault();

            if (usuario == null) { return NotFound(); }

            return usuario;
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<UserDto>>> Get(string textoBusqueda, int? tipoFiltro)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<UserDto>(); }

            textoBusqueda = textoBusqueda.ToLower();

            var usuarios = (from oUsuarios in context.Users
                            where oUsuarios.NormalizedUserName.Contains(textoBusqueda.ToUpper()) &&
                                  !oUsuarios.DeBaja
                            select new UserDto
                            {
                                UserId = oUsuarios.Id,
                                email = oUsuarios.Email,
                                UserName = oUsuarios.UserName,
                                DeBaja = oUsuarios.DeBaja
                            }).ToList();

            return usuarios;
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
