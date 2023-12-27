#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class LegajoService
    {
        #region GetLegajoDataTable
        /// <summary>
        /// Gets the legajo personas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetLegajoDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.LEGAJOCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetLegajoDataTable

        #region GetLegajoInfoCompleta
        /// <summary>
        /// Gets the legajo personas info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetLegajoInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.LEGAJO_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetLegajoInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    LEGAJORow row = new LEGAJORow();
                    string valorAnterior = string.Empty;

                    if (!campos.Contains(LegajoService.Id_NombreCol))
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("legajo_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ESTADO = Definiciones.Estado.Activo;
                        row.ENTRADA_ID = (decimal)campos[LegajoService.EntradaId_NombreCol];
                        row.SUBENTRADA_ID = (decimal)campos[LegajoService.SubEntradaId_NombreCol];
                        row.USUARIO_CREACION_ID = sesion.Usuario_Id;
                        row.FECHA_CREACION = DateTime.Now;
                        row.FINALIZADO = Definiciones.SiNo.No;
                                                
                        //Verificar a que se asociara el registro del legajo
                        if (campos.Contains(PersonaId_NombreCol))
                        {
                            row.PERSONA_ID = (decimal)campos[LegajoService.PersonaId_NombreCol];
                            row.IsPROVEEDOR_IDNull = true;
                            row.IsACTIVO_IDNull = true;
                        }
                        else if (campos.Contains(ProveedorId_NombreCol))
                        {
                            row.IsPERSONA_IDNull = true;
                            row.PROVEEDOR_ID = (decimal)campos[LegajoService.ProveedorId_NombreCol];
                            row.IsACTIVO_IDNull = true;
                        }
                        else if (campos.Contains(ActivoId_NombreCol))
                        {
                            row.IsPERSONA_IDNull = true;
                            row.IsPROVEEDOR_IDNull = true;
                            row.ACTIVO_ID = (decimal)campos[LegajoService.ActivoId_NombreCol];
                        }
                    }
                    else
                    {
                        row = sesion.Db.LEGAJOCollection.GetByPrimaryKey((decimal)campos[LegajoService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.FECHA = DateTime.Now; //Se actualiza la fecha cada vez que se guarda
                    row.OBSERVACION = (string)campos[LegajoService.Observacion_NombreCol];

                    if (!campos.Contains(LegajoService.Id_NombreCol)) sesion.Db.LEGAJOCollection.Insert(row);
                    else sesion.Db.LEGAJOCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();

                    return row.ID;
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
        /// Borrars the specified LEGAJO_id.
        /// </summary>
        /// <param name="LEGAJO_id">The LEGAJO_id.</param>
        public static void Borrar(decimal LEGAJO_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    
                    LEGAJORow row = sesion.Db.LEGAJOCollection.GetByPrimaryKey(LEGAJO_id);
                    string valorAnterior = row.ToString();

                    row.ESTADO = Definiciones.Estado.Inactivo;
                    
                    sesion.Db.LEGAJOCollection.Update(row);
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
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "LEGAJO"; }
        }
        public static string ActivoId_NombreCol
        {
            get { return LEGAJOCollection.ACTIVO_IDColumnName; }
        }
        public static string EntradaId_NombreCol
        {
            get { return LEGAJOCollection.ENTRADA_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return LEGAJOCollection.ESTADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return LEGAJOCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return LEGAJOCollection.IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return LEGAJOCollection.OBSERVACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return LEGAJOCollection.PERSONA_IDColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return LEGAJOCollection.PROVEEDOR_IDColumnName; }
        }
        public static string SubEntradaId_NombreCol
        {
            get { return LEGAJOCollection.SUBENTRADA_IDColumnName; }
        }
        public static string UsuarioCreacionId_NombreCol
        {
            get { return LEGAJOCollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string VistaActivoCodigo_NombreCol
        {
            get { return LEGAJO_INFO_COMPLETACollection.ACTIVO_CODIGOColumnName; }
        }
        public static string VistaEntradaDescripcion_NombreCol
        {
            get { return LEGAJO_INFO_COMPLETACollection.ENTRADA_DESCRIPCIONColumnName; }
        }
        public static string VistaEntidadId_NombreCol
        {
            get { return LEGAJO_INFO_COMPLETACollection.ENTIDAD_IDColumnName; }
        }
        public static string VistaEntradaNombre_NombreCol
        {
            get { return LEGAJO_INFO_COMPLETACollection.ENTRADA_NOMBREColumnName; }
        }
        public static string VistaPersonaNombreCompleto_NombreCol
        {
            get { return LEGAJO_INFO_COMPLETACollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaProveedorDescripcion_NombreCol
        {
            get { return LEGAJO_INFO_COMPLETACollection.PROVEEDOR_DESCColumnName; }
        }
        public static string VistaSubEntradaDescripcion_NombreCol
        {
            get { return LEGAJO_INFO_COMPLETACollection.SUBENTRADA_DESCRIPCIONColumnName; }
        }
        public static string VistaSubEntradaNombre_NombreCol
        {
            get { return LEGAJO_INFO_COMPLETACollection.SUBENTRADA_NOMBREColumnName; }
        }
        public static string VistaTipoDetallePersonalizadoId_NombreCol
        {
            get { return LEGAJO_INFO_COMPLETACollection.TIPO_DETALLE_PERSONALIZADO_IDColumnName; }
        }
        public static string VistaUsuarioCreacionDesripcion_NombreCol
        {
            get { return LEGAJO_INFO_COMPLETACollection.USUARIO_DESCColumnName; }
        }
        #endregion Accessors

    }
}
