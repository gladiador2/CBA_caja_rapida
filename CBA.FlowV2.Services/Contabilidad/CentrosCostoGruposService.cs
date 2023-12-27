using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System.Collections;

namespace CBA.FlowV2.Services.Contabilidad
{
    public class CentrosCostoGruposService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="centro_costo_grupo_id">The centro_costo_grupo_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal centro_costo_grupo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CENTROS_COSTO_GRUPOSRow row = sesion.Db.CENTROS_COSTO_GRUPOSCollection.GetByPrimaryKey(centro_costo_grupo_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region EstaHabilitarComoCentroCosto
        public static bool EstaHabilitarComoCentroCosto(decimal centro_costo_grupo_id)
        {
            DataTable dt = CentrosCostoService.GetCentrosCostoDataTable(CentrosCostoService.CentroCostoGrupoId_NombreCol + " = " + centro_costo_grupo_id, string.Empty);
            return dt.Rows.Count > 0;
        }
        #endregion EstaHabilitarComoCentroCosto

        #region GetCentrosCostoGruposDataTable
        /// <summary>
        /// Gets the centros costo grupos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCentrosCostoGruposDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.CENTROS_COSTO_GRUPOSCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetCentrosCostoGruposDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try{
                    CENTROS_COSTO_GRUPOSRow row = new CENTROS_COSTO_GRUPOSRow();
                    string valorAnterior = string.Empty;

                    #region Validaciones
                    if (((string)campos[CentrosCostoGruposService.Nombre_NombreCol]).Length <= 0)
                        throw new Exception("Debe indicar el nombre");
                    #endregion Validaciones

                    if (!campos.Contains(CentrosCostoGruposService.Id_NombreCol))
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("centros_costo_grupos_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.CENTROS_COSTO_GRUPOSCollection.GetByPrimaryKey((decimal)campos[CentrosCostoGruposService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.ESTADO = (string)campos[CentrosCostoGruposService.Estado_NombreCol];
                    row.NOMBRE = (string)campos[CentrosCostoGruposService.Nombre_NombreCol];

                    if (!campos.Contains(CentrosCostoGruposService.Id_NombreCol)) sesion.Db.CENTROS_COSTO_GRUPOSCollection.Insert(row);
                    else sesion.Db.CENTROS_COSTO_GRUPOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    return row.ID;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Guardar

        #region HabilitarComoCentroCosto
        public static void HabilitarComoCentroCosto(decimal centro_costo_grupo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    DataTable dtCentroCosto = CentrosCostoService.GetCentrosCostoDataTable(CentrosCostoService.CentroCostoGrupoId_NombreCol + " = " + centro_costo_grupo_id, string.Empty, sesion);
                    if (dtCentroCosto.Rows.Count != 0)
                        throw new Exception("El grupo ya existe como centro de costo.");

                    CENTROS_COSTO_GRUPOSRow row = sesion.db.CENTROS_COSTO_GRUPOSCollection.GetByPrimaryKey(centro_costo_grupo_id);
                    Hashtable campos = new Hashtable();

                    campos.Add(CentrosCostoService.Abreviatura_NombreCol, row.NOMBRE);
                    campos.Add(CentrosCostoService.Nombre_NombreCol, row.NOMBRE);
                    campos.Add(CentrosCostoService.Orden_NombreCol, CentrosCostoService.GetOrdenMaximo() + 1);
                    campos.Add(CentrosCostoService.Estado_NombreCol, row.ESTADO);
                    campos.Add(CentrosCostoService.CentroCostoGrupoId_NombreCol, row.ID);
                    CentrosCostoService.Guardar(campos, sesion);

                    sesion.CommitTransaction();
                }
                catch 
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion HabilitarComoCentroCosto

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CENTROS_COSTO_GRUPOS"; }
        }
        public static string Estado_NombreCol
        {
            get { return CENTROS_COSTO_GRUPOSCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CENTROS_COSTO_GRUPOSCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CENTROS_COSTO_GRUPOSCollection.NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
