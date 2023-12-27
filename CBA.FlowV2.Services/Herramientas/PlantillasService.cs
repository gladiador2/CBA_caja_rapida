using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.General;
namespace CBA.FlowV2.Services.Herramientas
{
    public class PlantillasService
    {
        #region GetPlantilla

        /// <summary>
        /// Gets the plantilla.
        /// </summary>
        /// <param name="plantilla_id">The plantilla_id.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetPlantilla(decimal plantilla_id) 
        {
            using(SessionService sesion = new SessionService())
            {
                string where = PlantillasService.Id_NombreCol + " = " + plantilla_id;

                return sesion.Db.PLANTILLASCollection.GetAsDataTable(where, PlantillasService.Id_NombreCol);
            }

        }
        /// <summary>
        /// Gets the plantilla.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetPlantilla(string clausula, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = PlantillasService.VistasEntidadId_NombreCol + " = " + sesion.EntidadActual_Id;

                if (!clausula.Equals(string.Empty)) where += " and " + clausula;
                if (soloActivos) where += " and " + PlantillasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                
                return sesion.Db.PLANTILLASCollection.GetAsDataTable(where, PlantillasService.Id_NombreCol);
            }

        }
        /// <summary>
        /// Gets the plantilla info completa.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetPlantillaInfoCompleta(string clausula, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = PlantillasService.VistasEntidadId_NombreCol + " = " + sesion.EntidadActual_Id;

                if (!clausula.Equals(string.Empty)) where += " and " + clausula;
                if (soloActivos) where += " and " + PlantillasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                
                return sesion.Db.PLANTILLAS_INFO_COMPLETACollection.GetAsDataTable(where, PlantillasService.Id_NombreCol);
            }

        }
        #endregion GetPlantilla

        #region EstaActivo
      
        public bool EstaActivo(decimal plantilla_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PLANTILLASRow row =new  PLANTILLASRow();
                row = sesion.Db.PLANTILLASCollection.GetByPrimaryKey(plantilla_id);

                return row.ESTADO.Equals(Definiciones.Estado.Activo);
            }

        }
        #endregion EstaActivo
       
       
        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PLANTILLASRow row = new PLANTILLASRow();
                    string valorAnterior = string.Empty;
                    

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("plantillas_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.PLANTILLASCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    row.ESTADO = (string)campos[PlantillasService.Estado_NombreCol];
                    row.NOMBRE = (string)campos[PlantillasService.Nombre_NombreCol];
                    row.TIPO_PLANTILLA_ID = (decimal)campos[PlantillasService.TipoPlantillaId_NombreCol];
                    row.USUARIO_ID = sesion.Usuario.ID;
                    
                    if (insertarNuevo) sesion.Db.PLANTILLASCollection.Insert(row);
                    else sesion.Db.PLANTILLASCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion guardar

        #region Accessors
        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "PLANTILLAS"; }
        }
        public static string Id_NombreCol
        {
            get { return PLANTILLASCollection.IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return PLANTILLASCollection.ESTADOColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return PLANTILLASCollection.NOMBREColumnName; }
        }
        public static string AdjuntoId_NombreCol
        {
            get { return PLANTILLASCollection.ADJUNTO_IDColumnName; }
        }
        public static string TipoPlantillaId_NombreCol
        {
            get { return PLANTILLASCollection.TIPO_PLANTILLA_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return PLANTILLASCollection.USUARIO_IDColumnName; }
        }
        #endregion Tablas
        #region Vistas
        public static string VistasEntidadId_NombreCol
        {
            get { return PLANTILLAS_INFO_COMPLETACollection.ENTIDAD_IDColumnName; }
        }
        public static string VistaEntidadNombre_NombreCol
        {
            get { return PLANTILLAS_INFO_COMPLETACollection.ENTIDAD_NOMBREColumnName; }
        }
        public static string VistaUsuario_NombreCol
        {
            get { return PLANTILLAS_INFO_COMPLETACollection.USUARIO_NOMBREColumnName; }
        }
        public static string VistaTipoPlantillaNombre_NombreCol
        {
            get { return PLANTILLAS_INFO_COMPLETACollection.TIPO_PLANTILLA_NOMBREColumnName; }
        }
        #endregion Vistas
        #endregion Accessors
    }
}
