using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZF_AuditoriaCalidad.Shared
{
    [Table("tblPuntosAuditoria")]
    public class PuntoAuditoria
    {
        public int ID { get; set; }

        public string Descripcion { get; set; }

        public bool DeBaja { get; set; }

        public DateTime FechaDeBaja { get; set; }

        public string UsuarioDeBaja { get; set; }
    }
}