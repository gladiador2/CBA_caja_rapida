using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteCajaComposicionDetalleService
    {
        #region GetCtacteCajaComposDataTable
        public static DataTable GetCtacteCajaComposDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCtacteCajaComposDetalleDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCtacteCajaComposDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_CAJA_COMPOSICION_DETCollection.GetAsDataTable(clausulas, orden);
        }
              
        #endregion GetCtacteCajaDataTable

        #region GetCtacteCajaComposInfoCompleta
        public static DataTable GetCtacteCajaComposDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_CAJA_COMPOS_DET_INF_COMCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCtacteCajaComposInfoCompleta

        #region GetGrupo
        public static DataTable GetCajaComposicionGrupos(decimal caja_composicion_id)
        {
            DataTable dtGrupos = new DataTable();

            dtGrupos = GetCajaComposicionGrupos(caja_composicion_id, string.Empty);
                
            return dtGrupos;
           
        }

        public static DataTable GetCajaComposicionGrupos(decimal caja_composicion_id, string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dtGrupos = new DataTable();

                string clausulas = "select " + Grupo_NombreCol + " from " + Nombre_Tabla + " where " +
                                    CtaCteCajaComposicionId_NombreCol + " = " + caja_composicion_id + clausula + " group by " + Grupo_NombreCol + " order by " + Grupo_NombreCol;
                
                dtGrupos = sesion.Db.EjecutarQuery(clausulas);
                
                return dtGrupos;
            }
        }

        public static DataTable GetCajaComposicionPorGrupo(decimal caja_composicion_id, decimal caja_composicion_grupo)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dtGrupo = new DataTable();

                string clausulas = CtaCteCajaComposicionId_NombreCol + " = " + caja_composicion_id + " and " + 
                                    Grupo_NombreCol + " = " + caja_composicion_grupo;

                dtGrupo = sesion.Db.CTACTE_CAJA_COMPOS_DET_INF_COMCollection.GetAsDataTable(clausulas, Id_NombreCol);

                return dtGrupo;
            }

        }
        #endregion GetGrupo

        #region ExisteArqueo
        public static bool ExisteArqueo(string clausula, SessionService sesion)
        {
            bool existe = false;
            
            DataTable dtArqueo = sesion.Db.CTACTE_CAJA_COMPOSICIONCollection.GetAsDataTable(clausula, string.Empty);

            if (dtArqueo.Columns.Count > 0)
                existe = true;
            
            return existe;
        }
        #endregion ExisteArqueo

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns>El id del recibo</returns>
        public static void Guardar(System.Collections.Hashtable campos, bool insertar_nuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CTACTE_CAJA_COMPOSICION_DETRow row = new CTACTE_CAJA_COMPOSICION_DETRow();
                    string valorAnterior = string.Empty;

                    if (insertar_nuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_caja_compos_det_sqc");
                    }
                    else
                    {
                        row = sesion.Db.CTACTE_CAJA_COMPOSICION_DETCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                    }

                    if (campos.Contains(MonedasDenominacionesId_NombreCol))
                        row.MONEDAS_DENOMINACIONES_ID = (decimal)campos[MonedasDenominacionesId_NombreCol];

                    if (campos.Contains(TextoPredefinidoId_NombreCol))
                        row.TEXTO_PREDEFINIDO_ID = (decimal)campos[TextoPredefinidoId_NombreCol];

                    if (campos.Contains(Cantidad_NombreCol))
                        row.CANTIDAD = (decimal)campos[Cantidad_NombreCol];

                    if (campos.Contains(Monto_NombreCol))
                        row.MONTO = (decimal)campos[Monto_NombreCol];

                    if (campos.Contains(Comentario_NombreCol))
                        row.COMENTARIO = campos[Comentario_NombreCol].ToString();

                    row.CTACTE_CAJA_COMPOSICION_ID = (decimal)campos[CtaCteCajaComposicionId_NombreCol];
                    row.GRUPO = (decimal)campos[Grupo_NombreCol];
                    row.MONEDA_ID = (decimal)campos[MonedaId_NombreCol];
                    row.SALDO_CAJA = (decimal)campos[SaldoCaja_NombreCol];
                    row.FECHA_MANUAL = (DateTime)campos[FechaManual_NombreCol];
                    row.FECHA_SISTEMA = (DateTime)campos[FechaSistema_NombreCol];

                    if (insertar_nuevo)
                        sesion.Db.CTACTE_CAJA_COMPOSICION_DETCollection.Insert(row);
                    else
                        sesion.Db.CTACTE_CAJA_COMPOSICION_DETCollection.Update(row);

                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ctacte_caja_composicion_det"; }
        }
        public static string Nombre_Vista
        {
            get { return "ctacte_caja_compos_det_inf_com"; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICION_DETCollection.IDColumnName; }
        }
        public static string CtaCteCajaComposicionId_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICION_DETCollection.CTACTE_CAJA_COMPOSICION_IDColumnName; }
        }
        public static string MonedasDenominacionesId_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICION_DETCollection.MONEDAS_DENOMINACIONES_IDColumnName; }
        }
        public static string Grupo_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICION_DETCollection.GRUPOColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICION_DETCollection.CANTIDADColumnName; }
        }
        public static string FechaSistema_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICION_DETCollection.FECHA_SISTEMAColumnName; }
        }
        public static string FechaManual_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICION_DETCollection.FECHA_MANUALColumnName; }
        }
        public static string SaldoCaja_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICION_DETCollection.SALDO_CAJAColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICION_DETCollection.MONEDA_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICION_DETCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string Comentario_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICION_DETCollection.COMENTARIOColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICION_DETCollection.MONTOColumnName; }
        }
        public static string VistaMonedaDenominacion_NombreCol
        {
            get { return CTACTE_CAJA_COMPOS_DET_INF_COMCollection.MONEDA_DENOMINACIONColumnName; }
        }
        public static string VistaMonedaDenomDescripcion_NombreCol
        {
            get { return CTACTE_CAJA_COMPOS_DET_INF_COMCollection.MONEDA_DEMON_DESCRIPColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_CAJA_COMPOS_DET_INF_COMCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_CAJA_COMPOS_DET_INF_COMCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaTextoPredefinido_NombreCol
        {
            get { return CTACTE_CAJA_COMPOS_DET_INF_COMCollection.TEXTOColumnName; }
        }
        public static string VistaTipoTextoPredefinidoId_NombreCol
        {
            get { return CTACTE_CAJA_COMPOS_DET_INF_COMCollection.TIPO_TEXTO_PREDEFINIDO_IDColumnName; }
        }
        #endregion Accessors
    }
}
