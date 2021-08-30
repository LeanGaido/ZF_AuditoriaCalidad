using System;
using System.Collections.Generic;
using System.Text;

namespace ZF_AuditoriaCalidad.Shared.DTOs
{
    public class UserDto
    {
        public string UserId { get; set; }

        public string email { get; set; }

        public string UserName { get; set; }

        public bool DeBaja { get; set; }
    }
}
