using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.NotaCreditosProveedores;
using System.Collections;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class PlanillasPagosService
    {
        #region GetPlanillaPago


        /// <summary>
        /// Gets the planilla pago.
        /// </summary>
        /// <param name="planilla_id">The planilla_id.</param>
        /// <returns></returns>
        public DataTable GetPlanillaPago(decimal planilla_id) 
        {
            using (SessionService sesion = new SessionService())
            {
                string where = PlanillasPagosService.Id_NombreCol + " = " + planilla_id;
                return sesion.Db.PLANILLA_PAGOSCollection.GetAsDataTable(where, PlanillasPagosService.Id_NombreCol);
            }
        }        

        /// <summary>
        /// Gets the planilla pago.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <returns></returns>
        public DataTable GetPlanillaPago(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = PlanillasPagosService.VistasEntidadId_NombreCol + " = " + sesion.EntidadActual_Id;

                if (!clausula.Equals(string.Empty)) where += " and " + clausula;              
                
                return sesion.Db.PLANILLA_PAGOSCollection.GetAsDataTable(where, PlantillasService.Id_NombreCol);
            }
        }

        /// <summary>
        /// Gets the planilla pago info completa.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <returns></returns>
        public DataTable GetPlanillaPagoInfoCompleta(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = PlanillasPagosService.VistasEntidadId_NombreCol + " = " + sesion.EntidadActual_Id;

                if (!clausula.Equals(string.Empty)) where += " and " + clausula;                
                
                return sesion.Db.PLANILLA_PAGOS_INFO_COMPLETACollection.GetAsDataTable(where, PlantillasService.Id_NombreCol);
            }

        }
        #endregion GetPlanillaPago
 
        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    string valorAnterior = string.Empty;
                    PLANILLA_PAGOSRow row = new PLANILLA_PAGOSRow();
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("planilla_pagos_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.USUARIO_ID = sesion.Usuario.ID; 
                       
                        row.OP_GENERADA = Definiciones.SiNo.No;
                        row.AUTONUMERACION_ID = decimal.Parse(campos[PlanillasPagosService.AutonumeracionId_NombreCol].ToString());
                        row.NRO_PLANILLA = AutonumeracionesService.GetSiguienteNumero2(row.AUTONUMERACION_ID, sesion);
                    }
                    else
                    {
                        row = sesion.Db.PLANILLA_PAGOSCollection.GetByPrimaryKey(decimal.Parse(campos[PlanillasPagosService.Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }
                    
                    row.CAJA_TESORERIA_ID = decimal.Parse(campos[PlanillasPagosService.CajaTesoreriaId_NombreCol].ToString());
                    row.COTIZACION_MONEDA = decimal.Parse(campos[PlanillasPagosService.CotizacionMoneda_NombreCol].ToString());
                    row.MONEDA_ID = decimal.Parse(campos[PlanillasPagosService.MonedaId_NombreCol].ToString());
                    row.SUCURSAL_ID = decimal.Parse(campos[PlanillasPagosService.SucursalId_NombreCol].ToString());
                    row.MONTO_TOTAL = decimal.Parse(campos[PlanillasPagosService.MontoTotal_NombreCol].ToString());
                    row.OBSERVACION = "Planilla de Pago.";
                    row.FECHA_CREACION = DateTime.Parse(campos[PlanillasPagosService.FechaCreacion_NombreCol].ToString());
                    if(insertarNuevo)sesion.Db.PLANILLA_PAGOSCollection.Insert(row);
                    else sesion.Db.PLANILLA_PAGOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch
                {
                    sesion.Db.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion guardar

        #region ActualizarTotal
        public static void ActualizarTotal(decimal planilla_id, decimal monto, SessionService sesion)
        {
            PLANILLA_PAGOSRow row = sesion.Db.PLANILLA_PAGOSCollection.GetByPrimaryKey(planilla_id);
            string valorAnterior = string.Empty;

            row.MONTO_TOTAL = monto;

            sesion.Db.PLANILLA_PAGOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion ActualizarTotal

        #region ActualizarOPGenerada
        public static void ActualizarOPGenerada(decimal id, string opGenerada, SessionService sesion)
        {
            try
            {
                string valorAnterior = string.Empty;

                PLANILLA_PAGOSRow row = sesion.Db.PLANILLA_PAGOSCollection.GetByPrimaryKey(id);
                valorAnterior = row.ToString();
                row.OP_GENERADA = opGenerada;

                sesion.Db.PLANILLA_PAGOSCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }  
        }
        #endregion ActualizarOPGenerada

        #region GenerarOrdenesPago
        public void GenerarOrdenesPago(decimal planilla_id, Hashtable datos)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    PLANILLA_PAGOSRow planilla = new PLANILLA_PAGOSRow();
                    planilla = sesion.Db.PLANILLA_PAGOSCollection.GetByPrimaryKey(planilla_id);
                    DataTable provedores = sesion.Db.PLANILLA_PAGO_DET_INFO_COMPLCollection.GetAsDataTable(PlanillasPagosDetallesService.PlanillaPagoId_NombreCol + "=" + planilla_id, PlanillasPagosDetallesService.PlanillaPagoId_NombreCol);
                    PLANILLA_PAGOS_DETALLESRow det;

                    provedores = sesion.Db.ObtenerDistintos(new string[] {
                        PlanillasPagosDetallesService.CtaCteProveedorProveedorId_NombreCol
                    }, provedores);

                    decimal proveedorId = 0;
                    PLANILLA_PAGO_DET_INFO_COMPLRow[] detalle;
                    string whereBase = PlanillasPagosDetallesService.PlanillaPagoId_NombreCol + "=" + planilla_id + " and ";
                    whereBase += PlanillasPagosDetallesService.CtaCteProveedorProveedorId_NombreCol + "=";
                    string where = string.Empty;
                    decimal vCasoId = Definiciones.Error.Valor.EnteroPositivo;
                    string vCasoEstado = string.Empty;
                    bool exito = false;
                    
                    foreach (DataRow dr in provedores.Rows)
                    {
                        System.Collections.Hashtable campos = new System.Collections.Hashtable();
                        proveedorId = decimal.Parse(dr[PlanillasPagosDetallesService.CtaCteProveedorProveedorId_NombreCol].ToString());
                        where = whereBase + proveedorId;
                        detalle = sesion.Db.PLANILLA_PAGO_DET_INFO_COMPLCollection.GetAsArray(where, PlanillasPagosDetallesService.Id_NombreCol);
                        campos.Add(OrdenesPagoService.Fecha_NombreCol, DateTime.Now);
                        campos.Add(OrdenesPagoService.NroReciboBeneficiario_NombreCol, "A confirmar");
                        campos.Add(OrdenesPagoService.NombreBeneficiario_NombreCol, detalle[0].PROVEEDOR_NOMBRE);
                        campos.Add(OrdenesPagoService.Observacion_NombreCol, "Orden de pago generada por planilla N° " + planilla.NRO_PLANILLA);
                        campos.Add(OrdenesPagoService.ObservacionInterna_NombreCol, "Orden de pago generada por planilla N° " + planilla.NRO_PLANILLA);
                        campos.Add(OrdenesPagoService.OrdenPagoTipoId_NombreCol, Definiciones.TiposOrdenesPago.PagoAProveedor);
                        campos.Add(OrdenesPagoService.SucursalOrigenId_NombreCol, planilla.SUCURSAL_ID);
                        campos.Add(OrdenesPagoService.MonedaId_NombreCol, planilla.MONEDA_ID);
                        campos.Add(OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol, planilla.CAJA_TESORERIA_ID);
                        campos.Add(OrdenesPagoService.RetencionAutonumeracionId_NombreCol, datos[OrdenesPagoService.RetencionAutonumeracionId_NombreCol]);
                        campos.Add(OrdenesPagoService.AutonumeracionId_NombreCol, datos[OrdenesPagoService.AutonumeracionId_NombreCol]);
                        campos.Add(OrdenesPagoService.CotizacionMoneda_NombreCol, datos[OrdenesPagoService.CotizacionMoneda_NombreCol]);

                        campos.Add(OrdenesPagoService.ProveedorId_NombreCol, proveedorId);

                        //Guardar los datos
                        exito = OrdenesPagoService.Guardar(campos, true, ref vCasoId, ref vCasoEstado);
                        decimal ordenId = OrdenesPagoService.GetOrdenPagoIDPorCaso2(vCasoId);

                        for (int i = 0; i < detalle.Length; i++)
                        {
                            System.Collections.Hashtable campos2 = new System.Collections.Hashtable();

                            campos2.Add(OrdenesPagoDetalleService.OrdenPagoId_NombreCol, ordenId);
                            campos2.Add(OrdenesPagoDetalleService.CtacteProveedorId_NombreCol, detalle[i].CTACTE_PROVEEDOR_ID);
                            campos2.Add(OrdenesPagoDetalleService.MonedaOrigenId_NombreCol, detalle[i].CTACTE_MONEDA_ID);
                            campos2.Add(OrdenesPagoDetalleService.MontoOrigen_NombreCol, detalle[i].MONTO_BRUTO);
                            campos2.Add(OrdenesPagoDetalleService.Observacion_NombreCol, "Detalle Generado por planilla N° " + planilla.NRO_PLANILLA);
                            campos2.Add(OrdenesPagoDetalleService.CasoReferidoId_NombreCol, detalle[i].CTACTE_CASO_ID);                            
                            
                            sesion.Db.BeginTransaction();
                            det = sesion.Db.PLANILLA_PAGOS_DETALLESCollection.GetByPrimaryKey(detalle[i].ID);
                            det.OP_CASO_ID = vCasoId;
                            sesion.Db.PLANILLA_PAGOS_DETALLESCollection.Update(det);
                            sesion.Db.CommitTransaction();

                            //Guardar los datos
                            OrdenesPagoDetalleService.Guardar(campos2);

                            DataTable dtNotasCreditoProv = NotasCreditoProveedorService.GetNotaCreditoProveedorPorCasoFacturaProvId(detalle[i].CTACTE_CASO_ID, false);

                            //Guarda en valores las notas de credito si hay
                            if (dtNotasCreditoProv.Rows.Count > 0)
                            {
                                for (int j = 0; j < dtNotasCreditoProv.Rows.Count; j++)
                                {
                                    System.Collections.Hashtable campos3 = new System.Collections.Hashtable();
                                    campos3.Add(OrdenesPagoValoresService.OrdenPagoId_NombreCol, ordenId);
                                    campos3.Add(OrdenesPagoValoresService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.NotaDeCredito);
                                    campos3.Add(OrdenesPagoValoresService.MonedaOrigenId_NombreCol, dtNotasCreditoProv.Rows[j][NotasCreditoProveedorService.MonedaId_NombreCol]);
                                    campos3.Add(OrdenesPagoValoresService.MontoOrigen_NombreCol, dtNotasCreditoProv.Rows[j]["monto_nota_credito"]);
                                    campos3.Add(OrdenesPagoValoresService.CotizacionMonedaDestino_NombreCol, dtNotasCreditoProv.Rows[j][NotasCreditoProveedorService.CotizacionMoneda_NombreCol]);
                                    campos3.Add(OrdenesPagoValoresService.Observacion_NombreCol, string.Empty);
                                    campos3.Add(OrdenesPagoValoresService.NotaCreditoProveedorId_NombreCol, dtNotasCreditoProv.Rows[j][NotasCreditoProveedorService.Id_NombreCol]);

                                    //Guardar los datos
                                    OrdenesPagoValoresService.Guardar(campos3);
                                }
                            }
                        }
                    }
                    sesion.Db.BeginTransaction();
                    planilla.OP_GENERADA = Definiciones.SiNo.Si;
                    sesion.Db.PLANILLA_PAGOSCollection.Update(planilla);
                    sesion.Db.CommitTransaction();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion GenerarOrdenesPago

        #region Accessors
        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "PLANILLA_PAGOS"; }
        }
        public static string Id_NombreCol
        {
            get { return PLANILLA_PAGOSCollection.IDColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return PLANILLA_PAGOSCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CajaTesoreriaId_NombreCol
        {
            get { return PLANILLA_PAGOSCollection.CAJA_TESORERIA_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return PLANILLA_PAGOSCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return PLANILLA_PAGOSCollection.FECHA_CREACIONColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return PLANILLA_PAGOSCollection.MONEDA_IDColumnName; }
        }
        public static string MontoTotal_NombreCol
        {
            get { return PLANILLA_PAGOSCollection.MONTO_TOTALColumnName; }
        }
        public static string NroPlanilla_NombreCol
        {
            get { return PLANILLA_PAGOSCollection.NRO_PLANILLAColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return PLANILLA_PAGOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return PLANILLA_PAGOSCollection.USUARIO_IDColumnName; }
        }
        public static string OPGenerada_NombreCol
        {
            get { return PLANILLA_PAGOSCollection.OP_GENERADAColumnName; }
        }

        #endregion Tablas
        #region Vistas
        public static string VistasEntidadId_NombreCol
        {
            get { return PLANILLA_PAGOS_INFO_COMPLETACollection.ENTIDAD_IDColumnName; }
        }
        public static string VistasMonedaNombre_NombreCol
        {
            get { return PLANILLA_PAGOS_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistasMonedaSimbolo_NombreCol
        {
            get { return PLANILLA_PAGOS_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistasTimbrado_NombreCol
        {
            get { return PLANILLA_PAGOS_INFO_COMPLETACollection.NUMERO_TIMBRADOColumnName; }
        }
        public static string VistasCajaNombre_NombreCol
        {
            get { return PLANILLA_PAGOS_INFO_COMPLETACollection.CAJA_NOMBREColumnName; }
        }
        public static string VistasSucursalNombre_NombreCol
        {
            get { return PLANILLA_PAGOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistasUsuarioNombre_NombreCol
        {
            get { return PLANILLA_PAGOS_INFO_COMPLETACollection.USUARIOColumnName; }
        }
        #endregion Vistas
        #endregion Accessors
    }
}
