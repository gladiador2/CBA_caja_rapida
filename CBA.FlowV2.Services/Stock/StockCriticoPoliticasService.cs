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
    public class StockCriticoPoliticasService
    {
        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal valor = Guardar(campos, insertarNuevo, sesion);
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

        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                STOCK_CRITICO_POLITICASRow politica = new STOCK_CRITICO_POLITICASRow();
                
                String valorAnterior = "";
                decimal dAux;      

                if (insertarNuevo)
                {
                    politica.ID = sesion.Db.GetSiguienteSecuencia("STOCK_CRITICO_POLITICAS_SQC");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }
                else
                {
                    if (!campos.Contains(StockCriticoPoliticasService.Id_NombreCol))
                        throw new Exception("Error de implementación: se debe incluir el ID.");
                    dAux = decimal.Parse(campos[StockCriticoPoliticasService.Id_NombreCol].ToString());
                    politica = sesion.Db.STOCK_CRITICO_POLITICASCollection.GetByPrimaryKey(dAux);
                    valorAnterior = politica.ToString();
                }

                if (campos.Contains(StockCriticoPoliticasService.ArticuloId_NombreCol))
                    politica.ARTICULO_ID = decimal.Parse(campos[StockCriticoPoliticasService.ArticuloId_NombreCol].ToString());
                if (campos.Contains(StockCriticoPoliticasService.FamiliaId_NombreCol))
                    politica.FAMILIA_ID = decimal.Parse(campos[StockCriticoPoliticasService.FamiliaId_NombreCol].ToString());
                if (campos.Contains(StockCriticoPoliticasService.GrupoId_NombreCol))
                    politica.GRUPO_ID = decimal.Parse(campos[StockCriticoPoliticasService.GrupoId_NombreCol].ToString());
                if (campos.Contains(StockCriticoPoliticasService.SubGrupoId_NombreCol))
                    politica.SUBGRUPO_ID = decimal.Parse(campos[StockCriticoPoliticasService.SubGrupoId_NombreCol].ToString());
                if (campos.Contains(StockCriticoPoliticasService.MarcaId_NombreCol))
                    politica.MARCA_ID = decimal.Parse(campos[StockCriticoPoliticasService.MarcaId_NombreCol].ToString());
                if (campos.Contains(StockCriticoPoliticasService.SucursalId_NombreCol))
                    politica.SUCURSAL_ID = decimal.Parse(campos[StockCriticoPoliticasService.SucursalId_NombreCol].ToString());
                if (campos.Contains(StockCriticoPoliticasService.DepositoId_NombreCol))
                    politica.DEPOSITO_ID = decimal.Parse(campos[StockCriticoPoliticasService.DepositoId_NombreCol].ToString());

                if (campos.Contains(StockCriticoPoliticasService.PoliticaCalculo_NombreCol))
                    politica.POLITICA_CALCULO = campos[StockCriticoPoliticasService.PoliticaCalculo_NombreCol].ToString();
                if (campos.Contains(StockCriticoPoliticasService.FrecuenciaCalculo_NombreCol))
                    politica.FRECUENCIA_CALCULO = campos[StockCriticoPoliticasService.FrecuenciaCalculo_NombreCol].ToString();

                if (insertarNuevo)
                {
                    politica.USUARIO_CREACION_ID = sesion.Usuario_Id;
                    politica.FECHA_CREACION = DateTime.Now;
                }
                else
                {
                    politica.FECHA_ULTIMA_EJECUCION = DateTime.Now;
                    politica.FECHA_PROXIMA_EJECUCION = (DateTime)campos[StockCriticoPoliticasService.FechaProximaEjecucion_NombreCol];
                }
                               
                if (campos.Contains(StockCriticoPoliticasService.Estado_NombreCol))
                    politica.ESTADO = campos[StockCriticoPoliticasService.Estado_NombreCol].ToString();

                if (insertarNuevo)
                    sesion.db.STOCK_CRITICO_POLITICASCollection.Insert(politica);
                else
                    sesion.db.STOCK_CRITICO_POLITICASCollection.Update(politica);
                                
                return politica.ID;
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

        #endregion Guardar

        #region Get
        public static DataTable GetStockCriticoPolitica(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetStockCriticoPolitica(clausulas, orden, sesion);
            }
        }

        public static DataTable GetStockCriticoPolitica(string clausulas, string orden, SessionService sesion)
        {
            string where = clausulas;  

            sesion.Db.IniciarBusquedaFlexible();
            DataTable stckCriticoPol = sesion.Db.STOCK_CRITICO_POLITICASCollection.GetAsDataTable(where, orden);
            sesion.Db.FinalizarBusquedaFlexible();

            return stckCriticoPol;
        }

        public static DataTable GetStockCriticoPoliticaInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetStockCriticoPoliticaInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetStockCriticoPoliticaInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            string where = clausulas;

            sesion.Db.IniciarBusquedaFlexible();
            DataTable stckCriticoPol = sesion.Db.STOCK_CRITICO_POL_INFO_COMPLCollection.GetAsDataTable(where, orden);
            sesion.Db.FinalizarBusquedaFlexible();

            return stckCriticoPol;
        }
        #endregion Get

        #region Cambiar Estado Politica
        public static void CambiarEstado(decimal politica_id, string estado)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    CambiarEstado(politica_id, estado, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw new Exception(exp.Message);
                }
            }
        }

        public static void CambiarEstado(decimal politica_id, string estado, SessionService sesion)
        {
            try
            {
                STOCK_CRITICO_POLITICASRow row = sesion.Db.STOCK_CRITICO_POLITICASCollection.GetByPrimaryKey(politica_id);
                row.ESTADO = estado;
                sesion.Db.STOCK_CRITICO_POLITICASCollection.Update(row);
            }
            catch (Exception exp)
            {
                throw new Exception (exp.Message);
            }
        }
        #endregion Inactivar Politica

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "STOCK_CRITICO_POLITICAS"; }
        }
        public static string Nombre_Vista
        {
            get { return "STOCK_CRITICO_POL_INFO_COMPL"; }
        }
        public static string Id_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.ARTICULO_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.SUCURSAL_IDColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.DEPOSITO_IDColumnName; }
        }
        public static string FamiliaId_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.FAMILIA_IDColumnName; }
        }
        public static string GrupoId_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.GRUPO_IDColumnName; }
        }
        public static string SubGrupoId_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.SUBGRUPO_IDColumnName; }
        }
        public static string MarcaId_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.MARCA_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.ESTADOColumnName; }
        }
        public static string FrecuenciaCalculo_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.FRECUENCIA_CALCULOColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaProximaEjecucion_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.FECHA_PROXIMA_EJECUCIONColumnName; }
        }
        public static string FechaUltimaEjecucion_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.FECHA_ULTIMA_EJECUCIONColumnName; }
        }
        public static string UsuarioCreacion_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.USUARIO_CREACION_IDColumnName; }
        }        
        public static string PoliticaCalculo_NombreCol
        {
            get { return STOCK_CRITICO_POLITICASCollection.POLITICA_CALCULOColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return STOCK_CRITICO_POL_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaDepositoNombre_NombreCol
        {
            get { return STOCK_CRITICO_POL_INFO_COMPLCollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaArticuloDescripcionInterna_NombreCol
        {
            get { return STOCK_CRITICO_POL_INFO_COMPLCollection.ARTICULO_DESCRIPCION_INTERNAColumnName; }
        }
        public static string VistaArticuloCodigoEmpresa_NombreCol
        {
            get { return STOCK_CRITICO_POL_INFO_COMPLCollection.ARTICULO_CODIGO_EMPRESAColumnName; }
        }
        public static string VistaFamiliaDescripcion_NombreCol
        {
            get { return STOCK_CRITICO_POL_INFO_COMPLCollection.FAMILIA_DESCRIPCIONColumnName; }
        }
        public static string VistaGrupoDescripcion_NombreCol
        {
            get { return STOCK_CRITICO_POL_INFO_COMPLCollection.GRUPO_DESCRIPCIONColumnName; }
        }
        public static string VistaSubGrupoDescripcion_NombreCol
        {
            get { return STOCK_CRITICO_POL_INFO_COMPLCollection.SUBGRUPO_DESCRIPCIONColumnName; }
        }
        public static string VistaMarcaNombre_NombreCol
        {
            get { return STOCK_CRITICO_POL_INFO_COMPLCollection.MARCA_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
