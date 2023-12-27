using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System;
using CBA.FlowV2.Services.Herramientas;
using System.Collections.Generic;

namespace CBA.FlowV2.Services.Reportes
{
    public class ReportesParametrosService
    {
        #region Clase Configuracion
        public class Configuracion
        {
            public int FormatoReporte;
            public bool Imprimir, EnviarMail;
            public bool DescargarPDF, DescargarExcel, DescargarWord;
            public string PathDescarga;
            public bool GenerarMultiplesPDF, PortraitPDF, GenerarZip;
            public bool Exportar, ExportarCSV;
            public List<string> ListaIdAGenerar;
            public Definiciones.Impresora impresora;
            public decimal? IdEnIteracion; //Utilizado para iterar sobre el ID al generar multiples PDF

            #region Constructores
            public Configuracion()
            {
                this.FormatoReporte = Definiciones.Error.Valor.IntPositivo;
                this.Imprimir = EnviarMail = false;
                this.DescargarPDF = this.DescargarExcel = this.DescargarWord = false;
                this.PathDescarga = string.Empty;
                this.GenerarMultiplesPDF = this.PortraitPDF = this.GenerarZip = false;
                this.Exportar = this.ExportarCSV = false;
                this.ListaIdAGenerar = new List<string>();
            }
            #endregion Constructores

            #region CantidadRepeticiones
            [Newtonsoft.Json.JsonIgnore]
            public int CantidadRepeticiones { get { return this.ListaIdAGenerar.Count > 0 ? this.ListaIdAGenerar.Count : 1; } }
            #endregion CantidadRepeticiones

            #region Es
            [Newtonsoft.Json.JsonIgnore]
            public bool EsCrystal { get { return this.FormatoReporte == Definiciones.FormatosReporte.CrystalReports; } }
            [Newtonsoft.Json.JsonIgnore]
            public bool EsLatex { get { return this.FormatoReporte == Definiciones.FormatosReporte.Latex || this.FormatoReporte == Definiciones.FormatosReporte.Matricial; } }
            [Newtonsoft.Json.JsonIgnore]
            public bool EsMatricial { get { return this.FormatoReporte == Definiciones.FormatosReporte.Matricial; } }
            [Newtonsoft.Json.JsonIgnore]
            public bool EsChart { get { return this.FormatoReporte == Definiciones.FormatosReporte.Chart; } }
            [Newtonsoft.Json.JsonIgnore]
            public bool EsExportarTXT { get { return this.FormatoReporte == Definiciones.FormatosReporte.ExportarTXT; } }
            [Newtonsoft.Json.JsonIgnore]
            public bool EsJSReport { get { return this.FormatoReporte == Definiciones.FormatosReporte.JSReport; } }
            #endregion Es
        }
        #endregion Clase Configuracion

        #region Utilizable

        /// <summary>
        /// Utilizadoes the specified reporte_parametro_id.
        /// </summary>
        /// <param name="reporte_parametro_id">The reporte_parametro_id.</param>
        /// <returns></returns>
        public static bool EsUtilizable(decimal reporte_parametro_id)
        {
            using (SessionService sesion = new SessionService())
            {
                REPORTES_PARAMETROSRow reporteParametro = sesion.Db.REPORTES_PARAMETROSCollection.GetRow(Id_NombreColumna + " = " + reporte_parametro_id);
                return reporteParametro.UTILIZADO.Equals(Definiciones.SiNo.No);
            }
        }

        /// <summary>
        /// Res the utilizable.
        /// </summary>
        /// <param name="reporte_parametro_id">The reporte_parametro_id.</param>
        /// <returns></returns>
        public static bool ReUtilizable(decimal reporte_parametro_id)
        {
            using (SessionService sesion = new SessionService())
            {
                REPORTES_PARAMETROSRow reporteParametro = sesion.Db.REPORTES_PARAMETROSCollection.GetRow(Id_NombreColumna + " = " + reporte_parametro_id);

                if (reporteParametro.REUTILIZABLE.Equals(Definiciones.SiNo.No)) return false;
                else return true;
            }
        }
        #endregion Utilizable

