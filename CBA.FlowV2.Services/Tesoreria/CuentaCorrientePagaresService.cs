using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasDebitoPersona;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Services.Common;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrientePagaresService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="ctacte_pagares_id">The ctacte_pagares_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal ctacte_pagares_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_PAGARESRow row = sesion.Db.CTACTE_PAGARESCollection.GetByPrimaryKey(ctacte_pagares_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region EsGarantia
        /// <summary>
        /// Eses the garantia.
        /// </summary>
        /// <param name="ctacte_pagares_id">The ctacte_pagares_id.</param>
        /// <returns></returns>
        public static bool EsGarantia(decimal ctacte_pagares_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_PAGARESRow row = sesion.Db.CTACTE_PAGARESCollection.GetByPrimaryKey(ctacte_pagares_id);
                return row.GARANTIA == Definiciones.SiNo.Si;
            }
        }
        #endregion EsGarantia

        #region ExistePorCaso
        /// <summary>
        /// Existes the por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static bool ExistePorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return ExistePorCaso(caso_id, sesion);
            }
        }
        public static bool ExistePorCaso(decimal caso_id, SessionService sesion)
        {
            CTACTE_PAGARESRow[] rows = sesion.Db.CTACTE_PAGARESCollection.GetByCASO_GARANTIA_ID(caso_id);
            return rows.Length > 0;
        }
        #endregion ExistePorCaso

        #region GetCuentaCorrientePagaresDataTable
        public static DataTable GetCuentaCorrientePagaresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrientePagaresDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCuentaCorrientePagaresDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_PAGARESCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCuentaCorrientePagaresDataTable

        #region GetCuentaCorrientePagaresInfoCompleta
        public static DataTable GetCuentaCorrientePagaresInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrientePagaresInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCuentaCorrientePagaresInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_PAGARES_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCuentaCorrientePagaresInfoCompleta

        #region SetJuegoAprobado
        /// <summary>
        /// Sets the juego aprobado.
        /// </summary>
        /// <param name="ctacte_pagare_id">The ctacte_pagare_id.</param>
        /// <returns></returns>
        public static string SetJuegoAprobado(decimal ctacte_pagare_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CTACTE_PAGARESRow row = sesion.Db.CTACTE_PAGARESCollection.GetByPrimaryKey(ctacte_pagare_id);
                    string valorAnterior = row.ToString(), mensaje;

                    if (!row.JUEGO_PAGARES_APROBADO.Equals(Definiciones.SiNo.No))
                        throw new Exception("El juego de pagarés ya estaba aprobado");

                    if (row.GARANTIA == Definiciones.SiNo.Si)
                    {
                        if (row.IsCASO_GARANTIA_IDNull)
                            throw new Exception("El juego de pagarés no tiene un " + Traducciones.Caso + " asociado.");

                        row.JUEGO_PAGARES_APROBADO = Definiciones.SiNo.Si;
                        row.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(row.AUTONUMERACION_ID, sesion);
                        sesion.Db.CTACTE_PAGARESCollection.Update(row);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    }
                    else
                    {
                        #region Afectar la ctacte
                        DataTable dtCtactePersona, dtCtactePagareDocumentos, dtCtactePagareDetalles;
                        decimal saldo;
                        DataTable dtCtactePersonaDet, dtCtactePersonaMovPrincipal;
                        System.Collections.Hashtable montoPorImpuesto = new System.Collections.Hashtable();
                        decimal[] impuestoId, monto;
                        int indiceAux;
                        decimal montoVerificacion, montoAux;
                        decimal totalDetalles, totalDocumentos;
                        int cantidadDecimales = MonedasService.CantidadDecimalesStatic(row.MONEDA_ID);

                        dtCtactePagareDetalles = CuentaCorrientePagaresDetalleService.GetCuentaCorrientePagaresDetalleDataTable(CuentaCorrientePagaresDetalleService.CtactePagareId_NombreCol + " = " + ctacte_pagare_id, string.Empty);
                        dtCtactePagareDocumentos = CuentaCorrientePagaresDocumentosService.GetCuentaCorrientePagaresDocumentosDataTable(CuentaCorrientePagaresDocumentosService.CtactePagareId_NombreCol + " = " + ctacte_pagare_id, string.Empty);

                        #region Validar totales
                        totalDetalles = 0;
                        totalDocumentos = 0;

                        for (int i = 0; i < dtCtactePagareDetalles.Rows.Count; i++)
                            totalDetalles += (decimal)dtCtactePagareDetalles.Rows[i][CuentaCorrientePagaresDetalleService.MontoTotal_NombreCol];

                        for (int i = 0; i < dtCtactePagareDocumentos.Rows.Count; i++)
                            totalDocumentos += (decimal)dtCtactePagareDocumentos.Rows[i][CuentaCorrientePagaresDocumentosService.MontoDestino_NombreCol];

                        if (Math.Round(totalDocumentos, cantidadDecimales) != Math.Round(totalDetalles, cantidadDecimales))
                            throw new Exception("El monto total de documentos difiere del de pagarés.");

                        #endregion Validar totales

                        #region Calcular discriminacion de monto por impuesto
                        //Al guardar los pagares se inserta en forma temporal el monto
                        //total de la ctacte persona como si fuera exenta.
                        //Ahora que se confirma deben borrarse esos detalles de ctacte y
                        //cargar los reales distribuyendo los montos por impuesto
                        for (int i = 0; i < dtCtactePagareDocumentos.Rows.Count; i++)
                        {
                            dtCtactePersonaMovPrincipal = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.CtactePersonaRelacionada_NombreCol + " = " + dtCtactePagareDocumentos.Rows[i][CuentaCorrientePagaresDocumentosService.CtactePersonaId_NombreCol], string.Empty, sesion);
                            dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable((decimal)dtCtactePersonaMovPrincipal.Rows[0][CuentaCorrientePersonasService.Id_NombreCol], sesion);

                            for (int j = 0; j < dtCtactePersonaDet.Rows.Count; j++)
                            {
                                // (monto pagado) / (Debito cuenta pagada) * monto correspondiente al tipo de impuetso en la cuenta principal
                                montoAux = (decimal)dtCtactePagareDocumentos.Rows[i][CuentaCorrientePagaresDocumentosService.MontoOrigen_NombreCol] / (decimal)dtCtactePersonaMovPrincipal.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol] * (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol];

                                if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                                    montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + montoAux;
                                else
                                    montoPorImpuesto.Add(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], montoAux);
                            }
                        }

                        impuestoId = new decimal[montoPorImpuesto.Count];
                        monto = new decimal[montoPorImpuesto.Count];

                        indiceAux = 0;
                        montoVerificacion = 0;
                        foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                        {
                            impuestoId[indiceAux] = (decimal)par.Key;
                            monto[indiceAux] = (decimal)par.Value;

                            montoVerificacion += (decimal)par.Value;

                            indiceAux++;
                        }

                        if (Math.Round(row.MONTO_TOTAL, cantidadDecimales) != Math.Round(montoVerificacion, cantidadDecimales))
                            throw new Exception("Error en CuentaCorrientePagaresService.SetJuegoAprobado(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + row.MONTO_TOTAL + ".");

                        #endregion Calcular discriminacion de monto por impuesto

                        #region Actualizar discriminacion
                        for (int i = 0; i < dtCtactePagareDetalles.Rows.Count; i++)
                        {
                            decimal[] montoPorPagare = new decimal[monto.Length];
                            dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.CtactePagareDetId_NombreCol + " = " + dtCtactePagareDetalles.Rows[i][CuentaCorrientePagaresDetalleService.Id_NombreCol], string.Empty);

                            //Borrar detalles anteriores
                            CuentaCorrientePersonasDetalleService.Borrar((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol], sesion);

                            for (int j = 0; j < monto.Length; j++)
                                montoPorPagare[j] = (decimal)dtCtactePagareDetalles.Rows[i][CuentaCorrientePagaresDetalleService.MontoTotal_NombreCol] / row.MONTO_TOTAL * monto[j];


                            //Guardar nuevos detalles
                            CuentaCorrientePersonasDetalleService.Guardar((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol],
                                                                          impuestoId,
                                                                          montoPorPagare,
                                                                          sesion);
                        }
                        #endregion Actualizar discriminacion

                        row.JUEGO_PAGARES_APROBADO = Definiciones.SiNo.Si;
                        row.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(row.AUTONUMERACION_ID, sesion);

                        sesion.Db.CTACTE_PAGARESCollection.Update(row);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                        //Si el saldo del documento es cero, cerrar el caso segun el flujo
                        for (int i = 0; i < dtCtactePagareDocumentos.Rows.Count; i++)
                        {
                            dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.Id_NombreCol + " = " + dtCtactePagareDocumentos.Rows[i][CuentaCorrientePagaresDocumentosService.CtactePersonaId_NombreCol], string.Empty);

                            saldo = (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol] -
                                    (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol];

                            if (Math.Round(saldo, 4) == 0)
                            {
                                int flujoId = Convert.ToInt32(dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaFlujoId_NombreCol]);
                                string casoEstado = CasosService.GetEstadoCaso((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol]);
                                bool exitoCasoAsociado = false;

                                //Puede pasar que un juego este creado pero no aprobado, luego el cliente realice pagos
                                //dejando el saldo en cero y posteriormente se apruebe el juego. En dicho caso
                                //la aprobacion del juego no debe intentar modificar el estado del caso
                                switch (flujoId)
                                {
                                    case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                                        if (casoEstado.Equals(Definiciones.EstadosFlujos.Caja))
                                        {
                                            FacturasClienteService facturaCliente = new FacturasClienteService();
                                            exitoCasoAsociado = facturaCliente.ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                                            if (exitoCasoAsociado)
                                                exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                                            if (exitoCasoAsociado)
                                                facturaCliente.EjecutarAccionesLuegoDeCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, sesion);

                                            if (!exitoCasoAsociado)
                                                throw new Exception("Error en CuentaCorrientePagaresService.SetJuegoAprobado, Facturacion Cliente. " + mensaje + ".");
                                        }
                                        break;
                                    case Definiciones.FlujosIDs.NOTA_DEBITO_PERSONA:
                                        if (casoEstado.Equals(Definiciones.EstadosFlujos.Aprobado))
                                        {
                                            NotasDebitoPersonaService notaDebitoPersona = new NotasDebitoPersonaService();
                                            exitoCasoAsociado = notaDebitoPersona.ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                                            if (exitoCasoAsociado)
                                                exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                                            if (exitoCasoAsociado)
                                                notaDebitoPersona.EjecutarAccionesLuegoDeCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, sesion);

                                            if (!exitoCasoAsociado)
                                                throw new Exception("Error en CuentaCorrientePagaresService.SetJuegoAprobado, Nota de débito persona. " + mensaje + ".");
                                        }
                                        break;
                                }
                            }
                        }
                        #endregion Afectar la ctacte
                    }

                    return row.NRO_COMPROBANTE;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion SetJuegoAprobado

        #region Guardar
        public static decimal Guardar(Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal id = Guardar(campos, sesion);
                    sesion.CommitTransaction();
                    return id;
                }
                catch (Exception)
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        public static decimal Guardar(Hashtable campos, SessionService sesion)
        {
            CTACTE_PAGARESRow row = new CTACTE_PAGARESRow();
            string valorAnterior = string.Empty;

            if (campos.Contains(CuentaCorrientePagaresService.Id_NombreCol))
            {
                row = sesion.Db.CTACTE_PAGARESCollection.GetByPrimaryKey((decimal)campos[CuentaCorrientePagaresService.Id_NombreCol]);
                valorAnterior = row.ToString();
            }
            else
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_pagares_sqc");
                row.FECHA = DateTime.Now;
                row.USUARIO_ID = sesion.Usuario.ID;
                row.ESTADO = Definiciones.Estado.Activo;
                row.JUEGO_PAGARES_APROBADO = Definiciones.SiNo.No;
                row.GARANTIA = Definiciones.SiNo.No;
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }

            //Si el juego ya fue aprobado no pueden guardarse modificaciones
            if (row.JUEGO_PAGARES_APROBADO == Definiciones.SiNo.Si)
                throw new Exception("El juego de pagarés ya fue aprobado. No puede realizar cambios.");

            //Si cambia
            if (row.SUCURSAL_ID.Equals(DBNull.Value) || row.SUCURSAL_ID != (decimal)campos[CuentaCorrientePagaresService.SucursalId_NombreCol])
            {
                row.SUCURSAL_ID = (decimal)campos[CuentaCorrientePagaresService.SucursalId_NombreCol];
                if (!SucursalesService.EstaActivo(row.SUCURSAL_ID))
                    throw new Exception("La sucursal no se encuentra activa.");
            }

            //Si cambia
            if (row.MONEDA_ID.Equals(DBNull.Value) || row.MONEDA_ID != (decimal)campos[CuentaCorrientePagaresService.MonedaId_NombreCol])
            {
                row.MONEDA_ID = (decimal)campos[CuentaCorrientePagaresService.MonedaId_NombreCol];
                if (!MonedasService.EstaActivo(row.MONEDA_ID))
                    throw new Exception("La moneda no se encuentra activa.");

                row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA, sesion);
                if (row.COTIZACION_MONEDA == Definiciones.Error.Valor.EnteroPositivo)
                    throw new Exception("Debe actualizar la cotización de la moneda.");
            }

            row.DIRECCION_BENEFICIARIO = (string)campos[CuentaCorrientePagaresService.DireccionBeneficiario_NombreCol];
            row.DIRECCION_CODEUDOR = (string)campos[CuentaCorrientePagaresService.DireccionCodeudor_NombreCol];
            row.DIRECCION_DEUDOR = (string)campos[CuentaCorrientePagaresService.DireccionDeudor_NombreCol];
            row.DOCUMENTO_BENEFICIARIO = (string)campos[CuentaCorrientePagaresService.DocumentoBeneficiario_NombreCol];
            row.DOCUMENTO_CODEUDOR = (string)campos[CuentaCorrientePagaresService.DocumentoCodeudor_NombreCol];
            row.DOCUMENTO_DEUDOR = (string)campos[CuentaCorrientePagaresService.DocumentoDeudor_NombreCol];
            row.AUTONUMERACION_ID = (decimal)campos[CuentaCorrientePagaresService.AutonumeracionId_NombreCol];
            row.NRO_COMPROBANTE = (string)campos[CuentaCorrientePagaresService.NroComprobante_NombreCol];

            if (campos.Contains(CuentaCorrientePagaresService.MontoTotal_NombreCol))
                row.MONTO_TOTAL = (decimal)campos[CuentaCorrientePagaresService.MontoTotal_NombreCol];                        
            else
                row.MONTO_TOTAL = 0;

            if (campos.Contains(CuentaCorrientePagaresService.Garantia_NombreCol))
                row.GARANTIA = (string)campos[CuentaCorrientePagaresService.Garantia_NombreCol];

            if (campos.Contains(CuentaCorrientePagaresService.CasoGarantiaId_NombreCol))
                row.CASO_GARANTIA_ID = (decimal)campos[CuentaCorrientePagaresService.CasoGarantiaId_NombreCol];

            //Si cambia de activo a inactivo
            if (row.ESTADO.Equals(Definiciones.Estado.Activo) &&
                (string)campos[CuentaCorrientePagaresService.Estado_NombreCol] == Definiciones.Estado.Inactivo)
            {
                row.ESTADO = Definiciones.Estado.Inactivo;
                row.FECHA_ANULADO = DateTime.Now;
                row.USUARIO_ANULADO_ID = sesion.Usuario.ID;
            }

            row.FECHA_EMISION = (DateTime)campos[CuentaCorrientePagaresService.FechaEmision_NombreCol];

            if (campos.Contains(CuentaCorrientePagaresService.FechaFirma_NombreCol))
                row.FECHA_FIRMA = (DateTime)campos[CuentaCorrientePagaresService.FechaFirma_NombreCol];
            else
                row.IsFECHA_FIRMANull = true;

            row.NOMBRE_BENEFICIARIO = (string)campos[CuentaCorrientePagaresService.NombreBeneficiario_NombreCol];
            row.NOMBRE_CODEUDOR = (string)campos[CuentaCorrientePagaresService.NombreCodeudor_NombreCol];
            row.NOMBRE_DEUDOR = (string)campos[CuentaCorrientePagaresService.NombreDeudor_NombreCol];

            row.TELEFONO_BENEFICIARIO = (string)campos[CuentaCorrientePagaresService.TelefonoBeneficiario_NombreCol];
            row.TELEFONO_CODEUDOR = (string)campos[CuentaCorrientePagaresService.TelefonoCodeudor_NombreCol];
            row.TELEFONO_DEUDOR = (string)campos[CuentaCorrientePagaresService.TelefonoDeudor_NombreCol];

            //Si cambia
            if (row.PERSONA_ID.Equals(DBNull.Value) || row.PERSONA_ID != (decimal)campos[CuentaCorrientePagaresService.PersonaId_NombreCol])
            {
                row.PERSONA_ID = (decimal)campos[CuentaCorrientePagaresService.PersonaId_NombreCol];
                if (!PersonasService.EstaActivo(row.PERSONA_ID))
                    throw new Exception("La persona no se encuentra activa.");
            }

            if (campos.Contains(CuentaCorrientePagaresService.Id_NombreCol))
                sesion.Db.CTACTE_PAGARESCollection.Update(row);
            else
                sesion.Db.CTACTE_PAGARESCollection.Insert(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified ctacte_pagare_id.
        /// </summary>
        /// <param name="ctacte_pagare_id">The ctacte_pagare_id.</param>
        public static void Borrar(decimal ctacte_pagare_id, SessionService sesion)
        {
            try
            {
                CTACTE_PAGARESRow row = sesion.Db.CTACTE_PAGARESCollection.GetByPrimaryKey(ctacte_pagare_id);

                //Se controla que el juego de pagares no este aprobado
                if (row.JUEGO_PAGARES_APROBADO == Definiciones.SiNo.Si)
                    throw new Exception("El juego de pagarés ya fue aprobado. No puede realizar cambios.");

                CuentaCorrientePagaresDetalleService.Borrar(row.ID, sesion);

                sesion.Db.CTACTE_PAGARESCollection.Delete(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Borrar

        #region ActualizarCantidadPagares
        /// <summary>
        /// Guardars the cantidad pagares.
        /// </summary>
        /// <param name="ctacte_pagares_id">The ctacte_pagares_id.</param>
        /// <param name="cantidad">The cantidad.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarCantidadPagares(decimal ctacte_pagares_id, SessionService sesion)
        {
            CTACTE_PAGARESRow row = sesion.Db.CTACTE_PAGARESCollection.GetByPrimaryKey(ctacte_pagares_id);
            string valorAnterior = row.ToString();

            row.CANTIDAD_PAGARES = CuentaCorrientePagaresDetalleService.GetCantidadPagaresComponenJuego(ctacte_pagares_id, sesion);

            sesion.Db.CTACTE_PAGARESCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion GuardarCantidadPagares

        #region ActualizarTotal
        /// <summary>
        /// Actualizars the total.
        /// </summary>
        /// <param name="ctacte_pagares_id">The ctacte_pagares_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarTotal(decimal ctacte_pagares_id, decimal monto, bool es_garantia, SessionService sesion)
        {
            CTACTE_PAGARESRow row = sesion.Db.CTACTE_PAGARESCollection.GetByPrimaryKey(ctacte_pagares_id);
            string valorAnterior = row.ToString();
            DataTable dtDocumentos, dtDetalles;

            if (es_garantia)
            {
                row.MONTO_TOTAL = monto;
                dtDetalles = CuentaCorrientePagaresDetalleService.GetCuentaCorrientePagaresDetalleDataTable(CuentaCorrientePagaresDetalleService.CtactePagareId_NombreCol + " = " + ctacte_pagares_id, string.Empty, sesion);
                
                if (dtDetalles.Rows.Count != 1)
                    throw new Exception("El pagaré de garantía no debía tener más de un detalle.");
                
                CuentaCorrientePagaresDetalleService.ActualizarMonto((decimal)dtDetalles.Rows[0][CuentaCorrientePagaresDetalleService.Id_NombreCol], monto, sesion);
            }
            else
            {
                row.MONTO_TOTAL = 0;
                dtDocumentos = CuentaCorrientePagaresDocumentosService.GetCuentaCorrientePagaresDocumentosDataTable(CuentaCorrientePagaresDocumentosService.CtactePagareId_NombreCol + " = " + ctacte_pagares_id, string.Empty, sesion);
                string where = CuentaCorrientePagaresService.Id_NombreCol + " = " + ctacte_pagares_id;

                for (int i = 0; i < dtDocumentos.Rows.Count; i++)
                    row.MONTO_TOTAL += (decimal)dtDocumentos.Rows[i][CuentaCorrientePagaresDocumentosService.MontoDestino_NombreCol];

                if (row.MONTO_TOTAL <= 0)
                {
                    dtDetalles = CuentaCorrientePagaresDetalleService.GetCuentaCorrientePagaresDetalleDataTable(CuentaCorrientePagaresDetalleService.CtactePagareId_NombreCol + " = " + ctacte_pagares_id, string.Empty, sesion);
                    for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        row.MONTO_TOTAL += (decimal)dtDetalles.Rows[i][CuentaCorrientePagaresDetalleService.MontoTotal_NombreCol];
                }
            }

            sesion.Db.CTACTE_PAGARESCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion ActualizarTotal

        #region CrearPagareGarantia
        /// <summary>
        /// Crears the pagare garantia.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <param name="cotizacion">The cotizacion.</param>
        /// <param name="monto">The monto.</param>
        /// <param name="vencimiento">The vencimiento.</param>
        /// <param name="persona_deudor">The persona_deudor.</param>
        /// <param name="persona_codeudor1">The persona_codeudor1.</param>
        /// <param name="persona_codeudor2">The persona_codeudor2.</param>
        /// <param name="autonumeracion_id">The autonumeracion_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">No se encontró una casa matriz definida.</exception>
        public static decimal CrearPagareGarantia(decimal caso_id, decimal moneda_id, decimal cotizacion, decimal monto, DateTime vencimiento, decimal persona_deudor, decimal persona_codeudor1, decimal persona_codeudor2, decimal autonumeracion_id, SessionService sesion)
        {
            try
            {
                decimal idCreado;
                Hashtable campos = new Hashtable();
                DataTable dtCaso = CasosService.GetCasosInfoCompleta(CasosService.Id_NombreCol + " = " + caso_id, string.Empty, sesion);
                DataTable dtPersonaDeudor = null;
                DataTable dtPersonaCodeudor1 = null;
                DataTable dtPersonaCodeudor2 = null;
                DataTable dtAutonumeracion = null;
                DataTable dtCasaMatriz;
                string nroDocumentoCasaMatriz, direccionDeudor, direccionBeneficiario, telefonoBeneficiario;
                decimal sucursalCasaMatrizId;

                //Validar que aun no fue creado un pagare de garantia sobre el caso
                if (CuentaCorrientePagaresService.ExistePorCaso(caso_id, sesion))
                    throw new Exception("Ya existe un juego de pagarés como garantía del " + Traducciones.Caso + " " + caso_id + ".");

                #region Obtener casa matriz
                sucursalCasaMatrizId = SucursalesService.GetCasaMatriz((decimal)dtCaso.Rows[0][CasosService.SucursalId_NombreCol], sesion);
                if (sucursalCasaMatrizId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    dtCasaMatriz = SucursalesService.GetSucursalesDataTable2(SucursalesService.Id_NombreCol + " = " + dtCaso.Rows[0][CasosService.SucursalId_NombreCol], string.Empty, true, sesion);
                else
                    dtCasaMatriz = SucursalesService.GetSucursalesDataTable2(SucursalesService.Id_NombreCol + " = " + sucursalCasaMatrizId, string.Empty, true, sesion);

                if (dtCasaMatriz.Rows.Count <= 0 || !dtCasaMatriz.Rows[0][SucursalesService.EsCasaMatriz_NombreCol].Equals(Definiciones.SiNo.Si))
                    throw new Exception("No se encontró una casa matriz definida.");
                #endregion Obtener casa matriz

                #region Crear cabecera
                dtPersonaDeudor = PersonasService.GetPersonasInfoCompleta2(PersonasService.Id_NombreCol + " = " + persona_deudor, string.Empty, false, sesion);

                if (!persona_codeudor1.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    dtPersonaCodeudor1 = PersonasService.GetPersonasInfoCompleta2(PersonasService.Id_NombreCol + " = " + persona_codeudor1, string.Empty, false, sesion);

                if (!persona_codeudor2.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    dtPersonaCodeudor2 = PersonasService.GetPersonasInfoCompleta2(PersonasService.Id_NombreCol + " = " + persona_codeudor2, string.Empty, false, sesion);

                if (autonumeracion_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesPorTabla2(CuentaCorrientePagaresService.Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, sesion);
                    if (dtAutonumeracion.Rows.Count <= 0)
                        throw new Exception("No existe un talonario definido para pagarés");
                }

                if (!Interprete.EsNullODBNull(dtCasaMatriz.Rows[0][SucursalesService.Ruc_NombreCol]))
                    nroDocumentoCasaMatriz = dtCasaMatriz.Rows[0][SucursalesService.Ruc_NombreCol] + "-" + TiposDocumentosIdentidadService.GetDigitoVerificadorRUC((string)dtCasaMatriz.Rows[0][SucursalesService.Ruc_NombreCol]);
                else
                    throw new Exception("Debe definirse el RUC de la casa matriz.");

                if (!Interprete.EsNullODBNull(dtCasaMatriz.Rows[0][SucursalesService.Telefono_NombreCol]))
                    telefonoBeneficiario = (string)dtCasaMatriz.Rows[0][SucursalesService.Telefono_NombreCol];
                else
                    throw new Exception("Debe definirse el teléfono de la casa matriz.");

                if (!Interprete.EsNullODBNull(dtCasaMatriz.Rows[0][SucursalesService.Direccion_NombreCol]))
                    direccionBeneficiario = (string)dtCasaMatriz.Rows[0][SucursalesService.Direccion_NombreCol];
                else
                    throw new Exception("Debe definirse la dirección de la casa matriz.");

                if (!Interprete.EsNullODBNull(dtPersonaDeudor.Rows[0][PersonasService.Calle1_NombreCol]))
                    direccionDeudor = dtPersonaDeudor.Rows[0][PersonasService.Calle1_NombreCol] + ", " + dtPersonaDeudor.Rows[0][PersonasService.VistaCiudad1Nombre_NombreCol] + " - " + dtPersonaDeudor.Rows[0][PersonasService.VistaPaisResidencia_NombreCol];
                else
                    direccionDeudor = dtPersonaDeudor.Rows[0][PersonasService.CalleCobranza_NombreCol] + ", " + dtPersonaDeudor.Rows[0][PersonasService.VistaCiudadCobranza_NombreCol] + " - " + dtPersonaDeudor.Rows[0][PersonasService.VistaPaisResidencia_NombreCol];

                campos.Add(CuentaCorrientePagaresService.Garantia_NombreCol, Definiciones.SiNo.Si);
                campos.Add(CuentaCorrientePagaresService.CasoGarantiaId_NombreCol, caso_id);
                campos.Add(CuentaCorrientePagaresService.SucursalId_NombreCol, dtCaso.Rows[0][CasosService.SucursalId_NombreCol]);
                campos.Add(CuentaCorrientePagaresService.MonedaId_NombreCol, moneda_id);
                campos.Add(CuentaCorrientePagaresService.DireccionBeneficiario_NombreCol, Interprete.EsNullODBNull(dtCasaMatriz.Rows[0][SucursalesService.Direccion_NombreCol]) ? string.Empty : dtCasaMatriz.Rows[0][SucursalesService.Direccion_NombreCol]);
                campos.Add(CuentaCorrientePagaresService.DocumentoBeneficiario_NombreCol, nroDocumentoCasaMatriz);
                campos.Add(CuentaCorrientePagaresService.NombreBeneficiario_NombreCol, VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.NombreEmpresa));
                campos.Add(CuentaCorrientePagaresService.TelefonoBeneficiario_NombreCol, telefonoBeneficiario);

                campos.Add(CuentaCorrientePagaresService.PersonaId_NombreCol, dtPersonaDeudor.Rows[0][PersonasService.Id_NombreCol]);
                campos.Add(CuentaCorrientePagaresService.DireccionDeudor_NombreCol, direccionDeudor);
                campos.Add(CuentaCorrientePagaresService.DocumentoDeudor_NombreCol, dtPersonaDeudor.Rows[0][PersonasService.NumeroDocumento_NombreCol]);
                campos.Add(CuentaCorrientePagaresService.NombreDeudor_NombreCol, dtPersonaDeudor.Rows[0][PersonasService.NombreCompleto_NombreCol]);
                campos.Add(CuentaCorrientePagaresService.TelefonoDeudor_NombreCol, Interprete.EsNullODBNull(dtPersonaDeudor.Rows[0][PersonasService.Telefono1_NombreCol]) ? string.Empty : dtPersonaDeudor.Rows[0][PersonasService.Telefono1_NombreCol]);
                campos.Add(CuentaCorrientePagaresService.MontoTotal_NombreCol, monto);

                if (dtPersonaCodeudor1 != null)
                {
                    campos.Add(CuentaCorrientePagaresService.DireccionCodeudor_NombreCol, Interprete.EsNullODBNull(dtPersonaCodeudor1.Rows[0][PersonasService.Calle1_NombreCol]) ? string.Empty : dtPersonaCodeudor1.Rows[0][PersonasService.Calle1_NombreCol] + ", " + dtPersonaCodeudor1.Rows[0][PersonasService.VistaCiudad1Nombre_NombreCol] + " - " + dtPersonaCodeudor1.Rows[0][PersonasService.VistaPaisResidencia_NombreCol]);
                    campos.Add(CuentaCorrientePagaresService.DocumentoCodeudor_NombreCol, dtPersonaCodeudor1.Rows[0][PersonasService.NumeroDocumento_NombreCol]);
                    campos.Add(CuentaCorrientePagaresService.NombreCodeudor_NombreCol, dtPersonaCodeudor1.Rows[0][PersonasService.NombreCompleto_NombreCol]);
                    campos.Add(CuentaCorrientePagaresService.TelefonoCodeudor_NombreCol, Interprete.EsNullODBNull(dtPersonaCodeudor1.Rows[0][PersonasService.Telefono1_NombreCol]) ? string.Empty : dtPersonaCodeudor1.Rows[0][PersonasService.Telefono1_NombreCol]);
                }

                campos.Add(CuentaCorrientePagaresService.FechaEmision_NombreCol, DateTime.Now);
                campos.Add(CuentaCorrientePagaresService.Estado_NombreCol, Definiciones.Estado.Activo);

                if (autonumeracion_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    campos.Add(CuentaCorrientePagaresService.AutonumeracionId_NombreCol, dtAutonumeracion.Rows[0][AutonumeracionesService.Id_NombreCol]);
                    campos.Add(CuentaCorrientePagaresService.NroComprobante_NombreCol, AutonumeracionesService.GetSiguienteNumero2((decimal)dtAutonumeracion.Rows[0][AutonumeracionesService.Id_NombreCol]));
                }
                else
                {
                    campos.Add(CuentaCorrientePagaresService.AutonumeracionId_NombreCol, autonumeracion_id);
                    campos.Add(CuentaCorrientePagaresService.NroComprobante_NombreCol, AutonumeracionesService.GetSiguienteNumero2(autonumeracion_id));
                }

                idCreado = CuentaCorrientePagaresService.Guardar(campos, sesion);
                #endregion Crear cabecera

                #region Crear detalles
                campos = new Hashtable();
                campos.Add(CuentaCorrientePagaresDetalleService.CtactePagareId_NombreCol, idCreado);
                campos.Add(CuentaCorrientePagaresDetalleService.FechaVencimiento_NombreCol, vencimiento);
                campos.Add(CuentaCorrientePagaresDetalleService.MontoTotal_NombreCol, monto);
                campos.Add(CuentaCorrientePagaresDetalleService.NumeroPagare_NombreCol, (decimal)1);

                CuentaCorrientePagaresDetalleService.Guardar(campos, sesion);
                #endregion Crear detalles

                return idCreado;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion CrearPagareGarantia

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PAGARES"; }
        }
        public static string CantidadPagares_NombreCol
        {
            get { return CTACTE_PAGARESCollection.CANTIDAD_PAGARESColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return CTACTE_PAGARESCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoGarantiaId_NombreCol
        {
            get { return CTACTE_PAGARESCollection.CASO_GARANTIA_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_PAGARESCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string DireccionBeneficiario_NombreCol
        {
            get { return CTACTE_PAGARESCollection.DIRECCION_BENEFICIARIOColumnName; }
        }
        public static string DireccionCodeudor_NombreCol
        {
            get { return CTACTE_PAGARESCollection.DIRECCION_CODEUDORColumnName; }
        }
        public static string DireccionDeudor_NombreCol
        {
            get { return CTACTE_PAGARESCollection.DIRECCION_DEUDORColumnName; }
        }
        public static string DocumentoBeneficiario_NombreCol
        {
            get { return CTACTE_PAGARESCollection.DOCUMENTO_BENEFICIARIOColumnName; }
        }
        public static string DocumentoCodeudor_NombreCol
        {
            get { return CTACTE_PAGARESCollection.DOCUMENTO_CODEUDORColumnName; }
        }
        public static string DocumentoDeudor_NombreCol
        {
            get { return CTACTE_PAGARESCollection.DOCUMENTO_DEUDORColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_PAGARESCollection.ESTADOColumnName; }
        }
        public static string FechaAnulado_NombreCol
        {
            get { return CTACTE_PAGARESCollection.FECHA_ANULADOColumnName; }
        }
        public static string FechaEmision_NombreCol
        {
            get { return CTACTE_PAGARESCollection.FECHA_EMISIONColumnName; }
        }
        public static string FechaFirma_NombreCol
        {
            get { return CTACTE_PAGARESCollection.FECHA_FIRMAColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CTACTE_PAGARESCollection.FECHAColumnName; }
        }
        public static string Garantia_NombreCol
        {
            get { return CTACTE_PAGARESCollection.GARANTIAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PAGARESCollection.IDColumnName; }
        }
        public static string JuegoPagaresAprobado_NombreCol
        {
            get { return CTACTE_PAGARESCollection.JUEGO_PAGARES_APROBADOColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_PAGARESCollection.MONEDA_IDColumnName; }
        }
        public static string MontoTotal_NombreCol
        {
            get { return CTACTE_PAGARESCollection.MONTO_TOTALColumnName; }
        }
        public static string NombreBeneficiario_NombreCol
        {
            get { return CTACTE_PAGARESCollection.NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string NombreCodeudor_NombreCol
        {
            get { return CTACTE_PAGARESCollection.NOMBRE_CODEUDORColumnName; }
        }
        public static string NombreDeudor_NombreCol
        {
            get { return CTACTE_PAGARESCollection.NOMBRE_DEUDORColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return CTACTE_PAGARESCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CTACTE_PAGARESCollection.PERSONA_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CTACTE_PAGARESCollection.SUCURSAL_IDColumnName; }
        }
        public static string TelefonoBeneficiario_NombreCol
        {
            get { return CTACTE_PAGARESCollection.TELEFONO_BENEFICIARIOColumnName; }
        }
        public static string TelefonoCodeudor_NombreCol
        {
            get { return CTACTE_PAGARESCollection.TELEFONO_CODEUDORColumnName; }
        }
        public static string TelefonoDeudor_NombreCol
        {
            get { return CTACTE_PAGARESCollection.TELEFONO_DEUDORColumnName; }
        }
        public static string UsuarioAnuladoId_NombreCol
        {
            get { return CTACTE_PAGARESCollection.USUARIO_ANULADO_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return CTACTE_PAGARESCollection.USUARIO_IDColumnName; }
        }
        public static string VistaCantidadPagaresRestantes_NombreCol
        {
            get { return CTACTE_PAGARES_INFO_COMPLETACollection.CANTIDAD_PAGARES_RESTANTESColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_PAGARES_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_PAGARES_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaMontoSaldo_NombreCol
        {
            get { return CTACTE_PAGARES_INFO_COMPLETACollection.MONTO_SALDOColumnName; }
        }
        public static string VistaMontoVencido_NombreCol
        {
            get { return CTACTE_PAGARES_INFO_COMPLETACollection.MONTO_VENCIDOColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return CTACTE_PAGARES_INFO_COMPLETACollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return CTACTE_PAGARES_INFO_COMPLETACollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CTACTE_PAGARES_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
