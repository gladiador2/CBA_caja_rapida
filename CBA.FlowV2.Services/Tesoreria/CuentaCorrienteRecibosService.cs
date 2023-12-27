using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;
using CBA.FlowV2.Services.Common;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteRecibosService
    {
        #region GetNumeroRecibo
        /// <summary>
        /// Gets the numero recibo.
        /// </summary>
        /// <param name="ctacte_recibo_id">The ctacte_recibo_id.</param>
        /// <returns></returns>
        public static string GetNumeroRecibo(decimal ctacte_recibo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNumeroRecibo(ctacte_recibo_id, sesion);
            }
        }

        /// <summary>
        /// Gets the numero recibo.
        /// </summary>
        /// <param name="ctacte_recibo_id">The ctacte_recibo_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static string GetNumeroRecibo(decimal ctacte_recibo_id, SessionService sesion)
        {
            return sesion.Db.CTACTE_RECIBOSCollection.GetByPrimaryKey(ctacte_recibo_id).NRO_COMPROBANTE;
        }
        #endregion GetNumeroRecibo

        #region GetImpreso
        public static string GetImpreso(decimal ctacte_recibo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetImpreso(ctacte_recibo_id, sesion);
            }
        }

        public static string GetImpreso(decimal ctacte_recibo_id, SessionService sesion)
        {
            return sesion.Db.CTACTE_RECIBOSCollection.GetByPrimaryKey(ctacte_recibo_id).IMPRESO;
        }
        #endregion GetNumeroRecibo

        #region GetCtacteReciboDataTable
        [Obsolete("Utilizar metodos estaticos")]
        /// <summary>
        /// Gets the ctacte recibo data table.
        /// </summary>
        /// <param name="ctacte_recibo_id">The ctacte_recibo_id.</param>
        /// <returns></returns>
        public DataTable GetCtacteReciboDataTable(decimal ctacte_recibo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCtacteReciboDataTable(ctacte_recibo_id, sesion);
            }
        }


        /// <summary>
        /// Gets the ctacte recibo data table.
        /// </summary>
        /// <param name="ctacte_recibo_id">The ctacte_recibo_id.</param>
        /// <returns></returns>
        public static DataTable GetCtacteReciboDataTable2(decimal ctacte_recibo_id)
        {
            using (SessionService sesion = new SessionService()) {
                return GetCtacteReciboDataTable2(ctacte_recibo_id, sesion);
            }
        }

        [Obsolete("utilizar metodos estaticos")]
        /// <summary>
        /// Gets the ctacte recibo data table.
        /// </summary>
        /// <param name="ctacte_recibo_id">The ctacte_recibo_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public DataTable GetCtacteReciboDataTable(decimal ctacte_recibo_id, SessionService sesion)
        {
            return sesion.Db.CTACTE_RECIBOSCollection.GetAsDataTable(CuentaCorrienteRecibosService.Id_NombreCol + " = " + ctacte_recibo_id, string.Empty);
        }
        /// <summary>
        /// Gets the ctacte recibo data table.
        /// </summary>
        /// <param name="ctacte_recibo_id">The ctacte_recibo_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetCtacteReciboDataTable2(decimal ctacte_recibo_id, SessionService sesion)
        {
            return sesion.Db.CTACTE_RECIBOSCollection.GetAsDataTable(CuentaCorrienteRecibosService.Id_NombreCol + " = " + ctacte_recibo_id, string.Empty);
        }

        public static DataTable GetCtacteReciboDataTable(string clausulas, SessionService sesion)
        {
            return sesion.Db.CTACTE_RECIBOSCollection.GetAsDataTable(clausulas, string.Empty);
        }
        public static DataTable GetCtacteReciboInfoCompletaDataTable(string clausulas)
        {
            using (SessionService sesion =new  SessionService())
            {
                return GetCtacteReciboInfoCompletaDataTable(clausulas, sesion);
            }
        }

        public static DataTable GetCtacteReciboInfoCompletaDataTable(string clausulas, SessionService sesion)
        {
            return sesion.Db.CTACTE_RECIBOS_INFO_COMPLETACollection.GetAsDataTable(clausulas, NroComprobanteSecuencia_NombreCol);
        }
        #endregion GetCtacteReciboDataTable       
         
        #region ExisteNumeroRecibo
        public static bool ExisteNroRecibo(decimal autonumeracion_id, string nro_recibo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                bool existe = false;
                string clausula;

                //Para consultar si el numero de recibo ya existe
                clausula = CuentaCorrienteRecibosService.AutonumeracionId_NombreCol + " = " + autonumeracion_id;
                clausula += " and " + CuentaCorrienteRecibosService.NroComprobante_NombreCol + " = '" + nro_recibo_id + "'";
                
                DataTable dtReciboExiste = sesion.Db.CTACTE_RECIBOSCollection.GetAsDataTable(clausula, string.Empty);
                
                if (dtReciboExiste.Rows.Count > 0)
                    existe = true;
                
                return existe;
            }
        }
        #endregion ExisteNumeroRecibo

        #region ActualizarNumeroRecibo
        /// <summary>
        /// Actualizars the numero recibo.
        /// </summary>
        /// <param name="ctacte_recibo_id">The ctacte_recibo_id.</param>
        /// <param name="nro_comprobante">The nro_comprobante.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarNumeroRecibo(decimal ctacte_recibo_id, string nro_comprobante, SessionService sesion)
        {
            CTACTE_RECIBOSRow row = sesion.db.CTACTE_RECIBOSCollection.GetByPrimaryKey(ctacte_recibo_id);

            if (row == null)
                return;

            row.NRO_COMPROBANTE = nro_comprobante;
            sesion.db.CTACTE_RECIBOSCollection.Update(row);
        }
        #endregion ActualizarNumeroRecibo
        
        #region Guardar
        public static void CambiarPersona(decimal nuevaPersona, decimal reciboId)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {

                    CTACTE_RECIBOSRow row = new CTACTE_RECIBOSRow();
                    row = sesion.Db.CTACTE_RECIBOSCollection.GetByPrimaryKey(reciboId);
                    string valorAnterior = string.Empty;

                    row.PERSONA_ID = nuevaPersona;

                    sesion.Db.CTACTE_RECIBOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }



        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns>El id del recibo</returns>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, bool realizarVerificaciones, decimal ctacte_pago_persona_id, SessionService sesion)
        {
            try
            {
                CTACTE_RECIBOSRow row = new CTACTE_RECIBOSRow();
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_recibos_sqc");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.IMPRESO = Definiciones.SiNo.No;
                    row.FECHA_CREACION = DateTime.Now;
                }
                else
                {
                    row = sesion.Db.CTACTE_RECIBOSCollection.GetRow(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + campos[CuentaCorrienteChequesRecibidosService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                if(campos.Contains(CuentaCorrienteRecibosService.AutonumeracionId_NombreCol))
                {
                    if (!AutonumeracionesService.EsGeneracionManual((decimal)campos[CuentaCorrienteRecibosService.AutonumeracionId_NombreCol]))
                    {
                        if (campos.Contains(CuentaCorrienteRecibosService.NroComprobanteSecuencia_NombreCol))
                            row.NRO_COMPROBANTE_SECUENCIA = (decimal)campos[CuentaCorrienteRecibosService.NroComprobanteSecuencia_NombreCol];
                    }
                    //Si cambia, se controla que la nueva se encuentre activa
                    if (row.IsAUTONUMERACION_IDNull || !row.AUTONUMERACION_ID.Equals((decimal)campos[CuentaCorrienteRecibosService.AutonumeracionId_NombreCol]))
                    {
                        if(realizarVerificaciones)
                        {
                            if (!AutonumeracionesService.EstaActivo((decimal)campos[CuentaCorrienteRecibosService.AutonumeracionId_NombreCol]))
                            {
                                throw new System.Exception("El tipo de talonario se encuentra inactivo.");
                            }
                            else
                            {
                                row.AUTONUMERACION_ID = (decimal)campos[CuentaCorrienteRecibosService.AutonumeracionId_NombreCol];
                            }
                        }
                        else
                        {
                            row.AUTONUMERACION_ID = (decimal)campos[CuentaCorrienteRecibosService.AutonumeracionId_NombreCol];
                        }
                    }
                }
                else
                {
                    row.IsAUTONUMERACION_IDNull = true;
                }

                row.ESTADO = (string)campos[CuentaCorrienteRecibosService.Estado_NombreCol];
                row.FECHA = (DateTime)campos[CuentaCorrienteRecibosService.Fecha_NombreCol];

                //Si cambia, se controla que la nueva se encuentre activa
                if (!row.MONEDA_ID.Equals((decimal)campos[CuentaCorrienteRecibosService.MonedaId_NombreCol]))
                {
                    if (!MonedasService.EstaActivo((decimal)campos[CuentaCorrienteRecibosService.MonedaId_NombreCol]))
                    {
                        throw new System.Exception("La moneda se encuentra inactiva.");
                    }
                    else
                    {
                        row.MONEDA_ID = (decimal)campos[CuentaCorrienteRecibosService.MonedaId_NombreCol];
                    }
                }

                if (!ctacte_pago_persona_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.MONTO = 0; //El monto se actualiza en ActualizarTotal
                else
                    row.MONTO = (decimal)campos[CuentaCorrienteRecibosService.Monto_NombreCol];

                row.NRO_COMPROBANTE = (string)campos[CuentaCorrienteRecibosService.NroComprobante_NombreCol];

                //Si cambia, se controla que la nueva se encuentre activa
                if (!row.PERSONA_ID.Equals((decimal)campos[CuentaCorrienteRecibosService.PersonaId_NombreCol]))
                {
                    if (!PersonasService.EstaActivo((decimal)campos[CuentaCorrienteRecibosService.PersonaId_NombreCol]))
                    {
                        throw new System.Exception("La persona se encuentra inactiva.");
                    }
                    else
                    {
                        row.PERSONA_ID = (decimal)campos[CuentaCorrienteRecibosService.PersonaId_NombreCol];
                    }
                }
            
                if (campos.Contains(CuentaCorrienteRecibosService.Impreso_NombreCol))
                    row.IMPRESO = (string)campos[CuentaCorrienteRecibosService.Impreso_NombreCol];
                
                if (insertarNuevo) sesion.Db.CTACTE_RECIBOSCollection.Insert(row);
                else sesion.Db.CTACTE_RECIBOSCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Anular
        /// <summary>
        /// Anulars the specified ctacte_recibo_id.
        /// </summary>
        /// <param name="ctacte_recibo_id">The ctacte_recibo_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Anular(decimal ctacte_recibo_id, SessionService sesion)
        {
            try
            {
                CTACTE_RECIBOSRow row = sesion.Db.CTACTE_RECIBOSCollection.GetByPrimaryKey(ctacte_recibo_id);
                string valorAnterior = row.ToString();

                row.ESTADO = Definiciones.Estado.Inactivo;
                row.NRO_COMPROBANTE += "-" + row.ID; //Permite que pueda crearse un nuevo recibo con mismo nro comprobante

                sesion.Db.CTACTE_RECIBOSCollection.Update(row);
                
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Anular

        #region ActulizarMonto
        public static void ActulizarMonto(decimal recibo_id,decimal monto, SessionService sesion)
        {
           
                CTACTE_RECIBOSRow row = sesion.Db.CTACTE_RECIBOSCollection.GetByPrimaryKey(recibo_id);
                string valorAnterior = row.ToString();

                row.MONTO  = monto;
                
                sesion.Db.CTACTE_RECIBOSCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
           
        }
        #endregion ActulizarMOnto

        #region ActualizarTotal
        /// <summary>
        /// Actualizars the total.
        /// </summary>
        /// <param name="pago_persona_id">The pago_persona_id.</param>
        public static void ActualizarTotal(DataTable dtPagoPersona, SessionService sesion)
        {
            //Si todavia no existe un recibo, se retorna
            if (dtPagoPersona.Rows[0][PagosDePersonaService.CtacteReciboId_NombreCol].Equals(DBNull.Value))
                return;

            CTACTE_RECIBOSRow row = sesion.db.CTACTE_RECIBOSCollection.GetByPrimaryKey((decimal)dtPagoPersona.Rows[0][PagosDePersonaService.CtacteReciboId_NombreCol]);
            
            string valorAnterior = row.ToString();
            decimal total = 0;

            if ((string)dtPagoPersona.Rows[0][PagosDePersonaService.ReciboEmitirPorDocumentos_NombreCol] == Definiciones.SiNo.Si)
            {
                decimal montoContado, montoCredito, montoFinanciero, montoRecargo;
                CuentaCorrientePagosPersonaDocumentoService.GetMontoTotal((decimal)dtPagoPersona.Rows[0][PagosDePersonaService.Id_NombreCol], out montoContado, out montoCredito, out montoFinanciero, out montoRecargo, sesion);


                decimal montoRecibo = montoCredito;

                if (dtPagoPersona.Rows[0][PagosDePersonaService.FCCliente1CompAutonId_NombreCol].Equals(DBNull.Value) && dtPagoPersona.Rows[0][PagosDePersonaService.FCCliente2CompAutonId_NombreCol].Equals(DBNull.Value))
                    montoRecibo = montoCredito + montoFinanciero + montoRecargo;

                total = montoRecibo;
            }
            else
            {
                bool excluirValores = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.PagoPersonasReciboExcluirValores, sesion).Equals(Definiciones.SiNo.Si);
                total = CuentaCorrientePagosPersonaDetalleService.CalcularValores(excluirValores, (decimal)dtPagoPersona.Rows[0][PagosDePersonaService.Id_NombreCol], (decimal)dtPagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol], (decimal)dtPagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol], sesion);
            }

            row.MONEDA_ID = (decimal)dtPagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol];
            row.FECHA = (DateTime)dtPagoPersona.Rows[0][PagosDePersonaService.Fecha_NombreCol];
            row.MONTO = total;
            row.PERSONA_ID = (decimal)dtPagoPersona.Rows[0][PagosDePersonaService.PersonaId_NombreCol];

            sesion.db.CTACTE_RECIBOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion ActualizarTotal

        #region CrearRecibo
        public static decimal CrearRecibo(decimal autonumeracion_id, string nro_comprobante_sin_prefijo, decimal persona_id, decimal moneda_id, decimal monto, DateTime fecha, string estado, out string mensaje)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    if (!AutonumeracionesService.EstaActivo(autonumeracion_id))
                        throw new Exception("La autonumeración no está activa.");

                    decimal ctacteReciboId = Definiciones.Error.Valor.EnteroPositivo;
                    decimal nroComprobanteDecimal = Definiciones.Error.Valor.EnteroPositivo;
                    mensaje = string.Empty;
                    DataTable dtAutonumeraciones = AutonumeracionesService.GetAutonumeracionesDataTable(AutonumeracionesService.Id_NombreCol + " = " + autonumeracion_id, string.Empty);
                    string prefijo = string.Empty, sufijo = string.Empty;
                    Hashtable campos = new Hashtable();

                    if (dtAutonumeraciones.Rows.Count != 1)
                        throw new Exception("La autonumeración no es válida");

                    if (!Interprete.EsNullODBNull(dtAutonumeraciones.Rows[0][AutonumeracionesService.Prefijo_NombreCol]))
                        prefijo = (string)dtAutonumeraciones.Rows[0][AutonumeracionesService.Prefijo_NombreCol];
                    if (!Interprete.EsNullODBNull(dtAutonumeraciones.Rows[0][AutonumeracionesService.Sufijo_NombreCol]))
                        sufijo = (string)dtAutonumeraciones.Rows[0][AutonumeracionesService.Sufijo_NombreCol];

                    campos.Add(CuentaCorrienteRecibosService.AutonumeracionId_NombreCol, autonumeracion_id);
                    if(decimal.TryParse(nro_comprobante_sin_prefijo, out nroComprobanteDecimal))
                        campos.Add(CuentaCorrienteRecibosService.NroComprobanteSecuencia_NombreCol, nroComprobanteDecimal);
                    campos.Add(CuentaCorrienteRecibosService.NroComprobante_NombreCol, prefijo + nro_comprobante_sin_prefijo + sufijo);
                    campos.Add(CuentaCorrienteRecibosService.Estado_NombreCol, estado);
                    campos.Add(CuentaCorrienteRecibosService.Fecha_NombreCol, fecha);
                    campos.Add(CuentaCorrienteRecibosService.MonedaId_NombreCol, moneda_id);
                    campos.Add(CuentaCorrienteRecibosService.Monto_NombreCol, monto);
                    campos.Add(CuentaCorrienteRecibosService.PersonaId_NombreCol, persona_id);
                    ctacteReciboId = CuentaCorrienteRecibosService.Guardar(campos, true, true, Definiciones.Error.Valor.EnteroPositivo, sesion);

                    //Actualizar el numero actual de la autonumeracion
                    if (!nroComprobanteDecimal.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        AutonumeracionesService.ActualizarNumeroActual(autonumeracion_id, nroComprobanteDecimal, sesion);

                    return ctacteReciboId;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion CrearRecibo

        #region ActualizarImpreso
        public static void ActualizarImpreso(decimal recibo_id)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    CTACTE_RECIBOSRow row = sesion.Db.CTACTE_RECIBOSCollection.GetByPrimaryKey(recibo_id);
                    string valorAnterior = row.ToString();
                    row.IMPRESO = Definiciones.SiNo.Si;
                    sesion.Db.CTACTE_RECIBOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion ActualizarImpreso

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "CTACTE_RECIBOS"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return CTACTE_RECIBOSCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_RECIBOSCollection.ESTADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CTACTE_RECIBOSCollection.FECHAColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return CTACTE_RECIBOSCollection.FECHA_CREACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_RECIBOSCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_RECIBOSCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_RECIBOSCollection.MONTOColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return CTACTE_RECIBOSCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string NroComprobanteSecuencia_NombreCol
        {
            get { return CTACTE_RECIBOSCollection.NRO_COMPROBANTE_SECUENCIAColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CTACTE_RECIBOSCollection.PERSONA_IDColumnName; }
        }
        public static string Impreso_NombreCol
        {
            get { return CTACTE_RECIBOSCollection.IMPRESOColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string Nombre_Vista
        {
            get { return "ctacte_recibos_info_completa"; }
        }
        public static string VistaAutonumeracionCodigo_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.AUTONUMERACION_CODIGOColumnName; }
        }
        public static string VistaAutonumeracionFuncionarioCodigo_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.AUTONUMERACION_FUNC_CODIGOColumnName; }
        }
        public static string VistaAutonumeracionFuncionarioNombre_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.AUTONUMERACION_FUNC_NOMBREColumnName; }
        }
        public static string VistaAutonumeracionFuncionarioId_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.AUTONUMERACION_FUNCIOANRIO_IDColumnName; }
        }
        public static string VistaAutonumeracionSucursalAbreviatura_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.AUTONUMERACION_SUCURSAL_ABREColumnName; }
        }
        public static string VistaAutonumeracionSucursalId_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.AUTONUMERACION_SUCURSAL_IDColumnName; }
        }
        public static string VistaAutonumeracionSucursalNombre_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.AUTONUMERACION_SUCURSALColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.MONEDA_CANT_DECIMALESColumnName; }
        }
        public static string VistaMonedaFormatoDecimales_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.MONEDA_FORMATO_DECIMALESColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaPersonaCodigo_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.PERSONA_CODIGOColumnName; }
        }
        public static string VistaPersonaNroDoumento_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.PERSONA_DOCUMENTOColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaTipoClienteNombre_NombreCol
        {
            get { return CTACTE_RECIBOS_INFO_COMPLETACollection.TIPO_CLIENTES_NOMBREColumnName; }
        }
        
        #endregion Vista
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static CuentaCorrienteRecibosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new CuentaCorrienteRecibosService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable

        #region Propiedades
        protected CTACTE_RECIBOSRow row;
        protected CTACTE_RECIBOSRow rowSinModificar;
        public class Modelo : CTACTE_CONDICIONES_PAGOCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? AutonumeracionId { get { if (row.IsAUTONUMERACION_IDNull) return null; else return row.AUTONUMERACION_ID; } set { if (value.HasValue) row.AUTONUMERACION_ID = value.Value; else row.IsAUTONUMERACION_IDNull = true; } }
        public string Estado { get { return ClaseCBABase.GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public DateTime FechaCreacion { get { return row.FECHA_CREACION; } set { row.FECHA_CREACION = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Impreso { get { return ClaseCBABase.GetStringHelper(row.IMPRESO); } set { row.IMPRESO = value; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal Monto { get { return row.MONTO; } set { row.MONTO = value; } }
        public string NroComprobante { get { return ClaseCBABase.GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public decimal? NroComprobanteSecuencia { get { if (row.IsNRO_COMPROBANTE_SECUENCIANull) return null; else return row.NRO_COMPROBANTE_SECUENCIA; } set { if (value.HasValue) row.NRO_COMPROBANTE_SECUENCIA = value.Value; else row.IsNRO_COMPROBANTE_SECUENCIANull = true; } }
        public decimal PersonaId { get { return row.PERSONA_ID; } set { row.PERSONA_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = new MonedasService(this.MonedaId);
                return this._moneda;
            }
        }

        private PersonasService _persona;
        public PersonasService Persona
        {
            get
            {
                if (this._persona == null)
                    this._persona = new PersonasService(this.PersonaId);
                return this._persona;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_RECIBOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_RECIBOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public CuentaCorrienteRecibosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrienteRecibosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrienteRecibosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public CuentaCorrienteRecibosService(EdiCBA.Recibo edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion); 
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = CuentaCorrienteRecibosService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.Estado = edi.anulado ? Definiciones.Estado.Inactivo : Definiciones.Estado.Activo;
            this.Fecha = edi.fecha;
            this.FechaCreacion  = this.Fecha;
            this.Impreso  = Definiciones.SiNo.No;
            
            #region moneda
            if (!string.IsNullOrEmpty(edi.moneda_uuid))
                this._moneda = MonedasService.GetPorUUID(edi.moneda_uuid, sesion);
           
            if (this._moneda == null)
                throw new Exception("No se encontró el UUID " + edi.moneda_uuid + " ni se definieron los datos del objeto.");

            if (!this.Moneda.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Moneda.Id.HasValue)
                this.MonedaId = this.Moneda.Id.Value;
            #endregion moneda

            this.Monto = edi.monto;
            this.NroComprobante = edi.nro_comprobante;
            this.NroComprobanteSecuencia = edi.nro_comprobante_numerico;

            #region persona
            if (!string.IsNullOrEmpty(edi.persona_uuid))
                this._persona = PersonasService.GetPorUUID(edi.persona_uuid, sesion);
            if (this._persona == null && edi.persona != null)
                this._persona = new PersonasService(edi.persona, almacenar_localmente, sesion);
            if (this._persona == null)
                throw new Exception("No se encontró el UUID " + edi.persona_uuid + " ni se definieron los datos del objeto.");

            if (!this.Persona.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Persona.Id.HasValue)
                this.PersonaId = this.Persona.Id.Value;
            #endregion persona
        }
        #endregion Constructores

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);
            var e = new EdiCBA.Recibo()
            {
                anulado = this.Estado == Definiciones.Estado.Inactivo,
                persona_uuid = this.Persona.GetOrCreateUUID(sesion),
                fecha = this.Fecha,
                moneda_uuid = this.Moneda.GetOrCreateUUID(sesion),
                monto = this.Monto,
                nro_comprobante = this.NroComprobante,
                nro_comprobante_numerico = this.NroComprobanteSecuencia,
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.persona = (EdiCBA.Persona)this.Persona.ToEDI(nueva_profundidad, sesion);
                e.moneda = (EdiCBA.Moneda)this.Moneda.ToEDI(nueva_profundidad, sesion);
            }

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = this.GetOrCreateUUID(sesion);
            }
            return e;
        }
        #endregion ToEDI
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
