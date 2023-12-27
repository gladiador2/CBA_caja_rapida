#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using Oracle.ManagedDataAccess.Client;
using System.Data;
#endregion Using

namespace CBA.FlowV2.Services.Tramites
{
    public class TramitesMedidasCautelaresService
    {
        #region GetTramitesMedidasCautelaresDataTable
        /// <summary>
        /// Gets the tramites medidas cautelares data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesMedidasCautelaresDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMITES_MEDIDAS_CAUTELARESCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesMedidasCautelaresDataTable

        #region GetTramitesMedidasCautelaresInfoCompleta
        /// <summary>
        /// Gets the tramites medidas cautelares info completa.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesMedidasCautelaresInfoCompleta(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMIT_MEDIDAS_CAUT_INF_COMPCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesMedidasCautelaresInfoCompleta
        
        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    TRAMITES_MEDIDAS_CAUTELARESRow row = new TRAMITES_MEDIDAS_CAUTELARESRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("tramit_medidas_cautelares_sqc");
                        row.TRAMITE_ID = (decimal)campos[TramitesMedidasCautelaresService.TramiteId_NombreCol];
                    }
                    else
                    {
                        row = sesion.Db.TRAMITES_MEDIDAS_CAUTELARESCollection.GetByPrimaryKey(decimal.Parse(campos[TramitesMedidasCautelaresService.Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.TEXTO_PREDEFINIDO_ID_TIPO = (decimal)campos[TramitesMedidasCautelaresService.TextoPredefinidoIdTipo_NombreCol];
                    row.FECHA_INSCRIPCION = (DateTime)campos[TramitesMedidasCautelaresService.FechaInscripcion_NombreCol];
                    row.OBSERVACION = (string)campos[TramitesMedidasCautelaresService.Observacion_NombreCol];
                    row.NRO_CUENTA_BANCARIA = (string)campos[TramitesMedidasCautelaresService.NroCuentaBancaria_NombreCol];
                    row.ENTIDAD = (string)campos[TramitesMedidasCautelaresService.Entidad_NombreCol];
                    row.CUENTA = (string)campos[TramitesMedidasCautelaresService.Cuenta_NombreCol];
                    row.DATOS_DEL_BIEN = (string)campos[TramitesMedidasCautelaresService.DatosDelBien_NombreCol];
                    row.OTROS_EMBARGOS_BIEN = (string)campos[TramitesMedidasCautelaresService.OtrosEmbargosBien_NombreCol];                    

                    if (campos.Contains(TramitesMedidasCautelaresService.FechaOtorgamiento_NombreCol))
                        row.FECHA_OTORGAMIENTO = (DateTime)campos[TramitesMedidasCautelaresService.FechaOtorgamiento_NombreCol];

                    if (campos.Contains(TramitesMedidasCautelaresService.MontoEmbargado_NombreCol))
                        row.MONTO_EMBARGADO = (decimal)campos[TramitesMedidasCautelaresService.MontoEmbargado_NombreCol];

                    if (campos.Contains(TramitesMedidasCautelaresService.TextoPredefinidoIdBien_NombreCol))
                        row.TEXTO_PREDEFINIDO_ID_BIEN = (decimal)campos[TramitesMedidasCautelaresService.TextoPredefinidoIdBien_NombreCol];

                    if (insertarNuevo) sesion.Db.TRAMITES_MEDIDAS_CAUTELARESCollection.Insert(row);
                    else sesion.Db.TRAMITES_MEDIDAS_CAUTELARESCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified tramite medida cautelar id.
        /// </summary>
        /// <param name="tramiteMedidaCautelarId">The tramite medida cautelar id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal tramiteMedidaCautelarId, SessionService sesion)
        {
            try
            {
                TRAMITES_MEDIDAS_CAUTELARESRow fila = sesion.Db.TRAMITES_MEDIDAS_CAUTELARESCollection.GetByPrimaryKey(tramiteMedidaCautelarId);

                sesion.Db.TRAMITES_MEDIDAS_CAUTELARESCollection.DeleteByPrimaryKey(tramiteMedidaCautelarId);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, tramiteMedidaCautelarId, fila.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static void Borrar(decimal tramiteMedidaCautelarId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(tramiteMedidaCautelarId, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TRAMITES_MEDIDAS_CAUTELARES"; }
        }
        public static string Cuenta_NombreCol
        {
            get { return TRAMITES_MEDIDAS_CAUTELARESCollection.CUENTAColumnName; }
        }
        public static string DatosDelBien_NombreCol
        {
            get { return TRAMITES_MEDIDAS_CAUTELARESCollection.DATOS_DEL_BIENColumnName; }
        }
        public static string Entidad_NombreCol
        {
            get { return TRAMITES_MEDIDAS_CAUTELARESCollection.ENTIDADColumnName; }
        }
        public static string FechaInscripcion_NombreCol
        {
            get { return TRAMITES_MEDIDAS_CAUTELARESCollection.FECHA_INSCRIPCIONColumnName; }
        }
        public static string FechaOtorgamiento_NombreCol
        {
            get { return TRAMITES_MEDIDAS_CAUTELARESCollection.FECHA_OTORGAMIENTOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return TRAMITES_MEDIDAS_CAUTELARESCollection.IDColumnName; }
        }
        public static string MontoEmbargado_NombreCol
        {
            get { return TRAMITES_MEDIDAS_CAUTELARESCollection.MONTO_EMBARGADOColumnName; }
        }
        public static string NroCuentaBancaria_NombreCol
        {
            get { return TRAMITES_MEDIDAS_CAUTELARESCollection.NRO_CUENTA_BANCARIAColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return TRAMITES_MEDIDAS_CAUTELARESCollection.OBSERVACIONColumnName; }
        }
        public static string OtrosEmbargosBien_NombreCol
        {
            get { return TRAMITES_MEDIDAS_CAUTELARESCollection.OTROS_EMBARGOS_BIENColumnName; }
        }
        public static string TramiteId_NombreCol
        {
            get { return TRAMITES_MEDIDAS_CAUTELARESCollection.TRAMITE_IDColumnName; }
        }
        public static string TextoPredefinidoIdBien_NombreCol
        {
            get { return TRAMITES_MEDIDAS_CAUTELARESCollection.TEXTO_PREDEFINIDO_ID_BIENColumnName; }
        }
        public static string TextoPredefinidoIdTipo_NombreCol
        {
            get { return TRAMITES_MEDIDAS_CAUTELARESCollection.TEXTO_PREDEFINIDO_ID_TIPOColumnName; }
        }
        public static string VistaTipoTextoPredefinidoNombreTipo_NombreCol
        {
            get { return TRAMIT_MEDIDAS_CAUT_INF_COMPCollection.TIPO_TEXTO_PREDEF_NOMBRE_TIPOColumnName; }
        }
        public static string VistaTextoPredefinidoTipo_NombreCol
        {
            get { return TRAMIT_MEDIDAS_CAUT_INF_COMPCollection.TEXTO_PREDEF_TIPOColumnName; }
        }
        public static string VistaTipoTextoPredefinidoNombreBien_NombreCol
        {
            get { return TRAMIT_MEDIDAS_CAUT_INF_COMPCollection.TIPO_TEXTO_PREDEF_NOMBRE_BIENColumnName; }
        }
        public static string VistaTextoPredefinidoBien_NombreCol
        {
            get { return TRAMIT_MEDIDAS_CAUT_INF_COMPCollection.TEXTO_PREDEF_BIENColumnName; }
        }
        public static string VistaTramiteTipoId_NombreCol
        {
            get { return TRAMIT_MEDIDAS_CAUT_INF_COMPCollection.TRAMITE_TIPO_IDColumnName; }
        }
        public static string VistaTramiteTipoNombre_NombreCol
        {
            get { return TRAMIT_MEDIDAS_CAUT_INF_COMPCollection.TRAMITE_TIPO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
