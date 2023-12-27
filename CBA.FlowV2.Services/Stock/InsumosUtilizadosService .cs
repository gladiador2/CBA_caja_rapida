using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;

namespace CBA.FlowV2.Services.Stock
{
    public class InsumosUtilizadosService
    {
        #region GetInsumosUtilizadosDataTable
        public static DataTable GetInsumosUtilizadosDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.INSUMOS_UTILIZADOSCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetOrdenesCompraDetalleDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// 

        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Guardar(campos, insertarNuevo, sesion);
                    sesion.CommitTransaction();                    
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            if (!campos.Contains(InsumosUtilizadosService.Modelo.PROD_BALAN_IDColumnName) && 
                !campos.Contains(InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName))
                throw new Exception("Debe indicar la cabecera.");

            INSUMOS_UTILIZADOSRow row = new INSUMOS_UTILIZADOSRow();
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("INSUMOS_UTILIZADOS_SQC");
                
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.Db.INSUMOS_UTILIZADOSCollection.GetRow(InsumosUtilizadosService.Modelo.IDColumnName + " = " + campos[InsumosUtilizadosService.Modelo.IDColumnName]);
                valorAnterior = row.ToString();
            }

            if (campos.Contains(InsumosUtilizadosService.Modelo.PROD_BALAN_IDColumnName))
                row.PROD_BALAN_ID = (decimal)campos[InsumosUtilizadosService.Modelo.PROD_BALAN_IDColumnName];
            if (campos.Contains(InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName))
                row.EGRESO_PRODUCTO_ID = (decimal)campos[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName];
            if (campos.Contains(InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName))
                row.ARTICULO_ID = (decimal)campos[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName];
            if (campos.Contains(InsumosUtilizadosService.Modelo.CANTIDADColumnName))
                row.CANTIDAD = (decimal)campos[InsumosUtilizadosService.Modelo.CANTIDADColumnName];
            if (campos.Contains(InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName))
                row.CANTIDAD_NOMINAL = (decimal)campos[InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName];
            if (campos.Contains(InsumosUtilizadosService.Modelo.LOTE_IDColumnName))
                row.LOTE_ID = (decimal)campos[InsumosUtilizadosService.Modelo.LOTE_IDColumnName];
            if (campos.Contains(InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName))
                row.UNIDAD_MEDIDA_ID = (string)campos[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName];
            if (campos.Contains(InsumosUtilizadosService.Modelo.SUCURSAL_IDColumnName))
                row.SUCURSAL_ID = (decimal)campos[InsumosUtilizadosService.Modelo.SUCURSAL_IDColumnName];
            if (campos.Contains(InsumosUtilizadosService.Modelo.DEPOSITO_IDColumnName))
                row.DEPOSITO_ID = (decimal)campos[InsumosUtilizadosService.Modelo.DEPOSITO_IDColumnName];

            if (insertarNuevo) sesion.Db.INSUMOS_UTILIZADOSCollection.Insert(row);
            else sesion.Db.INSUMOS_UTILIZADOSCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    INSUMOS_UTILIZADOSRow row = new INSUMOS_UTILIZADOSRow();

                    row = sesion.Db.INSUMOS_UTILIZADOSCollection.GetByPrimaryKey(id);
                    //Se borra las relaciones si existen

                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.INSUMOS_UTILIZADOSCollection.DeleteByPrimaryKey(id);
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

        public static void BorrarPorProduccionBalanceadoId(decimal produccionBalanceadoId, SessionService sesion)
        {
            sesion.Db.INSUMOS_UTILIZADOSCollection.DeleteByPROD_BALAN_ID(produccionBalanceadoId);
        }

        public static void BorrarPorEgresoProductoId(decimal egresoProductoId, SessionService sesion)
        {
            sesion.Db.INSUMOS_UTILIZADOSCollection.DeleteByEGRESO_PRODUCTO_ID(egresoProductoId);
        }

        #endregion Borrar

        #region Accesors
        public const string Nombre_Tabla = "INSUMOS_UTILIZADOS";
        public class Modelo : INSUMOS_UTILIZADOSCollection_Base { public Modelo() : base(null) { } }
        #endregion Accesors
    }
}
