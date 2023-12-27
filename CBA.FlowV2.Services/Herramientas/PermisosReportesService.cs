using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PermisosReportesService
    {
        #region GetPermisosDataTable
        /// <summary>
        /// Gets the permisos data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetPermisosDataTable()
        {
            return GetPermisosDataTable("");
        }

        /// <summary>
        /// Gets the permisos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <returns></returns>
        public DataTable GetPermisosDataTable(String clausulas)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    DataTable dtDatos;
                    string where = PermisosReportesENTIDAD_ID_NombreCol+"=" + sesion.Entidad.ID;

                    if (clausulas != string.Empty) where += " and " + clausulas;

                    dtDatos = sesion.Db.PERMISOS_REPORTESCollection.GetAsDataTable(clausulas, "");

                    return dtDatos;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetPermisosDataTable

        #region GetPermisosInfoCompleta
        /// <summary>
        /// Gets the permisos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <returns></returns>
        public DataTable GetPermisosInfoCompleta(String clausulas)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    DataTable dtDatos;
                    string where = "=" + sesion.Entidad.ID;

                    if (clausulas != string.Empty) where += " and " + clausulas;

                    dtDatos = sesion.Db.PERMISOS_REPORTES_INFO_COMPLCollection.GetAsDataTable(clausulas,PermisosReportesID_NombreCol);

                    return dtDatos;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetPermisosInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo) {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PERMISOS_REPORTESRow permiso = new PERMISOS_REPORTESRow();
                    String valorAnterior = "";

                    if (insertarNuevo)
                    {
                        permiso.ID = sesion.Db.GetSiguienteSecuencia("permisos_reportes_sqc");
                        permiso.ENTIDAD_ID = sesion.Usuario.ENTIDAD_ID;
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                       
                    }
                    else
                    {
                        permiso = sesion.Db.PERMISOS_REPORTESCollection.GetRow(PermisosReportesID_NombreCol + " = " + campos[PermisosReportesID_NombreCol]);
                        valorAnterior = permiso.ToString();
                    }

                   
                    

                    //Se puede recibir el nombre del estado o Definiciones.IdNull si son todos los estados
                    if (!campos[PermisosReportesTIPO_REPORTE_ID_NombreCol].Equals(Definiciones.IdNull))
                    {
                        permiso.TIPO_REPORTE_ID = (decimal)campos[PermisosReportesTIPO_REPORTE_ID_NombreCol]; 

                    }
                    

                    //Se puede recibir el id del rol o Definiciones.IdNull si son todos los roles
                    if (campos[PermisosReportesROL_ID_NombreCol].Equals(Definiciones.IdNull)) permiso.IsROL_IDNull = true;
                    else permiso.ROL_ID = (decimal)campos[PermisosReportesROL_ID_NombreCol];

                    

                    //Se pude comprueba que tenga fecha de vencimiento
                    
                    if (campos.Contains(PermisosReportesFECHA_FIN_NombreCol))
                    {
                        permiso.FECHA_FIN = DateTime.Parse((string)campos[PermisosReportesFECHA_FIN_NombreCol]);
                    }
                    else
                    {
                        permiso.IsFECHA_FINNull = true;
                    }

                    //Se pude comprueba el reporte que se utiliza
                    if (campos.Contains(PermisosReportesREPORTE_ID_NombreCol))
                    {
                        permiso.REPORTE_ID = (decimal)campos[PermisosReportesREPORTE_ID_NombreCol];
                    }
                    else
                    {
                        permiso.IsREPORTE_IDNull = true;
                        
                    }

                    //Se pude comprueba la sucursal que se utiliza
                    if (campos.Contains(PermisosReportesSUCURSAL_ID_NombreCol))
                    {
                        permiso.SUCURSAL_ID = (decimal)campos[PermisosReportesSUCURSAL_ID_NombreCol];  
                    }
                    else
                    {
                        permiso.IsSUCURSAL_IDNull = true;
                        
                    }

                    //Se pude comprueba el usuario
                    if (campos.Contains(PermisosReportesUSUARIO_ID_NombreCol))
                    {
                        permiso.USUARIO_ID = (decimal)campos[PermisosReportesUSUARIO_ID_NombreCol];
                    }
                    else
                    {
                        permiso.IsUSUARIO_IDNull = true;

                    }

                   
                    if (insertarNuevo) sesion.Db.PERMISOS_REPORTESCollection.Insert(permiso);
                    else sesion.Db.PERMISOS_REPORTESCollection.Update(permiso);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, permiso.ID, valorAnterior, permiso.ToString(), sesion);

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
        /// <summary>
        /// Borrars the specified permisos_reportes_id.
        /// </summary>
        /// <param name="permisos_reportes_id">The permisos_reportes_id.</param>
        public void Borrar(decimal permisos_reportes_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PERMISOS_REPORTESRow permiso = sesion.Db.PERMISOS_REPORTESCollection.GetByPrimaryKey(permisos_reportes_id);

                    sesion.Db.PERMISOS_REPORTESCollection.Delete(permiso);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, permiso.ID, permiso.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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

        #region Metodos Estaticos
        public static string Nombre_Tabla
        { get { return "PERMISOS_REPORTES"; } }

        public static string PermisosReportesID_NombreCol
        {
            get { return PERMISOS_REPORTESCollection.IDColumnName; } 
        }
        public static string PermisosReportesTIPO_REPORTE_ID_NombreCol
        {
            get { return PERMISOS_REPORTESCollection.TIPO_REPORTE_IDColumnName; }
        }
        public static string PermisosReportesREPORTE_ID_NombreCol
        {
            get { return PERMISOS_REPORTESCollection.REPORTE_IDColumnName; }
        }
        public static string PermisosReportesROL_ID_NombreCol
        {
            get { return PERMISOS_REPORTESCollection.ROL_IDColumnName; }
        }
        public static string PermisosReportesUSUARIO_ID_NombreCol
        {
            get { return PERMISOS_REPORTESCollection.USUARIO_IDColumnName; }
        }
        public static string PermisosReportesSUCURSAL_ID_NombreCol
        {
            get { return PERMISOS_REPORTESCollection.SUCURSAL_IDColumnName; }
        }
        public static string PermisosReportesENTIDAD_ID_NombreCol
        {
            get { return PERMISOS_REPORTESCollection.ENTIDAD_IDColumnName; }
        }
        public static string PermisosReportesFECHA_FIN_NombreCol
        {
            get { return PERMISOS_REPORTESCollection.FECHA_FINColumnName; }
        }
        public static string PermisosReportesVistaID_NombreCol
        {
            get { return PERMISOS_REPORTES_INFO_COMPLCollection.IDColumnName; }
        }
        public static string PermisosReportesVistaTIPO_REPORTE_ID_NombreCol
        {
            get { return PERMISOS_REPORTES_INFO_COMPLCollection.TIPO_REPORTE_IDColumnName; }

        }
        public static string PermisosReportesVistaTIPO_REPORTE_NOMBRE_NombreCol
        {
            get { return PERMISOS_REPORTES_INFO_COMPLCollection.TIPO_REPORTE_NOMBREColumnName; }

        }
        public static string PermisosReportesVistaREPORTE_ID_NombreCol
        {
            get { return PERMISOS_REPORTES_INFO_COMPLCollection.REPORTE_IDColumnName; }

        }
        public static string PermisosReportesVistaREPORTE_NOMBRE_NombreCol
        {
            get { return PERMISOS_REPORTES_INFO_COMPLCollection.REPORTE_NOMBREColumnName; }

        }
        public static string PermisosReportesVistaROL_ID_NombreCol
        {
            get { return PERMISOS_REPORTES_INFO_COMPLCollection.ROL_IDColumnName; }

        }
        public static string PermisosReportesVistaROL_DESCRIPCION_NombreCol
        {
            get { return PERMISOS_REPORTES_INFO_COMPLCollection.ROL_DESCRIPCIONColumnName; }

        }
        public static string PermisosReportesVistaUSUARIO_ID_NombreCol
        {
            get { return PERMISOS_REPORTES_INFO_COMPLCollection.USUARIO_IDColumnName; }

        }
        public static string PermisosReportesVistaUSUARIO_NOMBRE_NombreCol
        {
            get { return PERMISOS_REPORTES_INFO_COMPLCollection.USUARIO_NOMBREColumnName; }

        }
        public static string PermisosReportesVistaSUCURSAL_ID_NombreCol
        {
            get { return PERMISOS_REPORTES_INFO_COMPLCollection.SUCURSAL_IDColumnName; }

        }
        public static string PermisosReportesVistaSUCURSAL_NOMBRE_NombreCol
        {
            get { return PERMISOS_REPORTES_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }

        }
        public static string PermisosReportesVistaFECHA_FIN_NombreCol
        {
            get { return PERMISOS_REPORTES_INFO_COMPLCollection.FECHA_FINColumnName; }

        }
        #endregion Metodos Estaticos
    }
}