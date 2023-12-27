using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class ProfesionesService
    {
        #region EstaActivo
        public static bool EstaActivo(String profesion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PROFESIONESRow profesion = sesion.Db.PROFESIONESCollection.GetRow(Nombre_NombreCol + " = '" + profesion_id + "'");
                return profesion.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetProfesionesDataTable
        public DataTable GetProfesionesDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.PROFESIONESCollection.GetAsDataTable(" 1=1 ", "upper("+Nombre_NombreCol+")" );
                return table;
            }
        }

        public static DataTable GetProfesionesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.PROFESIONESCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetProfesionesDataTable

        #region GetProfesionesActivas
        public DataTable GetProfesionesActivas()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.PROFESIONESCollection.GetAsDataTable(Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ", "upper("+Nombre_NombreCol+")");
                return table;
            }
        }
        #endregion GetProfesionesActivas

        #region GetDescripcion
        public String GetDescripcion(String nombre)
        {
            using (SessionService sesion = new SessionService())
            {
                PROFESIONESRow p = sesion.Db.PROFESIONESCollection.GetRow(Nombre_NombreCol + " = " + nombre);
                return p.DESCRIPCION;
            }
        }
        #endregion GetDescripcion


        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public string Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PROFESIONESRow profesion = new PROFESIONESRow();
                    String valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        profesion = sesion.Db.PROFESIONESCollection.GetRow(Nombre_NombreCol + " = '" + (string)campos[Nombre_NombreCol] + "'");
                        valorAnterior = profesion.ToString();
                    }

                    profesion.NOMBRE = (string)campos[Nombre_NombreCol];
                    profesion.DESCRIPCION = (string)campos[Descripcion_NombreCol];
                    profesion.ESTADO = (string)campos[Estado_NombreCol];

                    if (insertarNuevo) sesion.Db.PROFESIONESCollection.Insert(profesion);
                    else sesion.Db.PROFESIONESCollection.Update(profesion);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, profesion.ToString(), sesion);

                    sesion.Db.CommitTransaction();

                    return profesion.NOMBRE;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar


        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PROFESIONES"; }
        }
        public static string Descripcion_NombreCol
        {
            get { return PROFESIONESCollection.DESCRIPCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return PROFESIONESCollection.ESTADOColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return PROFESIONESCollection.NOMBREColumnName; }
        }

        #endregion Accessors
    }
}
