using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class TemporadasService
    {
        public TemporadasService()
        {

        }

        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="temporada_id">The temporada_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal temporada_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TEMPORADASRow temporada = sesion.Db.TEMPORADASCollection.GetByPrimaryKey(temporada_id);
                return temporada.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetTemporadasDataTable
        /// <summary>
        /// Gets the temporadas data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetTemporadasDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.TEMPORADASCollection.GetAsDataTable(TemporadasService.EntidadId_NombreCol + " = " + sesion.Entidad.ID, "upper(" + TemporadasService.Nombre_NombreCol + ")");
                return table;
            }
        }

        public static DataTable GetTemporadasDataTable2(){
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.TEMPORADASCollection.GetAsDataTable(TemporadasService.EntidadId_NombreCol + " = " + sesion.Entidad.ID, "upper(" + TemporadasService.Nombre_NombreCol + ")");
                return table;
            }
        }

        public static TEMPORADASRow GetTemporadasRow(decimal temporadaId)
        {
            using (SessionService sesion = new SessionService()) {
                return sesion.Db.TEMPORADASCollection.GetByPrimaryKey(temporadaId);
            }
        }

        /// <summary>
        /// Gets the temporadas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetTemporadasDataTable(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = TemporadasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.TEMPORADASCollection.GetAsDataTable(clausulas + " and " + TemporadasService.EntidadId_NombreCol + " = " + sesion.Entidad.ID + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.TEMPORADASCollection.GetAsDataTable(TemporadasService.EntidadId_NombreCol + " = " + sesion.Entidad.ID + " and " + estado, orden);
                }
                return table;
            }
        }

        public static DataTable GetTemporadasDataTable2(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = TemporadasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.TEMPORADASCollection.GetAsDataTable(clausulas + " and " + TemporadasService.EntidadId_NombreCol + " = " + sesion.Entidad.ID + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.TEMPORADASCollection.GetAsDataTable(TemporadasService.EntidadId_NombreCol + " = " + sesion.Entidad.ID + " and " + estado, orden);
                }
                return table;
            }
        }
        #endregion GetTemporadasDataTable

        #region GetTemporada

        /// <summary>
        /// Temporadas the specified temporada_id.
        /// </summary>
        /// <param name="temporada_id">The temporada_id.</param>
        /// <returns></returns>
        public DataTable GetTemporada(decimal temporada_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.TEMPORADASCollection.GetAsDataTable(TemporadasService.Id_NombreCol + " = " + temporada_id, string.Empty);
                return tabla;
            }
        }
        #endregion GetTemporada
       
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

                    TEMPORADASRow temporada = new TEMPORADASRow();
                    String valorAnterior = string.Empty;
                    decimal aux;

                    if (insertarNuevo)
                    {
                        temporada.ID = sesion.Db.GetSiguienteSecuencia("temporadas_sqc");
                        temporada.ENTIDAD_ID = sesion.Entidad.ID;
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        aux = decimal.Parse(campos[TemporadasService.Id_NombreCol].ToString());
                        temporada = sesion.Db.TEMPORADASCollection.GetByPrimaryKey(aux);
                        valorAnterior = temporada.ToString();
                    }

                    temporada.NOMBRE = campos[TemporadasService.Nombre_NombreCol].ToString();
                    temporada.DESCRIPCION = campos[TemporadasService.Descripcion_NombreCol].ToString();
                    temporada.ESTADO = campos[TemporadasService.Estado_NombreCol].ToString();

                    temporada.FECHA_INICIO = DateTime.Parse(campos[TemporadasService.FechaInicio_NombreCol].ToString());
                    temporada.FECHA_FIN = DateTime.Parse(campos[TemporadasService.FechaFin_NombreCol].ToString());



                    if (insertarNuevo) sesion.Db.TEMPORADASCollection.Insert(temporada);
                    else sesion.Db.TEMPORADASCollection.Update(temporada);

                    LogCambiosService.LogDeRegistro(TemporadasService.Nombre_Tabla, temporada.ID, valorAnterior, temporada.ToString(), sesion);

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
        public static string Nombre_Tabla
        {
            get { return "TEMPORADAS"; }
        }
        public static string Id_NombreCol
        {
            get { return TEMPORADASCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TEMPORADASCollection.NOMBREColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return TEMPORADASCollection.DESCRIPCIONColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return TEMPORADASCollection.FECHA_INICIOColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return TEMPORADASCollection.FECHA_FINColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return TEMPORADASCollection.ESTADOColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return TEMPORADASCollection.ENTIDAD_IDColumnName; }
        }
        #endregion Accessors
    }
}
