using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Stock 
{
    public class EgresoProductosDetallesService
    {
        #region Getters
        public static bool GetExisteNroComprobante(decimal egreso_producto_id, decimal autonumeracion_id, string nro_comprobante, SessionService sesion)
        {
            bool existe = false;
            string clausulas = string.Empty;

            if (!autonumeracion_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                clausulas += EgresoProductosDetallesService.Modelo.AUTONUMERACION_IDColumnName + " = " + autonumeracion_id + " and ";

            clausulas += EgresoProductosDetallesService.Modelo.NROCOMPROBANTEColumnName + " = '" + nro_comprobante + "' " +
                         " and " + EgresoProductosDetallesService.Modelo.EGRESO_PRODUCTO_IDColumnName + " <> " + egreso_producto_id;

            DataTable rows = EgresoProductosDetallesService.GetEgresoProductosDetallesDataTable(clausulas, string.Empty);

            existe = rows.Rows.Count > 0;

            return existe;
        }

        #region GetEgresoProductosDetallesDataTable
        public static DataTable GetEgresoProductosDetallesDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.EGRESO_PRODUCTOS_DETALLESCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetOrdenesCompraDetalleDataTable

        #endregion Getters        

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
                    sesion.BeginTransaction();

                    if (!campos.Contains(EgresoProductosDetallesService.Modelo.EGRESO_PRODUCTO_IDColumnName))
                        throw new Exception("Debe indicar la cabecera.");
                    if (!campos.Contains(EgresoProductosDetallesService.Modelo.PRESENTACION_IDColumnName))
                        throw new Exception("Debe indicar la presentacion del detalle.");                    

                    EGRESO_PRODUCTOS_DETALLESRow row = new EGRESO_PRODUCTOS_DETALLESRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("EGRESO_PRODUCTOS_DETALLES_SQC");
                        row.EGRESO_PRODUCTO_ID = (decimal)campos[EgresoProductosDetallesService.Modelo.EGRESO_PRODUCTO_IDColumnName];
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.EGRESO_PRODUCTOS_DETALLESCollection.GetRow(EgresoProductosDetallesService.Modelo.IDColumnName + " = " + campos[EgresoProductosDetallesService.Modelo.IDColumnName]);
                        valorAnterior = row.ToString();
                    }

                    EGRESO_PRODUCTOSRow cabecerarow = sesion.Db.EGRESO_PRODUCTOSCollection.GetByPrimaryKey(row.EGRESO_PRODUCTO_ID);
                    EGRESO_PRODUCTOS_DETALLESRow[] rowSumatoria = sesion.Db.EGRESO_PRODUCTOS_DETALLESCollection.GetByEGRESO_PRODUCTO_ID(row.EGRESO_PRODUCTO_ID);

                    
                        if (campos.Contains(EgresoProductosDetallesService.Modelo.PRESENTACION_IDColumnName))
                            row.PRESENTACION_ID = (decimal)campos[EgresoProductosDetallesService.Modelo.PRESENTACION_IDColumnName];
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.CANTIDAD_PRESENTACIONColumnName))
                        row.CANTIDAD_PRESENTACION = (decimal)campos[EgresoProductosDetallesService.Modelo.CANTIDAD_PRESENTACIONColumnName];
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.CANTIDADColumnName))
                        row.CANTIDAD = (decimal)campos[EgresoProductosDetallesService.Modelo.CANTIDADColumnName];
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.USAR_CANTIDADColumnName))
                        row.USAR_CANTIDAD = campos[EgresoProductosDetallesService.Modelo.USAR_CANTIDADColumnName].ToString();
                    
                    decimal suma = 0;
                    for (int i = 0; i < rowSumatoria.Length; i++)
                    {
                        if (!rowSumatoria[i].ID.Equals(row.ID))
                            suma += rowSumatoria[i].CANTIDAD;
                    }
                    //--Eso
                    if (suma+row.CANTIDAD > cabecerarow.CANTIDAD)
                        throw new Exception("La  sumatoria de las cantidades detalladas superan la cantidad solicitada");

                    
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.CANTIDAD_BASCULAColumnName))
                        row.CANTIDAD_BASCULA = (decimal)campos[EgresoProductosDetallesService.Modelo.CANTIDAD_BASCULAColumnName];
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.USAR_CANTIDAD_BASCULAColumnName))
                        row.USAR_CANTIDAD_BASCULA = campos[EgresoProductosDetallesService.Modelo.USAR_CANTIDAD_BASCULAColumnName].ToString();
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.CHAPA_CAMIONColumnName))
                        row.CHAPA_CAMION = (campos[EgresoProductosDetallesService.Modelo.CHAPA_CAMIONColumnName] + "").ToString();
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.CHAPA_CARRETAColumnName))
                        row.CHAPA_CARRETA = (campos[EgresoProductosDetallesService.Modelo.CHAPA_CARRETAColumnName] + "").ToString();
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.CHOFER_NOMBREColumnName))
                        row.CHOFER_NOMBRE = (campos[EgresoProductosDetallesService.Modelo.CHOFER_NOMBREColumnName] + "").ToString();
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.CHOFER_DOCUMENTOColumnName))
                        row.CHOFER_DOCUMENTO = (campos[EgresoProductosDetallesService.Modelo.CHOFER_DOCUMENTOColumnName] + "").ToString();
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.CHOFER_TELEFONOColumnName))
                        row.CHOFER_TELEFONO = (campos[EgresoProductosDetallesService.Modelo.CHOFER_TELEFONOColumnName] + "").ToString();
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.DESTINO_CLIENTEColumnName))
                        row.DESTINO_CLIENTE = (campos[EgresoProductosDetallesService.Modelo.DESTINO_CLIENTEColumnName] + "").ToString();
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.DESTINOColumnName))
                        row.DESTINO = campos[EgresoProductosDetallesService.Modelo.DESTINOColumnName].ToString();
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.PERSONA_IDColumnName))
                        row.PERSONA_ID = decimal.Parse(campos[EgresoProductosDetallesService.Modelo.PERSONA_IDColumnName].ToString());
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.PROVEEDOR_IDColumnName))
                        row.PROVEEDOR_ID = decimal.Parse(campos[EgresoProductosDetallesService.Modelo.PROVEEDOR_IDColumnName].ToString());
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.AUTONUMERACION_IDColumnName))
                        row.AUTONUMERACION_ID = (decimal)campos[EgresoProductosDetallesService.Modelo.AUTONUMERACION_IDColumnName];
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.NROCOMPROBANTEColumnName))
                        row.NROCOMPROBANTE = campos[EgresoProductosDetallesService.Modelo.NROCOMPROBANTEColumnName].ToString();
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.MARCAColumnName))
                        row.MARCA = (campos[EgresoProductosDetallesService.Modelo.MARCAColumnName] + "").ToString();
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.DEPARTAMENTO_IDColumnName))
                        row.DEPARTAMENTO_ID = (decimal)campos[EgresoProductosDetallesService.Modelo.DEPARTAMENTO_IDColumnName];
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.CIUDAD_IDColumnName))
                        row.CIUDAD_ID = (decimal)campos[EgresoProductosDetallesService.Modelo.CIUDAD_IDColumnName];
                    if (campos.Contains(EgresoProductosDetallesService.Modelo.CHOFER_DIRECCIONColumnName))
                        row.CHOFER_DIRECCION = campos[EgresoProductosDetallesService.Modelo.CHOFER_DIRECCIONColumnName].ToString();

                    if (insertarNuevo) sesion.Db.EGRESO_PRODUCTOS_DETALLESCollection.Insert(row);
                    else sesion.Db.EGRESO_PRODUCTOS_DETALLESCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified detalles_id.
        /// </summary>
        /// <param name="detalles_id">The detalles_id.</param>
        public static void Borrar(decimal detalles_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    EGRESO_PRODUCTOS_DETALLESRow row = new EGRESO_PRODUCTOS_DETALLESRow();

                    row = sesion.Db.EGRESO_PRODUCTOS_DETALLESCollection.GetByPrimaryKey(detalles_id);
                    //Se borra las relaciones si existen
                    DataTable materiales = EgresoProductosDetalleMaterialesService.GetEgresoProductosDetalleMaterialesDataTable(" and "+EgresoProductosDetalleMaterialesService.Modelo.EGRESO_PRODUCTO_DET_IDColumnName + " = " + row.ID, string.Empty);
                    foreach (DataRow material in materiales.Rows)
                        EgresoProductosDetalleMaterialesService.Borrar((decimal)material[EgresoProductosDetalleMaterialesService.Modelo.IDColumnName]);
                    
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.EGRESO_PRODUCTOS_DETALLESCollection.DeleteByPrimaryKey(detalles_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }
        #endregion Borrar        

        #region Accesors
        public const string Nombre_Tabla = "EGRESO_PRODUCTOS_DETALLES";
        public class Modelo : EGRESO_PRODUCTOS_DETALLESCollection_Base { public Modelo() : base(null) { } }
        #endregion Accesors
    }
}
