using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZF_AuditoriaCalidad.Shared;
using ZF_AuditoriaCalidad.Shared.DTOs;

namespace ZF_AuditoriaCalidad.Server.Models
{
    public class AutomapperPerfiles : Profile
    {
        public AutomapperPerfiles()
        {
            CreateMap<Auditoria, AuditoriaDTO>();
            CreateMap<DetalleAuditoria, DetalleAuditoriaDTO>();
        }
    }
}
