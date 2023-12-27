using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Facturacion;
using System.Data;

namespace CBA.FlowV2.Services.Facturacion
{
    public class RemisionesDetalleFacturaClienteRelacionesService
    {
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
                    sesion.db.BeginTransaction();
                    Guardar(campos, insertarNuevo, sesion);
                    sesion.db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            REMISIONES_FC_RELACIONRow row = new REMISIONES_FC_RELACIONRow();
            string valorAnterior = string.Empty;

            if (!campos.Contains(RemisionesDetalleFacturaClienteRelacionesService.RemisionDetalleId_NombreCol))
                throw new Exception("Falta indicar el detalle de la Remisión");
            if (!campos.Contains(RemisionesDetalleFacturaClienteRelacionesService.Cantidad_NombreCol))
                throw new Exception("Falta indicar la cantidad.");

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("REMISIONES_FC_RELACION_SQC");
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                if (!campos.Contains(RemisionesDetalleFacturaClienteRelacionesService.Id_NombreCol))
                    throw new Exception("Falta indicar el detalle de la Remisión");
                row = sesion.db.REMISIONES_FC_RELACIONCollection.GetByPrimaryKey(decimal.Parse(campos[RemisionesDetalleFacturaClienteRelacionesService.Id_NombreCol].ToString()));
                valorAnterior = row.ToString();
            }

            row.REMISION_DETALLE_ID = decimal.Parse(campos[RemisionesDetalleFacturaClienteRelacionesService.RemisionDetalleId_NombreCol].ToString());
            row.CANTIDAD = decimal.Parse(campos[RemisionesDetalleFacturaClienteRelacionesService.Cantidad_NombreCol].ToString());

            if (campos.Contains(RemisionesDetalleFacturaClienteRelacionesService.FacturaClienteDetalleId_NombreCol))
            {
                row.FACTURA_CLIENTE_DETALLE_ID = decimal.Parse(campos[RemisionesDetalleFacturaClienteRelacionesService.FacturaClienteDetalleId_NombreCol].ToString());
                
                //Si el detalle proviene de una remisión entonces la factura no debe afectar stock
                var facturaDetalle = new FacturasClienteDetalleService(row.FACTURA_CLIENTE_DETALLE_ID, sesion);
                if (facturaDetalle.FacturaCliente.AfectaStock == Definiciones.SiNo.Si)
                    throw new Exception("La factura no debe afectar stock si desea facturar detalles de remisiones.");
            }
            else
            {
                row.IsFACTURA_CLIENTE_DETALLE_IDNull = true;
            }

            if (insertarNuevo) sesion.Db.REMISIONES_FC_RELACIONCollection.Insert(row);
            else sesion.Db.REMISIONES_FC_RELACIONCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion Guardar 
     
        #region Borrar
        public static void BorrarPorFCCliente(decimal fc_cliente_detalle_id, SessionService sesion)
        {
            REMISIONES_FC_RELACIONRow[] row = sesion.Db.REMISIONES_FC_RELACIONCollection.GetByFACTURA_CLIENTE_DETALLE_ID(fc_cliente_detalle_id);

            string valorAnterior = row.ToString();
            string valorNuevo = Definiciones.Log.RegistroBorrado;
            for (int i = 0; i < row.Length; i++)
            {
                sesion.Db.REMISIONES_FC_RELACIONCollection.DeleteByPrimaryKey(row[i].ID);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row[i].ID, valorAnterior, valorNuevo, sesion);
            }
        }
        #endregion Borrar

        #region ModificarDetalllePorIdFactura
        public static void ModificarDetalllePorIdFacturaCliente(decimal fc_cliente_detalle_id, decimal cantidad, bool anular)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    ModificarDetallePorIdFacturaCliente(fc_cliente_detalle_id, cantidad, sesion, anular);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        public static void ModificarDetallePorIdFacturaCliente(decimal fc_cliente_detalle_id, decimal cantidad, SessionService sesion, bool anular)
        {
            REMISIONES_FC_RELACIONRow[] row = sesion.Db.REMISIONES_FC_RELACIONCollection.GetByFACTURA_CLIENTE_DETALLE_ID(fc_cliente_detalle_id);

            string valorAnterior = string.Empty;

            for (int i = 0; i < row.Length; i++)
            {
                valorAnterior = row[i].ToString();
                if (!anular)
                    row[i].CANTIDAD = cantidad;
                else
                    if (row[i].CANTIDAD - cantidad == 0)
                    {
                        BorrarPorFCCliente(fc_cliente_detalle_id, sesion);
                    }
                    else
                        row[i].CANTIDAD = row[i].CANTIDAD - cantidad;

                sesion.Db.REMISIONES_FC_RELACIONCollection.Update(row[i]);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row[i].ID, valorAnterior, row[i].ToString(), sesion);
            }
        }
        #endregion ModificarDetalllePorIdFactura

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "REMISIONES_FC_RELACION"; }
        }

        public static string Id_NombreCol
        {
            get { return REMISIONES_FC_RELACIONCollection.IDColumnName; }
        }
        public static string FacturaClienteDetalleId_NombreCol
        {
            get { return REMISIONES_FC_RELACIONCollection.FACTURA_CLIENTE_DETALLE_IDColumnName; }
        }
        public static string RemisionDetalleId_NombreCol
        {
            get { return REMISIONES_FC_RELACIONCollection.REMISION_DETALLE_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return REMISIONES_FC_RELACIONCollection.CANTIDADColumnName; }
        }

        #endregion Accesors

    }
}
