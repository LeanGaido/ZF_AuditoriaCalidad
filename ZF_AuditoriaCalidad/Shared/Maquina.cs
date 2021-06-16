using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZF_AuditoriaCalidad.Shared
{
    [Table("tblMaquinas")]
    public class Maquina
    {
        public int ID { get; set; }

        [StringLength(240, ErrorMessage = "El largo del texto no puede superar 240 Caracteres")]
        public string Descripcion { get; set; }
    }
}