        #region Getters
        /// <summary>
        /// Obteners the parametros.
        /// </summary>
        /// <param name="reporte_parametro_id">The reporte_parametro_id.</param>
        /// <returns></returns>
        public string ObtenerParametros(decimal reporte_parametro_id, string codigo, string ip, out decimal usuario_id, out ReportesParametrosService.Configuracion configuracion) 
        {
            using (CBAV2 db = new CBAV2())
            {
                string exito = Definiciones.SiNo.No;
                
                ReportesContadoresService contador = new ReportesContadoresService();
                REPORTES_PARAMETROSRow reporteParametro = db.REPORTES_PARAMETROSCollection.GetRow(Id_NombreColumna + " = " + reporte_parametro_id);

                usuario_id = Definiciones.Error.Valor.EnteroPositivo;
                if (reporteParametro != null)
                {
                    usuario_id = reporteParametro.USUARIO_ID;

                    //Se verifica que el codigo sea el mismo
                    if (reporteParametro.CODIGO.Equals(codigo.ToString()))
                    {
                        // se verifica si el link es reutilizable
                        if (reporteParametro.REUTILIZABLE.Equals(Definiciones.SiNo.Si))
                        {
                            MarcarUtlizado(reporte_parametro_id, db);
                            exito = Definiciones.SiNo.Si;
                            // si el link es reutilzable se controla
                            //si el link nunca fue utilizado se carga en el contador de utilizacion
                            if (reporteParametro.UTILIZADO.Equals(Definiciones.SiNo.No))
                            {
                                contador.Guardar(reporteParametro.REPORTE_ID, exito, db, ip, reporteParametro.USUARIO_ID);
                                ActualizarUltimaActualizacion(reporte_parametro_id, db);
                            }
                            else
                            {
                                //si ya fue utilizado alguna vez se revisa en el tiempo para 
                                //no guardar cada vez que se navegeun en las hojas
                                DateTime ahora = DateTime.Now;
                                TimeSpan diferencia = ahora - reporteParametro.ULTIMA_UTILIZACION;
                                int cantidad = diferencia.Minutes;
                                if (cantidad > 5)
                                {
                                    contador.Guardar(reporteParametro.REPORTE_ID, exito, db, ip, reporteParametro.USUARIO_ID);
                                    ActualizarUltimaActualizacion(reporte_parametro_id, db);
                                }
                            }

                            configuracion = JsonUtil.Deserializar<Configuracion>(reporteParametro.CONFIGURACION);

                            return reporteParametro.PARAMETROS;
                        }
                        else
                        {
                            //Si el link no es reutilizable se verfica si ya fue utilizado
                            if (reporteParametro.UTILIZADO.Equals(Definiciones.SiNo.No))
                            {
                                exito = Definiciones.SiNo.Si;
                                contador.Guardar(reporteParametro.REPORTE_ID, exito, db, ip, reporteParametro.USUARIO_ID);
                                ActualizarUltimaActualizacion(reporte_parametro_id, db);
                                MarcarUtlizado(reporte_parametro_id, db);

                                configuracion = JsonUtil.Deserializar<Configuracion>(reporteParametro.CONFIGURACION);

                                return reporteParametro.PARAMETROS;
                            }
                            else
                            {
                                //Si el link ya fue utilizado se verfica cuanto tiempo ha pasado desde que fue urizado
                                //a fin de no agregar registros en los contadores si solo se estan pasando de hojas el reporte.
                                //el tiempo de Vigencia de un link ya utilizado es de 10 minutos
                                DateTime ahora = DateTime.Now;
                                TimeSpan diferencia = ahora - reporteParametro.ULTIMA_UTILIZACION;
                                int cantidad = diferencia.Minutes;
                                if (cantidad > 10)
                                {
                                    exito = Definiciones.SiNo.No;
                                    contador.Guardar(reporteParametro.REPORTE_ID, exito, db, ip, reporteParametro.USUARIO_ID);

                                    throw new Exception("El reporte no se encuentra disponible. Debe solicitarlo nuevamente.");
                                }
                                else
                                {
                                    exito = Definiciones.SiNo.Si;
                                    ActualizarUltimaActualizacion(reporte_parametro_id, db);

                                    configuracion = JsonUtil.Deserializar<Configuracion>(reporteParametro.CONFIGURACION);
                                    
                                    return reporteParametro.PARAMETROS;
                                }
                            }
                        }
                    }
                    else
                    {
                        exito = Definiciones.SiNo.No;
                        contador.Guardar(reporteParametro.REPORTE_ID, exito, db, ip, reporteParametro.USUARIO_ID);
                    }
                }

                configuracion = null;

                return string.Empty;
            }
        }
        /// <summary>
        /// Obteners the codigo.
        /// </summary>
        /// <param name="reporte_parametro_id">The reporte_parametro_id.</param>
        /// <returns></returns>
        public string ObtenerCodigo(decimal reporte_parametro_id)
        {
            using (SessionService sesion = new SessionService())
            {
                REPORTES_PARAMETROSRow reporteParametro = sesion.Db.REPORTES_PARAMETROSCollection.GetRow(Id_NombreColumna + " = " + reporte_parametro_id);
                return reporteParametro.CODIGO;
            }
        }
        #endregion Getters

