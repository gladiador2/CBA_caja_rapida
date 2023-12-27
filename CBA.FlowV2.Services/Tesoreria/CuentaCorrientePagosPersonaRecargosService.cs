#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasDebitoPersona;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrientePagosPersonaRecargosService
    {
        #region GetCuentaCorrientePagosPersonaRecargosDataTable
        /// <summary>
        /// Gets the cuenta corriente pagos persona recargos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaRecargosDataTable(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    string where = CuentaCorrientePagosPersonaRecargosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                    if (clausulas.Length > 0)
                        where += " and " + clausulas;

                    return sesion.Db.CTACTE_PAGOS_PERSONA_RECARGOCollection.GetAsDataTable(where, orden);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetCuentaCorrientePagosPersonaDocumentoDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        public static void Guardar(System.Collections.Hashtable campos, decimal ctacte_pago_persona_id)
        {
            Guardar(campos, ctacte_pago_persona_id, new SessionService());
        }

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        public static void Guardar(System.Collections.Hashtable campos, decimal ctacte_pago_persona_id, SessionService sesion)
        {
            CTACTE_PAGOS_PERSONA_RECARGORow row = new CTACTE_PAGOS_PERSONA_RECARGORow();

            try
            {
                string valorAnterior = Definiciones.Log.RegistroNuevo;

                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_pagos_persona_rec_sqc");
                row.ESTADO = Definiciones.Estado.Activo;
                row.COTIZACION = (decimal)campos[CuentaCorrientePagosPersonaRecargosService.Cotizacion_NombreCol];
                row.CTACTE_CONCEPTO_ID = (decimal)campos[CuentaCorrientePagosPersonaRecargosService.CtacteConceptoId_NombreCol];
                row.MONEDA_ID = (decimal)campos[CuentaCorrientePagosPersonaRecargosService.MonedaId_NombreCol];
                row.MONTO = (decimal)campos[CuentaCorrientePagosPersonaRecargosService.Monto_NombreCol];
                row.IMPUESTO_ID = (decimal)campos[CuentaCorrientePagosPersonaRecargosService.ImpuestoId_NombreCol];
                row.OBSERVACION = (string)campos[CuentaCorrientePagosPersonaRecargosService.Observacion_NombreCol];
                row.TIPO_RECARGO = (decimal)campos[CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol];

                if (campos.Contains(CuentaCorrientePagosPersonaRecargosService.CtactePagoPersonaDocId_NombreCol))
                    row.CTACTE_PAGO_PERSONA_DOC_ID = (decimal)campos[CuentaCorrientePagosPersonaRecargosService.CtactePagoPersonaDocId_NombreCol];
                else
                    row.IsCTACTE_PAGO_PERSONA_DOC_IDNull = true;

                if (campos.Contains(CuentaCorrientePagosPersonaRecargosService.CtactePagoPersonaCompEnId_NombreCol))
                    row.CTACTE_PAGO_PERSONA_COMP_EN_ID = (decimal)campos[CuentaCorrientePagosPersonaRecargosService.CtactePagoPersonaCompEnId_NombreCol];
                else
                    row.IsCTACTE_PAGO_PERSONA_COMP_EN_IDNull = true;

                sesion.Db.CTACTE_PAGOS_PERSONA_RECARGOCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                
                //Agregar documento al pago de personas si se indica el documento o no se indica documento ni compensacion
                if (!row.IsCTACTE_PAGO_PERSONA_DOC_IDNull)
                {
                    System.Collections.Hashtable camposDocumento = new System.Collections.Hashtable();
                    camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol, ctacte_pago_persona_id);
                    camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.CtactePagoPersonaRecargoId_NombreCol, row.ID);
                    camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.MonedaId_NombreCol, row.MONEDA_ID);
                    camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.CotizacionMoneda_NombreCol, row.COTIZACION);
                    camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol, row.MONTO);
                    camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.Observacion_NombreCol, row.OBSERVACION);

                    //Guardar los datos
                    CuentaCorrientePagosPersonaDocumentoService.Guardar(camposDocumento, false, sesion);
                }

                //Agregar documento a la compensacion
                if (!row.IsCTACTE_PAGO_PERSONA_COMP_EN_IDNull)
                {
                    System.Collections.Hashtable camposDocumento = new System.Collections.Hashtable();
                    camposDocumento.Add(CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePagosPersonaId_NombreCol, ctacte_pago_persona_id);
                    camposDocumento.Add(CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePagoPersonaRecargoId_NombreCol, row.ID);
                    camposDocumento.Add(CuentaCorrientePagosPersonaCompensacionEntradaService.MonedaId_NombreCol, row.MONEDA_ID);
                    camposDocumento.Add(CuentaCorrientePagosPersonaCompensacionEntradaService.CotizacionMoneda_NombreCol, row.COTIZACION);
                    camposDocumento.Add(CuentaCorrientePagosPersonaCompensacionEntradaService.Monto_NombreCol, row.MONTO);
                    camposDocumento.Add(CuentaCorrientePagosPersonaCompensacionEntradaService.Observacion_NombreCol, row.OBSERVACION);

                    //Guardar los datos
                    CuentaCorrientePagosPersonaCompensacionEntradaService.Guardar(camposDocumento);
                }

            }
            catch (Exception exp)
            {
                //Si la excepcion es lanzada desde CuentaCorrientePagosPersonaDocumentoService().Guardar
                //entonces se hace rollback dentro de dicho metodo y la transaccion regresa cerrada
                //por lo que el rollback de este metodo puede generar otra excepcion
                try
                {
                    sesion.Db.RollbackTransaction();
                }
                catch (Exception)
                {
                    CuentaCorrientePagosPersonaRecargosService.Borrar(row.ID, new SessionService());
                }

                throw exp;
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified ctacte_pago_persona_recargo_id.
        /// </summary>
        /// <param name="ctacte_pago_persona_recargo_id">The ctacte_pago_persona_recargo_id.</param>
        public static void Borrar(decimal ctacte_pago_persona_recargo_id, SessionService sesion)
        {
            CTACTE_PAGOS_PERSONA_RECARGORow row = sesion.Db.CTACTE_PAGOS_PERSONA_RECARGOCollection.GetByPrimaryKey(ctacte_pago_persona_recargo_id);
            string valorAnterior = row.ToString();
            row.ESTADO = Definiciones.Estado.Inactivo;
            sesion.Db.CTACTE_PAGOS_PERSONA_RECARGOCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion Borrar
    
        #region CrearCredito
        /// <summary>
        /// Crears the credito.
        /// </summary>
        /// <param name="ctacte_pago_persona_recargo_id">The ctacte_pago_persona_recargo_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal CrearCredito(decimal ctacte_pago_persona_recargo_id, decimal ctacte_pago_persona_id, SessionService sesion)
        {
            decimal ctacte_persona_id;
            DataTable dtPagoPersona = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + ctacte_pago_persona_id, string.Empty, sesion);
            CTACTE_PAGOS_PERSONA_RECARGORow row = sesion.Db.CTACTE_PAGOS_PERSONA_RECARGOCollection.GetByPrimaryKey(ctacte_pago_persona_recargo_id);

            ctacte_persona_id = CuentaCorrientePersonasService.AgregarCredito(
                    (decimal)dtPagoPersona.Rows[0][PagosDePersonaService.PersonaId_NombreCol],
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.CuentaCorrienteConceptos.Recargo,
                    (decimal)dtPagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol],
                    row.MONEDA_ID,
                    row.COTIZACION,
                    new decimal[] { row.IMPUESTO_ID },
                    new decimal[] { row.MONTO },
                    row.OBSERVACION,
                    DateTime.Now,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    row.ID,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    1,
                    1,
                    sesion);

            return ctacte_persona_id;
        }
        #endregion CrearCredito

        #region BorrarCredito
        public static void BorrarCredito(decimal ctacte_pago_persona_recargo_id, SessionService sesion)
        {
            CuentaCorrientePersonasService.DeshacerAgregarCredito(Definiciones.Error.Valor.EnteroPositivo, ctacte_pago_persona_recargo_id, Definiciones.Error.Valor.EnteroPositivo, false, sesion);
        }
        #endregion BorrarCredito

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PAGOS_PERSONA_RECARGO"; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_RECARGOCollection.COTIZACIONColumnName; }
        }
        public static string CtacteConceptoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_RECARGOCollection.CTACTE_CONCEPTO_IDColumnName; }
        }
        public static string CtactePagoPersonaDocId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_RECARGOCollection.CTACTE_PAGO_PERSONA_DOC_IDColumnName; }
        }
        public static string CtactePagoPersonaCompEnId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_RECARGOCollection.CTACTE_PAGO_PERSONA_COMP_EN_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_RECARGOCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_RECARGOCollection.IDColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_RECARGOCollection.IMPUESTO_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_RECARGOCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_RECARGOCollection.MONTOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_RECARGOCollection.OBSERVACIONColumnName; }
        }
        public static string TipoRecargo_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_RECARGOCollection.TIPO_RECARGOColumnName; }
        }
        #endregion Accessors
    }
}
