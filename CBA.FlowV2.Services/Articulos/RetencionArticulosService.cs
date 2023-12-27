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
    public class RetencionArticulosService
    {
        #region GetRetencionArticulosDataTable
        /// <summary>
        /// Gets the retencion articulos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetRetencionArticulosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.RETENCION_ARTICULOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetRetencionArticulosDataTable


        #region GetRetencionArticulosInfoCompleta
        /// <summary>
        /// Gets the retencion articulos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetRetencionArticulosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.RETENCION_ARTIC_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetRetencionArticulosInfoCompleta
        
        #region GetRetencionArticulosDataTablePorArticuloId
        public DataTable GetRetencionArticulosDataTablePorArticuloId(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = RetencionArticulosService.ArticuloID_NombreColumn + " = " + articulo_id;
                return sesion.Db.RETENCION_ARTIC_INFO_COMPLCollection.GetAsDataTable(where, RetencionArticulosService.Id_NombreCol);
            }
        }
        #endregion GetRetencionArticulosDataTablePorArticuloId

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

                    RETENCION_ARTICULOSRow row = new RETENCION_ARTICULOSRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = GetMaxID();
                    }
                    else
                    {
                        row = sesion.Db.RETENCION_ARTICULOSCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.ARTICULO_ID = decimal.Parse(campos[ArticuloID_NombreColumn].ToString());
                    row.PORCENTAJE = decimal.Parse(campos[Porcentaje_NombreColumn].ToString());
                 

                    if (insertarNuevo) sesion.Db.RETENCION_ARTICULOSCollection.Insert(row);
                    else sesion.Db.RETENCION_ARTICULOSCollection.Update(row);
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

        #region GetMaxID
        private static decimal GetMaxID()
        {
            
            using (SessionService sesion = new SessionService())
            {
                string sql = "select nvl(max("+Id_NombreCol+"),0)+1 from "+Nombre_Tabla;
                DataTable dt = sesion.Db.EjecutarQuery(sql);
               
                return (decimal)dt.Rows[0][0];
            }
        }
        #endregion GetMaxID


        #region Accesors
        public static string Nombre_Tabla
        { get { return "retencion_articulos"; } }

        public static string Id_NombreCol
        { get { return RETENCION_ARTICULOSCollection.IDColumnName; } }

        public static string ArticuloID_NombreColumn
        { get { return RETENCION_ARTICULOSCollection.ARTICULO_IDColumnName; } }

        public static string Porcentaje_NombreColumn
        { get { return RETENCION_ARTICULOSCollection.PORCENTAJEColumnName; } }

        //accesors VISTA
        public static string CodigoEmpresa_NombreColumn
        { get { return ARTICULOSCollection.CODIGO_EMPRESAColumnName; } }

        public static string DescripcionInterna_NombreColumn
        { get { return ARTICULOSCollection.DESCRIPCION_INTERNAColumnName; } }

        public static string DescripcionImpresion_NombreColumn
        { get { return ARTICULOSCollection.DESCRIPCION_IMPRESIONColumnName; } }

        public static string UnidadMedidaId_NombreColumn
        { get { return ARTICULOSCollection.UNIDAD_MEDIDA_IDColumnName; } }

        public static string CantidadMInima_NombreColumn
        { get { return ARTICULOSCollection.CANTIDAD_MINIMAColumnName; } }

        public static string CantidadMaxima_NombreColumn
        { get { return ARTICULOSCollection.CANTIDAD_MAXIMAColumnName; } }

        public static string CantidadMayorista_NombreColumn
        { get { return ARTICULOSCollection.CANTIDAD_MAYORISTAColumnName; } }

        public static string UnidadMedidaControl_NombreColumn
        { get { return ARTICULOSCollection.UNIDAD_MEDIDA_CONTROLColumnName; } }
        #endregion Accesors
    }
}
