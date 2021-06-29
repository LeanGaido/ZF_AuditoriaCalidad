using System.ComponentModel.DataAnnotations.Schema;

namespace ZF_AuditoriaCalidad.Shared
{
    [Table("tblPuntosAuditoria")]
    public class PuntoAuditoria
    {
        public int ID { get; set; }

        public string Descripcion { get; set; }
    }
}