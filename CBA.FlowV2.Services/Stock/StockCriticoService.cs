using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Stock
{
    public class StockCriticoService
    {
        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, System.Collections.Hashtable camposPoliticas)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal valor = Guardar(campos, insertarNuevo, camposPoliticas, sesion);
                    sesion.CommitTransaction();
                    return valor;
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw (exp);
                }
            }
        }

        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, System.Collections.Hashtable camposPoliticas, SessionService sesion)
        {
            try
            {
                STOCK_CRITICORow stockCritico = new STOCK_CRITICORow();

                String valorAnterior = "";
                decimal dAux;

                if (insertarNuevo)
                {
                    stockCritico.ID = sesion.Db.GetSiguienteSecuencia("STOCK_CRITICO_SQC");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }
                else
                {
                    if (!campos.Contains(StockCriticoService.Id_NombreCol))
                        throw new Exception("Error de implementación: se debe incluir el ID.");
                    dAux = decimal.Parse(campos[StockCriticoService.Id_NombreCol].ToString());
                    stockCritico = sesion.Db.STOCK_CRITICOCollection.GetByPrimaryKey(dAux);
                    valorAnterior = stockCritico.ToString();
                }

                if (campos.Contains(StockCriticoService.ArticuloId_NombreCol))
                    stockCritico.ARTICULO_ID = decimal.Parse(campos[StockCriticoService.ArticuloId_NombreCol].ToString());
                if (campos.Contains(StockCriticoService.FamiliaId_NombreCol))
                    stockCritico.FAMILIA_ID = decimal.Parse(campos[StockCriticoService.FamiliaId_NombreCol].ToString());
                if (campos.Contains(StockCriticoService.GrupoId_NombreCol))
                    stockCritico.GRUPO_ID = decimal.Parse(campos[StockCriticoService.GrupoId_NombreCol].ToString());
                if (campos.Contains(StockCriticoService.SubGrupoId_NombreCol))
                    stockCritico.SUBGRUPO_ID = decimal.Parse(campos[StockCriticoService.SubGrupoId_NombreCol].ToString());
                if (campos.Contains(StockCriticoService.MarcaId_NombreCol))
                    stockCritico.MARCA_ID = decimal.Parse(campos[StockCriticoService.MarcaId_NombreCol].ToString());
                if (campos.Contains(StockCriticoService.SucursalId_NombreCol))
                    stockCritico.SUCURSAL_ID = decimal.Parse(campos[StockCriticoService.SucursalId_NombreCol].ToString());
                if (campos.Contains(StockCriticoService.DepositoId_NombreCol))
                    stockCritico.DEPOSITO_ID = decimal.Parse(campos[StockCriticoService.DepositoId_NombreCol].ToString());
                if (campos.Contains(StockCriticoService.Cantidad_NombreCol))
                    stockCritico.CANTIDAD = decimal.Parse(campos[StockCriticoService.Cantidad_NombreCol].ToString());
                if (campos.Contains(StockCriticoService.StockCriticoPoliticaId_NombreCol))
                    stockCritico.STOCK_CRITICO_POLITICA_ID = decimal.Parse(campos[StockCriticoService.StockCriticoPoliticaId_NombreCol].ToString());
          
                stockCritico.FECHA_CAMBIO = DateTime.Now;
                                                
                if (insertarNuevo)
                    sesion.db.STOCK_CRITICOCollection.Insert(stockCritico);
                else
                    sesion.db.STOCK_CRITICOCollection.Update(stockCritico);

                if (camposPoliticas != null)
                    StockCriticoPoliticasService.Guardar(camposPoliticas, false);

                return stockCritico.ID;
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

        #endregion Guardar
        
        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "STOCK_CRITICO"; }
        }
        public static string Nombre_Vista
        {
            get { return "STOCK_CRITICO_INFO_COMPL"; }
        }
        public static string Id_NombreCol
        {
            get { return STOCK_CRITICOCollection.IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return STOCK_CRITICOCollection.ARTICULO_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return STOCK_CRITICOCollection.SUCURSAL_IDColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return STOCK_CRITICOCollection.DEPOSITO_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return STOCK_CRITICOCollection.CANTIDADColumnName; }
        }
        public static string FechaCambio_NombreCol
        {
            get { return STOCK_CRITICOCollection.FECHA_CAMBIOColumnName; }
        }
        public static string FamiliaId_NombreCol
        {
            get { return STOCK_CRITICOCollection.FAMILIA_IDColumnName; }
        }
        public static string GrupoId_NombreCol
        {
            get { return STOCK_CRITICOCollection.GRUPO_IDColumnName; }
        }
        public static string SubGrupoId_NombreCol
        {
            get { return STOCK_CRITICOCollection.SUBGRUPO_IDColumnName; }
        }
        public static string MarcaId_NombreCol
        {
            get { return STOCK_CRITICOCollection.MARCA_IDColumnName; }
        }
        public static string StockCriticoPoliticaId_NombreCol
        {
            get { return STOCK_CRITICOCollection.STOCK_CRITICO_POLITICA_IDColumnName; }
        }
        public static string VistaArticuloCodigoEmpresa_NombreCol
        {
            get { return STOCK_CRITICO_INFO_COMPLCollection.ARTICULO_CODIGO_EMPRESAColumnName; }
        }
        public static string VistaArticuloDescripcionImpresion_NombreCol
        {
            get { return STOCK_CRITICO_INFO_COMPLCollection.ARTICULO_DESCRIPCION_IMPRESIONColumnName; }
        }
        public static string VistaDepositoNombre_NombreCol
        {
            get { return STOCK_CRITICO_INFO_COMPLCollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaFamiliaDescripcion_NombreCol
        {
            get { return STOCK_CRITICO_INFO_COMPLCollection.FAMILIA_DESCRIPCIONColumnName; }
        }
        public static string VistaGrupoDescripcion_NombreCol
        {
            get { return STOCK_CRITICO_INFO_COMPLCollection.GRUPO_DESCRIPCIONColumnName; }
        }
        public static string VistaMarcaNombre_NombreCol
        {
            get { return STOCK_CRITICO_INFO_COMPLCollection.MARCA_NOMBREColumnName; }
        } 
        public static string VistaSubGrupoDescripcion_NombreCol
        {
            get { return STOCK_CRITICO_INFO_COMPLCollection.SUBGRUPO_DESCRIPCIONColumnName; }
        } 
        public static string VistaSucursalNombre_NombreCol
        {
            get { return STOCK_CRITICO_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }     
        #endregion Accessors
    }
}
