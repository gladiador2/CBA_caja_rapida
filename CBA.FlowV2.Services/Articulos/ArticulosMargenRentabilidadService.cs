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
    public class ArticulosMargenRentabilidadService
    {
        #region GetArticulosMargenRentabilidadDataTable
        /// <summary>
        /// Gets the articulos margen data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetArticulosMargenRentabilidadDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return  sesion.Db.ARTICULOS_MARGEN_RENTABILIDADCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosMargenRentabilidadDataTable

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

                    ARTICULOS_MARGEN_RENTABILIDADRow row = new ARTICULOS_MARGEN_RENTABILIDADRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("articulos_margen_rentab_sqc");
                        row.ESTADO = Definiciones.Estado.Activo;
                        row.FECHA_CREACION = DateTime.Now;
                    }
                    else
                    {
                        row = sesion.Db.ARTICULOS_MARGEN_RENTABILIDADCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.ARTICULOS_ID = decimal.Parse(campos[ArticulosID_NombreCol].ToString());
                    if (campos.Contains(SucursalesId_NombreCol))
                        row.SUCURSALES_ID = decimal.Parse(campos[SucursalesId_NombreCol].ToString());
                    else
                        throw new Exception("Es obligatorio seleccionar la sucursal.");

                    row.LISTA_PRECIOS_ID = decimal.Parse(campos[ListaPreciosId_NombreCol].ToString());
                    row.PORCENTAJE = decimal.Parse(campos[Porcentaje_NombreCol].ToString());
                    row.FECHA_INICIO = (DateTime)campos[FechaInicio_NombreCol];
                    if (campos.Contains(FechaFin_NombreCol))
                        row.FECHA_FIN = ((DateTime)campos[FechaFin_NombreCol]).Date;
                    else
                        row.IsFECHA_FINNull = true;

                    if (campos.Contains(Estado_NombreCol))
                        row.ESTADO = campos[Estado_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.ARTICULOS_MARGEN_RENTABILIDADCollection.Insert(row);
                    else sesion.Db.ARTICULOS_MARGEN_RENTABILIDADCollection.Update(row);
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

                    ARTICULOS_MARGEN_RENTABILIDADRow row = new ARTICULOS_MARGEN_RENTABILIDADRow();
                    String valorAnterior = string.Empty;

                    row = sesion.Db.ARTICULOS_MARGEN_RENTABILIDADCollection.GetByPrimaryKey(id);

                    sesion.Db.ARTICULOS_MARGEN_RENTABILIDADCollection.Delete(row);
                   
                    sesion.Db.CommitTransaction();
                    return sesion.Db.ARTICULOS_MARGEN_RENTABILIDADCollection.Delete(row); ;
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
        { get { return ARTICULOS_MARGEN_RENTABILIDADCollection.IDColumnName; } }

        public static string SucursalesId_NombreCol
        { get { return ARTICULOS_MARGEN_RENTABILIDADCollection.SUCURSALES_IDColumnName; } }

        public static string ListaPreciosId_NombreCol
        { get { return ARTICULOS_MARGEN_RENTABILIDADCollection.LISTA_PRECIOS_IDColumnName; } }

        public static string ArticulosID_NombreCol
        { get { return ARTICULOS_MARGEN_RENTABILIDADCollection.ARTICULOS_IDColumnName; } }

        public static string Porcentaje_NombreCol
        { get { return ARTICULOS_MARGEN_RENTABILIDADCollection.PORCENTAJEColumnName; } }

        public static string FechaInicio_NombreCol
        { get { return ARTICULOS_MARGEN_RENTABILIDADCollection.FECHA_INICIOColumnName; } }

        public static string FechaFin_NombreCol
        { get { return ARTICULOS_MARGEN_RENTABILIDADCollection.FECHA_FINColumnName; } }

        public static string FechaCreacion_NombreCol
        { get { return ARTICULOS_MARGEN_RENTABILIDADCollection.FECHA_CREACIONColumnName; } }

        public static string Estado_NombreCol
        { get { return ARTICULOS_MARGEN_RENTABILIDADCollection.ESTADOColumnName; } }
        #endregion Accesors
    }
}
