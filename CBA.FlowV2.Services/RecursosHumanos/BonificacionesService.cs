using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class BonificacionesService
    {
        #region EstaActivo


        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="bonificacion_id">The bonificacion_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal bonificacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                BONIFICACIONESRow row = sesion.Db.BONIFICACIONESCollection.GetByPrimaryKey(bonificacion_id);
                return row.ESTADO.Equals(Definiciones.Estado.Activo);
            }
        }
        #endregion EstaActivo
        
        #region EsUnica
        /// <summary>
        /// Eses the unica.
        /// </summary>
        /// <param name="bonificacion_id">The bonificacion_id.</param>
        /// <returns></returns>
        public static bool EsUnica(decimal bonificacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                BONIFICACIONESRow row = sesion.Db.BONIFICACIONESCollection.GetByPrimaryKey(bonificacion_id);
                return row.UNICA.Equals(Definiciones.SiNo.Si);
            }
        }
        #endregion EsUnica

        #region AplicarDescuento
        /// <summary>
        /// Aplicar descuento.
        /// </summary>
        /// <param name="bonificacion_id">The bonificacion_id.</param>
        /// <returns></returns>
        public static bool AplicarDescuento(decimal bonificacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return AplicarDescuento(bonificacion_id, sesion);
            }
        }

        public static bool AplicarDescuento(decimal bonificacion_id, SessionService sesion)
        {
            BONIFICACIONESRow row = sesion.Db.BONIFICACIONESCollection.GetByPrimaryKey(bonificacion_id);
            return row.DESCONTAR.Equals(Definiciones.SiNo.Si);
        }
        #endregion AplicarDescuento

        #region GetPorcentaje


        public static decimal GetPorcentaje(decimal bonificacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                BONIFICACIONESRow row = sesion.Db.BONIFICACIONESCollection.GetByPrimaryKey(bonificacion_id);
                return row.PORCENTAJE_SUGERIDO;
            }
        }
        #endregion GetPorcentaje

        #region GetBonificacionesDataTable


        /// <summary>
        /// Gets the bonificaciones data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetBonificacionesDataTable()
        {
            return GetBonificacionesDataTable(string.Empty, Orden_NombreCol, false);
        }

        /// <summary>
        /// Gets the bonificaciones data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetBonificacionesDataTable(String clausulas, String orden)
        {
            return GetBonificacionesDataTable(clausulas, orden, false);
        }

        /// <summary>
        /// Gets the bonificaciones data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetBonificacionesDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = EntidadId_NombreCol+" = "+ sesion.Entidad.ID;
                if (soloActivos) estado +=" and "+ Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.BONIFICACIONESCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.BONIFICACIONESCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetBonificacionesDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    BONIFICACIONESRow row = new BONIFICACIONESRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("bonificaciones_sqc");
                        row.ENTIDAD_ID = sesion.Entidad.ID;
                        //El nombre es el ID principal, por lo que no puede
                        //modificarse si el registro ya estaba creado
                        
                    }
                    else
                    {
                        row = sesion.Db.BONIFICACIONESCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }
                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    
                    if (campos.Contains(Descripcion_NombreCol)) 
                        row.DESCRIPCION = campos[Descripcion_NombreCol].ToString();
                    else 
                        row.DESCRIPCION = string.Empty;

                    row.UNICA = campos[Unica_NombreCol].ToString();
                    row.PORCENTAJE_SUGERIDO = decimal.Parse(campos[PorcentajeSugerido_NombreCol].ToString());
                    row.ESTADO = campos[Estado_NombreCol].ToString();
                    row.ORDEN = decimal.Parse(campos[Orden_NombreCol].ToString());
                    row.DESCONTAR = campos[Descontar_NombreCol].ToString();
                    row.INCLUIR_A_AGUINALDO = campos[IncluirAAaguinaldo_NombreCol].ToString();
                    
                    if (insertarNuevo) 
                        sesion.Db.BONIFICACIONESCollection.Insert(row);
                    else 
                        sesion.Db.BONIFICACIONESCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (OracleException exp)
                {
                    sesion.Db.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("Ya existe un registro con ese nombre.");
                        default: throw exp;
                    }
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
            get { return "BONIFICACIONES"; }
        }
        public static string Descripcion_NombreCol
        { get { return BONIFICACIONESCollection.DESCRIPCIONColumnName; } }

        public static string EntidadId_NombreCol
        { get { return BONIFICACIONESCollection.ENTIDAD_IDColumnName; } }

        public static string Estado_NombreCol
        { get { return BONIFICACIONESCollection.ESTADOColumnName; } }

        public static string Id_NombreCol
        { get { return BONIFICACIONESCollection.IDColumnName; } }

        public static string Nombre_NombreCol
        { get { return BONIFICACIONESCollection.NOMBREColumnName; } }

        public static string Orden_NombreCol
        { get { return BONIFICACIONESCollection.ORDENColumnName; } }

        public static string PorcentajeSugerido_NombreCol
        { get { return BONIFICACIONESCollection.PORCENTAJE_SUGERIDOColumnName; } }

        public static string Unica_NombreCol
        { get { return BONIFICACIONESCollection.UNICAColumnName; } }

        public static string Descontar_NombreCol
        { get { return BONIFICACIONESCollection.DESCONTARColumnName; } }

        public static string IncluirAAaguinaldo_NombreCol
        { get { return BONIFICACIONESCollection.INCLUIR_A_AGUINALDOColumnName; } }
        
        #endregion Accessors
    }
}
