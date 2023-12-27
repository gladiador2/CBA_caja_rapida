using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class AjustesBancariosDetalleService
    {
        #region GetAjustesBancariosDetalleDataTable
        /// <summary>
        /// Gets the ajustes bancarios data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAjustesBancariosDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAjustesBancariosDetalleDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetAjustesBancariosDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.AJUSTES_BANCARIOS_DETCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAjustesBancariosDetalleDataTable

        #region GetAjustesBancariosDetalleInfoCompleta
        /// <summary>
        /// Gets the ajustes bancarios data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAjustesBancariosDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAjustesBancariosDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetAjustesBancariosDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.AJUSTES_BANC_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAjustesBancariosDetalleInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService()) {
                try {
                    bool actualizarTotal = false;

                    sesion.Db.BeginTransaction();

                    AJUSTES_BANCARIOS_DETRow row;
                    string valorAnterior = string.Empty;
                    AjustesBancariosService ajusteBancario = new AjustesBancariosService();

                    if (campos.Contains(AjustesBancariosDetalleService.Id_NombreCol)) {
                        row = sesion.Db.AJUSTES_BANCARIOS_DETCollection.GetByPrimaryKey((decimal)campos[AjustesBancariosDetalleService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    } else {
                        row = new AJUSTES_BANCARIOS_DETRow();
                        row.AJUSTE_BANCARIO_ID = (decimal)campos[AjustesBancariosDetalleService.AjusteBancarioId_NombreCol];
                        row.ID = sesion.Db.GetSiguienteSecuencia("ajustes_bancarios_det_sqc");

                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }

                    if (!row.MONTO.Equals((decimal)campos[AjustesBancariosDetalleService.Monto_NombreCol])) {
                        row.MONTO = (decimal)campos[AjustesBancariosDetalleService.Monto_NombreCol];
                        actualizarTotal = true;
                    }

                    row.OBSERVACION = (string)campos[AjustesBancariosDetalleService.Observacion_NombreCol];

                    if (campos.Contains(AjustesBancariosDetalleService.TextoPredefinidoId_NombreCol)) {
                        row.TEXTO_PREDEFINIDO_ID = (decimal)campos[AjustesBancariosDetalleService.TextoPredefinidoId_NombreCol];
                    } else {
                        row.IsTEXTO_PREDEFINIDO_IDNull = true;
                    }

                    if (campos.Contains(AjustesBancariosDetalleService.Id_NombreCol))
                        sesion.Db.AJUSTES_BANCARIOS_DETCollection.Update(row);
                    else
                        sesion.Db.AJUSTES_BANCARIOS_DETCollection.Insert(row);


                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    //Se actualiza el total de la cabecera
                    if (actualizarTotal)
                        AjustesBancariosService.ActualizarTotal(row.AJUSTE_BANCARIO_ID, sesion);

                    sesion.Db.CommitTransaction();
                } catch (Exception exp) {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified ajuste_bancario_detalle_id.
        /// </summary>
        /// <param name="ajuste_bancario_detalle_id">The ajuste_bancario_detalle_id.</param>
        public static void Borrar(decimal ajuste_bancario_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    AJUSTES_BANCARIOS_DETRow row = sesion.Db.AJUSTES_BANCARIOS_DETCollection.GetByPrimaryKey(ajuste_bancario_detalle_id);

                    sesion.Db.AJUSTES_BANCARIOS_DETCollection.Delete(row);

                    //Se actualiza el total de la cabecera
                    AjustesBancariosService.ActualizarTotal(row.AJUSTE_BANCARIO_ID, sesion);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "AJUSTES_BANCARIOS_DET"; }
        }
        public static string AjusteBancarioId_NombreCol
        {
            get { return AJUSTES_BANCARIOS_DETCollection.AJUSTE_BANCARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return AJUSTES_BANCARIOS_DETCollection.IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return AJUSTES_BANCARIOS_DETCollection.MONTOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return AJUSTES_BANCARIOS_DETCollection.OBSERVACIONColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return AJUSTES_BANCARIOS_DETCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        #endregion Tabla
        #region Vistas
        public static string VistaTextoPredefinidoTexto_NombreCol
        {
            get { return AJUSTES_BANC_DET_INFO_COMPLCollection.TEXTO_PREDEFINIDO_TEXTOColumnName; }
        }
        #endregion Vistas
        #endregion Accessors
    }
}
