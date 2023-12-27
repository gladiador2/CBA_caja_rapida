using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using Oracle.ManagedDataAccess.Client;


namespace CBA.FlowV2.Services.Activos
{
    public class ActivosMovimientosService
    {
        #region GetActivosMovimientosDataTable
        public static DataTable GetActivosMovimientosDataTable(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetActivosMovimientosDataTable(where, orden, sesion);
            }       
        }
        public static DataTable GetActivosMovimientosDataTable(string where, string orden, SessionService sesion)
        {
            string clausulas = Modelo.ESTADOColumnName + "='" + Definiciones.Estado.Activo + "'";
            if (!where.Equals(string.Empty))
                clausulas += " and " + where;
            if (orden.Equals(string.Empty))
                orden = Modelo.FECHA_MOVIMIENTOColumnName + "," + Modelo.IDColumnName;

            return sesion.db.ACTIVOS_MOVIMIENTOSCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetActivosMovimientosDataTable

        #region GetActivosMovimientosInfoCompletaDataTable
        public static DataTable GetActivosMovimientosInfoCompletaDataTable(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetActivosMovimientosInfoCompletaDataTable(where, orden, sesion);
            }
        }
        public static DataTable GetActivosMovimientosInfoCompletaDataTable(string where, string orden, SessionService sesion)
        {
            string clausulas = Modelo.ESTADOColumnName + "='" + Definiciones.Estado.Activo + "'";
            if (!where.Equals(string.Empty))
                clausulas += " and " + where;
            if (orden.Equals(string.Empty))
                orden = VistaModelo.FECHA_MOVIMIENTOColumnName + "," + VistaModelo.IDColumnName;

            return sesion.db.ACTIVOS_MOV_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetActivosMovimientosInfoCompletaDataTable

        #region GetActivosMovimientosDataTablePorActivoId
        public static DataTable GetActivosMovimientosDataTablePorActivoId(decimal activo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetActivosMovimientosDataTablePorActivoId(activo_id, sesion);
            }
        }
        public static DataTable GetActivosMovimientosDataTablePorActivoId(decimal activo_id, SessionService sesion)
        {
            string clausulas = Modelo.ESTADOColumnName + "='" + Definiciones.Estado.Activo + "'";
            clausulas += " and " + Modelo.ACTIVO_IDColumnName + "=" + activo_id;
            string orden = Modelo.FECHA_MOVIMIENTOColumnName + "," + Modelo.IDColumnName;

            return sesion.db.ACTIVOS_MOVIMIENTOSCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetActivosMovimientosDataTablePorActivoId

        #region GetActivosMovimientosInfoCompletaDataTablePorActivoId
        public static DataTable GetActivosMovimientosInfoCompletaDataTablePorActivoId(decimal activo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetActivosMovimientosInfoCompletaDataTablePorActivoId(activo_id, sesion);
            }
        }
        /// <summary>
        /// Gets the activos movimientos information completa data table por activo identifier.
        /// </summary>
        /// <param name="activo_id">The activo_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetActivosMovimientosInfoCompletaDataTablePorActivoId(decimal activo_id, SessionService sesion)
        {
            string clausulas = VistaModelo.ESTADOColumnName + "='" + Definiciones.Estado.Activo + "'";
            clausulas += " and " + VistaModelo.ACTIVO_IDColumnName + "=" + activo_id;
            string orden = VistaModelo.FECHA_MOVIMIENTOColumnName + "," + VistaModelo.IDColumnName;

            return sesion.db.ACTIVOS_MOV_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetActivosMovimientosInfoCompletaDataTablePorActivoId

        #region Guardar

        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <param name="sesion">The sesion.</param>
        /// <exception cref="Exception">
        /// Debe Indicar el Activo
        /// or
        /// Debe Indicar la sucursal de origen
        /// or
        /// Debe indicar la sucursal destino
        /// or
        /// Debe Indicar la fecha del movimiento
        /// or
        /// Debe el identificador del movimiento.
        /// </exception>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
           
               
                    ACTIVOS_MOVIMIENTOSRow row = new ACTIVOS_MOVIMIENTOSRow();
                    String valorAnterior = string.Empty;
                    if (!campos.Contains(Modelo.ACTIVO_IDColumnName))
                        throw new Exception("Debe Indicar el Activo");
                    if (!campos.Contains(Modelo.SUCURSAL_ORIGEN_IDColumnName))
                        throw new Exception("Debe Indicar la sucursal de origen");
                    if (!campos.Contains(Modelo.SUCURSAL_DESTINO_IDColumnName))
                        throw new Exception("Debe indicar la sucursal destino");
                    if (!campos.Contains(Modelo.FECHA_MOVIMIENTOColumnName))
                        throw new Exception("Debe Indicar la fecha del movimiento");
                    
                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("ACTIVOS_MOVIMIENTOS_SQC");
                        row.ESTADO = Definiciones.Estado.Activo;
                    }
                    else
                    {
                        if (!campos.Contains(Modelo.IDColumnName))
                            throw new Exception("Debe el identificador del movimiento.");
                        row = sesion.Db.ACTIVOS_MOVIMIENTOSCollection.GetByPrimaryKey(decimal.Parse(campos[Modelo.IDColumnName].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.ACTIVO_ID = decimal.Parse(campos[Modelo.ACTIVO_IDColumnName].ToString());
                    row.SUCURSAL_ORIGEN_ID = decimal.Parse(campos[Modelo.SUCURSAL_ORIGEN_IDColumnName].ToString());
                   
                    row.SUCURSAL_DESTINO_ID = decimal.Parse(campos[Modelo.SUCURSAL_DESTINO_IDColumnName].ToString());
                    row.FECHA_MOVIMIENTO = DateTime.Parse(campos[Modelo.FECHA_MOVIMIENTOColumnName].ToString());
                    if (campos.Contains(Modelo.OBSERVACIONESColumnName))
                        row.OBSERVACIONES = campos[Modelo.OBSERVACIONESColumnName].ToString();

                    row.USUARIO_MOVIMIENTO_ID = sesion.Usuario.ID;

                    

                    if (insertarNuevo) sesion.Db.ACTIVOS_MOVIMIENTOSCollection.Insert(row);
                    else sesion.Db.ACTIVOS_MOVIMIENTOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                
            
        }

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
                    sesion.db.BeginTransaction();
                    Guardar(campos, insertarNuevo, sesion);
                    sesion.db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified activo_movimiento_id.
        /// </summary>
        /// <param name="activo_movimiento_id">The activo_movimiento_id.</param>
        public static void Borrar(decimal activo_movimiento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    Borrar(activo_movimiento_id, sesion);
                    sesion.db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        /// <summary>
        /// Borrars the specified activo_movimiento_id.
        /// </summary>
        /// <param name="activo_movimiento_id">The activo_movimiento_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal activo_movimiento_id, SessionService sesion)
        {
            ACTIVOS_MOVIMIENTOSRow row = sesion.db.ACTIVOS_MOVIMIENTOSCollection.GetByPrimaryKey(activo_movimiento_id);
            string valorAnterior = row.ToString();
            row.ESTADO = Definiciones.Estado.Inactivo;
            sesion.Db.ACTIVOS_MOVIMIENTOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

        }
        #endregion Borrar

        #region Accessors


        public static string Nombre_Tabla
        {
            get { return "ACTIVOS_MOVIMIENTOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "activos_mov_info_completa"; }
        }
        public class Modelo : ACTIVOS_MOVIMIENTOSCollection_Base { public Modelo() : base(null) { } }
        public class VistaModelo : ACTIVOS_MOV_INFO_COMPLETACollection_Base { public VistaModelo() : base(null) { } }
        
        #endregion Accessors
    }
}

