using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZF_AuditoriaCalidad.Shared
{
    [Table("tblAuditorias")]
    public class Auditoria
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        //Numero del Mes de la auditoria. Ej.: 8
        public int Mes { get; set; }

        //Numero del año de la auditoria. Ej.: 2020
        public int Anio { get; set; }

        [StringLength(5, ErrorMessage = "El formato de la hora tiene que ser HH:MM. Ej.: 09:45")]
        public string Hora { get; set; }

        [ForeignKey("Maquina")]
        [Required(ErrorMessage = "El numero de Maquina es Requerido")]
        public int MaquinaID { get; set; }

        //Nro de orden de produccion, dato obtenido al scannear el codigo de barras
        [Required(ErrorMessage = "El numero de Orden es Requerido y no puede estar vacio")]
        public string NroOrden { get; set; }

        //Nro de orden de produccion, dato obtenido al scannear el codigo de barras
        [Required(ErrorMessage = "El numero de Pieza es Requerido y no puede estar vacio")]
        public string NroPieza { get; set; }

        //UserId del operario
        [ForeignKey("Operario")]
        [Required(ErrorMessage = "El Operario es Requerido")]
        public int OperarioID { get; set; }

        //UserId del supervisor
        [ForeignKey("Supervisor")]
        [Required(ErrorMessage = "El Supervisor es Requerido")]
        public int SupervisorID { get; set; }

        //UserId del auditor
        public string UserID { get; set; }

        public bool DeBaja { get; set; }

        public DateTime? FechaBaja { get; set; }

        public string UserBajaID { get; set; }

        public virtual Maquina Maquina { get; set; }

        public virtual Operario Operario { get; set; }

        public virtual Operario Supervisor { get; set; }

        public virtual List<DetalleAuditoria> DetallesAuditoria { get; set; }
    }
}
