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

        [ForeignKey("Observacion")]
        public int ObservacionID { get; set; }

        public bool Contemplada { get; set; }

        public virtual DetalleAuditoria DetalleAuditoria { get; set; }

        public virtual Observacion Observacion { get; set; }
    }
}
