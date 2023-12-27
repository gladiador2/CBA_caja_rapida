using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.NotaCreditosProveedores;
using System.Collections.Generic;
using System.Collections;
using CBA.FlowV2.Services.Facturacion;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class PlanillaParaCobranzaService
    {
        #region NombreColumnas para importar
        public abstract class NombreColumnas
        {
            public const string Documento = "Documento";
            public const string CodigoExterno = "Código Externo";
            public const string Caso = "Caso";
            public const string Comprobante = "Comprobante";
            public const string Moneda = "Moneda";
            public const string Vencimiento = "Vencimiento";
            public const string Cuota = "Cuota";
            public const string MontoCuota = "Pago Cuota";
            public const string MontoMora = "Mora";
            public const string Cobrado = "Pago a Realizar";
        }
        #endregion NombreColumnas para importar

        #region GetPlanillaParaCobranza
        public static DataTable GetDataTable(string clausulas, string orden)
        {
            using(SessionService sesion= new SessionService())
            {
                return GetDataTable(clausulas, orden, sesion);
            }
        }
        public static DataTable GetDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.PLANILLA_PARA_COBRANZACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetPlanillaParaCobranza

        #region GetPlanillaParaCobranzaInfoCompleta
        public static DataTable GetPlanillaParaCobranzaInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPlanillaParaCobranzaInfoCompleta(clausulas, orden, sesion);
            }
        }
        public static DataTable GetPlanillaParaCobranzaInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.PLANILLA_P_COBRAN_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetPlanillaParaCobranzaInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos, bool incluir_mora, bool esNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    PlanillaParaCobranzaService.Guardar(campos, incluir_mora, esNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void Guardar(System.Collections.Hashtable campos, bool incluir_mora, bool esNuevo, SessionService sesion)
        {
            PLANILLA_PARA_COBRANZARow row = new PLANILLA_PARA_COBRANZARow();
            CuentaCorrientePersonasService ctactePersona = null;
            DataTable dtCabecera = PlanillaCobranzaService.GetPlanillaCobranza((decimal)campos[PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol], sesion);
            string valorAnterior = string.Empty;
            
            if(esNuevo)
            {
               valorAnterior = Definiciones.Log.RegistroNuevo;
               row.ID = sesion.Db.GetSiguienteSecuencia("PLANILLA_PARA_COBRANZA_SQC");
            }
            else
            {
                row = sesion.Db.PLANILLA_PARA_COBRANZACollection.GetByPrimaryKey((decimal)campos[PlanillaParaCobranzaService.Id_NombreCol]);
                valorAnterior = row.ToString();
            }
            
            row.PLANILLA_DE_COBRANZA_ID = (decimal)campos[PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol];

            ctactePersona = new CuentaCorrientePersonasService((decimal)campos[PlanillaParaCobranzaService.CtaCtePersonaId_NombreCol], sesion);
            if (!ctactePersona.ExisteEnDB)
                throw new System.Exception("El documento no fue encontrado.");

            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionCtacteIndependiente, sesion) == Definiciones.SiNo.Si && ctactePersona.CasoId.HasValue)
            {
                var sucursal = new SucursalesService((decimal)dtCabecera.Rows[0][PlanillaCobranzaService.SucursalId_NombreCol], sesion);
                if (ctactePersona.Caso.Sucursal.RegionId != sucursal.RegionId)
                    throw new Exception("El documento proviene de una región distinta al caso.");
            }

            row.CTACTE_PERSONA_ID = (decimal)campos[PlanillaParaCobranzaService.CtaCtePersonaId_NombreCol];
            if (esNuevo)
            {
                //Se verifica que la misma cuenta ya no exita en el sistema    
                string clausula = PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol + "=" + row.PLANILLA_DE_COBRANZA_ID;
                clausula += " and " + PlanillaParaCobranzaService.CtaCtePersonaId_NombreCol + "=" + row.CTACTE_PERSONA_ID;

                DataTable dato = sesion.db.PLANILLA_PARA_COBRANZACollection.GetAsDataTable(clausula, string.Empty);
                if (dato.Rows.Count > 0)
                    throw new Exception("El item ya forma parte de la planilla");
            }

            row.MONTO_CUOTA = (decimal)campos[PlanillaParaCobranzaService.MontoCuota_NombreCol];

            //Usar la mora provista o calcular
            if (campos.Contains(PlanillaParaCobranzaService.MontoMora_NombreCol))
            {
                row.MONTO_MORA = (decimal)campos[PlanillaParaCobranzaService.MontoMora_NombreCol];
            }
            else
            {
                row.MONTO_MORA = 0;
                if (incluir_mora)
                {
                    decimal porcentajeMora = 0;
                    decimal montoMoraDiario = 0;
                    decimal? montoMoraManual = null;
                    decimal diasDeGraciaMora, diasDeGraciaInteresPunitorio;

                    DataTable dtPlanillaCobranza = PlanillaCobranzaService.GetPlanillaCobranza(row.PLANILLA_DE_COBRANZA_ID, sesion);
                    TimeSpan span = (DateTime)dtPlanillaCobranza.Rows[0][PlanillaCobranzaService.FechaFin_NombreCol] - ctactePersona.FechaVencimiento.Date;

                    #region mora segun flujo
                    switch ((int)ctactePersona.Caso.FlujoId)
                    {
                        case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                            porcentajeMora = FacturasClienteService.GetPorcentajeMora(ctactePersona.CasoId.Value);
                            diasDeGraciaMora = FacturasClienteService.GetDiasGracia(ctactePersona.CasoId.Value);
                            diasDeGraciaInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarInteresPunitorioFCDesdeDias);
                            break;
                        case Definiciones.FlujosIDs.NOTA_DEBITO_PERSONA:
                            diasDeGraciaMora = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarMoraFCDesdeDias);
                            diasDeGraciaInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarInteresPunitorioFCDesdeDias);
                            break;
                        case Definiciones.FlujosIDs.CREDITOS:
                            diasDeGraciaInteresPunitorio = decimal.MaxValue;
                            var credito = CreditosService.GetPorCaso(ctactePersona.CasoId.Value, sesion);
                            credito.IniciarUsingSesion(sesion);
                            diasDeGraciaMora = credito.DiasGracia;
                                
                            if (ctactePersona.CalendarioPagosCRCliId.HasValue && ctactePersona.CalendarioPagosCRCli.MontoMoraManual.HasValue)
                            {
                                montoMoraManual = ctactePersona.CalendarioPagosCRCli.MontoMoraManual.Value;
                            }
                            else
                            {
                                if (credito.PorcentajeDiarioMora.HasValue)
                                    porcentajeMora = credito.PorcentajeDiarioMora.Value;
                                else
                                    montoMoraDiario = credito.MontoDiarioMora.Value;
                            }
                            credito.FinalizarUsingSesion();
                            
                            break;
                        case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES:
                            diasDeGraciaMora = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarMoraDescuentoDocDesdeDias);
                            diasDeGraciaInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarInteresPunitorioDescuentoDocDesdeDias);
                            break;
                        case Definiciones.FlujosIDs.TRANSFERENCIA_CTACTE_PERSONA:
                            diasDeGraciaMora = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarMoraFCDesdeDias);
                            diasDeGraciaInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarInteresPunitorioFCDesdeDias);
                            break;
                        case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                            diasDeGraciaMora = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarMoraFCDesdeDias);
                            diasDeGraciaInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarInteresPunitorioFCDesdeDias);
                            break;
                        default:
                            porcentajeMora = montoMoraDiario = 0;
                            break;
                    }
                    #endregion mora segun flujo

                    //Monto mora es el monto pagado por el porcentaje diario de mora por la cantidad de dias de atraso
                    if (montoMoraManual.HasValue)
                    {
                        row.MONTO_MORA = montoMoraManual.Value;
                    }
                    else
                    {
                        if (porcentajeMora > 0)
                            row.MONTO_MORA = row.MONTO_CUOTA * porcentajeMora / 100 * span.Days;
                        else
                            row.MONTO_MORA = montoMoraDiario * span.Days;
                    }
                }
            }

            if (campos.Contains(PlanillaParaCobranzaService.Cobrado_NombreCol) && !esNuevo)
                row.COBRADO = (decimal)campos[PlanillaParaCobranzaService.Cobrado_NombreCol];
            else
                row.COBRADO= row.MONTO_CUOTA + row.MONTO_MORA;

            if (campos.Contains(PlanillaParaCobranzaService.PlanillaDeCobranzaDetalleId_NombreCol))
                row.PLANILLA_DE_COBRANZA_DET_ID = (decimal)campos[PlanillaParaCobranzaService.PlanillaDeCobranzaDetalleId_NombreCol];
            
            if (campos.Contains(PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol))
                row.PLANILLA_DE_COBRANZA_ID = (decimal)campos[PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol];
            else 
                throw new Exception("El campo de Planilla de Cobranza es obligatorio");
                               
           if (esNuevo)
               sesion.Db.PLANILLA_PARA_COBRANZACollection.Insert(row);
           else
               sesion.Db.PLANILLA_PARA_COBRANZACollection.Update(row);

           CuentaCorrientePersonasService.SetBloqueado(row.CTACTE_PERSONA_ID, true, sesion);
           LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal planilla_para_cobranza_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(planilla_para_cobranza_detalle_id, sesion);
                    sesion.CommitTransaction();
                 }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void Borrar(decimal planilla_para_cobranza_detalle_id, SessionService sesion)
        {
            var row = sesion.Db.PLANILLA_PARA_COBRANZACollection.GetByPrimaryKey(planilla_para_cobranza_detalle_id);
            sesion.Db.PLANILLA_PARA_COBRANZACollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

            CuentaCorrientePersonasService.SetBloqueado(row.CTACTE_PERSONA_ID, false, sesion);
        }
        #endregion Borrar

        #region BorrarPorPlanillaDetalle
        public static void BorrarPorPlanillaDetalle(decimal planilla_Cobranza_detalle_id, SessionService sesion)
        {
            PLANILLA_PARA_COBRANZARow[] rows;
            rows = sesion.Db.PLANILLA_PARA_COBRANZACollection.GetByPLANILLA_DE_COBRANZA_DET_ID(planilla_Cobranza_detalle_id);
            for(int i=0 ; i<rows.Length; i++)
            {
                Borrar(rows[i].ID,sesion);
            }
        }
        #endregion BorrarPorPlanillaDetalle

        #region DesbloqueCtactePorPlanillaDetalle
        public static void DesbloqueCtactePorPlanillaDetalle(decimal planilla_Cobranza_detalle_id, SessionService sesion)
        {
            PLANILLA_PARA_COBRANZARow[] rows;
            rows = sesion.Db.PLANILLA_PARA_COBRANZACollection.GetByPLANILLA_DE_COBRANZA_DET_ID(planilla_Cobranza_detalle_id);   
            for (int i = 0; i < rows.Length; i++)
            {
                CuentaCorrientePersonasService.SetBloqueado(rows[i].CTACTE_PERSONA_ID, false, sesion);
            }
        }
        #endregion DesbloqueCtactePorPlanillaDetalle

        #region ActualizarPlanillaDetalle
        public static void ActualizarPlanillaCobranzaDetalleId(decimal planilla_para_cobranza_id, decimal planilla_cobranza_detalle_id, SessionService sesion)
        {      
            try
            {
                PLANILLA_PARA_COBRANZARow row = new PLANILLA_PARA_COBRANZARow();

                row = sesion.Db.PLANILLA_PARA_COBRANZACollection.GetByPrimaryKey(planilla_para_cobranza_id);
                string valorAnterior = row.ToString();

                row.PLANILLA_DE_COBRANZA_DET_ID = planilla_cobranza_detalle_id;

                sesion.Db.PLANILLA_PARA_COBRANZACollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void ActualizarPlanillaDetallePorDetalle(decimal planilla_cobranza_detalle_id_actual, decimal planilla_cobranza_detalle_id_nueva, SessionService sesion)
        {
            PLANILLA_PARA_COBRANZARow[] rows = sesion.Db.PLANILLA_PARA_COBRANZACollection.GetByPLANILLA_DE_COBRANZA_DET_ID(planilla_cobranza_detalle_id_actual);
            string valorAnterior = string.Empty;
            for (int i = 0; i < rows.Length;i++ )
            {
                valorAnterior = rows[i].ToString();
                if (!(planilla_cobranza_detalle_id_nueva == Definiciones.Error.Valor.EnteroPositivo))
                    rows[i].PLANILLA_DE_COBRANZA_DET_ID = planilla_cobranza_detalle_id_nueva;
                else
                    rows[i].IsPLANILLA_DE_COBRANZA_DET_IDNull = true;
                
                sesion.Db.PLANILLA_PARA_COBRANZACollection.Update(rows[i]);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[i].ID, valorAnterior, rows.ToString(), sesion);
            }
        }
        #endregion ActualizarPlanillaDetalle

        #region ActualizarMontoCobrado
        public static CBA.FlowV2.Services.Base.Excepciones ActualizarMontoCobrado(decimal planilla_cobranza_id, bool incluir_mora, DataTable dt)
        {
            using (SessionService sesion = new SessionService())
            {
                CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

                try
                {
                    sesion.BeginTransaction();

                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        excepciones.Agregar("No se encontraron datos.");
                        return excepciones;
                    }

                    string clausulas;
                    DataTable dtDetalles, dtPersona;
                    decimal saldo, montoAplicar;
                    bool porCaso = false;
                    bool porCasoYCuota = false;
                    bool porDocumento = false;

                    //Si solo se indicaron Documento y Monto
                    if (dt.Columns.Contains(NombreColumnas.Caso) && dt.Columns.Contains(NombreColumnas.Cuota))
                        porCasoYCuota = true;
                    else if (dt.Columns.Contains(NombreColumnas.Caso))
                        porCaso = true;
                    else if (dt.Columns.Contains(NombreColumnas.Documento))
                        porDocumento = true;
                    else
                        excepciones.Agregar("No se indicaron datos suficientes para encontrar las cuotas.");

                    if (excepciones.Cantidad > 0)
                        return excepciones;

                    //Primero modificar el monto en los detalles existentes de la persona
                    //y luego completar con otras cuotas de la persona. No debe existir mas
                    //de un registro por persona
                    if (porDocumento)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            #region Obtener datos
                            if (!decimal.TryParse(dt.Rows[i][NombreColumnas.Cobrado].ToString(), out saldo))
                            {
                                excepciones.Agregar("Línea " + i + ", el monto a cobrar no es un número válido.");
                                continue;
                            }

                            dtPersona = PersonasService.GetPersonasDataTable("upper(" + PersonasService.NumeroDocumento_NombreCol + ") = '" + dt.Rows[i][NombreColumnas.Documento].ToString().ToUpper() + "'", string.Empty);
                            if (dtPersona.Rows.Count <= 0)
                            {
                                excepciones.Agregar("Línea " + (i + 1) + ", no se encontró a la persona con documento " + dt.Rows[i][NombreColumnas.Documento] + ".");
                                continue;
                            }

                            clausulas = PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol + " = " + planilla_cobranza_id + " and " +
                                        PlanillaParaCobranzaService.VistaPersonaId_NombreCol + " = " + dtPersona.Rows[0][PersonasService.Id_NombreCol] + " and " +
                                        PlanillaParaCobranzaService.VistaMonedaSimbolo_NombreCol + " = '" + dt.Rows[i][NombreColumnas.Moneda] + "'";
                            dtDetalles = GetPlanillaParaCobranzaInfoCompleta(clausulas, PlanillaParaCobranzaService.Id_NombreCol);
                            #endregion Obtener datos

                            #region Modificar monto de detalles o borrar si no queda saldo
                            for (int j = 0; j < dtDetalles.Rows.Count; j++)
                            {
                                if (saldo > 0)
                                {
                                    PLANILLA_PARA_COBRANZARow row = sesion.db.PLANILLA_PARA_COBRANZACollection.GetByPrimaryKey((decimal)dtDetalles.Rows[j][PlanillaParaCobranzaService.Id_NombreCol]);
                                    montoAplicar = Math.Min((decimal)dtDetalles.Rows[j][PlanillaParaCobranzaService.Cobrado_NombreCol], saldo);

                                    row.COBRADO = montoAplicar;
                                    sesion.db.PLANILLA_PARA_COBRANZACollection.Update(row);
                                    saldo -= montoAplicar;
                                }
                                else
                                {
                                    sesion.db.PLANILLA_PARA_COBRANZACollection.DeleteByPrimaryKey((decimal)dtDetalles.Rows[j][PlanillaParaCobranzaService.Id_NombreCol]);
                                }
                            }
                            #endregion Modificar monto de detalles o borrar si no queda saldo

                            #region Agregar detalles hasta cubrir saldo
                            if (saldo > 0)
                            {
                                var moneda = MonedasService.Instancia.GetPrimero<MonedasService>(new ClaseCBABase.Filtro { Columna = MonedasService.Modelo.SIMBOLOColumnName, Valor = (string)dt.Rows[i][NombreColumnas.Moneda] });
                                clausulas = CuentaCorrientePersonasService.MonedaId_NombreCol + " = " + moneda.Id.Value + " and " +
                                            "not exists(select ppc." + PlanillaParaCobranzaService.Id_NombreCol +
                                            "             from " + PlanillaParaCobranzaService.Nombre_Tabla + " ppc " +
                                            "            where ppc." + PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol + " = " + planilla_cobranza_id +
                                            "              and ppc." + PlanillaParaCobranzaService.CtaCtePersonaId_NombreCol + " = " + CuentaCorrientePersonasService.Nombre_Vista + "." + CuentaCorrientePersonasService.Id_NombreCol +
                                            ")";
                                
                                DataTable dtCtactePersonaDocumentos = CuentaCorrientePersonasService.GetOrdenadoPorVencimientoDataTable((decimal)dtPersona.Rows[0][PersonasService.Id_NombreCol], clausulas, sesion);
                                decimal sumaDocumentosDestino = 0;
                                for (int j = 0; j < dtCtactePersonaDocumentos.Rows.Count && saldo > 0; j++)
                                {
                                    //Asignar el monto maximo que podria pagarse del documento
                                    decimal saldoCuota = (decimal)dtCtactePersonaDocumentos.Rows[j][CuentaCorrientePersonasService.VistaSaldoDebito_NombreCol] * (-1);
                                    montoAplicar = Math.Min(saldoCuota, saldo);

                                    sumaDocumentosDestino += montoAplicar;

                                    Hashtable campos = new Hashtable();
                                    campos.Add(PlanillaParaCobranzaService.CtaCtePersonaId_NombreCol, dtCtactePersonaDocumentos.Rows[j][CuentaCorrientePersonasService.Id_NombreCol]);
                                    campos.Add(PlanillaParaCobranzaService.MontoCuota_NombreCol, saldoCuota);
                                    campos.Add(PlanillaParaCobranzaService.Cobrado_NombreCol, montoAplicar);
                                    campos.Add(PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol, planilla_cobranza_id);
                                    PlanillaParaCobranzaService.Guardar(campos, incluir_mora, true, sesion);

                                    saldo -= montoAplicar;
                                }
                            }
                            #endregion Agregar detalles hasta cubrir saldo
                        }
                    }
                    //Modificar el monto en los detalles existentes por caso y cuota si se definio
                    //No debe existir mas de un registro por caso, o caso y cuota
                    else if (porCasoYCuota || porCaso)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            #region Obtener datos
                            if (!decimal.TryParse(dt.Rows[i][NombreColumnas.Cobrado].ToString(), out saldo))
                            {
                                excepciones.Agregar("Línea " + i + ", el monto a cobrar no es un número válido.");
                                continue;
                            }

                            clausulas = PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol + " = " + planilla_cobranza_id + " and " +
                                        PlanillaParaCobranzaService.VistaCasoId_NombreCol + " = " + dt.Rows[i][NombreColumnas.Caso] + " and ";

                            if(porCasoYCuota)
                                clausulas += PlanillaParaCobranzaService.VistaNroCuota_NombreCol + " = '" + dt.Rows[i][NombreColumnas.Cuota] + "' ";

                            dtDetalles = GetPlanillaParaCobranzaInfoCompleta(clausulas, PlanillaParaCobranzaService.Id_NombreCol);
                            #endregion Obtener datos

                            #region Modificar monto de detalle
                            for (int j = 0; j < dtDetalles.Rows.Count; j++)
                            {
                                if (saldo > 0)
                                {
                                    PLANILLA_PARA_COBRANZARow row = sesion.db.PLANILLA_PARA_COBRANZACollection.GetByPrimaryKey((decimal)dtDetalles.Rows[j][PlanillaParaCobranzaService.Id_NombreCol]);
                                    montoAplicar = Math.Min((decimal)dtDetalles.Rows[j][PlanillaParaCobranzaService.Cobrado_NombreCol], saldo);

                                    row.COBRADO = montoAplicar;
                                    sesion.db.PLANILLA_PARA_COBRANZACollection.Update(row);
                                    saldo -= montoAplicar;
                                }
                                else
                                {
                                    sesion.db.PLANILLA_PARA_COBRANZACollection.DeleteByPrimaryKey((decimal)dtDetalles.Rows[j][PlanillaParaCobranzaService.Id_NombreCol]);
                                }
                            }
                            #endregion Modificar monto de detalles o borrar si no queda saldo

                            #region Agregar detalles hasta cubrir saldo
                            if (saldo > 0)
                            {
                                var moneda = MonedasService.Instancia.GetPrimero<MonedasService>(new ClaseCBABase.Filtro { Columna = MonedasService.Modelo.SIMBOLOColumnName, Valor = (string)dt.Rows[i][NombreColumnas.Moneda] });
                                clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + dt.Rows[i][NombreColumnas.Caso] + " and " +
                                            CuentaCorrientePersonasService.Bloqueado_NombreCol + " = '" + Definiciones.SiNo.No + "' and " +
                                            CuentaCorrientePersonasService.MonedaId_NombreCol + " = " + moneda.Id.Value + " and ";
                                if (porCasoYCuota)
                                    clausulas += CuentaCorrientePersonasService.VistaCuota_NombreCol + " = '" + dt.Rows[i][NombreColumnas.Cuota] + "' and ";

                                clausulas += CuentaCorrientePersonasService.Credito_NombreCol + " > " + CuentaCorrientePersonasService.Debito_NombreCol + " and " +
                                            "not exists(select ppc." + PlanillaParaCobranzaService.Id_NombreCol +
                                            "             from " + PlanillaParaCobranzaService.Nombre_Tabla + " ppc " +
                                            "            where ppc." + PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol + " = " + planilla_cobranza_id +
                                            "              and ppc." + PlanillaParaCobranzaService.CtaCtePersonaId_NombreCol + " = " + CuentaCorrientePersonasService.Nombre_Vista + "." + CuentaCorrientePersonasService.Id_NombreCol +
                                            ")";
                                dtDetalles = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(clausulas, CuentaCorrientePersonasService.FechaVencimiento_NombreCol, sesion);
                                for (int j = 0; j < dtDetalles.Rows.Count && saldo > 0; j++)
                                {
                                    decimal saldoCuota = (decimal)dtDetalles.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol] - (decimal)dtDetalles.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol];
                                    montoAplicar = Math.Min(saldoCuota, saldo);

                                    Hashtable campos = new Hashtable();
                                    campos.Add(PlanillaParaCobranzaService.CtaCtePersonaId_NombreCol, dtDetalles.Rows[j][CuentaCorrientePersonasService.Id_NombreCol]);
                                    campos.Add(PlanillaParaCobranzaService.MontoCuota_NombreCol, saldoCuota);
                                    campos.Add(PlanillaParaCobranzaService.Cobrado_NombreCol, montoAplicar);
                                    campos.Add(PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol, planilla_cobranza_id);
                                    PlanillaParaCobranzaService.Guardar(campos, incluir_mora, true, sesion);

                                    saldo -= montoAplicar;
                                }
                            }
                            #endregion Agregar detalles hasta cubrir saldo
                        }
                    }

                    sesion.CommitTransaction();
                }
                catch(Exception e)
                {
                    sesion.RollbackTransaction();
                    excepciones.Agregar(e.Message, e);
                }

                return excepciones;
            }
        }
        #endregion ActualizarMontoCobrado

        #region Accessors
        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "PLANILLA_PARA_COBRANZA"; }
        }

        public static string Id_NombreCol
        {
            get { return PLANILLA_PARA_COBRANZACollection.IDColumnName; }
        }
        public static string CtaCtePersonaId_NombreCol
        {
            get { return PLANILLA_PARA_COBRANZACollection.CTACTE_PERSONA_IDColumnName; }
        }
        public static string MontoCuota_NombreCol
        {
            get { return PLANILLA_PARA_COBRANZACollection.MONTO_CUOTAColumnName; }
        }
        public static string MontoMora_NombreCol
        {
            get { return PLANILLA_PARA_COBRANZACollection.MONTO_MORAColumnName; }
        }
        public static string PlanillaDeCobranzaId_NombreCol
        {
            get { return PLANILLA_PARA_COBRANZACollection.PLANILLA_DE_COBRANZA_IDColumnName; }
        }
        public static string PlanillaDeCobranzaDetalleId_NombreCol
        {
            get { return PLANILLA_PARA_COBRANZACollection.PLANILLA_DE_COBRANZA_DET_IDColumnName; }
        }
        public static string Cobrado_NombreCol
        {
            get { return PLANILLA_PARA_COBRANZACollection.COBRADOColumnName; }
        }
        #endregion Tablas
        
        #region Vistas

        public static string Nombre_Vista
        {
            get { return "PLANILLA_P_COBRAN_INFO_COMPL"; }
        }
        public static string VistaCasoId_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.CASO_IDColumnName; }
        }
        public static string VistaFlujoNombre_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.FLUJO_NOMBREColumnName; }
        }
        public static string VistaCotizacionMoneda_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string VistaNroCuota_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.CUOTA_NUMEROColumnName; }
        }
        public static string VistaFechaVencimiento_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }
        public static string VistaMonedaCadenaDecimales_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.MONEDA_CADENA_DECIMALESColumnName; }
        }
        public static string VistaMonedaId_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.MONEDA_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaCasoNroComprobante_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.CASO_NRO_COMPROBANTEColumnName; }
        }
        public static string VistaPersonaCodigo_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.PERSONA_CODIGOColumnName; }
        }
        public static string VistaPersonaCodigoExterno_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.PERSONA_CODIGO_EXTERNOColumnName; }
        }
        public static string VistaPersonaId_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.PERSONA_IDColumnName; }
        }
        public static string VistaPersonaNombreCompleto_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaPersonaNumeroDocumento_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.PERSONA_NUMERO_DOCUMENTOColumnName; }
        }
        public static string VistaPersonaDireccion_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.PERSONA_DIRECCIONColumnName; }
        }
        public static string VistaSaldoCuota_NombreCol
        {
            get { return PLANILLA_P_COBRAN_INFO_COMPLCollection.SALDO_CUOTAColumnName; }
        }
        
        #endregion Vistas
        #endregion Accessors
    }
}
