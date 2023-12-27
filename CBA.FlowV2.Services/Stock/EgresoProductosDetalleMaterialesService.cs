using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Articulos;

namespace CBA.FlowV2.Services.Stock
{
    public class EgresoProductosDetalleMaterialesService
    {
        #region GetEgresoProductosDetalleMaterialesDataTable        
        public static DataTable GetEgresoProductosDetalleMaterialesDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.EjecutarQuery("select epdm.*, a." + ArticulosService.EsTrazable_NombreCol + ", al." + ArticulosLotesService.LOTE_NombreCol + 
                        " from " + EgresoProductosDetalleMaterialesService.Nombre_Tabla + " epdm, " +
                        ArticulosLotesService.Nombre_Tabla + " al, " +
                        ArticulosService.Nombre_Tabla + " a where epdm." + EgresoProductosDetalleMaterialesService.Modelo.LOTE_IDColumnName + " = al." + ArticulosLotesService.Id_NombreCol + 
                        " and epdm." + EgresoProductosDetalleMaterialesService.Modelo.ARTICULO_IDColumnName + " = a." + ArticulosService.Id_NombreCol + clausula);              
            }
        }
        #endregion GetEgresoProductosDetallesMaterialeDataTable

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
            if (!campos.Contains(EgresoProductosDetalleMaterialesService.Modelo.ARTICULO_IDColumnName))
                throw new Exception("Debe indicar el artículo.");
            if (!campos.Contains(EgresoProductosDetalleMaterialesService.Modelo.LOTE_IDColumnName))
                throw new Exception("Debe indicar el lote.");

            EGRESO_PROD_DET_MATERIALESRow row = new EGRESO_PROD_DET_MATERIALESRow();
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("EGRESO_PROD_DET_MATERIALES_SQC");
                row.EGRESO_PRODUCTO_DET_ID = (decimal)campos[EgresoProductosDetalleMaterialesService.Modelo.EGRESO_PRODUCTO_DET_IDColumnName];
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.Db.EGRESO_PROD_DET_MATERIALESCollection.GetRow(EgresoProductosDetalleMaterialesService.Modelo.IDColumnName + " = " + campos[EgresoProductosDetalleMaterialesService.Modelo.IDColumnName]);
                valorAnterior = row.ToString();
            }

            row.ARTICULO_ID = (decimal)campos[EgresoProductosDetalleMaterialesService.Modelo.ARTICULO_IDColumnName];
            row.LOTE_ID = (decimal)campos[EgresoProductosDetalleMaterialesService.Modelo.LOTE_IDColumnName];         
            row.CANTIDAD = (decimal)campos[EgresoProductosDetalleMaterialesService.Modelo.CANTIDADColumnName];
            row.UNIDAD_MEDIDA_ID = campos[EgresoProductosDetalleMaterialesService.Modelo.UNIDAD_MEDIDA_IDColumnName].ToString();
            row.OBSERVACION = campos[EgresoProductosDetalleMaterialesService.Modelo.OBSERVACIONColumnName].ToString();
            row.FACTOR_CONVERSION = (new ArticulosConversionesService()).GetFactorConversion(row.ARTICULO_ID, row.UNIDAD_MEDIDA_ID, null);
            
            if (insertarNuevo)
                sesion.Db.EGRESO_PROD_DET_MATERIALESCollection.Insert(row);
            else
                sesion.Db.EGRESO_PROD_DET_MATERIALESCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal material_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    EGRESO_PROD_DET_MATERIALESRow row = new EGRESO_PROD_DET_MATERIALESRow();
                    row = sesion.Db.EGRESO_PROD_DET_MATERIALESCollection.GetByPrimaryKey(material_id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;

                    sesion.Db.EGRESO_PROD_DET_MATERIALESCollection.DeleteByPrimaryKey(material_id);
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
        public const string Nombre_Tabla = "EGRESO_PROD_DET_MATERIALES";
        public class Modelo : EGRESO_PROD_DET_MATERIALESCollection_Base { public Modelo() : base(null) { } }
        #endregion Accesors

    }
}
