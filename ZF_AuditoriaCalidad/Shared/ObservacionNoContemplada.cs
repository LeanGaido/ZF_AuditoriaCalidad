using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZF_AuditoriaCalidad.Shared
{
    [Table("tblObservacionesNoContempladas")]
    public class ObservacionNoContemplada
    {
        public int ID { get; set; }

        public string Descripcion { get; set; }

        public bool ParaLaLinea { get; set; }

        [ForeignKey("AreaResponsable")]
        public int AreaResponsableID { get; set; }

        [ForeignKey("PuntoAuditoria")]
        public int PuntoAuditoriaID { get; set; }

        public string UserID { get; set; }

        public virtual Area AreaResponsable { get; set; }

        public virtual PuntoAuditoria PuntoAuditoria { get; set; }
    }
}
