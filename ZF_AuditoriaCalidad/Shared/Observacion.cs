using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZF_AuditoriaCalidad.Shared
{
    [Table("tblObservaciones")]
    public class Observacion
    {
        public int ID { get; set; }

        public string Descripcion { get; set; }

        public bool ParaLaLinea { get; set; }

        [ForeignKey("AreaResponsable")]
        public int AreaResponsableID { get; set; }

        [ForeignKey("PuntoAuditoria")]
        public int PuntoAuditoriaID { get; set; }

        [NotMapped]
        public bool Contemplada { get; set; }

        public bool DeBaja { get; set; }

        public DateTime FechaDeBaja { get; set; }

        public string UsuarioDeBaja { get; set; }

        public virtual Area AreaResponsable { get; set; }

        public virtual PuntoAuditoria PuntoAuditoria { get; set; }
    }
}
