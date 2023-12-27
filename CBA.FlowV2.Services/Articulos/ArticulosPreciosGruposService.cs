using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosPreciosGruposService
    {
        #region GetArticulosPreciosGruposSDataTable
        /// <summary>
        /// Gets the articulos precios grupo data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetArticulosPreciosGruposDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return  sesion.Db.ARTICULOS_PRECIOS_GRUPOCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosPreciosGruposSDataTable

        #region GetMontoPorcentajePorArticuloListaDataTable
        public static DataTable GetMontoPorcentajePorArticuloListaDataTable(decimal listaPrecioId, decimal articuloId)
        {
            using (SessionService sesion = new SessionService())
            {
                string query = "SELECT apg."+ArticulosPreciosGruposService.Monto_NombreCol+", apg."+ArticulosPreciosGruposService.Porcentaje_NombreCol
                                + "\n FROM "+Nombre_Tabla+" apg, "+ArticulosGruposService.Nombre_Tabla+" ag, "+ArticulosService.Nombre_Tabla+" a "
                                + "\nwhere apg." + ArticulosPreciosGruposService.ArticulosGrupoID_NombreCol + " = ag." + ArticulosGruposService.Id_NombreCol + " "
                                + "\n and a." + ArticulosService.GrupoId_NombreCol + " = ag." + ArticulosGruposService.Id_NombreCol + " "
                                + "\n and a." + ArticulosService.Id_NombreCol + " = " + articuloId
                                + "\n and apg." + ArticulosPreciosGruposService.ListaPrecioId_NombreCol + " = " + listaPrecioId
                                + "\n and rownum = 1 "
                                + "\n order by apg." + ArticulosPreciosGruposService.Id_NombreCol + " desc ";

                return sesion.db.EjecutarQuery(query);
            }
        }
        #endregion GetMontoPorcentajePorArticuloListaDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction(); 

                    ARTICULOS_PRECIOS_GRUPORow row = new ARTICULOS_PRECIOS_GRUPORow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("articulos_precios_grupo_sqc");
                    }
                    else
                    {
                        row = sesion.Db.ARTICULOS_PRECIOS_GRUPOCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.ARTICULOS_GRUPO_ID = decimal.Parse(campos[ArticulosGrupoID_NombreCol].ToString());
                    row.LISTA_PRECIO_ID =decimal.Parse( campos[ListaPrecioId_NombreCol].ToString());
                    row.PORCENTAJE = decimal.Parse(campos[Porcentaje_NombreCol].ToString());
                    row.MONTO = decimal.Parse(campos[Monto_NombreCol].ToString());
                 
                    if (insertarNuevo) sesion.Db.ARTICULOS_PRECIOS_GRUPOCollection.Insert(row);
                    else sesion.Db.ARTICULOS_PRECIOS_GRUPOCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Eliminar
        /// <summary>
        /// Hace un delete del registro.
        /// </summary>
        /// <param name="id">Id del registro a eliminarse</param>
        public bool Eliminar(Decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ARTICULOS_PRECIOS_GRUPORow row = new ARTICULOS_PRECIOS_GRUPORow();
                    String valorAnterior = string.Empty;

                    row = sesion.Db.ARTICULOS_PRECIOS_GRUPOCollection.GetByPrimaryKey(id);

                    sesion.Db.ARTICULOS_PRECIOS_GRUPOCollection.Delete(row);
                   
                    sesion.Db.CommitTransaction();
                    return sesion.Db.ARTICULOS_PRECIOS_GRUPOCollection.Delete(row); ;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Accesors
        public static string Nombre_Tabla
        { get { return "articulos_precios_grupo"; } }

        public static string Id_NombreCol
        { get { return ARTICULOS_PRECIOS_GRUPOCollection.IDColumnName; } }

        public static string ListaPrecioId_NombreCol
        { get { return ARTICULOS_PRECIOS_GRUPOCollection.LISTA_PRECIO_IDColumnName; } }

        public static string ArticulosGrupoID_NombreCol
        { get { return ARTICULOS_PRECIOS_GRUPOCollection.ARTICULOS_GRUPO_IDColumnName ; } }

        public static string Porcentaje_NombreCol
        { get { return ARTICULOS_PRECIOS_GRUPOCollection.PORCENTAJEColumnName; } }

        public static string Monto_NombreCol
        { get { return ARTICULOS_PRECIOS_GRUPOCollection.MONTOColumnName; } }

       
        #endregion Accesors
    }
}
