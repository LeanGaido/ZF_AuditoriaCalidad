using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZF_AuditoriaCalidad.Shared
{
    [Table("tblParametrosGenerales")]
    public class ParametroGeneral
    {
        [Key]
        public int ID { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
