using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PlantillasDetallesService
    {
        #region GetPlantillaDetalles
        /// <summary>
        /// Gets the plantilla detalles.
        /// </summary>
        /// <param name="plantilla_detalle_id">The plantilla_detalle_id.</param>
        /// <returns></returns>
        public DataTable GetPlantillaDetalles(decimal plantilla_detalle_id) 
        {
            using(SessionService sesion = new SessionService())
            {
                return sesion.Db.PLANTILLAS_DETALLESCollection.GetAsDataTable(PlantillasDetallesService.Id_NombreCol + " = " + plantilla_detalle_id,Id_NombreCol);
            }

        }
        #endregion GetPlantillaDetalles

        #region GetPlantillaDetallesPorPlantilla
        /// <summary>
        /// Gets the plantilla detalles por plantilla.
        /// </summary>
        /// <param name="plantilla_id">The plantilla_id.</param>
        /// <returns></returns>
        public DataTable GetPlantillaDetallesPorPlantilla(decimal plantilla_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PLANTILLAS_DETALLESCollection.GetByPLANTILLA_IDAsDataTable(plantilla_id);
            }

        }
        #endregion GetPlantillaDetallesPorPlantilla

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

                    PLANTILLAS_DETALLESRow row = new PLANTILLAS_DETALLESRow();
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("plantillas_detalles_sqc");
                        row.PLANTILLA_ID = (decimal)campos[PlantillasDetallesService.PlantillaId_NombreCol];
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.PLANTILLAS_DETALLESCollection.GetByPrimaryKey((decimal)campos[PlantillasDetallesService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    if (campos.Contains(CaracterRelleno_NombreCol)) row.CARACTER_RELLENO = (string)campos[PlantillasDetallesService.CaracterRelleno_NombreCol];
                    if (campos.Contains(LongitudMinima_NombreCol)) row.LONGITUD_MINIMA = (decimal)(campos[PlantillasDetallesService.LongitudMinima_NombreCol]);
                    if (campos.Contains(TablaId_NombreCol)) row.TABLA_ID = (string)campos[PlantillasDetallesService.TablaId_NombreCol];
                    if (campos.Contains(Pregunta_NombreCol)) row.PREGUNTA = (string)campos[PlantillasDetallesService.Pregunta_NombreCol];
                    if (campos.Contains(TipoDato_NombreCol)) row.TIPO_DATO = (string)campos[PlantillasDetallesService.TipoDato_NombreCol];

                    if (campos.Contains(Parametro_NombreCol)) row.PARAMETRO = (string)campos[PlantillasDetallesService.Parametro_NombreCol];
                    if (campos.Contains(Sql_NombreCol)) row.SQL = (string)campos[PlantillasDetallesService.Sql_NombreCol];

                    if (insertarNuevo) sesion.Db.PLANTILLAS_DETALLESCollection.Insert(row);
                    else sesion.Db.PLANTILLAS_DETALLESCollection.Update(row);

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

        #region Borrar
        /// <summary>
        /// Borrars the specified detalle_plantilla_id.
        /// </summary>
        /// <param name="detalle_plantilla_id">The detalle_plantilla_id.</param>
        public void Borrar(decimal detalle_plantilla_id) 
        {
            using (SessionService sesion = new SessionService()) 
            {
                
                try
                {
                    sesion.Db.BeginTransaction();
                    
                    PLANTILLAS_DETALLESRow row = sesion.Db.PLANTILLAS_DETALLESCollection.GetByPrimaryKey(detalle_plantilla_id);
                    
                    sesion.Db.PLANTILLAS_DETALLESCollection.DeleteByPrimaryKey(detalle_plantilla_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PLANTILLAS_DETALLES"; }
        }
        public static string Id_NombreCol
        {
            get { return PLANTILLAS_DETALLESCollection.IDColumnName; }
        }
        public static string CaracterRelleno_NombreCol
        {
            get { return PLANTILLAS_DETALLESCollection.CARACTER_RELLENOColumnName; }
        }
        public static string LongitudMinima_NombreCol
        {
            get { return PLANTILLAS_DETALLESCollection.LONGITUD_MINIMAColumnName; }
        }
        public static string Parametro_NombreCol
        {
            get { return PLANTILLAS_DETALLESCollection.PARAMETROColumnName; }
        }
        public static string PlantillaId_NombreCol
        {
            get { return PLANTILLAS_DETALLESCollection.PLANTILLA_IDColumnName; }
        }
        public static string Sql_NombreCol
        {
            get { return PLANTILLAS_DETALLESCollection.SQLColumnName; }
        }
        public static string TablaId_NombreCol
        {
            get { return PLANTILLAS_DETALLESCollection.TABLA_IDColumnName; }
        }
        public static string Pregunta_NombreCol
        {
            get { return PLANTILLAS_DETALLESCollection.PREGUNTAColumnName; }
        }
        public static string TipoDato_NombreCol
        {
            get { return PLANTILLAS_DETALLESCollection.TIPO_DATOColumnName; }
        }
        #endregion Accessors
    }
}
