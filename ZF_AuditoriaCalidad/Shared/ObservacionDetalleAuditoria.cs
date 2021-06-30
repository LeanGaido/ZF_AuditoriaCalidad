using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZF_AuditoriaCalidad.Shared
{
    [Table("tblObservacionesDetalleAuditoria")]
    public class ObservacionDetalleAuditoria
    {
        public int ID { get; set; }

        [ForeignKey("DetalleAuditoria")]
        public int DetalleAuditoriaID { get; set; }

        public int ObservacionID { get; set; }

        public bool Contemplada { get; set; }

        public virtual DetalleAuditoria DetalleAuditoria { get; set; }

        [NotMapped]
        public Observacion Observacion { get; set; }

        [NotMapped]
        public ObservacionNoContemplada ObservacionNoContemplada { get; set; }
    }
}
