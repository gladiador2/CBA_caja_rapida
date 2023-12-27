#region using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
#endregion using

namespace CBA.FlowV2.Services.NotaCreditosProveedores
{
    public class NotasCreditoProveedorDetalleCentrosCostoService
    {
        #region GetNotasCreditoProveedorDetalleCentrosCostoDataTable
        /// <summary>
        /// Gets the notas de credito proveedor detalle centros costo data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetNotasCreditoProveedorDetalleCentrosCostoDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.NOTAS_CREDITO_PROV_DET_CENT_CCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetNotasCreditoProveedorDetalleCentrosCostoDataTable

        #region GetNotasCreditoProveedorDetalleCentrosCostoInfoCompleta
        /// <summary>
        /// Gets the nota credito proveedor detalle centros costo information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetNotasCreditoProveedorDetalleCentrosCostoInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.NOTAS_CRED_PROV_DET_C_C_INF_CCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetNotasCreditoProveedorDetalleCentrosCostoInfoCompleta

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
                    NOTAS_CREDITO_PROV_DET_CENT_CRow row;
                    string valorAnterior = string.Empty;

                    if (campos.Contains(NotasCreditoProveedorDetalleCentrosCostoService.Id_NombreCol))
                    {
                        row = sesion.db.NOTAS_CREDITO_PROV_DET_CENT_CCollection.GetByPrimaryKey((decimal)campos[NotasCreditoProveedorDetalleCentrosCostoService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        #region Validar que no fue agregado anteriormente
                        string clausulas = NotasCreditoProveedorDetalleCentrosCostoService.NotaCreditoPorveedorDetalleId_NombreCol + " = " + campos[NotasCreditoProveedorDetalleCentrosCostoService.NotaCreditoPorveedorDetalleId_NombreCol] + " and " +
                                           NotasCreditoProveedorDetalleCentrosCostoService.CentroCostoId_NombreCol + " = " + campos[NotasCreditoProveedorDetalleCentrosCostoService.CentroCostoId_NombreCol];
                        DataTable dt = GetNotasCreditoProveedorDetalleCentrosCostoInfoCompleta(clausulas, string.Empty);

                        if (dt.Rows.Count > 0)
                            throw new Exception("El centro de costo " + dt.Rows[0][NotasCreditoProveedorDetalleCentrosCostoService.VistaCentroCostoNombre_NombreCol] + " ya estaba incluido.");
                        #endregion Validar que no es parte del grupo

                        row = new NOTAS_CREDITO_PROV_DET_CENT_CRow();
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.db.GetSiguienteSecuencia("notas_credito_prov_det_cc_sqc");
                        row.NOTA_CREDITO_PROVEEDOR_DET_ID = (decimal)campos[NotasCreditoProveedorDetalleCentrosCostoService.NotaCreditoPorveedorDetalleId_NombreCol];
                    }

                    row.CENTRO_COSTO_ID = (decimal)campos[NotasCreditoProveedorDetalleCentrosCostoService.CentroCostoId_NombreCol];
                    row.PORCENTAJE = (decimal)campos[NotasCreditoProveedorDetalleCuentaContableService.Porcentaje_NombreCol];

                    if (campos.Contains(NotasCreditoProveedorDetalleCentrosCostoService.Id_NombreCol))
                        sesion.db.NOTAS_CREDITO_PROV_DET_CENT_CCollection.Update(row);
                    else
                        sesion.db.NOTAS_CREDITO_PROV_DET_CENT_CCollection.Insert(row);

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
        /// <summary>
        /// Borrar the specified nota_credito_proveedor_detalle_centro_costo_id.
        /// </summary>
        /// <param name="nota_credito_proveedor_detalle_centro_costo_id">The nota_credito_proveedor_detalle_centro_costo_id.</param>
        public static void Borrar(decimal nota_credito_proveedor_detalle_centro_costo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                NotasCreditoProveedorDetalleCentrosCostoService.Borrar(nota_credito_proveedor_detalle_centro_costo_id, sesion);
            }
        }

        public static void Borrar(decimal nota_credito_proveedor_detalle_centro_costo_id, decimal nota_credito_proveedor_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                NotasCreditoProveedorDetalleCentrosCostoService.Borrar(nota_credito_proveedor_detalle_centro_costo_id, nota_credito_proveedor_detalle_id, sesion);
            }
        }

