#region Using
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
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class OrdenesServicioFuncionariosService
    {
        #region GetOrdenesServicioFuncionariosDataTable
        /// <summary>
        /// Gets the ordenes servicio detalle data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetOrdenesServicioFuncionariosDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ORDENES_SERVICIO_FUNCIONARIOSCollection.GetAsDataTable(clausula, orden);
            }
        }
        
        #endregion GetUsoDeInsumosFuncionariosDataTable

        #region GetOrdenesServicioFuncionariosInfoCompleta
        /// <summary>
        /// Gets the ordenes servicio detalle info completa static.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetOrdenesServicioFuncionariosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ORDENES_SERV_FUNC_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetOrdenesServicioFuncionariosInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    ORDENES_SERVICIO_FUNCIONARIOSRow row = new ORDENES_SERVICIO_FUNCIONARIOSRow();
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("ordenes_servicio_func_sqc");
                        row.ORDEN_SERVICIO_ID = (decimal)campos[OrdenesServicioFuncionariosService.OrdenServicioId_NombreCol];
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.ORDENES_SERVICIO_FUNCIONARIOSCollection.GetRow(OrdenesServicioFuncionariosService.Id_NombreCol + " = " + campos[OrdenesServicioFuncionariosService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.FUNCIONARIO_ID = (decimal)campos[OrdenesServicioFuncionariosService.FuncionarioId_NombreCol];
                    row.PORCENTAJE_COMISION = (decimal)campos[OrdenesServicioFuncionariosService.PorcentajeComision_NombreCol];

                    if (insertarNuevo) sesion.Db.ORDENES_SERVICIO_FUNCIONARIOSCollection.Insert(row);
                    else sesion.Db.ORDENES_SERVICIO_FUNCIONARIOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified detalles_id.
        /// </summary>
        /// <param name="detalles_id">The detalles_id.</param>
        public static void Borrar(decimal detalles_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    ORDENES_SERVICIO_FUNCIONARIOSRow row = new ORDENES_SERVICIO_FUNCIONARIOSRow();
                    row = sesion.Db.ORDENES_SERVICIO_FUNCIONARIOSCollection.GetByPrimaryKey(detalles_id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.ORDENES_SERVICIO_FUNCIONARIOSCollection.DeleteByPrimaryKey(detalles_id);
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
       
        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ORDENES_SERVICIO_FUNCIONARIOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "ORDENES_SERV_FUNC_INFO_COMPL"; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return ORDENES_SERVICIO_FUNCIONARIOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ORDENES_SERVICIO_FUNCIONARIOSCollection.IDColumnName; }
        }
        public static string OrdenServicioId_NombreCol
        {
            get { return ORDENES_SERVICIO_FUNCIONARIOSCollection.ORDEN_SERVICIO_IDColumnName; }
        }
        public static string PorcentajeComision_NombreCol
        {
            get { return ORDENES_SERVICIO_FUNCIONARIOSCollection.PORCENTAJE_COMISIONColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return ORDENES_SERV_FUNC_INFO_COMPLCollection.FUNCIONARIO_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaOrdenServicioCaso_NombreCol
        {
            get { return ORDENES_SERV_FUNC_INFO_COMPLCollection.ORDEN_SERVICIO_CASOColumnName; }
        }
        public static string VistaOrdenServicioTipo_NombreCol
        {
            get { return ORDENES_SERV_FUNC_INFO_COMPLCollection.ORDEN_SERVICIO_TIPOColumnName; }
        }
        public static string VistaOrdenServicioTitulo_NombreCol
        {
            get { return ORDENES_SERV_FUNC_INFO_COMPLCollection.ORDEN_SERVICIO_TITULOColumnName; }
        }
        #endregion Accessors
    }
}




