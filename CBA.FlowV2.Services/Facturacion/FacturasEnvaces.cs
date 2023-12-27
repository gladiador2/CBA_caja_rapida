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
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
   public class FacturasEnvaces
    {
        #region GetArticulosEnvasesDataTable
        /// <summary>
        /// Gets the articulos lineas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosEnvasesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ENVASESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosEnvasesDataTable

        #region GetArticulosEnvasesInfoCompleta
        /// <summary>
        /// Gets the articulos lineas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosEnvasesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ENVASESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosEnvasesInfoCompleta

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
                        row = sesion.Db.FACTURA_ENVASESCollection.GetByPrimaryKey((decimal)campos[FacturasEnvaces.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.FACTURA_CLIENTE_DETALLE_ID = (decimal)campos[FacturasEnvaces.FacturaClienteDetalleID_NombreCol];
                    row.ENVASE_ID = (decimal)campos[FacturasEnvaces.EnvaseID_NombreCol];
                    row.CANTIDAD = (decimal)campos[FacturasEnvaces.Cantidad_NombreCol];
                    row.PESO = (decimal)campos[FacturasEnvaces.Peso_NombreCol];

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
        public void Borrar(decimal articulo_envase_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    FACTURA_ENVASESRow row = sesion.Db.FACTURA_ENVASESCollection.GetRow(Id_NombreCol + "= " + articulo_envase_id);
                    String valorAnterior = row.ToString();

                    sesion.Db.ENVASESCollection.DeleteByPrimaryKey(articulo_envase_id);
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
        public static string FacturaClienteDetalleID_NombreCol
        {
            get { return FACTURA_ENVASESCollection.FACTURA_CLIENTE_DETALLE_IDColumnName; }
        }
        public static string EnvaseID_NombreCol
        {
            get { return FACTURA_ENVASESCollection.ENVASE_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return FACTURA_ENVASESCollection.CANTIDADColumnName; }
        }
        public static string Peso_NombreCol
        {
            get { return FACTURA_ENVASESCollection.PESOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FACTURA_ENVASESCollection.IDColumnName; }
        }
        
       
        #endregion Accessors
    }
}
