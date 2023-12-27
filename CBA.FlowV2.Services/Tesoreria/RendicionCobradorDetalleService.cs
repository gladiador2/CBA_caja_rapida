#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.ToolbarFlujo;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class RendicionCobradorDetalleService 
    {
        public static DataTable GetRendicionCobradorDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.RENDICION_COBRADOR_DET_INFO_CCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static decimal GenerarPago(decimal rendicionCobradorDetalleId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    RENDICION_COBRADOR_DET_INFO_CRow detalleRow = sesion.Db.RENDICION_COBRADOR_DET_INFO_CCollection.GetRow(RendicionCobradorDetalleService.Id_NombreCol + " = " + rendicionCobradorDetalleId);
                    RENDICION_COBRADORRow cabeceraRow = sesion.Db.RENDICION_COBRADORCollection.GetByPrimaryKey(detalleRow.RENDICION_COBRADOR_ID);
                    CASOSRow casoRow = CasosService.GetCasoPorId(cabeceraRow.CASO_ID, sesion);
                    decimal funcinarioId = UsuariosService.GetFuncionarioId(casoRow.USUARIO_CREACION_ID);
                    decimal casoCreadoId = Definiciones.Error.Valor.EnteroPositivo;
                    string mensaje = string.Empty;
                    bool exito = false;

                    casoCreadoId = PagosDePersonaService.CrearCaso(cabeceraRow.SUCURSAL_ID,
                                                                   detalleRow.PERSONA_ID,
                                                                   cabeceraRow.FECHA,
                                                                   detalleRow.MONEDA_ID,
                                                                   funcinarioId,
                                                                   cabeceraRow.FUNCIONARIO_ID,
                                                                   detalleRow.RECIBO_ID,
                                                                   detalleRow.NRO_COMPROBANTE,
                                                                   detalleRow.AUTONUMERACION_ID,
                                                                   null,
                                                                   new decimal[] { detalleRow.MONTO },
                                                                   Definiciones.CuentaCorrienteValores.Efectivo,
                                                                   Definiciones.Error.Valor.EnteroPositivo,
                                                                   string.Empty,
                                                                   Definiciones.Error.Valor.EnteroPositivo, 
                                                                   true,
                                                                   cabeceraRow.CASO_ID,
                                                                   sesion);

                    if (detalleRow.ESTADO_RECIBO_ID.ToString().Equals(Definiciones.Estado.Inactivo))
                    {
                        exito = (new PagosDePersonaService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Anulado, false, out mensaje, sesion);
                        if (exito)
                            exito = (new ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Anulado, "Transición automática por generación de pago de personas con recibo anulado", sesion);
                        if (exito)
                            (new PagosDePersonaService()).EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Anulado, sesion);
                        if (!exito)
                            throw new Exception("Error en RendicionCobradorDetalleService.GenerarPago. " + mensaje + ".");
                    }

                    System.Collections.Hashtable campos = new System.Collections.Hashtable();

                    campos.Add(RendicionCobradorDetalleService.Id_NombreCol, detalleRow.ID);
                    campos.Add(RendicionCobradorDetalleService.CasoPago_NombreCol, casoCreadoId);

                    RendicionCobradorDetalleService.Guardar(campos, sesion);

                    sesion.CommitTransaction();
                    return casoCreadoId;

                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                RENDICION_COBRADOR_DETALLERow row = new RENDICION_COBRADOR_DETALLERow();

                if (!campos.Contains(Id_NombreCol))
                    row.ID = sesion.Db.GetSiguienteSecuencia("RENDICION_COBRADOR_DETALLE_SQC");
                else
                    row = sesion.Db.RENDICION_COBRADOR_DETALLECollection.GetByPrimaryKey(decimal.Parse(campos[RendicionCobradorDetalleService.Id_NombreCol].ToString()));

                if (campos.Contains(RendicionCobradorId_NombreCol))
                    row.RENDICION_COBRADOR_ID = (decimal)campos[RendicionCobradorDetalleService.RendicionCobradorId_NombreCol];

                if (campos.Contains(ReciboId_NombreCol))
                    row.RECIBO_ID = (decimal)campos[RendicionCobradorDetalleService.ReciboId_NombreCol];

                if (campos.Contains(CasoPago_NombreCol))
                    row.CASO_PAGO = (decimal)campos[RendicionCobradorDetalleService.CasoPago_NombreCol];

                if (campos.Contains(Id_NombreCol))
                    sesion.Db.RENDICION_COBRADOR_DETALLECollection.Update(row);
                else
                    sesion.Db.RENDICION_COBRADOR_DETALLECollection.Insert(row);
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
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                Guardar(campos, sesion);
            }
        }
        #endregion Guardar


        #region Borrar
        public static void Borrar(decimal rendicion_cobrador_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    RENDICION_COBRADOR_DETALLERow row = sesion.Db.RENDICION_COBRADOR_DETALLECollection.GetByPrimaryKey(rendicion_cobrador_detalle_id);
                    
                    sesion.Db.RENDICION_COBRADOR_DETALLECollection.DeleteByPrimaryKey(rendicion_cobrador_detalle_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    sesion.Db.CommitTransaction();
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

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "RENDICION_COBRADOR_DETALLE"; }
        }
        public static string Id_NombreCol
        {
            get { return RENDICION_COBRADOR_DETALLECollection.IDColumnName; }
        }
        public static string ReciboId_NombreCol
        {
            get { return RENDICION_COBRADOR_DETALLECollection.RECIBO_IDColumnName; }
        }
        public static string RendicionCobradorId_NombreCol
        {
            get { return RENDICION_COBRADOR_DETALLECollection.RENDICION_COBRADOR_IDColumnName; }
        }
        public static string CasoPago_NombreCol
        {
            get { return RENDICION_COBRADOR_DETALLECollection.CASO_PAGOColumnName; }
        }
        #endregion Tabla
      
        #region Vista
        public static string VistaFecha_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.FECHAColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaMonto_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.MONTOColumnName; }
        }
        public static string VistaNombreCompleto_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaNroComprobante_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaReciboId_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.RECIBO_IDColumnName; }
        }
        public static string VistaCantidadDecimales_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.CANTIDADES_DECIMALESColumnName; }
        }
        public static string VistaCadenaDecimales_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.CADENA_DECIMALESColumnName; }
        }
        public static string VistaPersonaId_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.PERSONA_IDColumnName; }
        }
        public static string VistaMonedaId_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.MONEDA_IDColumnName; }
        }
        public static string VistaAutonumeracionId_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string VistaCasoPago_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.CASO_PAGOColumnName; }
        }
        public static string VistaEstadoCaso_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.ESTADO_IDColumnName; }
        }
        public static string VistaEstadoRecibo_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.ESTADO_RECIBOColumnName; }
        }
        public static string VistaEstadoReciboId_NombreCol
        {
            get { return RENDICION_COBRADOR_DET_INFO_CCollection.ESTADO_RECIBO_IDColumnName; }
        }
        #endregion Vista

        #endregion Accessors
    }
}