        /// <summary>
        /// Borrar the specified nota_credito_proveedor_detalle_centro_costo_id.
        /// </summary>
        /// <param name="nota_credito_proveedor_detalle_centro_costo_id">The nota_credito_proveedor_detalle_centro_costo_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal nota_credito_proveedor_detalle_centro_costo_id, SessionService sesion)
        {
            NOTAS_CREDITO_PROV_DET_CENT_CRow row = sesion.db.NOTAS_CREDITO_PROV_DET_CENT_CCollection.GetByPrimaryKey(nota_credito_proveedor_detalle_centro_costo_id);
            sesion.db.NOTAS_CREDITO_PROV_DET_CENT_CCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }

        public static void Borrar(decimal nota_credito_proveedor_detalle_centro_costo_id, decimal nota_credito_proveedor_detalle_id, SessionService sesion)
        {
            string where = NotasCreditoProveedorDetalleCentrosCostoService.NotaCreditoPorveedorDetalleId_NombreCol + " = " + nota_credito_proveedor_detalle_id + " and " + NotasCreditoProveedorDetalleCentrosCostoService.CentroCostoId_NombreCol + " = " + nota_credito_proveedor_detalle_centro_costo_id;
            NOTAS_CREDITO_PROV_DET_CENT_CRow row = sesion.db.NOTAS_CREDITO_PROV_DET_CENT_CCollection.GetRow(where);
            sesion.db.NOTAS_CREDITO_PROV_DET_CENT_CCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }
        #endregion Borrar

        #region DistribuirPorcentajesEquitativamente
        /// <summary>
        /// Distribuirs the porcentajes equitativamente.
        /// </summary>
        /// <param name="nota_credito_proveedor_detalle_id">The nota_credito_proveedor_detalle_id.</param>
        public static void DistribuirPorcentajesEquitativamente(decimal nota_credito_proveedor_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                NOTAS_CREDITO_PROV_DET_CENT_CRow[] rows = sesion.db.NOTAS_CREDITO_PROV_DET_CENT_CCollection.GetByNOTA_CREDITO_PROVEEDOR_DET_ID(nota_credito_proveedor_detalle_id);

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].PORCENTAJE = (decimal)100 / rows.Length;
                    sesion.db.NOTAS_CREDITO_PROV_DET_CENT_CCollection.Update(rows[i]);
                }
            }
        }
        #endregion DistribuirPorcentajesEquitativamente

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "NOTAS_CREDITO_PROV_DET_CENT_C"; }
        }
        public static string Nombre_Vista
        {
            get { return "NOTAS_CRED_PROV_DET_C_C_INF_C"; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return NOTAS_CREDITO_PROV_DET_CENT_CCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return NOTAS_CREDITO_PROV_DET_CENT_CCollection.IDColumnName; }
        }
        public static string NotaCreditoPorveedorDetalleId_NombreCol
        {
            get { return NOTAS_CREDITO_PROV_DET_CENT_CCollection.NOTA_CREDITO_PROVEEDOR_DET_IDColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return NOTAS_CREDITO_PROV_DET_CENT_CCollection.PORCENTAJEColumnName; }
        }
        public static string VistaCentroCostoAbreviatura_NombreCol
        {
            get { return NOTAS_CRED_PROV_DET_C_C_INF_CCollection.CENTRO_COSTO_ABREVIATURAColumnName; }
        }
        public static string VistaCentroCostoNombre_NombreCol
        {
            get { return NOTAS_CRED_PROV_DET_C_C_INF_CCollection.CENTRO_COSTO_NOMBREColumnName; }
        }
        public static string VistaCentroCostoOrden_NombreCol
        {
            get { return NOTAS_CRED_PROV_DET_C_C_INF_CCollection.CENTRO_COSTO_ORDENColumnName; }
        }
        #endregion Accessors
    }
}
