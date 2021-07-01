using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZF_AuditoriaCalidad.Shared
{
    [Table("tblDetallesAuditoria")]
    public class DetalleAuditoria
    {
        public int ID { get; set; }

        [ForeignKey("Auditoria")]
        public int AuditoriaID { get; set; }

        [ForeignKey("RespuestaDetalleAuditoria")]
        public int RespuestaID { get; set; }

        [ForeignKey("PuntoAuditoria")]
        public int PuntoAuditoriaID { get; set; }

        public DateTime? FechaCorreccion { get; set; }

        [NotMapped]
        public List<Observacion> Observaciones { get; set; }

        public virtual Auditoria Auditoria { get; set; }

        public virtual RespuestaDetalleAuditoria RespuestaDetalleAuditoria { get; set; }

        public virtual PuntoAuditoria PuntoAuditoria { get; set; }
    }
}
