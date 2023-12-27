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
    public class ArticulosPreciosProduccionService
    {
        #region GetArticulosPreciosProduccionDataTable
        /// <summary>
        /// Gets the articulos margen data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosPreciosProduccionDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return  sesion.Db.ARTICULOS_PRECIOS_PRODUCCIONCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosPreciosProduccionDataTable

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

                    ARTICULOS_PRECIOS_PRODUCCIONRow row = new ARTICULOS_PRECIOS_PRODUCCIONRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("articulos_precio_producc_sqc");
                        row.ESTADO = Definiciones.Estado.Activo;
                        row.FECHA_CREACION = DateTime.Now;
                    }
                    else
                    {
                        row = sesion.Db.ARTICULOS_PRECIOS_PRODUCCIONCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.ARTICULOS_ID = decimal.Parse(campos[ArticulosID_NombreCol].ToString());
                    if(campos.Contains(SucursalesId_NombreCol))
                        if (campos.Contains(SucursalesId_NombreCol))
                            row.SUCURSALES_ID = decimal.Parse(campos[SucursalesId_NombreCol].ToString());
                    row.LISTA_PRECIOS_ID =decimal.Parse( campos[ListaPreciosId_NombreCol].ToString());
                    row.PRECIO = decimal.Parse(campos[Precio_NombreCol].ToString());
                    row.FECHA_INICIO = (DateTime) campos[FechaInicio_NombreCol];
                    row.FECHA_FIN = (DateTime) campos[FechaFin_NombreCol];
                    if (campos.Contains(Estado_NombreCol))
                        row.ESTADO = campos[Estado_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.ARTICULOS_PRECIOS_PRODUCCIONCollection.Insert(row);
                    else sesion.Db.ARTICULOS_PRECIOS_PRODUCCIONCollection.Update(row);
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

                    ARTICULOS_PRECIOS_PRODUCCIONRow row = new ARTICULOS_PRECIOS_PRODUCCIONRow();
                    String valorAnterior = string.Empty;

                    row = sesion.Db.ARTICULOS_PRECIOS_PRODUCCIONCollection.GetByPrimaryKey(id);

                    sesion.Db.ARTICULOS_PRECIOS_PRODUCCIONCollection.Delete(row);
                   
                    sesion.Db.CommitTransaction();
                    return sesion.Db.ARTICULOS_PRECIOS_PRODUCCIONCollection.Delete(row); ;
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
        { get { return "ARTICULOS_MARGEN_RENTABILIDAD"; } }

        public static string Id_NombreCol
        { get { return ARTICULOS_PRECIOS_PRODUCCIONCollection.IDColumnName; } }

        public static string SucursalesId_NombreCol
        { get { return ARTICULOS_PRECIOS_PRODUCCIONCollection.SUCURSALES_IDColumnName; } }

        public static string ListaPreciosId_NombreCol
        { get { return ARTICULOS_PRECIOS_PRODUCCIONCollection.LISTA_PRECIOS_IDColumnName; } }

        public static string ArticulosID_NombreCol
        { get { return ARTICULOS_PRECIOS_PRODUCCIONCollection.ARTICULOS_IDColumnName; } }

        public static string Precio_NombreCol
        { get { return ARTICULOS_PRECIOS_PRODUCCIONCollection.PRECIOColumnName; } }

        public static string FechaInicio_NombreCol
        { get { return ARTICULOS_PRECIOS_PRODUCCIONCollection.FECHA_INICIOColumnName; } }

        public static string FechaFin_NombreCol
        { get { return ARTICULOS_PRECIOS_PRODUCCIONCollection.FECHA_FINColumnName; } }

        public static string FechaCreacion_NombreCol
        { get { return ARTICULOS_PRECIOS_PRODUCCIONCollection.FECHA_CREACIONColumnName; } }

        public static string Estado_NombreCol
        { get { return ARTICULOS_PRECIOS_PRODUCCIONCollection.ESTADOColumnName; } }
        #endregion Accesors
    }
}
