using System;
using System.Collections.Generic;
using System.Text;

namespace ZF_AuditoriaCalidad.Shared.DTOs
{
    public class DetalleAuditoriaDTO
    {
        public int ID { get; set; }

        public int AuditoriaID { get; set; }

        public int RespuestaID { get; set; }

        public int PuntoAuditoriaID { get; set; }

        public virtual Auditoria Auditoria { get; set; }

        public virtual RespuestaDetalleAuditoria RespuestaDetalleAuditoria { get; set; }

        public virtual PuntoAuditoria PuntoAuditoria { get; set; }
    }
}
