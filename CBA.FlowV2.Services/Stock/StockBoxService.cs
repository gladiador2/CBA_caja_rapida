using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Stock
{
    public class StockBoxService
    {
        #region GetStockBoxDataTable
        public static DataTable GetStockBoxDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.STOCK_BOXCollection.GetAsDataTable(clausula, orden);
            }
        }

        public static DataTable GetStockBoxDataTable(decimal deposito_id, bool solo_activos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;
                string clausula = DepositoId_NombreCol + " = " + deposito_id;

                if (solo_activos)
                    clausula += " and " + Estado_NombreCol + " = '" + CBA.FlowV2.Services.Base.Definiciones.Estado.Activo + "' ";

                dt = sesion.Db.STOCK_BOXCollection.GetAsDataTable(clausula, Orden_NombreCol);

                return dt;
            }
        }

        #endregion GetStockBoxDataTable

        #region GetStockBoxDataTablePorUsuario
        public static DataTable GetStockBoxDataTablePorUsuario(decimal usuarioId, SessionService sesion)
        {        
            DataTable dtStockBox;
            string query = " select sb." + Id_NombreCol + ", sb." + DepositoId_NombreCol + ", sb." + Nombre_NombreCol + ", sb." + Estado_NombreCol + ", sb." + Orden_NombreCol + 
                           " from " + Nombre_Tabla + " sb, " +
                           StockDepositosService.Nombre_Tabla + " sd, " +
                           UsuariosSucursalesService.Nombre_Tabla + " us " +
                           " where sb." + DepositoId_NombreCol + " = sd." + StockDepositosService.Id_NombreCol + 
                           " and sd." + StockDepositosService.SucursalId_NombreCol + " = us." + UsuariosSucursalesService.SucursalId_NombreCol + 
                           " and us." + UsuariosSucursalesService.UsuarioId_NombreCol + " = " + usuarioId;

            dtStockBox = sesion.Db.EjecutarQuery(query);
            return dtStockBox;            
        }
        #endregion GetStockBoxDataTablePorUsuario

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal id = Guardar(campos, insertarNuevo, sesion);
                    sesion.CommitTransaction();
                    return id;
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            STOCK_BOXRow row = new STOCK_BOXRow();

            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("STOCK_BOX_SQC");                
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.Db.STOCK_BOXCollection.GetRow(StockBoxService.Id_NombreCol + " = " + campos[StockBoxService.Id_NombreCol]);
                valorAnterior = row.ToString();
            }

            row.DEPOSITO_ID = (decimal)campos[StockBoxService.DepositoId_NombreCol];
            row.NOMBRE = campos[StockBoxService.Nombre_NombreCol].ToString();
            row.ESTADO = campos[StockBoxService.Estado_NombreCol].ToString();
            row.ORDEN = (decimal)campos[StockBoxService.Orden_NombreCol];

            if (insertarNuevo)
                sesion.Db.STOCK_BOXCollection.Insert(row);
            else
                sesion.Db.STOCK_BOXCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
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
                    STOCK_BOXRow row = new STOCK_BOXRow();
                    row = sesion.Db.STOCK_BOXCollection.GetByPrimaryKey(id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;

                    sesion.Db.STOCK_BOXCollection.DeleteByPrimaryKey(id);
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
        public static string Nombre_Tabla
        { get { return "STOCK_BOX"; } }
        public static string Id_NombreCol
        { get { return STOCK_BOXCollection.IDColumnName; } }
        public static string DepositoId_NombreCol
        { get { return STOCK_BOXCollection.DEPOSITO_IDColumnName; } }
        public static string Nombre_NombreCol
        { get { return STOCK_BOXCollection.NOMBREColumnName; } }
        public static string Estado_NombreCol
        { get { return STOCK_BOXCollection.ESTADOColumnName; } }
        public static string Orden_NombreCol
        { get { return STOCK_BOXCollection.ORDENColumnName; } }
        #endregion Accesors
    }
}
