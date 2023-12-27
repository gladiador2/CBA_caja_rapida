using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrientePagaresDetalleService
    {
        #region GetCuentaCorrientePagaresDetalleDataTable
        /// <summary>
        /// Gets the cuenta corriente pagares detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagaresDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrientePagaresDetalleDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCuentaCorrientePagaresDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_PAGARES_DETALLECollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCuentaCorrientePagaresDetalleDataTable

        #region GetCuentaCorrientePagaresDetalleDataTable
        public static DataTable GetCuentaCorrientePagaresDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrientePagaresDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCuentaCorrientePagaresDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_PAGARES_DET_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCuentaCorrientePagaresDetalleInfoCompleta

        #region GetCantidadPagaresComponenJuego
        /// <summary>
        /// Gets the cantidad pagares componen juego.
        /// </summary>
        /// <param name="ctacte_pagare_id">The ctacte_pagare_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal GetCantidadPagaresComponenJuego(decimal ctacte_pagare_id, SessionService sesion)
        {
            return sesion.Db.CTACTE_PAGARES_DETALLECollection.GetByCTACTE_PAGARE_ID(ctacte_pagare_id).Length;
        }
        #endregion GetCantidadPagaresComponenJuego

        #region GetMonto

        /// <summary>
        /// Gets the monto.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <returns></returns>
        public static decimal GetMonto(decimal pagareDetId)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_PAGARES_DETALLECollection.GetByPrimaryKey(pagareDetId).MONTO_TOTAL;
            }
        }

        #endregion GetMonto
        
        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Guardar(campos, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        public static void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            CTACTE_PAGARES_DETALLERow row;
            string valorAnterior;
            DataTable dtCtactePagares;
            bool insertarNuevo;

            dtCtactePagares = CuentaCorrientePagaresService.GetCuentaCorrientePagaresInfoCompleta(CuentaCorrientePagaresService.Id_NombreCol + " = " + campos[CuentaCorrientePagaresDetalleService.CtactePagareId_NombreCol], string.Empty, sesion);

            //Se controla que el juego de pagares aun no este aprobado
            if ((string)dtCtactePagares.Rows[0][CuentaCorrientePagaresService.JuegoPagaresAprobado_NombreCol] == Definiciones.SiNo.Si)
                throw new Exception("El juego de pagarés ya está aprobado. No puede editar los documentos que respalda.");

            insertarNuevo = !campos.Contains(CuentaCorrientePagaresDetalleService.Id_NombreCol);

            if(insertarNuevo)
            {
                row = new CTACTE_PAGARES_DETALLERow();
                valorAnterior = Definiciones.Log.RegistroNuevo;
                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_pagares_det_sqc");
            }
            else 
            {
                row = sesion.Db.CTACTE_PAGARES_DETALLECollection.GetByPrimaryKey((decimal)campos[CuentaCorrientePagaresDetalleService.Id_NombreCol]);
                valorAnterior = row.ToString();
            }
            
            row.CTACTE_PAGARE_ID = (decimal)campos[CuentaCorrientePagaresDetalleService.CtactePagareId_NombreCol];
            row.FECHA_VENCIMIENTO = (DateTime)campos[CuentaCorrientePagaresDetalleService.FechaVencimiento_NombreCol];
            row.MONTO_TOTAL = (decimal)campos[CuentaCorrientePagaresDetalleService.MontoTotal_NombreCol];
            row.NUMERO_PAGARE = (decimal)campos[CuentaCorrientePagaresDetalleService.NumeroPagare_NombreCol];

            if(insertarNuevo) sesion.Db.CTACTE_PAGARES_DETALLECollection.Insert(row);
            else sesion.Db.CTACTE_PAGARES_DETALLECollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            if (dtCtactePagares.Rows[0][CuentaCorrientePagaresService.Garantia_NombreCol].Equals(Definiciones.SiNo.No))
            {
                if (insertarNuevo)
                {
                    //Se agrega el credito a la cuenta corriente como si fuera un solo impuesto (exento)
                    //Al momento de aprobar el juego de pagares se rectifica la ditribucion del monto entre los tipos de impuesto
                    CuentaCorrientePersonasService.AgregarCredito((decimal)dtCtactePagares.Rows[0][CuentaCorrientePagaresService.PersonaId_NombreCol],
                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                 Definiciones.CuentaCorrienteConceptos.Financiacion,
                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                 (decimal)dtCtactePagares.Rows[0][CuentaCorrientePagaresService.MonedaId_NombreCol],
                                                 (decimal)dtCtactePagares.Rows[0][CuentaCorrientePagaresService.CotizacionMoneda_NombreCol],
                                                 new decimal[] { Definiciones.Impuestos.Exenta },
                                                 new decimal[] { row.MONTO_TOTAL },
                                                 string.Empty,
                                                 row.FECHA_VENCIMIENTO,
                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                 row.ID,
                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                 1,
                                                 1,
                                                 sesion);
                }
                else
                {
                    //Se actualiza el credito en la cuenta corriente
                    DataTable dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CtactePagareDetId_NombreCol + " = " + row.ID, string.Empty, sesion);
                    CuentaCorrientePersonasService.ActualizarFechaVencimientoYMonto((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol], row.FECHA_VENCIMIENTO, row.MONTO_TOTAL, true, sesion);
                    CuentaCorrientePersonasDetalleService.ActualizarMontos((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol], Definiciones.Impuestos.Exenta, row.MONTO_TOTAL, sesion);
                }
            }

            //Se recalculan los totales de la cabecera
            CuentaCorrientePagaresService.ActualizarCantidadPagares(row.CTACTE_PAGARE_ID, sesion);
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal ctacte_pagares_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(ctacte_pagares_id, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        public static void Borrar(decimal ctacte_pagares_id, SessionService sesion)
        {

            CTACTE_PAGARES_DETALLERow[] rows = sesion.Db.CTACTE_PAGARES_DETALLECollection.GetByCTACTE_PAGARE_ID(ctacte_pagares_id);
            DataTable dtCtactePagares;

            dtCtactePagares = CuentaCorrientePagaresService.GetCuentaCorrientePagaresInfoCompleta(CuentaCorrientePagaresService.Id_NombreCol + " = " + ctacte_pagares_id, string.Empty);

            //Se controla que el juego de pagares aun no este aprobado
            if ((string)dtCtactePagares.Rows[0][CuentaCorrientePagaresService.JuegoPagaresAprobado_NombreCol] == Definiciones.SiNo.Si)
                throw new Exception("El juego de pagarés ya está aprobado. No puede editar los documentos que respalda.");

            for (int i = 0; i < rows.Length; i++)
            {
                //Se quita de la cuenta corriente
                if ((string)dtCtactePagares.Rows[i][CuentaCorrientePagaresService.Garantia_NombreCol] == Definiciones.SiNo.No)
                    CuentaCorrientePersonasService.DeshacerAgregarCredito(rows[i].ID, Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo, true, sesion);

                //Se borra el detalle
                sesion.Db.CTACTE_PAGARES_DETALLECollection.Delete(rows[i]);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[i].ID, rows[i].ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }

            //Se recalculan los totales de la cabecera
            CuentaCorrientePagaresService.ActualizarCantidadPagares(ctacte_pagares_id, sesion);
        }
        #endregion borrar

        #region ActualizarMonto
        public static void ActualizarMonto(decimal ctacte_pagare_detalle_id, decimal monto, SessionService sesion)
        {
            CTACTE_PAGARES_DETALLERow row = sesion.db.CTACTE_PAGARES_DETALLECollection.GetByPrimaryKey(ctacte_pagare_detalle_id);
            string valorAnterior = row.ToString();
            row.MONTO_TOTAL = monto;
            sesion.db.CTACTE_PAGARES_DETALLECollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion ActualizarMonto

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PAGARES_DETALLE"; }
        }
        public static string CtactePagareId_NombreCol
        {
            get { return CTACTE_PAGARES_DETALLECollection.CTACTE_PAGARE_IDColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return CTACTE_PAGARES_DETALLECollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PAGARES_DETALLECollection.IDColumnName; }
        }
        public static string MontoTotal_NombreCol
        {
            get { return CTACTE_PAGARES_DETALLECollection.MONTO_TOTALColumnName; }
        }
        public static string NumeroPagare_NombreCol
        {
            get { return CTACTE_PAGARES_DETALLECollection.NUMERO_PAGAREColumnName; }
        }
        public static string VistaMonedaId_NombreCol
        {
            get { return CTACTE_PAGARES_DET_INFO_COMPCollection.MONEDA_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_PAGARES_DET_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_PAGARES_DET_INFO_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaCantidadPagares_NombreCol
        {
            get { return CTACTE_PAGARES_DET_INFO_COMPCollection.CANTIDAD_PAGARESColumnName; }
        }
        public static string VistaCtactePagaresEstado_NombreCol
        {
            get { return CTACTE_PAGARES_DET_INFO_COMPCollection.CTACTE_PAGARES_ESTADOColumnName; }
        }
        public static string VistaCtactePagaresSucursalId_NombreCol
        {
            get { return CTACTE_PAGARES_DET_INFO_COMPCollection.CTACTE_PAGARES_SUCURSALColumnName; }
        }
        public static string VistaCtactePagaresDeudor_NombreCol
        {
            get { return CTACTE_PAGARES_DET_INFO_COMPCollection.CTACTE_PAGARES_DEUDORColumnName; }
        }
        public static string VistaCtactePagaresDocumento_NombreCol
        {
            get { return CTACTE_PAGARES_DET_INFO_COMPCollection.CTACTE_PAGARES_DOCUMENTOColumnName; }
        }
        public static string VistaCustodiaValoresDetId_NombreCol
        {
            get { return CTACTE_PAGARES_DET_INFO_COMPCollection.CUSTODIA_VALORES_DET_IDColumnName; }
        }
        public static string VistaDescuentoDocumentoDetId_NombreCol
        {
            get { return CTACTE_PAGARES_DET_INFO_COMPCollection.DESCUENTO_DOCUMENTO_DET_IDColumnName; }
        }
        public static string VistaJuegoPagaresAprobado_NombreCol
        {
            get { return CTACTE_PAGARES_DET_INFO_COMPCollection.JUEGO_PAGARES_APROBADOColumnName; }
        }
        public static string VistaPersonaId_NombreCol
        {
            get { return CTACTE_PAGARES_DET_INFO_COMPCollection.PERSONA_IDColumnName; }
        }
        public static string VistaMontoSaldo_NombreCol
        {
            get { return CTACTE_PAGARES_DET_INFO_COMPCollection.MONTO_SALDOColumnName; }
        }
        public static string VistaNroComprobante_NombreCol
        {
            get { return CTACTE_PAGARES_DET_INFO_COMPCollection.NRO_COMPROBANTEColumnName; }
        }
        #endregion Accessors
    }
}
