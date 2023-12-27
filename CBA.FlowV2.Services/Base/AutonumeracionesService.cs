#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Common;
using System.Collections;
#endregion using

namespace CBA.FlowV2.Services.Base
{
    public class AutonumeracionesService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="autonumeracion_id">The autonumeracion_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal autonumeracion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                AUTONUMERACIONESRow row = sesion.Db.AUTONUMERACIONESCollection.GetRow(Id_NombreCol + " = " + autonumeracion_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region EsImprimible
        /// <summary>
        /// Eses the imprimible.
        /// </summary>
        /// <param name="autonumeracion_id">The autonumeracion_id.</param>
        /// <returns></returns>
        public static bool EsImprimible(decimal autonumeracion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                AUTONUMERACIONESRow row = sesion.Db.AUTONUMERACIONESCollection.GetRow(Id_NombreCol + " = " + autonumeracion_id);
                return row.IMPRIMIBLE == Definiciones.SiNo.Si;
            }
        }
        #endregion EsImprimible

        #region EsGeneracionManual
        /// <summary>
        /// Eses the generacion manual.
        /// </summary>
        /// <param name="autonumeracion_id">The autonumeracion_id.</param>
        /// <returns></returns>
        public static bool EsGeneracionManual(decimal autonumeracion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                AUTONUMERACIONESRow row = sesion.Db.AUTONUMERACIONESCollection.GetRow(Id_NombreCol + " = " + autonumeracion_id);
                return row.TIPO_GENERACION == Definiciones.TiposGeneracionAutonumeraciones.Manual_Nombre;
            }
        }

        public static bool EsGeneracionManual(decimal autonumeracion_id, SessionService sesion)
        {
            AUTONUMERACIONESRow row = sesion.Db.AUTONUMERACIONESCollection.GetRow(Id_NombreCol + " = " + autonumeracion_id);
            return row.TIPO_GENERACION == Definiciones.TiposGeneracionAutonumeraciones.Manual_Nombre;
        }
        #endregion EsGeneracionManual

        #region FuncionarioPuedeUsar
        public static bool FuncionarioPuedeUsar(decimal autonumeracion_id, decimal funcionario_id, SessionService sesion)
        {
            AUTONUMERACIONESRow row = sesion.Db.AUTONUMERACIONESCollection.GetRow(Id_NombreCol + " = " + autonumeracion_id);
            bool usoExclusivo = row.FUNCIONARIO_USO_EXCLUSIVO == Definiciones.SiNo.Si && 
                                row.IsFUNCIONARIO_IDNull == false;

            //No es de uso exclusivo o el funcionario es el asignado a la autonumeracion
            return !usoExclusivo || row.FUNCIONARIO_ID == funcionario_id;
        }
        #endregion FuncionarioPuedeUsar

        #region GetAutonumeracionesPorIP
        /// <summary>
        /// Gets the autonumeraciones.
        /// </summary>
        /// <param name="IP">La ip de la maquina</param>
       
        /// <returns></returns>
        /// 
        public decimal GetAutonumeracionesPorIP (string IP)
        {
            try 
	        {	        
        		using (SessionService sesion = new SessionService())
                {
                    DataTable dt = sesion.db.EjecutarQuery("select c.autonumeracion_id from caja_fisica_talonario c where c.IP like '"+ IP+"'");
                    if (dt.Rows.Count == 1)

                        return decimal.Parse(dt.Rows[0][0].ToString());
                    else
                        return Definiciones.Error.Valor.EnteroPositivo;
                    
                    
                }
	        }
	        catch (Exception)
	        {
        		
		        throw;
	        }
            
        }

        #endregion GetAutonumeracionesPorIP


        #region GetAutonumeracionesPorTabla
        /// <summary>
        /// Gets the autonumeraciones por tabla.
        /// </summary>
        /// <param name="tabla_id">The tabla_id.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetAutonumeracionesPorTabla(string tabla_id)
        {
            return GetAutonumeracionesPorTabla(tabla_id, Definiciones.Error.Valor.EnteroPositivo);
        }
        public static DataTable GetAutonumeracionesPorTabla2(string tabla_id)
        {
            return GetAutonumeracionesPorTabla2(tabla_id, Definiciones.Error.Valor.EnteroPositivo);
        }

        /// <summary>
        /// Gets the autonumeraciones por tabla.
        /// </summary>
        /// <param name="tabla_id">The tabla_id.</param>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetAutonumeracionesPorTabla(string tabla_id, decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                               AutonumeracionesService.TablaId_NombreCol + " = '" + tabla_id + "' ";

                if (!sucursal_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    where += " and " + AutonumeracionesService.SucursalId_NombreCol + " = " + sucursal_id;

                return sesion.Db.AUTONUMERACIONESCollection.GetAsDataTable(where, "upper(" + Codigo_NombreCol + ")");
            }
        }

        public static DataTable GetAutonumeracionesPorTabla2(string tabla_id, decimal sucursal_id)
        {
            return GetAutonumeracionesPorTabla2(tabla_id, sucursal_id, string.Empty);
        }

        public static DataTable GetAutonumeracionesPorTabla2(string tabla_id, decimal sucursal_id, SessionService sesion)
        {
            return GetAutonumeracionesPorTabla2(tabla_id, sucursal_id, string.Empty, string.Empty, sesion);
        }

        public static DataTable GetAutonumeracionesPorTabla2(string tabla_id, decimal sucursal_id, string clausulas)
        {
            return GetAutonumeracionesPorTabla2(tabla_id, sucursal_id, clausulas, "upper(" + Codigo_NombreCol + ")");
        }

        public static DataTable GetAutonumeracionesPorTabla2(string tabla_id, decimal sucursal_id, string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAutonumeracionesPorTabla2(tabla_id, sucursal_id, clausulas, orden, sesion);
            }
        }

        public static DataTable GetAutonumeracionesPorTabla2(string tabla_id, decimal sucursal_id, string clausulas, string orden, SessionService sesion)
        {
            string where = AutonumeracionesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                           AutonumeracionesService.FechaAgotoNumeracion_NombreCol + " is null and " +
                           AutonumeracionesService.TablaId_NombreCol + " = '" + tabla_id + "' ";

            if (!sucursal_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
            {
                where += " and( " + AutonumeracionesService.SucursalId_NombreCol + " = " + sucursal_id;
                where += " or " + AutonumeracionesService.SucursalId_NombreCol + " is null) ";
            }

            if (clausulas.Length > 0)
                where += " and " + clausulas;

            return sesion.Db.AUTONUMERACIONESCollection.GetAsDataTable(where, orden);
        }
        #endregion GetAutonumeracionesPorTabla

        #region GetAutonumeracionesPorFlujo
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetAutonumeracionesPorFlujo(decimal flujo_id)
        {
            return GetAutonumeracionesPorFlujo(flujo_id, Definiciones.Error.Valor.EnteroPositivo);
        }
        public static DataTable GetAutonumeracionesPorFlujo2(decimal flujo_id)
        {
            return GetAutonumeracionesPorFlujo2(flujo_id, Definiciones.Error.Valor.EnteroPositivo);
        }

        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetAutonumeracionesPorFlujo(decimal flujo_id, decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = AutonumeracionesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                               AutonumeracionesService.FlujoId_NombreCol + " = " + flujo_id;

                if (!sucursal_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    where += " and (" + AutonumeracionesService.SucursalId_NombreCol + " = " + sucursal_id +
                             "      or " + AutonumeracionesService.SucursalId_NombreCol + " is null)";
                }

                return sesion.Db.AUTONUMERACIONESCollection.GetAsDataTable(where, AutonumeracionesService.Codigo_NombreCol);
            }
        }
        public static DataTable GetAutonumeracionesPorFlujo2(decimal flujo_id, decimal? sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAutonumeracionesPorFlujo2(flujo_id, sucursal_id, AutonumeracionesService.Codigo_NombreCol, sesion);
            }
        }

        public static DataTable GetAutonumeracionesPorFlujo2(decimal flujo_id, decimal? sucursal_id, SessionService sesion)
        {
            return GetAutonumeracionesPorFlujo2(flujo_id, sucursal_id, AutonumeracionesService.Codigo_NombreCol, sesion);
        }

        public static DataTable GetAutonumeracionesPorFlujo2(decimal flujo_id, decimal? sucursal_id, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAutonumeracionesPorFlujo2(flujo_id, sucursal_id, orden, sesion);
            }
        }

        public static DataTable GetAutonumeracionesPorFlujo2(decimal flujo_id, decimal? sucursal_id, string orden, SessionService sesion)
        {
            string where = AutonumeracionesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                           AutonumeracionesService.FlujoId_NombreCol + " = " + flujo_id;

            if (!sucursal_id.HasValue)
            {
                where += " and " + AutonumeracionesService.SucursalId_NombreCol + " is null";
            }
            else if (sucursal_id.Value != Definiciones.Error.Valor.EnteroPositivo)
            {
                where += " and (" + AutonumeracionesService.SucursalId_NombreCol + " = " + sucursal_id.Value;
                where += " or " + AutonumeracionesService.SucursalId_NombreCol + " is null)";
            }

            return sesion.Db.AUTONUMERACIONESCollection.GetAsDataTable(where, orden);
        }
        #endregion GetAutonumeracionesPorFlujo

        #region Obtener siguiente numero de autonumeracion
        public static string GetSiguienteNumero2(decimal autonumeracion_id, SessionService sesion)
        {
            decimal aux;
            return GetSiguienteNumero2(autonumeracion_id, out aux, sesion);
        }

        /// <summary>
        /// Gets the siguiente numero2.
        /// </summary>
        /// <param name="autonumeracion_id">The autonumeracion_id.</param>
        /// <param name="numero">The numero.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static string GetSiguienteNumero2(decimal autonumeracion_id, out decimal numero, SessionService sesion)
        {
            string resultado = "";

            try
            {
                AUTONUMERACIONESRow autonumRow = sesion.Db.AUTONUMERACIONESCollection.GetByPrimaryKey(autonumeracion_id);

                /*if (autonumRow.TIPO_GENERACION != Definiciones.TiposGeneracionAutonumeraciones.Automatico_Nombre)
                    throw new Exception("La autonumeración no es automática.");*/

                #region validar que se puede utilizar la autonumeracion
                //Se controla que la autonumeracion se encuentre activa
                if (autonumRow.ESTADO.Equals(Definiciones.Estado.Inactivo))
                {
                    throw new Exception("Error. La autonumeración elegida se encuentra inactiva.");
                }

                //Se controla que la autonumeracion no se haya agotado
                if (!autonumRow.IsFECHA_AGOTO_NUMERACIONNull)
                {
                    throw new Exception("Error. La autonumeración elegida se encuentra agotada.");
                }

                //Se controla que el timbrado no este vencido
                if (!autonumRow.IsVENCIMIENTONull && autonumRow.VENCIMIENTO.Date < System.DateTime.Now.Date)
                {
                    throw new Exception("Error. El timbrado de la autonumeración elegida se encuentra vencido.");
                }
                #endregion validar que se puede utilizar la autonumeracion

                #region armado del siguiente numero
                //Se arma el siguiente numero
                resultado = autonumRow.PREFIJO;
                resultado += autonumRow.NUMERO_ACTUAL.ToString().PadLeft((int)Math.Round(autonumRow.CANTIDAD_CARACTERES), '0');
                resultado += autonumRow.SUFIJO;
                numero = autonumRow.NUMERO_ACTUAL;
                #endregion armado del siguiente numero

                //Si se llego al numero maximo, se indica como agotada
                if (autonumRow.NUMERO_ACTUAL >= autonumRow.LIMITE_SUPERIOR)
                {
                    autonumRow.FECHA_AGOTO_NUMERACION = System.DateTime.Now;
                    autonumRow.ESTADO = Definiciones.Estado.Inactivo;
                }

                //Se avanza en la numeracion
                autonumRow.NUMERO_ACTUAL += 1;

                //Se actualiza la autonumeracion
                sesion.Db.AUTONUMERACIONESCollection.Update(autonumRow);
            }
            catch
            {
                throw;
            }

            return resultado;
        }
        public static string GetSiguienteNumero2(decimal autonumeracion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal n;
                return GetSiguienteNumero2(autonumeracion_id, out n, sesion);
            }
        }
        #endregion Obtener siguiente numero de autonumeracion

        #region GetTipoGeneracion
        public static String GetTipoGeneracion(decimal autonumeracion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = AutonumeracionesService.Id_NombreCol + " = " + autonumeracion_id;

                return sesion.Db.AUTONUMERACIONESCollection.GetAsDataTable(where, AutonumeracionesService.Codigo_NombreCol).Rows[0][AutonumeracionesService.TipoGeneracion_NombreCol].ToString();
            }
        }
        #endregion GetTipoGeneracion

        #region EsAutoGeneracionPorFamilia
        /// <summary>
        /// Eses the imprimible.
        /// </summary>
        /// <param name="autonumeracion_id">The autonumeracion_id.</param>
        /// <returns></returns>
        public static bool EsAutoGeneracionPorFamilia(decimal autonumeracion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                AUTONUMERACIONESRow row = sesion.Db.AUTONUMERACIONESCollection.GetRow(Id_NombreCol + " = " + autonumeracion_id);
                return !row.ARTICULOS_FAMILIA_ID.Equals(System.DBNull.Value);
            }
        }
        #endregion EsAutoGeneracionPorFamilia

        #region GetPrefijo
        public static String GetPrefijo(decimal autonumeracion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPrefijo(autonumeracion_id, sesion);
            }
        }
        public static String GetPrefijo(decimal autonumeracion_id, SessionService sesion)
        {

            AUTONUMERACIONESRow row = sesion.db.AUTONUMERACIONESCollection.GetByPrimaryKey(autonumeracion_id);

            if (row != null)
            { 
                return row.PREFIJO;
            }
            return string.Empty;
        }
        #endregion GetPrefijo

        #region GetCantidadCaracteres
        public static decimal GetCantidadCaracteres(decimal autonumeracion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCantidadCaracteres(autonumeracion_id, sesion);
            }
        }
        public static decimal GetCantidadCaracteres(decimal autonumeracion_id, SessionService sesion)
        {

            AUTONUMERACIONESRow row = sesion.db.AUTONUMERACIONESCollection.GetByPrimaryKey(autonumeracion_id);

            if (row != null)
            {
                return row.CANTIDAD_CARACTERES;
            }
            return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion GetPrefijo

        #region GetAutonumeracionesDataTable
        /// <summary>
        /// Gets the autonumeraciones.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        /// 
        public static DataTable GetAutonumeracionesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = GetAutonumeracionesDataTable(clausulas, orden, sesion);
                return dt;
            }
        }

        public static DataTable GetAutonumeracionesDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = AutonumeracionesService.Entidad_Id_NombreCol + " = " + sesion.Entidad.ID;
            if (clausulas.Length > 0) where += " and " + clausulas;

            return sesion.Db.AUTONUMERACIONESCollection.GetAsDataTable(where, orden);
        }
        #endregion GetAutonumeracionesDataTable

        #region GetAutonumeracionesInfoCompleta
        public static DataTable GetAutonumeracionesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = AutonumeracionesService.Entidad_Id_NombreCol + " = " + sesion.Entidad.ID;
                if (clausulas.Length > 0) where += " and " + clausulas;

                return sesion.Db.AUTONUMERACIONES_INFO_COMPLETACollection.GetAsDataTable(where, orden);
            }
        }
        /// <summary>
        /// Gets the autonumeraciones info completa.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAutonumeracionesInfoCompleta()
        { //1 Referencia
            using (SessionService sesion = new SessionService())
            {
                string clausula = AutonumeracionesService.Entidad_Id_NombreCol + " = " + sesion.Entidad.ID;
                return sesion.Db.AUTONUMERACIONES_INFO_COMPLETACollection.GetAsDataTable(clausula, AutonumeracionesService.Id_NombreCol);
            }
        }
        #endregion GetAutonumeracionesInfoCompleta

        #region ActualizarFechaFinTalonario
        public static void ActualizarFechaFinTalonario(decimal ctacte_recibo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    AUTONUMERACIONESRow row = sesion.db.AUTONUMERACIONESCollection.GetByPrimaryKey(ctacte_recibo_id);

                    if (row == null)
                        return;

                    row.FECHA_AGOTO_NUMERACION = DateTime.Now.Date;
                    sesion.db.BeginTransaction();
                    sesion.db.AUTONUMERACIONESCollection.Update(row);
                    sesion.db.CommitTransaction();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion ActualizarFechaFinTalonario

        #region ActualizarNumeroActual
        /// <summary>
        /// Actualizars the fecha fin talonario.
        /// </summary>
        /// <param name="autonumeracion_id">The autonumeracion_id.</param>
        /// <param name="ultimo_utilizado">The ultimo_utilizado.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarNumeroActual(decimal autonumeracion_id, decimal ultimo_utilizado, SessionService sesion)
        {
            try
            {
                AUTONUMERACIONESRow row = sesion.db.AUTONUMERACIONESCollection.GetByPrimaryKey(autonumeracion_id);

                if (row.IsFECHA_AGOTO_NUMERACIONNull && (ultimo_utilizado + 1) <= row.LIMITE_SUPERIOR)
                    row.NUMERO_ACTUAL = ultimo_utilizado + 1;

                sesion.db.AUTONUMERACIONESCollection.Update(row);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion ActualizarNumeroActual

        #region GetAutonumeracionPorId
        public static DataTable GetAutonumeracionPorId(decimal autonumeracion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = AutonumeracionesService.Id_NombreCol + " = " + autonumeracion_id;
                return sesion.Db.AUTONUMERACIONESCollection.GetAsDataTable(where, AutonumeracionesService.Codigo_NombreCol);
            }
        }
        #endregion GetAutonumeracionPorId

        #region Consultar la siguiente numeración sin actualizar
        /// <summary>
        /// Consultars the siguiente numero.
        /// </summary>
        /// <param name="autonumeracion_id">The autonumeracion_id.</param>
        /// <returns></returns>
        public static string ConsultarSiguienteNumero(decimal autonumeracion_id)
        {
            return ConsultarSiguienteNumero(autonumeracion_id, new SessionService());
        }

        /// <summary>
        /// Consultars the siguiente numero.
        /// </summary>
        /// <param name="autonumeracion_id">The autonumeracion_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static string ConsultarSiguienteNumero(decimal autonumeracion_id, SessionService sesion)
        {
            string resultado = "";
            try
            {
                AUTONUMERACIONESRow autonumRow = sesion.Db.AUTONUMERACIONESCollection.GetByPrimaryKey(autonumeracion_id);

                #region validar que se puede utilizar la autonumeracion
                //Se controla que la autonumeracion se encuentre activa
                if (autonumRow.ESTADO.Equals(Definiciones.Estado.Inactivo))
                {
                    throw new Exception("Error. La autonumeración elegida se encuentra inactiva.");
                }

                //Se controla que la autonumeracion no se haya agotado
                if (!autonumRow.IsFECHA_AGOTO_NUMERACIONNull)
                {
                    throw new Exception("Error. La autonumeración elegida se encuentra agotada.");
                }

                //Se controla que el timbrado no este vencido
                if (!autonumRow.IsVENCIMIENTONull && autonumRow.VENCIMIENTO.Date < System.DateTime.Now.Date)
                {
                    throw new Exception("Error. El timbrado de la autonumeración elegida se encuentra vencido.");
                }
                #endregion validar que se puede utilizar la autonumeracion

                #region armado del siguiente numero
                //Se arma el siguiente numero
                resultado = autonumRow.PREFIJO;
                resultado += autonumRow.NUMERO_ACTUAL.ToString().PadLeft((int)Math.Round(autonumRow.CANTIDAD_CARACTERES), '0');
                resultado += autonumRow.SUFIJO;
                #endregion armado del siguiente numero
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return resultado;
        }
        #endregion Consultar la siguiente numeración sin actualizar

        #region ActualizarAutonumeracionSiguiente
        private static void ActualizarAutonumeracionSiguiente(decimal autonumeracion_id, decimal autonumeracion_siguiente_id, SessionService sesion)
        {
            // si hay alguna autonumeracion que tiene a autonumeracion_siguiente_id como siguiente, se borra 
            AUTONUMERACIONESRow[] rowAnterior = sesion.db.AUTONUMERACIONESCollection.GetByAUTONUMERACION_SIGUIENTE_ID(autonumeracion_siguiente_id);
            if (rowAnterior.Length > 0)
            {
                rowAnterior[0].IsAUTONUMERACION_SIGUIENTE_IDNull = true;
                sesion.db.AUTONUMERACIONESCollection.Update(rowAnterior[0]);
            }

            // se asigna autonumeracion_siguiente_id como siguiente de autonumeracion_id
            AUTONUMERACIONESRow row = sesion.db.AUTONUMERACIONESCollection.GetByPrimaryKey(autonumeracion_id);
            row.AUTONUMERACION_SIGUIENTE_ID = autonumeracion_siguiente_id;
            sesion.db.AUTONUMERACIONESCollection.Update(row);
        }

        public static void ActualizarAutonumeracionSiguiente(decimal autonumeracion_id, decimal autonumeracion_siguiente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    ActualizarAutonumeracionSiguiente(autonumeracion_id, autonumeracion_siguiente_id, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion ActualizarAutonumeracionSiguiente

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// 
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal id = Guardar(campos, insertarNuevo, sesion);
                    sesion.CommitTransaction();
                    return id;
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                AUTONUMERACIONESRow row = new AUTONUMERACIONESRow();
                string valorAnterior = string.Empty;
                bool puedeModificarValorActual = RolesService.Tiene("AUTONUMERACIONES CAMBIAR VALOR ACTUAL");
                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("autonumeraciones_sqc");
                    row.ENTIDAD_ID = sesion.Entidad.ID;
                    row.FECHA_CREACION = DateTime.Now;

                    //Una vez creada la autonumeracion no pueden modificarse los limites ni el numero actual
                    row.LIMITE_INFERIOR = (decimal)campos[LimiteInferior_NombreCol];
                    row.LIMITE_SUPERIOR = (decimal)campos[LimiteSuperior_NombreCol];
                    row.CANTIDAD_CARACTERES = (decimal)campos[CantidadCaracteres_NombreCol];
                    row.NUMERO_ACTUAL = row.LIMITE_INFERIOR;

                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }
                else
                {
                    row = sesion.Db.AUTONUMERACIONESCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }
                if (campos[ArticululosFamiliaId_NombreCol] != null) row.ARTICULOS_FAMILIA_ID = (decimal)campos[ArticululosFamiliaId_NombreCol];
                if (!ValidarDuplicado(row.ID, campos, sesion))
                    return Definiciones.Error.Valor.EnteroPositivo;

                row.TIPO_AUTONUMERACION_ID = (decimal)campos[TipoAutonumeracionId_NombreCol];
                if (campos.Contains(SucursalId_NombreCol))
                if (campos[SucursalId_NombreCol] != null) row.SUCURSAL_ID = (decimal)campos[SucursalId_NombreCol];
                else row.IsSUCURSAL_IDNull = true;

                if (campos[TablaId_NombreCol] != null) row.TABLA_ID = (string)campos[TablaId_NombreCol];
                
                row.CANTIDAD_CARACTERES = (decimal)campos[CantidadCaracteres_NombreCol];
                if (campos.Contains(LimiteInferior_NombreCol))
                    row.LIMITE_INFERIOR = (decimal)campos[LimiteInferior_NombreCol];
                if (campos.Contains(LimiteSuperior_NombreCol))
                    row.LIMITE_SUPERIOR = (decimal)campos[LimiteSuperior_NombreCol];

                if (puedeModificarValorActual)
                {
                    if (campos.Contains(NumeroActual_NombreCol))
                        row.NUMERO_ACTUAL = (decimal)campos[NumeroActual_NombreCol];
                }
                if (row.NUMERO_ACTUAL > row.LIMITE_SUPERIOR || row.NUMERO_ACTUAL < row.LIMITE_INFERIOR)
                {
                    throw new Exception("El número actual debe estar entre los límites definidos.");
                }

                if (campos[FuncionarioId_NombreCol] != null) row.FUNCIONARIO_ID = (decimal)campos[FuncionarioId_NombreCol];
                else row.IsFUNCIONARIO_IDNull = true;

                if (campos[FlujoId_NombreCol] != null) row.FLUJO_ID = (decimal)campos[FlujoId_NombreCol];
                else row.IsFLUJO_IDNull = true;

                if (campos[TablaId_NombreCol] != null) row.TABLA_ID = (string)campos[TablaId_NombreCol];
                else row.TABLA_ID = string.Empty;

                if (!campos[NumeroTimbrado_NombreCol].Equals(string.Empty)) row.NUMERO_TIMBRADO = (string)campos[NumeroTimbrado_NombreCol];
                else row.NUMERO_TIMBRADO = string.Empty;

                if (campos[CtaCteBancariaId_NombreCol] != null) row.CTACTE_BANCARIA_ID = (decimal)campos[CtaCteBancariaId_NombreCol];
                else row.IsCTACTE_BANCARIA_IDNull = true;

                if (!campos[Sufijo_NombreCol].Equals(string.Empty)) row.SUFIJO = (string)campos[Sufijo_NombreCol];
                else row.SUFIJO = string.Empty;

                if (!campos[Prefijo_NombreCol].Equals(string.Empty)) row.PREFIJO = (string)campos[Prefijo_NombreCol];
                else row.PREFIJO = string.Empty;

                if (campos.Contains(Codigo_NombreCol))
                    row.CODIGO = campos[Codigo_NombreCol].ToString();
                else
                    row.CODIGO = string.Empty;

                if (campos.Contains(NumeroTimbrado_NombreCol))
                    row.NUMERO_TIMBRADO = campos[NumeroTimbrado_NombreCol].ToString();

                if (campos.Contains(Vencimiento_NombreCol))
                    row.VENCIMIENTO = (DateTime)campos[Vencimiento_NombreCol];
                else
                    row.IsVENCIMIENTONull = true;

                if (campos.Contains(FechaInicio_NombreCol))
                    row.FECHA_INICIO = (DateTime)campos[FechaInicio_NombreCol];
                else
                    row.IsFECHA_INICIONull = true;

                if (campos.Contains(ImpresionDeltaAltura_NombreCol))
                    row.IMPRESION_DELTA_ALTURA = (decimal)campos[ImpresionDeltaAltura_NombreCol];
                else
                    row.IMPRESION_DELTA_ALTURA = 0;

                if (campos.Contains(ImpresionDeltaAncho_NombreCol))
                    row.IMPRESION_DELTA_ANCHO = (decimal)campos[ImpresionDeltaAncho_NombreCol];
                else
                    row.IMPRESION_DELTA_ANCHO = 0;

                if (campos.Contains(DetallesCantidadMaxima_NombreCol))
                    row.DETALLES_CANTIDAD_MAXIMA = (decimal)campos[DetallesCantidadMaxima_NombreCol];
                else 
                    row.IsDETALLES_CANTIDAD_MAXIMANull = true;

                row.FUNCIONARIO_USO_EXCLUSIVO = (string)campos[FuncionarioUsoExclusivo_NombreCol];
                row.ESTADO = (string)campos[Estado_NombreCol];
                row.IMPRIMIBLE = (string)campos[Imprimible_NombreCol];
                row.ELECTRONICO = (string)campos[Electronico_NombreCol];

                row.USUARIO_CREACION_ID = sesion.Usuario_Id;
                if (campos[TipoGeneracion_NombreCol] != null) row.TIPO_GENERACION = campos[TipoGeneracion_NombreCol].ToString();

                if (insertarNuevo)
                    sesion.Db.AUTONUMERACIONESCollection.Insert(row);
                else
                    sesion.Db.AUTONUMERACIONESCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                if (campos.Contains(AutonumeracionSiguienteID_NombreCol))
                    ActualizarAutonumeracionSiguiente((decimal)campos[AutonumeracionSiguienteID_NombreCol], row.ID, sesion);

                return row.ID;
            }
            catch (OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                        throw new System.ArgumentException("Ya existe esta autonumeración", exp);
                    default:
                        throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Guardar

        #region ValidarDuplicado
        public static bool ValidarDuplicado(decimal autonumeracion_id, Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                return ValidarDuplicado(autonumeracion_id, campos, sesion);
            }
        }
        public static bool ValidarDuplicado(decimal autonumeracion_id, Hashtable campos, SessionService sesion)
        {
            string clausulasValidacion = AutonumeracionesService.Codigo_NombreCol + " = '" + campos[AutonumeracionesService.Codigo_NombreCol] + "' and " +
                                         AutonumeracionesService.LimiteInferior_NombreCol + " = " + campos[AutonumeracionesService.LimiteInferior_NombreCol] + " and " +
                                         AutonumeracionesService.LimiteSuperior_NombreCol + " = " + campos[AutonumeracionesService.LimiteSuperior_NombreCol] + " and " +
                                         AutonumeracionesService.TipoAutonumeracionId_NombreCol + " = " + campos[AutonumeracionesService.TipoAutonumeracionId_NombreCol] + " and " +
                                         AutonumeracionesService.Id_NombreCol + " <> " + autonumeracion_id;

            if (!Interprete.EsNullODBNull(campos[AutonumeracionesService.TablaId_NombreCol]))
                clausulasValidacion += " and " + AutonumeracionesService.TablaId_NombreCol + " = '" + campos[AutonumeracionesService.TablaId_NombreCol] + "'";
            if (!Interprete.EsNullODBNull(campos[AutonumeracionesService.FlujoId_NombreCol]))
                clausulasValidacion += " and " + AutonumeracionesService.FlujoId_NombreCol + " = " + campos[AutonumeracionesService.FlujoId_NombreCol];

            DataTable dtValidacion = GetAutonumeracionesDataTable(clausulasValidacion, string.Empty);
            if (dtValidacion.Rows.Count > 0)
                throw new Exception("Ya existe otro talonario con igual código y límites inferior y superior.");

            return true;
        }
        #endregion ValidarDuplicado

        #region Nombre de Columnas
        public static string Nombre_Tabla
        {
            get { return "AUTONUMERACIONES"; }
        }
        public static string CtaCteBancariaId_NombreCol
        {
            get { return AUTONUMERACIONESCollection.CTACTE_BANCARIA_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return AUTONUMERACIONESCollection.ESTADOColumnName; }
        }
        public static string Codigo_NombreCol
        {
            get { return AUTONUMERACIONESCollection.CODIGOColumnName; }
        }
        public static string Entidad_Id_NombreCol
        {
            get { return AUTONUMERACIONESCollection.ENTIDAD_IDColumnName; }
        }
        public static string FechaAgotoNumeracion_NombreCol
        {
            get { return AUTONUMERACIONESCollection.FECHA_AGOTO_NUMERACIONColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return AUTONUMERACIONESCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return AUTONUMERACIONESCollection.FECHA_INICIOColumnName; }
        }
        public static string FlujoId_NombreCol
        {
            get { return AUTONUMERACIONESCollection.FLUJO_IDColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return AUTONUMERACIONESCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string FuncionarioUsoExclusivo_NombreCol
        {
            get { return AUTONUMERACIONESCollection.FUNCIONARIO_USO_EXCLUSIVOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return AUTONUMERACIONESCollection.IDColumnName; }
        }
        public static string ImpresionDeltaAltura_NombreCol
        {
            get { return AUTONUMERACIONESCollection.IMPRESION_DELTA_ALTURAColumnName; }
        }
        public static string ImpresionDeltaAncho_NombreCol
        {
            get { return AUTONUMERACIONESCollection.IMPRESION_DELTA_ANCHOColumnName; }
        }
        public static string Imprimible_NombreCol
        {
            get { return AUTONUMERACIONESCollection.IMPRIMIBLEColumnName; }
        }
        public static string LimiteInferior_NombreCol
        {
            get { return AUTONUMERACIONESCollection.LIMITE_INFERIORColumnName; }
        }
        public static string LimiteSuperior_NombreCol
        {
            get { return AUTONUMERACIONESCollection.LIMITE_SUPERIORColumnName; }
        }
        public static string NumeroActual_NombreCol
        {
            get { return AUTONUMERACIONESCollection.NUMERO_ACTUALColumnName; }
        }
        public static string Prefijo_NombreCol
        {
            get { return AUTONUMERACIONESCollection.PREFIJOColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return AUTONUMERACIONESCollection.SUCURSAL_IDColumnName; }
        }
        public static string Sufijo_NombreCol
        {
            get { return AUTONUMERACIONESCollection.SUFIJOColumnName; }
        }
        public static string TablaId_NombreCol
        {
            get { return AUTONUMERACIONESCollection.TABLA_IDColumnName; }
        }
        public static string TipoAutonumeracionId_NombreCol
        {
            get { return AUTONUMERACIONESCollection.TIPO_AUTONUMERACION_IDColumnName; }
        }
        public static string TipoGeneracion_NombreCol
        {
            get { return AUTONUMERACIONESCollection.TIPO_GENERACIONColumnName; }
        }
        public static string UsuarioCreacionId_NombreCol
        {
            get { return AUTONUMERACIONESCollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string Vencimiento_NombreCol
        {
            get { return AUTONUMERACIONESCollection.VENCIMIENTOColumnName; }
        }
        public static string CantidadCaracteres_NombreCol
        {
            get { return AUTONUMERACIONESCollection.CANTIDAD_CARACTERESColumnName; }
        }
        public static string AutonumeracionSiguienteID_NombreCol
        {
            get { return AUTONUMERACIONESCollection.AUTONUMERACION_SIGUIENTE_IDColumnName; }
        }
        public static string DetallesCantidadMaxima_NombreCol
        {
            get { return AUTONUMERACIONESCollection.DETALLES_CANTIDAD_MAXIMAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return AUTONUMERACIONES_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaFlujoDescripcion_NombreCol
        {
            get { return AUTONUMERACIONES_INFO_COMPLETACollection.FLUJO_DESCRIPCIONColumnName; }
        }
        public static string VistaTIPO_AUTONUMERACION_NOMBRE_NombreCol
        {
            get { return AUTONUMERACIONES_INFO_COMPLETACollection.TIPO_AUTONUMERACION_NOMBREColumnName; }
        }
        public static string VistaID_NombreCol
        {
            get { return AUTONUMERACIONES_INFO_COMPLETACollection.IDColumnName; }
        }
        public static string VistaCTACTE_NombreCol
        {
            get { return AUTONUMERACIONES_INFO_COMPLETACollection.CTACTEColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return AUTONUMERACIONES_INFO_COMPLETACollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaFuncionarioCodigo_NombreCol
        {
            get { return AUTONUMERACIONES_INFO_COMPLETACollection.FUNCIONARIO_CODIGOColumnName; }
        }
        public static string VistaEntidadNombre_NombreCol
        {
            get { return AUTONUMERACIONES_INFO_COMPLETACollection.ENTIDAD_NOMBREColumnName; }
        }
        public static string NumeroTimbrado_NombreCol
        {
            get { return AUTONUMERACIONES_INFO_COMPLETACollection.NUMERO_TIMBRADOColumnName; }
        }
        public static string Electronico_NombreCol
        {
            get { return AUTONUMERACIONES_INFO_COMPLETACollection.ELECTRONICOColumnName; }
        }
        public static string ArticululosFamiliaId_NombreCol
        {
            get { return AUTONUMERACIONESCollection.ARTICULOS_FAMILIA_IDColumnName; }
        }
        public static string Familia_NombreCol
        {
            get { return AUTONUMERACIONES_INFO_COMPLETACollection.FAMILIAColumnName; }
        }

        #endregion Nombre de Columnas
    }
}
