using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZF_AuditoriaCalidad.Shared.DTOs
{
    public class AuditoriaDTO
    {
        public int ID { get; set; }

        public DateTime Fecha { get; set; }

        //Numero del Mes de la auditoria. Ej.: 8
        public int Mes { get; set; }

        //Numero del año de la auditoria. Ej.: 2020
        public int Anio { get; set; }

        public string Hora { get; set; }

        public int MaquinaID { get; set; }

        //Nro de orden de produccion, dato obtenido al scannear el codigo de barras
        public string NroOrden { get; set; }

        //Nro de orden de produccion, dato obtenido al scannear el codigo de barras
        public string NroPieza { get; set; }

        //UserId del operario
        public int OperarioID { get; set; }

        //UserId del supervisor
        public int SupervisorID { get; set; }

        //UserId del auditor
        public string UserID { get; set; }

        public bool DeBaja { get; set; }

        public DateTime? FechaBaja { get; set; }

        public string UserBajaID { get; set; }

        public Area Area { get; set; }

        public Proceso Proceso { get; set; }

        public Maquina Maquina { get; set; }

        public Operario Operario { get; set; }

        public Operario Supervisor { get; set; }

        public List<DetalleAuditoria> DetallesAuditoria { get; set; }
    }
}
