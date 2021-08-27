using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZF_AuditoriaCalidad.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool DeBaja { get; set; }

        public DateTime? FechaBaja { get; set; }

        public string UserBajaId { get; set; }
    }
}
