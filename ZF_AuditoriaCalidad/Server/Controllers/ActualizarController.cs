using AutoMapper;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZF_AuditoriaCalidad.Server.Data;
using ZF_AuditoriaCalidad.Shared;

namespace ZF_AuditoriaCalidad.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualizarController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IHostEnvironment _environment;

        public ActualizarController(IHostEnvironment environment,
                                    ApplicationDbContext context,
                                    IMapper mapper)
        {
            this._environment = environment;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<string> Get(string FilePath, int FileType)
        {
            string Mensaje = "";
            switch (FileType)
            {
                case 1:
                    Mensaje = await ImportarMaquinas(FilePath);
                    break;
                case 2:
                    Mensaje = await ImportarOperarios(FilePath);
                    break;
                default:
                    break;
            }

            return Mensaje;
        }

        private async Task<string> ImportarMaquinas(string filePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    int row = 1;
                    Area area = new Area();
                    Proceso proceso = new Proceso();
                    Maquina maquina = new Maquina();
                    //do
                    //{
                    while (reader.Read()) //Each ROW
                    {
                        if (row == 1)
                        {
                            row++;
                            continue;
                        }
                        string nombreArea = reader.GetString(0);
                        if (string.IsNullOrEmpty(nombreArea))
                        {
                            string mensajeError = "El nombre del Area en la fila: " + row + ", no puede estar Vacio.";
                            return mensajeError;
                        }
                        string nombreProceso = reader.GetString(1);
                        if (string.IsNullOrEmpty(nombreProceso))
                        {
                            string mensajeError = "El nombre del Proceso en la fila: " + row + ", no puede estar Vacio.";
                            return mensajeError;
                        }
                        string numeroMaquina = reader.GetValue(2).ToString();
                        if (string.IsNullOrEmpty(numeroMaquina))
                        {
                            string mensajeError = "El nombre de la Maquina en la fila: " + row + ", no puede estar Vacio.";
                            return mensajeError;
                        }

                        if (area.Descripcion != nombreArea)
                        {
                            area = context.Areas.Where(x => x.Descripcion == nombreArea).FirstOrDefault();
                        }

                        if (area == null)
                        {
                            area = new Area();
                            area.Descripcion = nombreArea;

                            context.Areas.Add(area);
                            context.SaveChanges();
                        }

                        if (proceso.Descripcion != nombreProceso)
                        {
                            proceso = context.Procesos.Where(x => x.AreaID == area.ID && x.Descripcion == nombreProceso).FirstOrDefault();
                        }

                        if (proceso == null)
                        {
                            proceso = new Proceso();
                            proceso.Descripcion = nombreProceso;
                            proceso.AreaID = area.ID;

                            context.Procesos.Add(proceso);
                            context.SaveChanges();
                        }

                        maquina = context.Maquinas.Where(x => x.ProcesoID == proceso.ID && x.Descripcion == numeroMaquina).FirstOrDefault();
                        if (maquina == null)
                        {
                            maquina = new Maquina();
                            maquina.ProcesoID = proceso.ID;
                            maquina.Descripcion = numeroMaquina;

                            context.Maquinas.Add(maquina);
                            context.SaveChanges();
                        }
                        row++;
                    }
                    //} while (reader.NextResult()); //Move to NEXT SHEET

                }
            }

            return "Maquinas Importadas";
        }

        private async Task<string> ImportarOperarios(string filePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    int row = 1;
                    //do
                    //{

                    Operario operario = new Operario();

                    while (reader.Read()) //Each ROW
                    {
                        if(row == 1)
                        {
                            row++;
                            continue;
                        }
                        if(reader.GetValue(0) == null)
                        {
                            continue;
                        }
                        string legajo = reader.GetValue(0).ToString();
                        if (string.IsNullOrEmpty(legajo))
                        {
                            string mensajeError = "El numero de legajo en la fila: " + row + ", no puede estar Vacio.";
                            return mensajeError;
                        }
                        string nombreOperario = reader.GetString(1);
                        if (string.IsNullOrEmpty(nombreOperario))
                        {
                            string mensajeError = "El nombre del Operario en la fila: " + row + ", no puede estar Vacio.";
                            return mensajeError;
                        }
                        string telefonoOperario = reader.GetString(2);
                        if (string.IsNullOrEmpty(telefonoOperario))
                        {
                            string mensajeError = "El telefono del Operario en la fila: " + row + ", no puede estar Vacio.";
                            //return mensajeError;
                        }
                        string emailOperario = reader.GetString(3);
                        if (string.IsNullOrEmpty(emailOperario))
                        {
                            string mensajeError = "El email del Operario en la fila: " + row + ", no puede estar Vacio.";
                            //return mensajeError;
                        }
                        int operarioAuditor = 0;
                        if(!int.TryParse(reader.GetValue(4).ToString(), out operarioAuditor)){
                            string mensajeError = "Valor no valido para la Columna Auditor(0/1) en la fila: " + row + ".";
                            return mensajeError;
                        }
                        int operarioSupervisor = 0;
                        if (!int.TryParse(reader.GetValue(5).ToString(), out operarioSupervisor))
                        {
                            string mensajeError = "Valor no valido para la Columna Supervisor(0/1) en la fila: " + row + ".";
                            return mensajeError;
                        }

                        if (operario.Legajo != legajo)
                        {
                            operario = context.Operarios.Where(x => x.Legajo == legajo).FirstOrDefault();
                        }

                        if (operario == null)
                        {
                            operario = new Operario();
                            operario.Legajo = legajo;
                            operario.Nombre = nombreOperario;
                            operario.Telefono = telefonoOperario;
                            operario.Email = emailOperario;
                            operario.Auditor = (operarioAuditor == 1) ? true : false;
                            operario.Supervisor = (operarioSupervisor == 1) ? true : false;
                            operario.DeBaja = false;

                            context.Operarios.Add(operario);
                            context.SaveChanges();
                        }
                        else
                        {
                            operario.Legajo = legajo;
                            operario.Nombre = nombreOperario;
                            operario.Telefono = telefonoOperario;
                            operario.Email = emailOperario;
                            operario.Auditor = (operarioAuditor == 1) ? true : false;
                            operario.Supervisor = (operarioSupervisor == 1) ? true : false;
                            operario.DeBaja = false;
                            context.SaveChanges();
                        }
                        row++;
                    }
                    //} while (reader.NextResult()); //Move to NEXT SHEET

                }
            }

            return "Operarios Importados";
        }
    }
}
