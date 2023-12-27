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
    public class ProduccionBalanceadosDetallesService
    {
        #region GetProduccionBalanceadosDetallesDataTable
        public static DataTable GetProduccionBalanceadoDetallesDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PROD_BALAN_DETALLESCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetProduccionBalanceadosDetallesDataTable

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

                    if (!campos.Contains(ProduccionBalanceadosDetallesService.Modelo.PROD_BALAN_IDColumnName))
                        throw new Exception("Debe indicar la cabecera.");
                    if (!campos.Contains(ProduccionBalanceadosDetallesService.Modelo.PRESENTACION_IDColumnName))
                        throw new Exception("Debe indicar la presentacion del detalle.");                    

                    PROD_BALAN_DETALLESRow row = new PROD_BALAN_DETALLESRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("PROD_BALAN_DETALLES_SQC");
                        row.PROD_BALAN_ID = (decimal)campos[ProduccionBalanceadosDetallesService.Modelo.PROD_BALAN_IDColumnName];
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.PROD_BALAN_DETALLESCollection.GetRow(ProduccionBalanceadosDetallesService.Modelo.IDColumnName + " = " + campos[ProduccionBalanceadosDetallesService.Modelo.IDColumnName]);
                        valorAnterior = row.ToString();
                    }

                    PRODUCCION_BALANCEADOSRow cabecerarow = sesion.Db.PRODUCCION_BALANCEADOSCollection.GetByPrimaryKey(row.PROD_BALAN_ID);
                    PROD_BALAN_DETALLESRow[] rowSumatoria = sesion.Db.PROD_BALAN_DETALLESCollection.GetByPROD_BALAN_ID(row.PROD_BALAN_ID);

                    
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.PRESENTACION_IDColumnName))
                        row.PRESENTACION_ID = (decimal)campos[ProduccionBalanceadosDetallesService.Modelo.PRESENTACION_IDColumnName];
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.CANTIDAD_PRESENTACIONColumnName))
                        row.CANTIDAD_PRESENTACION = (decimal)campos[ProduccionBalanceadosDetallesService.Modelo.CANTIDAD_PRESENTACIONColumnName];
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.CANTIDADColumnName))
                        row.CANTIDAD = (decimal)campos[ProduccionBalanceadosDetallesService.Modelo.CANTIDADColumnName];
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.USAR_CANTIDADColumnName))
                        row.USAR_CANTIDAD = campos[ProduccionBalanceadosDetallesService.Modelo.USAR_CANTIDADColumnName].ToString();
                    
                    decimal suma = 0;
                    for (int i = 0; i < rowSumatoria.Length; i++)
                    {
                        if (!rowSumatoria[i].ID.Equals(row.ID))
                            suma += rowSumatoria[i].CANTIDAD;
                    }
                    //--Eso
                    if (suma+row.CANTIDAD > cabecerarow.CANTIDAD)
                        throw new Exception("La  sumatoria de las cantidades detalladas superan la cantidad solicitada");

                    
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.CANTIDAD_BASCULAColumnName))
                        row.CANTIDAD_BASCULA = (decimal)campos[ProduccionBalanceadosDetallesService.Modelo.CANTIDAD_BASCULAColumnName];
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.USAR_CANTIDAD_BASCULAColumnName))
                        row.USAR_CANTIDAD_BASCULA = campos[ProduccionBalanceadosDetallesService.Modelo.USAR_CANTIDAD_BASCULAColumnName].ToString();
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.CHAPA_CAMIONColumnName))
                        row.CHAPA_CAMION = (campos[ProduccionBalanceadosDetallesService.Modelo.CHAPA_CAMIONColumnName] + "").ToString();
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.CHAPA_CARRETAColumnName))
                        row.CHAPA_CARRETA = (campos[ProduccionBalanceadosDetallesService.Modelo.CHAPA_CARRETAColumnName] + "").ToString();
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.CHOFER_NOMBREColumnName))
                        row.CHOFER_NOMBRE = (campos[ProduccionBalanceadosDetallesService.Modelo.CHOFER_NOMBREColumnName] + "").ToString();
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.CHOFER_DOCUMENTOColumnName))
                        row.CHOFER_DOCUMENTO = (campos[ProduccionBalanceadosDetallesService.Modelo.CHOFER_DOCUMENTOColumnName] + "").ToString();
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.CHOFER_TELEFONOColumnName))
                        row.CHOFER_TELEFONO = (campos[ProduccionBalanceadosDetallesService.Modelo.CHOFER_TELEFONOColumnName] + "").ToString();
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.DESTINO_CLIENTEColumnName))
                        row.DESTINO_CLIENTE = (campos[ProduccionBalanceadosDetallesService.Modelo.DESTINO_CLIENTEColumnName] + "").ToString();
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.DESTINOColumnName))
                        row.DESTINO = campos[ProduccionBalanceadosDetallesService.Modelo.DESTINOColumnName].ToString();
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.PERSONA_IDColumnName))
                        row.PERSONA_ID = decimal.Parse(campos[ProduccionBalanceadosDetallesService.Modelo.PERSONA_IDColumnName].ToString());
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.PROVEEDOR_IDColumnName))
                        row.PROVEEDOR_ID = decimal.Parse(campos[ProduccionBalanceadosDetallesService.Modelo.PROVEEDOR_IDColumnName].ToString());
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.AUTONUMERACION_IDColumnName))
                        row.AUTONUMERACION_ID = (decimal)campos[ProduccionBalanceadosDetallesService.Modelo.AUTONUMERACION_IDColumnName];
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.NROCOMPROBANTEColumnName))
                        row.NROCOMPROBANTE = campos[ProduccionBalanceadosDetallesService.Modelo.NROCOMPROBANTEColumnName].ToString();
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.MARCAColumnName))
                        row.MARCA = (campos[ProduccionBalanceadosDetallesService.Modelo.MARCAColumnName] + "").ToString();
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.DEPARTAMENTO_IDColumnName))
                        row.DEPARTAMENTO_ID = (decimal)campos[ProduccionBalanceadosDetallesService.Modelo.DEPARTAMENTO_IDColumnName];
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.CIUDAD_IDColumnName))
                        row.CIUDAD_ID = (decimal)campos[ProduccionBalanceadosDetallesService.Modelo.CIUDAD_IDColumnName];
                    if (campos.Contains(ProduccionBalanceadosDetallesService.Modelo.CHOFER_DIRECCIONColumnName))
                        row.CHOFER_DIRECCION = campos[ProduccionBalanceadosDetallesService.Modelo.CHOFER_DIRECCIONColumnName].ToString();

                    if (insertarNuevo) sesion.Db.PROD_BALAN_DETALLESCollection.Insert(row);
                    else sesion.Db.PROD_BALAN_DETALLESCollection.Update(row);

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
                    PROD_BALAN_DETALLESRow row = new PROD_BALAN_DETALLESRow();

                    row = sesion.Db.PROD_BALAN_DETALLESCollection.GetByPrimaryKey(detalles_id);
                    //Se borra las relaciones si existen
                    DataTable materiales = ProduccionBalanceadosDetalleMaterialesService.GetProduccionBalancadosDetalleMaterialesDataTable(" and "+ProduccionBalanceadosDetalleMaterialesService.Modelo.PROD_BALAN_DET_IDColumnName + " = " + row.ID, string.Empty);
                    foreach (DataRow material in materiales.Rows)
                        ProduccionBalanceadosDetalleMaterialesService.Borrar((decimal)material[ProduccionBalanceadosDetalleMaterialesService.Modelo.IDColumnName]);
                    
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.PROD_BALAN_DETALLESCollection.DeleteByPrimaryKey(detalles_id);
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

        public static bool GetExisteNroComprobante(decimal PROD_BALAN_ID, decimal autonumeracion_id, string nro_comprobante, SessionService sesion)
        {
            bool existe = false;
            string clausulas = string.Empty;

            if (!autonumeracion_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                clausulas += ProduccionBalanceadosDetallesService.Modelo.AUTONUMERACION_IDColumnName + " = " + autonumeracion_id + " and ";

            clausulas +=  ProduccionBalanceadosDetallesService.Modelo.NROCOMPROBANTEColumnName+ " = '" + nro_comprobante + "' " +
                         " and " + ProduccionBalanceadosDetallesService.Modelo.PROD_BALAN_IDColumnName + " <> " + PROD_BALAN_ID ;

            DataTable rows = ProduccionBalanceadosDetallesService.GetProduccionBalanceadoDetallesDataTable(clausulas, string.Empty);

            existe = rows.Rows.Count > 0;

            return existe;
        }

        #region Accesors
        public const string Nombre_Tabla = "PROD_BALAN_DETALLES";
        public class Modelo : PROD_BALAN_DETALLESCollection_Base { public Modelo() : base(null) { } }
        #endregion Accesors
    }
}
