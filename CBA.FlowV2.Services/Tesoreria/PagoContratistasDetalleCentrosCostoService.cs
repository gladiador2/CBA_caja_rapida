#region using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
#endregion using

namespace CBA.FlowV2.Services.Herramientas
{
    public class PagosContratistasDetalleCentrosCostoService
    {
        #region GetDataTable
        public static DataTable GetDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.PAGO_CONTRATISTAS_DET_CENT_CCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetDataTable

        #region GetInfoCompleta
        public static DataTable GetInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PAGO_CONTRAT_DET_CC_INFO_CCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    PAGO_CONTRATISTAS_DET_CENT_CRow row;
                    string valorAnterior = string.Empty;

                    if (campos.Contains(PagoContratistasServices.Id_NombreCol))
                    {
                        row = sesion.db.PAGO_CONTRATISTAS_DET_CENT_CCollection.GetByPrimaryKey((decimal)campos[PagosContratistasDetalleCentrosCostoService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        #region Validar que no fue agregado anteriormente
                        string clausulas = PagosContratistasDetalleCentrosCostoService.PagoContratistasDetalleId_NombreCol + " = " + campos[PagosContratistasDetalleCentrosCostoService.PagoContratistasDetalleId_NombreCol] + " and " +
                                           PagosContratistasDetalleCentrosCostoService.CentroCostoId_NombreCol + " = " + campos[PagosContratistasDetalleCentrosCostoService.CentroCostoId_NombreCol];
                        DataTable dt = GetInfoCompleta(clausulas, string.Empty);

                        if (dt.Rows.Count > 0)
                            throw new Exception("El centro de costo " + dt.Rows[0][PagosContratistasDetalleCentrosCostoService.VistaCentroCostoNombre_NombreCol] + " ya estaba incluido.");
                        #endregion Validar que no es parte del grupo

                        row = new PAGO_CONTRATISTAS_DET_CENT_CRow();
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.db.GetSiguienteSecuencia("pago_contrat_det_cc_sqc");
                        row.PAGO_CONTRATISTAS_DET_ID = (decimal)campos[PagosContratistasDetalleCentrosCostoService.PagoContratistasDetalleId_NombreCol];
                        
                    }

                    row.CENTRO_COSTO_ID = (decimal)campos[PagosContratistasDetalleCentrosCostoService.CentroCostoId_NombreCol];
                    row.PORCENTAJE = (decimal)campos[PagosContratistasDetalleCentrosCostoService.Porcentaje_NombreCol];

                    if (campos.Contains(PagosContratistasDetalleCentrosCostoService.Id_NombreCol))
                        sesion.db.PAGO_CONTRATISTAS_DET_CENT_CCollection.Update(row);
                    else
                        sesion.db.PAGO_CONTRATISTAS_DET_CENT_CCollection.Insert(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal pago_contratista_detalle_centro_costo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PagosContratistasDetalleCentrosCostoService.Borrar(pago_contratista_detalle_centro_costo_id, sesion);
            }
        }

        public static void Borrar(decimal pago_contratistas_detalle_centro_costo_id, SessionService sesion)
        {
            PAGO_CONTRATISTAS_DET_CENT_CRow row = sesion.db.PAGO_CONTRATISTAS_DET_CENT_CCollection.GetByPrimaryKey(pago_contratistas_detalle_centro_costo_id);
            
            //Para realizar el borrado logico se aguarda a que
            //el detalle de FC Cliente tambien tenga borrado logico
            //row.ESTADO = Definiciones.Estado.Inactivo;
            //sesion.db.PAGO_CONTRATISTAS_DET_CENT_CCollection.Update(row);
            sesion.db.PAGO_CONTRATISTAS_DET_CENT_CCollection.Delete(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }
        #endregion Borrar

        #region DistribuirPorcentajesEquitativamente
        public static void DistribuirPorcentajesEquitativamente(decimal pago_contratistas_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PAGO_CONTRATISTAS_DET_CENT_CRow[] rows = sesion.db.PAGO_CONTRATISTAS_DET_CENT_CCollection.GetByPAGO_CONTRATISTAS_DET_ID(pago_contratistas_detalle_id);

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].PORCENTAJE = (decimal)100 / rows.Length;
                    sesion.db.PAGO_CONTRATISTAS_DET_CENT_CCollection.Update(rows[i]);
                }
            }
        }
        #endregion DistribuirPorcentajesEquitativamente

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PAGO_CONTRATISTAS_DET_CENT_C"; }
        }
        public static string Nombre_Vista
        {
            get { return "PAGO_CONTRAT_DET_CC_INFO_C"; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DET_CENT_CCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string PagoContratistasDetalleId_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DET_CENT_CCollection.PAGO_CONTRATISTAS_DET_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DET_CENT_CCollection.IDColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DET_CENT_CCollection.PORCENTAJEColumnName; }
        }
        public static string VistaCentroCostoAbreviatura_NombreCol
        {
            get { return PAGO_CONTRAT_DET_CC_INFO_CCollection.CENTRO_COSTO_ABREVIATURAColumnName; }
        }
        public static string VistaCentroCostoNombre_NombreCol
        {
            get { return PAGO_CONTRAT_DET_CC_INFO_CCollection.CENTRO_COSTO_NOMBREColumnName; }
        }
        public static string VistaCentroCostoOrden_NombreCol
        {
            get { return PAGO_CONTRAT_DET_CC_INFO_CCollection.CENTRO_COSTO_ORDENColumnName; }
        }
        #endregion Accessors
    }
}
