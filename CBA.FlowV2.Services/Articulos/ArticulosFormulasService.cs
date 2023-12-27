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
    public class ArticulosFormulasService
    {
        public ArticulosFormulasService()
        {
        }


        #region Guardar

        public void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {

                try
                {
                    ARTICULOS_FORMULASRow row = new ARTICULOS_FORMULASRow();
                    string valorAnterior = string.Empty;
                    sesion.Db.BeginTransaction();
                    row.ID = sesion.Db.GetSiguienteSecuencia("articulos_combos_sqc");
                    row.ARTICULO_FORMULA_ID = decimal.Parse(campos[ArticulosFormulasService.ArticuloFormulaId_NombreCol].ToString());
                    row.ARTICULO_DETALLE_ID = decimal.Parse(campos[ArticulosFormulasService.ArticuloDetalleId_NombreCol].ToString());
                    row.CANTIDAD_DESTINO = decimal.Parse(campos[ArticulosFormulasService.CantidadDestino_NombreCol].ToString());
                    row.CANTIDAD_ORIGEN = decimal.Parse(campos[ArticulosFormulasService.CantidadOrigen_NombreCol].ToString());
                    row.UNIDAD_DESTINO_ID = campos[ArticulosFormulasService.UnidadDestinoId_NombreCol].ToString();
                    row.UNIDAD_ORIGEN_ID = campos[ArticulosFormulasService.UnidadOrigenId_NombreCol].ToString();
                    row.FACTOR_CONVERSION = decimal.Parse(campos[ArticulosFormulasService.FactorConversion_NombreCol].ToString());
                    sesion.Db.ARTICULOS_FORMULASCollection.Insert(row);
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
        public void Borrar(decimal idFormula)
        {
            using (SessionService sesion = new SessionService())
            {

                try
                {
                    ARTICULOS_FORMULASRow row = new ARTICULOS_FORMULASRow();
                    row = sesion.Db.ARTICULOS_FORMULASCollection.GetByPrimaryKey(idFormula);
                    string valorAnterior = row.ToString();
                    sesion.Db.BeginTransaction();
                    sesion.Db.ARTICULOS_FORMULASCollection.DeleteByPrimaryKey(row.ID);
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

        #region GetArticulosPorFormulaInfoCompleta

        public static DataTable GetArticulosPorFormulaInfoCompleta(decimal articulo_combo_id)
        {
            using (SessionService sesion = new SessionService())
            {

                try
                {
                    return GetArticulosPorFormulaInfoCompleta(articulo_combo_id, sesion);
                }
                catch (Exception exp)
                {

                    throw exp;
                }
            }
        }
        public static DataTable GetArticulosPorFormulaInfoCompleta(decimal articulo_combo_id, SessionService sesion)
        {
            string where = ArticulosFormulasService.ArticuloFormulaId_NombreCol + "=" + articulo_combo_id;
            try
            {
                return sesion.Db.ARTICULOS_FORMULAS_INFO_COMPLCollection.GetAsDataTable(where, string.Empty);
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }
        #endregion GetArticulosPorFormulaInfoCompleta

        #region GetArticulosFormulasDataTable
        public static DataTable GetArticulosFormulasDataTable(string where, SessionService sesion)
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
        #endregion GetArticulosFormulasTodos

        #region Tipo de combo
        public class Tipo
        {

            public const string MICROFORMULA = "MICROFORMULA";
            public const string MACROFORMULA = "MACROFORMULA";
            
        }
        public static DataTable GetTipoFormula()
        {
            DataTable dtTipos = new DataTable();
            dtTipos.Columns.Add(TipoFormula_NombreCol);
            dtTipos.Rows.Add(ArticulosFormulasService.Tipo.MICROFORMULA);
            dtTipos.Rows.Add(ArticulosFormulasService.Tipo.MACROFORMULA);
            

            return dtTipos;
        }
        #endregion Tipo de combo

        #region Accessors
        public static string TipoFormula_NombreCol
        {
            get { return "Tipo"; }
        }

        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_FORMULAS"; }
        }
        public static string ArticuloFormulaId_NombreCol
        {
            get { return ARTICULOS_FORMULASCollection.ARTICULO_FORMULA_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ARTICULOS_FORMULASCollection.IDColumnName; }
        }
        public static string ArticuloDetalleId_NombreCol
        {
            get { return ARTICULOS_FORMULASCollection.ARTICULO_DETALLE_IDColumnName; }
        }
        public static string CantidadDestino_NombreCol
        {
            get { return ARTICULOS_FORMULASCollection.CANTIDAD_DESTINOColumnName; }
        }

        public static string CantidadOrigen_NombreCol
        {
            get { return ARTICULOS_FORMULASCollection.CANTIDAD_ORIGENColumnName; }
        }
        public static string UnidadDestinoId_NombreCol
        {
            get { return ARTICULOS_FORMULASCollection.UNIDAD_DESTINO_IDColumnName; }
        }
        public static string UnidadOrigenId_NombreCol
        {
            get { return ARTICULOS_FORMULASCollection.UNIDAD_ORIGEN_IDColumnName; }
        }
        public static string FactorConversion_NombreCol
        {
            get { return ARTICULOS_FORMULASCollection.FACTOR_CONVERSIONColumnName; }
        }

        public static string VistaArticuloDetalleDescripcion_NombreCol
        {
            get { return ARTICULOS_FORMULAS_INFO_COMPLCollection.ARTICULO_DETALLE_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloFormulaDescripcion_NombreCol
        {
            get { return ARTICULOS_FORMULAS_INFO_COMPLCollection.ARTICULO_COMBO_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloDetalleCodigo_NombreColl
        {
            get { return ARTICULOS_FORMULAS_INFO_COMPLCollection.ARTICULO_DETALLE_CODIGOColumnName; }
        }
        #endregion Accessors
    }
}