        #region Guardar
        public decimal Guardar(string parametros, Configuracion configuracion, decimal codigo, string reutilizable, decimal reporte_id, bool usar_sesion) 
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    REPORTES_PARAMETROSRow parametro = new REPORTES_PARAMETROSRow();
                    string valorAnterior = string.Empty;

                    if (configuracion == null)
                        configuracion = new Configuracion();

                    //se asigna el un nuevo id
                    parametro.ID = sesion.Db.GetSiguienteSecuencia("reportes_parametros_sqc");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                   
                    // se asigna el resto de los campos
                    parametro.PARAMETROS = parametros;

                    parametro.CODIGO = codigo.ToString();
                    parametro.FECHA_CREACION = DateTime.Now;
                    parametro.UTILIZADO = Definiciones.SiNo.No;
                    parametro.REUTILIZABLE = reutilizable;
                    parametro.USUARIO_ID = usar_sesion ? sesion.Usuario.ID : Definiciones.Usuarios.Soporte;
                    
                    if(!reporte_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    {
                        parametro.REPORTE_ID = reporte_id;
                        configuracion.FormatoReporte = ReportesService.GetFormatoReporte(reporte_id);
                    }
                    else
                    {
                        parametro.IsREPORTE_IDNull = true;
                    }

                    parametro.CONFIGURACION = JsonUtil.Serializar(configuracion);

                    sesion.Db.REPORTES_PARAMETROSCollection.Insert(parametro);
                    
                    if(usar_sesion)
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, parametro.ID, valorAnterior, parametro.ToString(), sesion);

                    return parametro.ID;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Guardar

        #region Actualizacion
        public void MarcarUtlizado(decimal parametro_reporte_id, CBAV2 db) 
        {
            db.BeginTransaction();
            REPORTES_PARAMETROSRow reporteParametro = db.REPORTES_PARAMETROSCollection.GetRow(Id_NombreColumna + " = " + parametro_reporte_id);
            reporteParametro.UTILIZADO = Definiciones.SiNo.Si;
            db.REPORTES_PARAMETROSCollection.Update(reporteParametro);
            db.CommitTransaction();
        }
        public void ActualizarUltimaActualizacion(decimal parametro_reporte_id, CBAV2 db)
        {
            db.BeginTransaction();
            REPORTES_PARAMETROSRow reporteParametro = db.REPORTES_PARAMETROSCollection.GetRow(Id_NombreColumna + " = " + parametro_reporte_id);
            reporteParametro.ULTIMA_UTILIZACION = DateTime.Now;
            reporteParametro.UTILIZADO = Definiciones.SiNo.Si;
            db.REPORTES_PARAMETROSCollection.Update(reporteParametro);
            db.CommitTransaction();
        }
        #endregion Actualizacion

        #region Metodos estaticos
        public static string Nombre_Tabla
        {
            get { return "REPORTES_PARAMETROS"; }
        }
        public static string Id_NombreColumna
        {
            get { return REPORTES_PARAMETROSCollection.IDColumnName; }
        }
        public static string Codigo_NombreColumna
        {
            get { return REPORTES_PARAMETROSCollection.CODIGOColumnName; }
        }
        public static string FechaCreacion_NombreColumna
        {
            get { return REPORTES_PARAMETROSCollection.FECHA_CREACIONColumnName; }
        }
        public static string Parametros_NombreColumna
        {
            get { return REPORTES_PARAMETROSCollection.PARAMETROSColumnName; }
        }
        public static string ReporteId_NombreColumna
        {
            get { return REPORTES_PARAMETROSCollection.REPORTE_IDColumnName; }
        }
        public static string Reutilizable_NombreColumna
        {
            get { return REPORTES_PARAMETROSCollection.REUTILIZABLEColumnName; }
        }
        public static string Utilizado_NombreColumna
        {
            get { return REPORTES_PARAMETROSCollection.UTILIZADOColumnName; }
        }
        public static string UltimaActualizacion_NombreColumna
        {
            get { return REPORTES_PARAMETROSCollection.ULTIMA_UTILIZACIONColumnName; }
        }
        public static string UsuarioId_NombreColumna
        {
            get { return REPORTES_PARAMETROSCollection.USUARIO_IDColumnName; }
        }
        #endregion Metodos estaticos

    }
}
