using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System.Data;

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosPorTemporadaDetallesService
    {
        #region GetArticulosPorTemporadaDetallesInfoCompleta
        public DataTable GetArticulosPorTemporadaDetallesInfoCompleta(decimal ArticulosPorTemporadaId)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = ArticulosPorTemporadaId_NombreCol + " = " + ArticulosPorTemporadaId;
                return sesion.Db.ART_POR_TEMP_DET_INF_COMPCollection.GetAsDataTable(clausulas, string.Empty);
            }
        }

        public DataTable GetArticulosPorTemporadaDetallesInfoCompleta(decimal ArticulosPorTemporadaId, string where)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = ArticulosPorTemporadaId_NombreCol + " = " + ArticulosPorTemporadaId;
                clausulas += " and " + where;
                return sesion.Db.ART_POR_TEMP_DET_INF_COMPCollection.GetAsDataTable(clausulas, string.Empty);
            }
        }

        public static DataTable GetArticulosPorTemporadaDetallesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ART_POR_TEMP_DET_INF_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }

        #endregion GetArticulosPorTemporadaDetallesInfoCompleta

        #region GetArticulosPorTemporadaDetallesDataTable
        public DataTable GetArticulosPorTemporadaDetallesDataTable(decimal ArticulosPorTemporadaId)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = ArticulosPorTemporadaId_NombreCol + " = " + ArticulosPorTemporadaId;
                return sesion.Db.ARTICULOS_POR_TEMPORADA_DETCollection.GetAsDataTable(clausulas, string.Empty);
            }
        }

        public static DataTable GetArticulosPorTemporadaDetallesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService()) {
                return sesion.Db.ARTICULOS_POR_TEMPORADA_DETCollection.GetAsDataTable(clausulas, orden);
            }
        }

        #endregion GetArticulosPorTemporadaDetallesDataTable

        #region GetArticulosPorTemporadaDetallesDataTable Static
        public static DataTable GetArticulosPorTemporadaDetDataTableStatic(decimal ArticulosPorTemporadaId)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = ArticulosPorTemporadaId_NombreCol + " = " + ArticulosPorTemporadaId;
                return sesion.Db.ARTICULOS_POR_TEMPORADA_DETCollection.GetAsDataTable(clausulas, string.Empty);
            }
        }
        #endregion GetArticulosPorTemporadaDetallesDataTable Static

        #region GetTotalArticuloPorTemporada
        public decimal GetTotalArticuloPorTemporada(decimal ArticuloTemporada_id,decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = ArticulosPorTemporadaId_NombreCol + " = " + ArticuloTemporada_id + 
                                    " and " + ArticuloId_NombreCol+" = "+articulo_id;
                if (sesion.Db.ARTICULOS_POR_TEMPORADA_DETCollection.GetRow(clausulas) != null)
                    return sesion.Db.ARTICULOS_POR_TEMPORADA_DETCollection.GetRow(clausulas).CANTIDAD_OBJETIVO;
                else return 0;
            }
        }
        #endregion GetTotalArticuloPorTemporada

        #region Guardar

        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.BeginTransaction();
                ARTICULOS_POR_TEMPORADA_DETRow row = new ARTICULOS_POR_TEMPORADA_DETRow();

                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("ARTICULOS_POR_TEMP_DET_SQC");
                }
                else
                {
                    row = sesion.Db.ARTICULOS_POR_TEMPORADA_DETCollection.GetRow(Id_NombreCol + " = " + campos[Id_NombreCol]);
                }
                row.ARTICULOS_POR_TEMPORADA_ID = decimal.Parse(campos[ArticulosPorTemporadaId_NombreCol].ToString());
                row.ARTICULO_ID = decimal.Parse(campos[ArticuloId_NombreCol].ToString());
                row.CANTIDAD_OBJETIVO = decimal.Parse(campos[CantidadObjetivo_NombreCol].ToString());

                if (insertarNuevo)
                    sesion.Db.ARTICULOS_POR_TEMPORADA_DETCollection.Insert(row);
                else
                    sesion.Db.ARTICULOS_POR_TEMPORADA_DETCollection.Update(row);
                sesion.Db.CommitTransaction();
            }
        }
        #endregion Guardar

        #region Borrar
        public void Borrar(decimal idDetalle)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.BeginTransaction();
                ARTICULOS_POR_TEMPORADA_DETRow row = new ARTICULOS_POR_TEMPORADA_DETRow();

                row = sesion.Db.ARTICULOS_POR_TEMPORADA_DETCollection.GetRow(Id_NombreCol + " = " + idDetalle.ToString());
                sesion.Db.ARTICULOS_POR_TEMPORADA_DETCollection.Delete(row);
                sesion.Db.CommitTransaction();
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_POR_TEMPORADA_DET"; }
        }

        public static string Id_NombreCol
        {
            get { return ARTICULOS_POR_TEMPORADA_DETCollection.IDColumnName; }
        }
        public static string ArticulosPorTemporadaId_NombreCol
        {
            get { return ARTICULOS_POR_TEMPORADA_DETCollection.ARTICULOS_POR_TEMPORADA_IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return ARTICULOS_POR_TEMPORADA_DETCollection.ARTICULO_IDColumnName; }
        }
        public static string CantidadObjetivo_NombreCol
        {
            get { return ARTICULOS_POR_TEMPORADA_DETCollection.CANTIDAD_OBJETIVOColumnName; }
        }

        public static string VistaArticulo_NombreCol
        {
            get { return ART_POR_TEMP_DET_INF_COMPCollection.ARTICULOColumnName; }
        }
        public static string VistaNombreLista_NombreCol
        {
            get { return ART_POR_TEMP_DET_INF_COMPCollection.NOMBRE_LISTAColumnName; }
        }
        #endregion Accessors

    }
}
