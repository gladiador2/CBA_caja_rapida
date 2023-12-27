using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.Text;

namespace CBA.FlowV2.Services.Herramientas
{
    public class RequisitosFlujoService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="requisito_flujo_id">The requisito_flujo_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal requisito_flujo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                REQUISITOS_FLUJORow row = sesion.Db.REQUISITOS_FLUJOCollection.GetRow(Id_NombreCol + " = " + requisito_flujo_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetRequisitosFlujoDataTable
        /// <summary>
        /// Gets the requisitos flujo data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRequisitosFlujoDataTable() 
        {
            return GetRequisitosFlujoDataTable("");
        }

        /// <summary>
        /// Gets the requisitos flujo data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <returns></returns>
        public static DataTable GetRequisitosFlujoDataTable(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                if (clausulas != string.Empty) clausulas += " and ";
                clausulas += EntidadId_NombreCol + " = " + sesion.Entidad.ID;

                return sesion.Db.REQUISITOS_FLUJOCollection.GetAsDataTable(clausulas, Id_NombreCol);
            }
        }

        #endregion GetMonedasDataTable

        #region GetRequisitosPorFlujo
        /// <summary>
        /// Gets the requisitos por flujo.
        /// </summary>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <returns></returns>
        public static DataTable GetRequisitosPorFlujo(decimal flujo_id)
        {
            return GetRequisitosPorFlujo(flujo_id, true, false);
        }

        public static DataTable GetRequisitosPorFlujo(decimal flujo_id, bool soloActivos, bool soloObligatorios)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas;
                
                clausulas = RequisitosFlujoService.FlujoId_NombreCol + " = " + flujo_id + " and " +
                            " (" + RequisitosFlujoService.RolVer_NombreCol + " is null or exists ( " + 
                            "      select id from " + UsuariosRolesService.Nombre_Tabla + " ur " +
                            "       where ur." + UsuariosRolesService.UsuarioId_NombreCol + " = " + sesion.Usuario.ID + " and " +
                            "             ur." + UsuariosRolesService.RolId_NombreCol + " = " + RequisitosFlujoService.RolVer_NombreCol + ")) ";

                if (soloActivos)
                    clausulas += " and " + RequisitosFlujoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (soloObligatorios)
                    clausulas += " and " + RequisitosFlujoService.Obligatorio_NombreCol + " = '" + Definiciones.SiNo.Si + "' ";

                return sesion.Db.REQUISITOS_FLUJOCollection.GetAsDataTable(clausulas, RequisitosFlujoService.Titulo_NombreCol);
            }
        }
        #endregion GetRequisitosPorFlujo

        #region GetRequisitosPorFlujoYEstado
        public static DataTable GetRequisitosPorFlujoYEstado(decimal flujo_id, string estado_id, bool soloActivos, bool soloObligatorios, SessionService sesion)
        {
            string clausulas;

            clausulas = RequisitosFlujoService.FlujoId_NombreCol + " = " + flujo_id + " and " +
                        " (" + RequisitosFlujoService.RolVer_NombreCol + " is null or exists ( " +
                        "      select id from " + UsuariosRolesService.Nombre_Tabla + " ur " +
                        "       where ur." + UsuariosRolesService.UsuarioId_NombreCol + " = " + sesion.Usuario.ID + " and " +
                        "             ur." + UsuariosRolesService.RolId_NombreCol + " = " + RequisitosFlujoService.RolVer_NombreCol + ")) ";

            if (soloActivos)
                clausulas += " and " + RequisitosFlujoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            if (soloObligatorios)
                clausulas += " and " + RequisitosFlujoService.Obligatorio_NombreCol + " = '" + Definiciones.SiNo.Si + "' ";

            return sesion.Db.REQUISITOS_FLUJOCollection.GetAsDataTable(clausulas, RequisitosFlujoService.Titulo_NombreCol);
        }
        #endregion GetRequisitosPorFlujoYEstado

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
                    REQUISITOS_FLUJORow row = new REQUISITOS_FLUJORow();
                    string valorAnterior = "";
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("requisitos_flujo_sqc");
                        row.ENTIDAD_ID = sesion.Entidad.ID;
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.REQUISITOS_FLUJOCollection.GetRow(Id_NombreCol + " = " + campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    
                    row.TITULO = (string)campos[Titulo_NombreCol];
                    row.DESCRIPCION = (string)campos[Descripcion_NombreCol];
                    row.ESTADO = (string)campos[Estado_NombreCol];
                    row.ESTADO_ID = (string)campos[EstadoId_NombreCol];
                    row.FLUJO_ID = (decimal)campos[FlujoId_NombreCol];
                    row.TIPO_REQUISITO_FLUJO_ID = (string)campos[TipoRequisitoFlujoId_NombreCol];
                    row.OBLIGATORIO = (string)campos[Obligatorio_NombreCol];
                    if (insertarNuevo) sesion.Db.REQUISITOS_FLUJOCollection.Insert(row);
                    else sesion.Db.REQUISITOS_FLUJOCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Guardar

        #region Metodos estaticos
        public static string Nombre_Tabla
        {
            get { return "REQUISITOS_FLUJO"; }
        }
        public static string Id_NombreCol
        {
            get { return REQUISITOS_FLUJOCollection.IDColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return REQUISITOS_FLUJOCollection.DESCRIPCIONColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return REQUISITOS_FLUJOCollection.ENTIDAD_IDColumnName; }
        }
        public static string EstadoId_NombreCol
        {
            get { return REQUISITOS_FLUJOCollection.ESTADO_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return REQUISITOS_FLUJOCollection.ESTADOColumnName; }
        }
        public static string FlujoId_NombreCol
        {
            get { return REQUISITOS_FLUJOCollection.FLUJO_IDColumnName; }
        }
        public static string Obligatorio_NombreCol
        {
            get { return REQUISITOS_FLUJOCollection.OBLIGATORIOColumnName; }
        }
        public static string TipoRequisitoFlujoId_NombreCol
        {
            get { return REQUISITOS_FLUJOCollection.TIPO_REQUISITO_FLUJO_IDColumnName; }
        }

        public static string RolEditar_NombreCol
        {
            get { return REQUISITOS_FLUJOCollection.ROL_EDITARColumnName; }
        }

        public static string RolVer_NombreCol
        {
            get { return REQUISITOS_FLUJOCollection.ROL_VERColumnName; }
        }

        public static string Titulo_NombreCol
        {
            get { return REQUISITOS_FLUJOCollection.TITULOColumnName; }
        }
        #endregion Metodos estaticos
    }
}
