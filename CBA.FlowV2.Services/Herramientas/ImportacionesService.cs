using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.Facturacion;

namespace CBA.FlowV2.Services.Herramientas
{
    public class ImportacionesService
    {

        #region GetImportacionesDataTable
        /// <summary>
        /// Gets the importaciones data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetImportacionesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.IMPORTACIONESCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }

        public static DataTable GetImportacionesStaticDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.IMPORTACIONESCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetImportacionesDataTable

        #region GetImportacionesInfoCompletaDataTable
        /// <summary>
        /// Gets the importaciones info completa data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetImportacionesInfoCompletaDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.IMPORTACIONES_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetImportacionesInfoCompletaDataTable

        #region GetImportacion
        public DataRow GetImportacion(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = Id_NombreCol + " = " + id.ToString();
                DataTable table = sesion.Db.IMPORTACIONESCollection.GetAsDataTable(clausulas, string.Empty);
                return table.Rows[0];
            }
        }

        public static DataTable GetImportaciones(bool soloActivas)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = "1=1";
                if (soloActivas)
                    clausulas = Finalizado_NombreCol + " = '" + Definiciones.SiNo.No + "'";

                DataTable table = sesion.Db.IMPORTACIONESCollection.GetAsDataTable(clausulas, string.Empty);
                return table;
            }
        }

        public DataRow GetImportacionInfoCompleta(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = Id_NombreCol + " = " + id.ToString();
                DataTable table = sesion.Db.IMPORTACIONES_INFO_COMPLETACollection.GetAsDataTable(clausulas, string.Empty);
                return table.Rows[0];
            }
        }
        #endregion GetImportacionesDataTable

        #region ControlarFinalizado

        public void ControlarFinalizado(decimal ImportacionId)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.BeginTransaction();
                IMPORTACIONESRow row = sesion.Db.IMPORTACIONESCollection.GetByPrimaryKey(ImportacionId);
                if (row.FINALIZADO == Definiciones.SiNo.Si || row.SE_PUEDE_MODIFICAR == Definiciones.SiNo.Si)
                    return;

                string clausulas = FacturasProveedorService.ImportacionId_NombreCol + " = " + ImportacionId.ToString() +
                    " and " + FacturasProveedorService.VistaCasoEstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Cerrado + "'" +
                    " and " + FacturasProveedorService.VistaCasoEstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "'";

                DataTable dt = FacturasProveedorService.GetFacturaProveedorInfoCompleta(clausulas, string.Empty, sesion);
                if (dt.Rows.Count == 0)
                {
                    row.FINALIZADO = Definiciones.SiNo.Si;
                }
                sesion.Db.IMPORTACIONESCollection.Update(row);
                sesion.Db.CommitTransaction();
            }
        }

        #endregion ControlarFinalizado

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                IMPORTACIONESRow row = new IMPORTACIONESRow();
                bool exito = false;
                try
                {
                    sesion.Db.BeginTransaction();

                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("importaciones_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.IMPORTACIONESCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                        valorAnterior = row.ToString();

                        if (row.SE_PUEDE_MODIFICAR == Definiciones.SiNo.No || row.FINALIZADO ==Definiciones.SiNo.Si)
                        {
                            throw new Exception("La Importacion ya no se puede modificar");
                        }
                    }
                    
                    row.DOCUMENTOS = (string)campos[Documentos_NombreCol];
                    row.EMBARCADOR = (string)campos[Embarcador_NombreCol];
                    row.FECHA_LLEGADA_DESTINO_FINAL = (DateTime)campos[FechaLlegadaDestinoFinal_NombreCol];
                    row.FECHA_LLEGADA_SITIO_INTERMEDIO = (DateTime)campos[FechaLlegadaSitioIntermedio_NombreCol];
                    row.FECHA_SALIDA = (DateTime)campos[FechaSalida_NombreCol];
                    row.FINALIZADO = (string)campos[Finalizado_NombreCol];
                    row.NOMBRE_INTERNO = (string)campos[NombreInterno_NombreCol];
                    row.NUMERO_BL = (string)campos[NumeroBL_NombreCol];

                    row.SE_PUEDE_MODIFICAR = (string)campos[SePuedeModificar_NombreCol];

                    if (insertarNuevo) sesion.Db.IMPORTACIONESCollection.Insert(row);
                    else sesion.Db.IMPORTACIONESCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();

                    if (row.SE_PUEDE_MODIFICAR == Definiciones.SiNo.No)
                    {
                        ControlarFinalizado(row.ID);
                    }

                    exito = true;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }

                return exito ? row.ID : Definiciones.Error.Valor.EnteroPositivo;
            }
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "IMPORTACIONES"; }
        }
        public static string Id_NombreCol
        {
            get { return IMPORTACIONESCollection.IDColumnName; }
        }
        public static string Documentos_NombreCol
        {
            get { return IMPORTACIONESCollection.DOCUMENTOSColumnName; }
        }
        public static string Embarcador_NombreCol
        {
            get { return IMPORTACIONESCollection.EMBARCADORColumnName; }
        }
        public static string FechaLlegadaDestinoFinal_NombreCol
        {
            get { return IMPORTACIONESCollection.FECHA_LLEGADA_DESTINO_FINALColumnName; }
        }
        public static string FechaLlegadaSitioIntermedio_NombreCol
        {
            get { return IMPORTACIONESCollection.FECHA_LLEGADA_SITIO_INTERMEDIOColumnName; }
        }
        public static string FechaSalida_NombreCol
        {
            get { return IMPORTACIONESCollection.FECHA_SALIDAColumnName; }
        }
        public static string Finalizado_NombreCol
        {
            get { return IMPORTACIONESCollection.FINALIZADOColumnName; }
        }
        public static string NombreInterno_NombreCol
        {
            get { return IMPORTACIONESCollection.NOMBRE_INTERNOColumnName; }
        }
        public static string NumeroBL_NombreCol
        {
            get { return IMPORTACIONESCollection.NUMERO_BLColumnName; }
        }
        public static string SePuedeModificar_NombreCol
        {
            get { return IMPORTACIONESCollection.SE_PUEDE_MODIFICARColumnName; }
        }
        public static string VistaMonedaPaisCotizacion_NombreCol
        {
            get { return IMPORTACIONES_INFO_COMPLETACollection.MONEDA_PAIS_COTIZACIONColumnName; }
        }
        public static string VistaMonedaPaisId_NombreCol
        {
            get { return IMPORTACIONES_INFO_COMPLETACollection.MONEDA_PAIS_IDColumnName; }
        }
        public static string VistaTotalGastos_NombreCol
        {
            get { return IMPORTACIONES_INFO_COMPLETACollection.TOTAL_GASTOColumnName; }
        }
        public static string VistaTotalImpuestosGastos_NombreCol
        {
            get { return IMPORTACIONES_INFO_COMPLETACollection.TOTAL_IMPUESTO_GASTOColumnName; }
        }
        public static string VistaTotalFacturas_NombreCol
        {
            get { return IMPORTACIONES_INFO_COMPLETACollection.TOTAL_FACTURAColumnName; }
        }
        #endregion Accessors

    }
}
