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
    public class NotasCreditoProveedorDetalleCuentaContableService
    {
        #region NCProveedorDetalleCuentaContableDataTable
        /// <summary>
        /// Gets the nc proveedor detalle cuenta contable data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetNCProveedorDetalleCuentaContableDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNCProveedorDetalleCuentaContableDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNCProveedorDetalleCuentaContableDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.NOTA_CR_PROV_DET_CTB_INFO_CCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion NCProveedorDetalleCuentaContableDataTable

        #region NCProveedorDetalleCuentaContableInfoCompleta
        /// <summary>
        /// Gets the nc proveedor detalle cuenta contable info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetNCProveedorDetalleCuentaContableInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.NOTA_CR_PROV_DET_CTB_INFO_CCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion NCProveedorDetalleCuentaContableInfoCompleta

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
                    NOTA_CREDITO_PROVEEDOR_DET_CTBRow row;
                    string valorAnterior = string.Empty;

                    if (campos.Contains(NotasCreditoProveedorDetalleCuentaContableService.Id_NombreCol))
                    {
                        row = sesion.db.NOTA_CREDITO_PROVEEDOR_DET_CTBCollection.GetByPrimaryKey((decimal)campos[NotasCreditoProveedorDetalleCuentaContableService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        row = new NOTA_CREDITO_PROVEEDOR_DET_CTBRow();
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.db.GetSiguienteSecuencia("NOTA_CREDITO_PROV_DET_CTB_SQC");
                        row.NOTA_CREDITO_PROVEEDOR_DET_ID = (decimal)campos[NotasCreditoProveedorDetalleCuentaContableService.NotaCreditoProveedorDetalleId_NombreCol];
                    }

                    row.CTB_CUENTA_ID = (decimal)campos[NotasCreditoProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                    row.PORCENTAJE = (decimal)campos[NotasCreditoProveedorDetalleCuentaContableService.Porcentaje_NombreCol];

                    if (campos.Contains(NotasCreditoProveedorDetalleCuentaContableService.Id_NombreCol))
                        sesion.db.NOTA_CREDITO_PROVEEDOR_DET_CTBCollection.Update(row);
                    else
                        sesion.db.NOTA_CREDITO_PROVEEDOR_DET_CTBCollection.Insert(row);

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
        /// Borrars the specified nota_credito_proveedor_detalle_cuenta_id.
        /// </summary>
        /// <param name="nota_credito_proveedor_detalle_cuenta_id">The nota_credito_proveedor_detalle_cuenta_id.</param>
        public static void Borrar(decimal nota_credito_proveedor_detalle_cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                NotasCreditoProveedorDetalleCuentaContableService.Borrar(nota_credito_proveedor_detalle_cuenta_id, sesion);
            }
        }

        public static void Borrar(decimal nota_credito_proveedor_detalle_cuenta_id, decimal nota_credito_proveedor_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                NotasCreditoProveedorDetalleCuentaContableService.Borrar(nota_credito_proveedor_detalle_cuenta_id, nota_credito_proveedor_detalle_id, sesion);
            }
        }

        /// <summary>
        /// Borrars the specified nota_credito_proveedor_detalle_cuenta_id.
        /// </summary>
        /// <param name="nota_credito_proveedor_detalle_cuenta_id">The nota_credito_proveedor_detalle_cuenta_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal nota_credito_proveedor_detalle_cuenta_id, SessionService sesion)
        {
            NOTA_CREDITO_PROVEEDOR_DET_CTBRow row = sesion.db.NOTA_CREDITO_PROVEEDOR_DET_CTBCollection.GetByPrimaryKey(nota_credito_proveedor_detalle_cuenta_id);
            sesion.db.NOTA_CREDITO_PROVEEDOR_DET_CTBCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }

        public static void Borrar(decimal nota_credito_proveedor_detalle_cuenta_id, decimal nota_credito_proveedor_detalle_id, SessionService sesion)
        {
            string where = NotasCreditoProveedorDetalleCuentaContableService.NotaCreditoProveedorDetalleId_NombreCol + " = " + nota_credito_proveedor_detalle_id + " and " + NotasCreditoProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol + " = " + nota_credito_proveedor_detalle_cuenta_id;
            NOTA_CREDITO_PROVEEDOR_DET_CTBRow row = sesion.db.NOTA_CREDITO_PROVEEDOR_DET_CTBCollection.GetRow(where);
            sesion.db.NOTA_CREDITO_PROVEEDOR_DET_CTBCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }
        #endregion Borrar

        #region DistribuirPorcentajesEquitativamente
        /// <summary>
        /// Distribuirs the porcentajes equitativamente.
        /// </summary>
        /// <param name="nota_credito_proveedor_detalle_cuenta_id">The nota_credito_proveedor_detalle_cuenta_id.</param>
        public static void DistribuirPorcentajesEquitativamente(decimal nota_credito_proveedor_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                NOTA_CREDITO_PROVEEDOR_DET_CTBRow[] rows = sesion.db.NOTA_CREDITO_PROVEEDOR_DET_CTBCollection.GetByNOTA_CREDITO_PROVEEDOR_DET_ID(nota_credito_proveedor_detalle_id);

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].PORCENTAJE = (decimal)100 / rows.Length;
                    sesion.db.NOTA_CREDITO_PROVEEDOR_DET_CTBCollection.Update(rows[i]);
                }
            }
        }
        #endregion DistribuirPorcentajesEquitativamente

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "NOTA_CREDITO_PROVEEDOR_DET_CTB"; }
        }
        public static string CtbCuentaId_NombreCol
        {
            get { return NOTA_CREDITO_PROVEEDOR_DET_CTBCollection.CTB_CUENTA_IDColumnName; }
        }
        public static string NotaCreditoProveedorDetalleId_NombreCol
        {
            get { return NOTA_CREDITO_PROVEEDOR_DET_CTBCollection.NOTA_CREDITO_PROVEEDOR_DET_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return NOTA_CREDITO_PROVEEDOR_DET_CTBCollection.IDColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return NOTA_CREDITO_PROVEEDOR_DET_CTBCollection.PORCENTAJEColumnName; }
        }
        public static string VistaCtbCuentaCodigoCompleto_NombreCol
        {
            get { return NOTA_CR_PROV_DET_CTB_INFO_CCollection.CTB_CUENTA_CODIGO_COMPLETOColumnName; }
        }
        public static string VistaCtbCuentaNombre_NombreCol
        {
            get { return NOTA_CR_PROV_DET_CTB_INFO_CCollection.CTB_CUENTA_NOMBREColumnName; }
        }
        public static string VistaCtbPlanCuentaId_NombreCol
        {
            get { return NOTA_CR_PROV_DET_CTB_INFO_CCollection.CTB_PLAN_CUENTA_IDColumnName; }
        }
        public static string VistaCtbPlanCuentaNombre_NombreCol
        {
            get { return NOTA_CR_PROV_DET_CTB_INFO_CCollection.CTB_PLAN_CUENTA_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
