#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;

using Oracle.ManagedDataAccess.Client;
using System.Net;
using System.IO;
#endregion Using

namespace CBA.FlowV2.Services.Articulos
{
    public class FacturasEnvasesService
    {
        #region GetFacturasEnvasesDataTable
        /// <summary>
        /// Gets the articulos lineas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetFacturasEnvasesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FACTURA_ENVASESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetFacturasEnvasesDataTable

        #region GetFacturasEnvasesInfoCompleta
        /// <summary>
        /// Gets the articulos lineas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetFacturasEnvasesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FACTURA_ENVASES_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetFacturasEnvasesInfoCompleta


        #region GetResumenEnvases
        /// <summary>
        /// Gets listado de envases por factura.
        /// </summary>
        /// <param name="fcId">id de la factura.</param>
        /// <param name="orden">.</param>
        /// <returns></returns>
        public DataTable GetResumenEnvases(decimal fcId)
        {
            using (SessionService sesion = new SessionService())
            {
              
                try
                {
                    string comando = "select fe.* from "+Nombre_Vista+ " fe, "+FacturasClienteDetalleService.Nombre_Tabla+" fd "+
                        "where fd." + FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + fcId.ToString() + " and fe.detalle_Factura_Id = fd.id";
                  return sesion.db.EjecutarQuery(comando);
                }
                catch (Exception exp)
                {
                    throw new Exception(exp.Message);
                }
            }
        }
        #endregion GetResumenEnvases

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    FACTURA_ENVASESRow row = new FACTURA_ENVASESRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("FACTURA_ENVASES_SQC");
                    }
                    else
                    {
                        row = sesion.Db.FACTURA_ENVASESCollection.GetByPrimaryKey((decimal)campos[FacturasEnvasesService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.FACTURA_CLIENTE_DETALLE_ID = (decimal)campos[FacturasEnvasesService.FacturaClienteDetalleID_NombreCol];
                    row.ENVASE_ID = (decimal)campos[FacturasEnvasesService.EnvaseId_NombreCol];
                    row.CANTIDAD = (decimal)campos[FacturasEnvasesService.Cantidad_NombreCol];
                    row.PESO = (decimal)campos[FacturasEnvasesService.Peso_NombreCol];

                    if (insertarNuevo) sesion.Db.FACTURA_ENVASESCollection.Insert(row);
                    else sesion.Db.FACTURA_ENVASESCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

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
        /// Borrars the specified articulo_linea_id.
        /// </summary>
        /// <param name="articulo_linea_id">The articulo_linea_id.</param>
        public void Borrar(decimal articulo_linea_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    FACTURA_ENVASESRow row = sesion.Db.FACTURA_ENVASESCollection.GetRow(Id_NombreCol + "= " + articulo_linea_id);
                    String valorAnterior = row.ToString();

                    sesion.Db.FACTURA_ENVASESCollection.DeleteByPrimaryKey(articulo_linea_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);

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
        public static string Nombre_Tabla
        {
            get { return "FACTURA_ENVASES"; }
        }
        public static string Nombre_Vista
        {
            get { return "FACTURA_ENVASES_INFO_COMPLETA"; }
        }
        public static string FacturaClienteDetalleID_NombreCol
        {
            get { return FACTURA_ENVASESCollection.FACTURA_CLIENTE_DETALLE_IDColumnName; }
        }
        public static string EnvaseId_NombreCol
        {
            get { return FACTURA_ENVASESCollection.ENVASE_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return FACTURA_ENVASESCollection.CANTIDADColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FACTURA_ENVASESCollection.IDColumnName; }
        }
        public static string Peso_NombreCol
        {
            get { return FACTURA_ENVASESCollection.PESOColumnName; }
        }
        public static string VistaNroComprobante_NombreCol
        {
            get { return FACTURA_ENVASES_INFO_COMPLETACollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaFacturaNroCaso_NombreCol
        {
            get { return FACTURA_ENVASES_INFO_COMPLETACollection.FACTURA_NRO_CASOColumnName; }
        }
        public static string VistaCantidad_NombreCol
        {
            get { return FACTURA_ENVASES_INFO_COMPLETACollection.CANTIDADColumnName; }
        }
        public static string VistaCodigo_NombreCol
        {
            get { return FACTURA_ENVASES_INFO_COMPLETACollection.CODIGOColumnName; }
        }
        public static string VistaDetallefacturaId_NombreCol
        {
            get { return FACTURA_ENVASES_INFO_COMPLETACollection.DETALLE_FACTURA_IDColumnName; }
        }
        public static string VistaEnvaseId_NombreCol
        {
            get { return FACTURA_ENVASES_INFO_COMPLETACollection.ENVASE_IDColumnName; }
        }
        public static string VistaFacturaEnvaseId_NombreCol
        {
            get { return FACTURA_ENVASES_INFO_COMPLETACollection.FACTURA_ENVASE_IDColumnName; }
        }
        public static string VistaNombre_NombreCol
        {
            get { return FACTURA_ENVASES_INFO_COMPLETACollection.NOMBREColumnName; }
        }
        public static string VistaPesable_NombreCol
        {
            get { return FACTURA_ENVASES_INFO_COMPLETACollection.PESABLEColumnName; }
        }
        public static string VistaPesoFactura_NombreCol
        {
            get { return FACTURA_ENVASES_INFO_COMPLETACollection.PESO_FACTURAColumnName; }
        }
        public static string VistaUnidadId_NombreCol
        {
            get { return FACTURA_ENVASES_INFO_COMPLETACollection.UNIDAD_IDColumnName; }
        }
        #endregion Accessors
    }
}
