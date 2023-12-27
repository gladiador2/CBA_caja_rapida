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
using CBA.FlowV2.Services.Stock;

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosCombosService
    {
        public ArticulosCombosService()
        {
        }


        #region Guardar

        public void  Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {

                try
                {
                    ARTICULOS_COMBOSRow row = new ARTICULOS_COMBOSRow();
                    string valorAnterior = string.Empty;
                    sesion.Db.BeginTransaction();
                    row.ID = sesion.Db.GetSiguienteSecuencia("articulos_combos_sqc");
                    row.ARTICULO_COMBO_ID = decimal.Parse(campos[ArticulosCombosService.ArticuloComboId_NombreCol].ToString());
                    row.ARTICULO_DETALLE_ID= decimal.Parse(campos[ArticulosCombosService.ArticuloDetalleId_NombreCol].ToString());
                    row.CANTIDAD_DESTINO = decimal.Parse(campos[ArticulosCombosService.CantidadDestino_NombreCol].ToString());
                    row.CANTIDAD_ORIGEN = decimal.Parse(campos[ArticulosCombosService.CantidadOrigen_NombreCol].ToString());
                    row.UNIDAD_DESTINO_ID = campos[ArticulosCombosService.UnidadDestinoId_NombreCol].ToString();
                    row.UNIDAD_ORIGEN_ID = campos[ArticulosCombosService.UnidadOrigenId_NombreCol].ToString();
                    row.FACTOR_CONVERSION = decimal.Parse(campos[ArticulosCombosService.FactorConversion_NombreCol].ToString());
                    sesion.Db.ARTICULOS_COMBOSCollection.Insert(row);
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
        public void Borrar(decimal idCombo)
        {
            using (SessionService sesion = new SessionService())
            {

                try
                {
                    ARTICULOS_COMBOSRow row = new ARTICULOS_COMBOSRow();
                    row= sesion.Db.ARTICULOS_COMBOSCollection.GetByPrimaryKey(idCombo);
                    string valorAnterior = row.ToString()  ;
                    sesion.Db.BeginTransaction();
                    sesion.Db.ARTICULOS_COMBOSCollection.DeleteByPrimaryKey(row.ID);
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

        #region GetArticulosPorComboInfoCompleta
       
        public static DataTable GetArticulosPorComboInfoCompleta(decimal articulo_combo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                
                try
                {
                   return GetArticulosPorComboInfoCompleta(articulo_combo_id, sesion);
                }
                catch (Exception exp)
                {
                    
                    throw exp;
                }
            }
        }
        public static DataTable GetArticulosPorComboInfoCompleta(decimal articulo_combo_id,SessionService sesion)
        {
            string where = ArticulosCombosService.ArticuloComboId_NombreCol + "=" + articulo_combo_id;
            try
            {
                return sesion.Db.ARTICULOS_COMBOS_INFO_COMPLETACollection.GetAsDataTable(where, string.Empty);
            }
            catch (Exception exp)
            {
                
                throw exp;
            }            
        }
        #endregion GetArticulosPorComboInfoCompleta      

        #region GetArticulosCombosDataTable
        public static DataTable GetArticulosCombosDataTable(string where, SessionService sesion)
        {
            try
            {
                return sesion.Db.ARTICULOS_FORMULASCollection.GetAsDataTable(where, string.Empty);
            }
            catch (Exception exp)
            {

                throw exp;
            }         
        }
        #endregion GetArticulosCombosTodos

        #region Tipo de combo
        public class Tipo
        {
            
            public  const string Simple = "Simple";
            public  const string Abierto = "Abierto";
            public  const string Representativo = "Representativo";
        }
        public static DataTable GetTipoCombo()
        {
            DataTable dtTipos = new DataTable();
            dtTipos.Columns.Add(TipoCombo_NombreCol);
            dtTipos.Rows.Add(ArticulosCombosService.Tipo.Simple);
            dtTipos.Rows.Add(ArticulosCombosService.Tipo.Abierto);
            dtTipos.Rows.Add(ArticulosCombosService.Tipo.Representativo);

            return dtTipos;
        }
        #endregion Tipo de combo

        #region Accessors
        public static string TipoCombo_NombreCol
        {
            get { return "Tipo"; }
        }

        public static string Nombre_Tabla
        {
            get { return"ARTICULOS_COMBOS"; }
        }
        public static string ArticuloComboId_NombreCol
        {
            get { return ARTICULOS_COMBOSCollection.ARTICULO_COMBO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ARTICULOS_COMBOSCollection.IDColumnName; }
        }
        public static string ArticuloDetalleId_NombreCol
        {
            get { return ARTICULOS_COMBOSCollection.ARTICULO_DETALLE_IDColumnName; }
        }
        public static string CantidadDestino_NombreCol
        {
            get { return ARTICULOS_COMBOSCollection.CANTIDAD_DESTINOColumnName; }
        }
        
        public static string CantidadOrigen_NombreCol
        {
            get { return ARTICULOS_COMBOSCollection.CANTIDAD_ORIGENColumnName; }
        }
        public static string UnidadDestinoId_NombreCol
        {
            get { return ARTICULOS_COMBOSCollection.UNIDAD_DESTINO_IDColumnName; }
        }
        public static string UnidadOrigenId_NombreCol
        {
            get { return ARTICULOS_COMBOSCollection.UNIDAD_ORIGEN_IDColumnName; }
        }
        public static string FactorConversion_NombreCol
        {
            get { return ARTICULOS_COMBOSCollection.FACTOR_CONVERSIONColumnName; }
        }

        public static string VistaArticuloDetalleDescripcion_NombreCol
        {
            get { return ARTICULOS_COMBOS_INFO_COMPLETACollection.ARTICULO_DETALLE_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloComboDescripcion_NombreCol
        {
            get { return ARTICULOS_COMBOS_INFO_COMPLETACollection.ARTICULO_COMBO_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloDetalleCodigo_NombreColl
        {
            get { return ARTICULOS_COMBOS_INFO_COMPLETACollection.ARTICULO_DETALLE_CODIGOColumnName; }
        }
        #endregion Accessors
    }
}
