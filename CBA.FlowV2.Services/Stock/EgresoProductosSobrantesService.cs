using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Stock
{
    public class EgresoProductosSobrantesService
    {
        #region GetEgresoProductosSobrantesDataTable       
        public static DataTable GetEgresoProductosSobrantesDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.EGRESO_PRODUCTOS_SOBRANTESCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetEgresoProductosSobrantesDataTable

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
            if (!campos.Contains(EgresoProductosSobrantesService.Modelo.ARTICULO_IDColumnName))
                throw new Exception("Debe indicar el artículo.");
            if (!campos.Contains(EgresoProductosSobrantesService.Modelo.LOTE_IDColumnName))
                throw new Exception("Debe indicar el lote.");

            EGRESO_PRODUCTOS_SOBRANTESRow row = new EGRESO_PRODUCTOS_SOBRANTESRow();
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("EGRESO_PRODUCTOS_SOBRANTES_SQC");
                row.EGRESO_PRODUCTO_ID = (decimal)campos[EgresoProductosSobrantesService.Modelo.EGRESO_PRODUCTO_IDColumnName];
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.Db.EGRESO_PRODUCTOS_SOBRANTESCollection.GetRow(EgresoProductosSobrantesService.Modelo.IDColumnName + " = " + campos[EgresoProductosSobrantesService.Modelo.IDColumnName]);
                valorAnterior = row.ToString();
            }

            row.ARTICULO_ID = (decimal)campos[EgresoProductosSobrantesService.Modelo.ARTICULO_IDColumnName];
            row.LOTE_ID = (decimal)campos[EgresoProductosSobrantesService.Modelo.LOTE_IDColumnName];
            row.CANTIDAD = (decimal)campos[EgresoProductosSobrantesService.Modelo.CANTIDADColumnName];
            row.UNIDAD_MEDIDA_ID = campos[EgresoProductosSobrantesService.Modelo.UNIDAD_MEDIDA_IDColumnName].ToString();
            row.OBSERVACION = campos[EgresoProductosSobrantesService.Modelo.OBSERVACIONColumnName].ToString();
            
            if (insertarNuevo)
                sesion.Db.EGRESO_PRODUCTOS_SOBRANTESCollection.Insert(row);
            else
                sesion.Db.EGRESO_PRODUCTOS_SOBRANTESCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal sobrante_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    EGRESO_PRODUCTOS_SOBRANTESRow row = new EGRESO_PRODUCTOS_SOBRANTESRow();
                    row = sesion.Db.EGRESO_PRODUCTOS_SOBRANTESCollection.GetByPrimaryKey(sobrante_id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;

                    sesion.Db.EGRESO_PRODUCTOS_SOBRANTESCollection.DeleteByPrimaryKey(sobrante_id);
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
        public const string Nombre_Tabla = "EGRESO_PRODUCTOS_SOBRANTES";
        public class Modelo : EGRESO_PRODUCTOS_SOBRANTESCollection_Base { public Modelo() : base(null) { } }
        #endregion Accesors
    }
}
