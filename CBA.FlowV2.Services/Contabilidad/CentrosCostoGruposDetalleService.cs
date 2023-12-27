using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Contabilidad
{
    public class CentrosCostoGruposDetalleService
    {
        #region GetPorcentaje
        /// <summary>
        /// Gets the porcentaje.
        /// </summary>
        /// <param name="centro_costo_grupo_id">The centro_costo_grupo_id.</param>
        /// <param name="centro_costo_id">The centro_costo_id.</param>
        /// <returns></returns>
        public static decimal GetPorcentaje(decimal centro_costo_grupo_id, decimal centro_costo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = CentrosCostoGruposDetalleService.CentroCostoId_NombreCol + " = " + centro_costo_id + " and " +
                                   CentrosCostoGruposDetalleService.CentroCostoGrupoId_NombreCol + " = " + centro_costo_grupo_id;

                DataTable dt = GetCentrosCostoGruposDetalleDataTable(clausulas, string.Empty);

                if (dt.Rows.Count <= 0) return Definiciones.Error.Valor.EnteroPositivo;
                else return (decimal)dt.Rows[0][CentrosCostoGruposDetalleService.Porcentaje_NombreCol];
            }
        }
        #endregion GetPorcentaje

        #region GetCentrosCostoGruposDetalleDataTable
        /// <summary>
        /// Gets the centros costo grupos detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCentrosCostoGruposDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCentrosCostoGruposDetalleDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCentrosCostoGruposDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CENTROS_COSTO_GRUPOS_DETCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCentrosCostoGruposDetalleDataTable

        #region GetCentrosCostoGruposDetalleInfoCompleta
        /// <summary>
        /// Gets the centros costo grupos detalle information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCentrosCostoGruposDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.CENTROS_COSTO_GRUPOS_DET_INF_CCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetCentrosCostoGruposDetalleInfoCompleta

        #region SetPorcentajes
        /// <summary>
        /// Sets the porcentajes.
        /// </summary>
        /// <param name="centro_costo_grupo_id">The centro_costo_grupo_id.</param>
        /// <param name="centro_costo_grupo_det_id">The centro_costo_grupo_det_id.</param>
        /// <param name="porcentaje">The porcentaje.</param>
        /// <exception cref="System.Exception">Error en CentrosCostoGruposDetalleService.SetPorcentajes. Los arreglos de id y porcentaje no tienen igual longitud.
        /// or
        /// La suma de los porcentajes debe ser 100%, actualmente es  + total + .
        /// or
        /// Error en CentrosCostoGruposDetalleService.SetPorcentajes. No se encuentra el id del centro de costo buscado.</exception>
        public static void SetPorcentajes(decimal[] id, decimal[] porcentaje)
        { 
           using (SessionService sesion = new SessionService())
            {
                try
                {
                    if (id.Length != porcentaje.Length)
                        throw new Exception("Error en CentrosCostoGruposDetalleService.SetPorcentajes. Los arreglos de id y porcentaje no tienen igual longitud.");

                    sesion.BeginTransaction();

                    string clausulas = CentrosCostoGruposDetalleService.Id_NombreCol + " in (" + string.Join(",", Array.ConvertAll(id, x => x.ToString())) + ")";
                    CENTROS_COSTO_GRUPOS_DETRow[] rows = sesion.db.CENTROS_COSTO_GRUPOS_DETCollection.GetAsArray(clausulas, CentrosCostoGruposDetalleService.Id_NombreCol);
                    decimal total = 0;
                    bool bandera;


                    for (int i = 0; i < rows.Length; i++)
                    {
                        bandera = false;
                        for (int j = 0; j < id.Length; j++)
                        {
                            if (rows[i].ID == id[j])
                            {
                                rows[i].PORCENTAJE = porcentaje[j];
                                total += porcentaje[j];
                                sesion.db.CENTROS_COSTO_GRUPOS_DETCollection.Update(rows[i]);

                                bandera = true;
                            }
                        }

                        if (!bandera)
                        {
                            throw new Exception("Error en CentrosCostoGruposDetalleService.SetPorcentajes. No se encuentra el id del centro de costo buscado.");
                        }
                    }

                    if (total != 100)
                        throw new Exception("La suma de los porcentajes debe ser 100%, actualmente es " + total + ".");

                    sesion.CommitTransaction();
                }
                catch (Exception)
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion SetPorcentajes

        #region Crear
        /// <summary>
        /// Crears the specified centro_costo_id.
        /// </summary>
        /// <param name="centro_costo_id">The centro_costo_id.</param>
        /// <param name="centro_costo_grupo_id">The centro_costo_grupo_id.</param>
        /// <returns></returns>
        public static decimal Crear(decimal centro_costo_id, decimal centro_costo_grupo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    #region Validar que no es parte del grupo
                    string clausulas = CentrosCostoGruposDetalleService.CentroCostoGrupoId_NombreCol + " = " + centro_costo_grupo_id + " and " +
                                       CentrosCostoGruposDetalleService.CentroCostoId_NombreCol + " = " + centro_costo_id;
                    DataTable dt = GetCentrosCostoGruposDetalleInfoCompleta(clausulas, string.Empty);
                    
                    if (dt.Rows.Count > 0)
                        throw new Exception("El centro de costo " + dt.Rows[0][CentrosCostoGruposDetalleService.VistaCentroCostoNombre_NombreCol] + " ya forma parte del grupo.");
                    #endregion Validar que no es parte del grupo

                    CENTROS_COSTO_GRUPOS_DETRow row = new CENTROS_COSTO_GRUPOS_DETRow();
                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.ID = sesion.Db.GetSiguienteSecuencia("centros_costo_grupos_det_sqc");
                    row.CENTRO_COSTO_GRUPO_ID = centro_costo_grupo_id;
                    row.CENTRO_COSTO_ID = centro_costo_id;
                    row.PORCENTAJE = 0;

                    sesion.Db.CENTROS_COSTO_GRUPOS_DETCollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    return row.ID;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Crear

        #region Borrar
        /// <summary>
        /// Borrars the specified centro_costo_grupo_detalle_id.
        /// </summary>
        /// <param name="centro_costo_grupo_detalle_id">The centro_costo_grupo_detalle_id.</param>
        public static void Borrar(decimal centro_costo_grupo_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CENTROS_COSTO_GRUPOS_DETRow row = sesion.Db.CENTROS_COSTO_GRUPOS_DETCollection.GetByPrimaryKey(centro_costo_grupo_detalle_id);
                sesion.Db.CENTROS_COSTO_GRUPOS_DETCollection.Delete(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CENTROS_COSTO_GRUPOS_DET"; }
        }public static string Nombre_Vista
        {
            get { return "CENTROS_COSTO_GRUPOS_DET_INF_C"; }
        }
        public static string CentroCostoGrupoId_NombreCol
        {
            get { return CENTROS_COSTO_GRUPOS_DETCollection.CENTRO_COSTO_GRUPO_IDColumnName; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return CENTROS_COSTO_GRUPOS_DETCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CENTROS_COSTO_GRUPOS_DETCollection.IDColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return CENTROS_COSTO_GRUPOS_DETCollection.PORCENTAJEColumnName; }
        }
        public static string VistaCentroCostoAbreviatura_NombreCol
        {
            get { return CENTROS_COSTO_GRUPOS_DET_INF_CCollection.CENTRO_COSTO_ABREVIATURAColumnName; }
        }
        public static string VistaCentroCostoGrupoNombre_NombreCol
        {
            get { return CENTROS_COSTO_GRUPOS_DET_INF_CCollection.CENTRO_COSTO_GRUPO_NOMBREColumnName; }
        }
        public static string VistaCentroCostoNombre_NombreCol
        {
            get { return CENTROS_COSTO_GRUPOS_DET_INF_CCollection.CENTRO_COSTO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
