using System.ComponentModel.DataAnnotations.Schema;

namespace ZF_AuditoriaCalidad.Shared
{
    [Table("tblRespuestasDetalleAuditoria")]
    public class RespuestaDetalleAuditoria
    {
        public int ID { get; set; }

        [NotMapped]
        public int PuntoAuditoriaID { get; set; }

        public string Descripcion { get; set; }

        public string ClaseHtml { get; set; }
    }
}