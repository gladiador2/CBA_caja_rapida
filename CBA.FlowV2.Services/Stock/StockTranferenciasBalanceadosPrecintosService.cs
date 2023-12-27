using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Base;
using System.Data;

namespace CBA.FlowV2.Services.Stock
{
    public class StockTranferenciasBalanceadosPrecintosService
    {
        #region GetStockTranferenciasBalanceadosPrecintosDataTable
        public static DataTable GetStockTranferenciasBalanceadosPrecintosDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.STOCK_TRANSF_BALANC_PRECINTOSCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetStockTranferenciasBalanceadosPrecintosDataTable

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
            STOCK_TRANSF_BALANC_PRECINTOSRow row = new STOCK_TRANSF_BALANC_PRECINTOSRow();

            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("STOCK_TRANSF_BALANC_PRECINTOS_SQC");
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.Db.STOCK_TRANSF_BALANC_PRECINTOSCollection.GetRow(StockTranferenciasBalanceadosPrecintosService.Modelo.IDColumnName + " = " + campos[StockTranferenciasBalanceadosPrecintosService.Modelo.IDColumnName]);
                valorAnterior = row.ToString();
            }

            row.TRANSFERENCIA_BALANC_ID = decimal.Parse(campos[StockTranferenciasBalanceadosPrecintosService.Modelo.TRANSFERENCIA_BALANC_IDColumnName].ToString());            
            row.CODIGO = campos[StockTranferenciasBalanceadosPrecintosService.Modelo.CODIGOColumnName].ToString();
            if (campos.Contains(StockTranferenciasBalanceadosPrecintosService.Modelo.DESCRIPCIONColumnName))
                row.DESCRIPCION = campos[StockTranferenciasBalanceadosPrecintosService.Modelo.DESCRIPCIONColumnName].ToString();

            if (insertarNuevo)
                sesion.Db.STOCK_TRANSF_BALANC_PRECINTOSCollection.Insert(row);
            else
                sesion.Db.STOCK_TRANSF_BALANC_PRECINTOSCollection.Update(row);

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
                    STOCK_TRANSF_BALANC_PRECINTOSRow row = new STOCK_TRANSF_BALANC_PRECINTOSRow();
                    row = sesion.Db.STOCK_TRANSF_BALANC_PRECINTOSCollection.GetByPrimaryKey(id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;

                    sesion.Db.STOCK_TRANSF_BALANC_PRECINTOSCollection.DeleteByPrimaryKey(id);
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
        public const string Nombre_Tabla = "STOCK_TRANSF_BALANC_PRECINTOS";
        public class Modelo : STOCK_TRANSF_BALANC_PRECINTOSCollection_Base { public Modelo() : base(null) { } }
        #endregion Accesors
    }
}
