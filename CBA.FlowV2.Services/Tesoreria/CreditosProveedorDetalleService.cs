using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CreditosProveedorDetalleService
    {
        #region GetCreditosProveedorDetalleDataTable
        /// <summary>
        /// Gets the creditos proveedor detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCreditosProveedorDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CREDITOS_PROVEEDOR_DETCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCreditosProveedorDetalleDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertar_nuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    CreditosProveedorService creditoProveedor = new CreditosProveedorService();
                    string valorAnterior;
                    CREDITOS_PROVEEDOR_DETRow row;

                    if (insertar_nuevo)
                    {    
                        row = new CREDITOS_PROVEEDOR_DETRow();
                        row.ID = sesion.Db.GetSiguienteSecuencia("creditos_proveedor_det_sqc");
                        row.CREDITO_PROVEEDOR_ID = (decimal)campos[CreditosProveedorDetalleService.CreditoProveedorId_NombreCol];
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.CREDITOS_PROVEEDOR_DETCollection.GetByPrimaryKey((decimal)(campos[CreditosProveedorDetalleService.Id_NombreCol]));
                        valorAnterior = row.ToString();
                    }

                    
                    row.FECHA_VENCIMIENTO = (DateTime)campos[CreditosProveedorDetalleService.FechaVencimiento_NombreCol];
                    row.MONTO_CAPITAL = (decimal)campos[CreditosProveedorDetalleService.MontoCapital_NombreCol];
                    row.MONTO_INTERES = (decimal)campos[CreditosProveedorDetalleService.MontoInteres_NombreCol];
                    row.NUMERO_CUOTA = (decimal)campos[CreditosProveedorDetalleService.NumeroCuota_NombreCol];

                    if(insertar_nuevo)
                        sesion.Db.CREDITOS_PROVEEDOR_DETCollection.Insert(row);
                    else
                        sesion.Db.CREDITOS_PROVEEDOR_DETCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }

                CreditosProveedorService.ActualizarTotalesCabecera((decimal)campos[CreditosProveedorDetalleService.CreditoProveedorId_NombreCol]);
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified deposito_bancario_detalle_id.
        /// </summary>
        /// <param name="credito_proveedor_det_id">The credito_proveedor_det_id.</param>
        public static void Borrar(decimal credito_proveedor_det_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CREDITOS_PROVEEDOR_DETRow row;

                try
                {
                    sesion.BeginTransaction();

                    row = sesion.Db.CREDITOS_PROVEEDOR_DETCollection.GetByPrimaryKey(credito_proveedor_det_id);

                    sesion.Db.CREDITOS_PROVEEDOR_DETCollection.Delete(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }

                CreditosProveedorService.ActualizarTotalesCabecera(row.CREDITO_PROVEEDOR_ID);
            }
        }
        #endregion borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CREDITOS_PROVEEDOR_DET"; }
        }
        public static string CreditoProveedorId_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_DETCollection.CREDITO_PROVEEDOR_IDColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_DETCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_DETCollection.IDColumnName; }
        }
        public static string MontoCapital_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_DETCollection.MONTO_CAPITALColumnName; }
        }
        public static string MontoInteres_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_DETCollection.MONTO_INTERESColumnName; }
        }
        public static string NumeroCuota_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_DETCollection.NUMERO_CUOTAColumnName; }
        }
        #endregion Accessors
    }
}
