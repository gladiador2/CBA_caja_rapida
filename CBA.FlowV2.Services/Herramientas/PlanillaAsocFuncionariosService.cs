

using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Anticipo;
using System.Collections;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.Tesoreria;
using System.Collections.Generic;
using CBA.FlowV2.Services.Common;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PlanillaAsocFuncionariosService
    {
        #region GetPlanillaAsocFuncionariosDataTable
        public static DataTable GetPlanillaAsocFuncionariosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.PLANILLA_ASOC_FUNCIONARIOSCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetPlanillaAsocFuncionariosDataTable

        #region GetPlanillaAsocFuncionariosInfoCompletaDataTable
        public static DataTable GetPlanillaAsocFuncionariosInfoCompletaDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.PLANILLA_ASOC_FUNC_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetPlanillaAsocFuncionariosInfoCompletaDataTable

        #region CrearAplicacionDocumentos
        public static Dictionary<decimal, string> CrearAplicacionDocumentos(decimal planilla_asociacion_funcionarios_id, decimal ctacte_caja_sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    PLANILLA_ASOC_FUNCIONARIOSRow row = sesion.db.PLANILLA_ASOC_FUNCIONARIOSCollection.GetByPrimaryKey(planilla_asociacion_funcionarios_id);
                    DataTable dtDetalles = PlanillaAsocFuncionariosDetService.GetPlanillaAsocFuncionariosDetDataTable(PlanillaAsocFuncionariosDetService.PlanillaAsocFuncionariosId_NombreCol + " = " + planilla_asociacion_funcionarios_id, PlanillaAsocFuncionariosDetService.Id_NombreCol);
                    DataTable dtAnticipoCliente = AnticiposPersonaService.GetAnticipoPersonaPorCasoDataTable2(row.CASO_ASOCIADO_ID);
                    DataTable dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesPorFlujo2(CBA.FlowV2.Services.Base.Definiciones.FlujosIDs.APLICACION_DOCUMENTOS, (decimal)dtAnticipoCliente.Rows[0][AnticiposPersonaService.SucursalId_NombreCol]);
                    DataTable dtCtactePersonaAnticipo = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CasoId_NombreCol + " = " + row.CASO_ASOCIADO_ID, CuentaCorrientePersonasService.Id_NombreCol, sesion);
                    DataTable dtAplicacionDocumento, dtCtactePersonaDocumentos;
                    decimal saldoAnticipo, montoDocumentoOrigen, montoDocumentoDestino, sumaDocumentosDestino;
                    decimal totalDetalles = 0;
                    string casoCreadoEstado = string.Empty, casoCreadoMensaje;
                    decimal casoCreadoId = Definiciones.Error.Valor.EnteroPositivo;
                    Dictionary<decimal, string> dResultado = new Dictionary<decimal,string>();
                    bool exito;
                    
                    #region Validar saldo suficiente
                    for (int i = 0; i < dtDetalles.Rows.Count; i++)
                    {
                        if (!Interprete.EsNullODBNull(dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.CasoAsociadoId_NombreCol]))
                            continue;

                        totalDetalles += (decimal)dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.Monto_NombreCol];
                    }

                    if((decimal)dtAnticipoCliente.Rows[0][AnticiposPersonaService.MonedaId_NombreCol] != row.MONEDA_ID)
                        saldoAnticipo = Math.Round((decimal)dtAnticipoCliente.Rows[0][AnticiposPersonaService.SaldoPorAplicar_NombreCol] / (decimal)dtAnticipoCliente.Rows[0][AnticiposPersonaService.CotizacionMoneda_NombreCol] * row.COTIZACION, MonedasService.CantidadDecimalesStatic(row.MONEDA_ID));
                    else
                        saldoAnticipo = Math.Round((decimal)dtAnticipoCliente.Rows[0][AnticiposPersonaService.SaldoPorAplicar_NombreCol], MonedasService.CantidadDecimalesStatic(row.MONEDA_ID));

                    if (totalDetalles > saldoAnticipo)
                        throw new Exception("El anticipo no tiene saldo suficiente. Hay una diferencia de " + (totalDetalles - saldoAnticipo) + ".");
                    #endregion Validar saldo suficiente

                    if(dtAutonumeracion.Rows.Count <= 0)
                        throw new Exception("No se encontró un talonario para Aplicación de Documentos.");

                    for (int i = 0; i < dtDetalles.Rows.Count; i++)
                    {
                        if (!Interprete.EsNullODBNull(dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.CasoAsociadoId_NombreCol]))
                            continue;

                        #region crear cabecera
                        casoCreadoId = Definiciones.Error.Valor.EnteroPositivo;
                        Hashtable campos = new Hashtable();
                        campos.Add(NotasCreditoPersonaAplicacionesService.SucursalId_NombreCol, dtAnticipoCliente.Rows[0][AnticiposPersonaService.SucursalId_NombreCol]);
                        campos.Add(NotasCreditoPersonaAplicacionesService.UsuarioId_NombreCol, sesion.Usuario.ID);
                        campos.Add(NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol, dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.PersonaId_NombreCol]);
                        campos.Add(NotasCreditoPersonaAplicacionesService.PersonaValoresId_NombreCol, dtAnticipoCliente.Rows[0][AnticiposPersonaService.PersonaId_NombreCol]);
                        campos.Add(NotasCreditoPersonaAplicacionesService.FuncionarioId_NombreCol, row.FUNCIONARIO_ID);
                        campos.Add(NotasCreditoPersonaAplicacionesService.CtacteCajaSucursalId_NombreCol, ctacte_caja_sucursal_id);
                        campos.Add(NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol, row.MONEDA_ID);
                        campos.Add(NotasCreditoPersonaAplicacionesService.Fecha_NombreCol, row.FECHA);
                        campos.Add(NotasCreditoPersonaAplicacionesService.Cotizacion_NombreCol, row.COTIZACION);
                        campos.Add(NotasCreditoPersonaAplicacionesService.AutonumeracionId_NombreCol, dtAutonumeracion.Rows[0][AutonumeracionesService.Id_NombreCol]);
                        campos.Add(NotasCreditoPersonaAplicacionesService.ConsolidacionDeuda_NombreCol, Definiciones.SiNo.No);
                        campos.Add(NotasCreditoPersonaAplicacionesService.TotalDocumentos_NombreCol, dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.Monto_NombreCol]);
                        campos.Add(NotasCreditoPersonaAplicacionesService.TotalValores_NombreCol, dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.Monto_NombreCol]);
                        campos.Add(NotasCreditoPersonaAplicacionesService.Observacion_NombreCol, CuentaCorrienteRecibosService.GetNumeroRecibo((decimal)dtAnticipoCliente.Rows[0][AnticiposPersonaService.CtacteReciboId_NombreCol], sesion));
                        NotasCreditoPersonaAplicacionesService.Guardar(campos, true, ref casoCreadoId, ref casoCreadoEstado, sesion);
                        dtAplicacionDocumento = NotasCreditoPersonaAplicacionesService.GetNotaCreditoPersonaAplicacionPorCaso(casoCreadoId, sesion);
                        #endregion crear cabecera

                        #region agregar valores
                        campos = new Hashtable();
                        campos.Add(NotasCreditoPersonaAplicacionValoresService.CtaCtePersonaId_NombreCol, (decimal)dtCtactePersonaAnticipo.Rows[0][CuentaCorrientePersonasService.Id_NombreCol]);
                        campos.Add(NotasCreditoPersonaAplicacionValoresService.Tipo_NombreCol, Definiciones.TipoComprobanteAplicable.Persona);
                        campos.Add(NotasCreditoPersonaAplicacionValoresService.MontoDestino_NombreCol, dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.Monto_NombreCol]);
                        if ((decimal)dtAnticipoCliente.Rows[0][AnticiposPersonaService.MonedaId_NombreCol] != row.MONEDA_ID)
                            campos.Add(NotasCreditoPersonaAplicacionValoresService.MontoOrigen_NombreCol, (decimal)dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.Monto_NombreCol] * (decimal)dtAnticipoCliente.Rows[0][AnticiposPersonaService.CotizacionMoneda_NombreCol] / row.COTIZACION);
                        else
                            campos.Add(NotasCreditoPersonaAplicacionValoresService.MontoOrigen_NombreCol, (decimal)dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.Monto_NombreCol]);
                        campos.Add(NotasCreditoPersonaAplicacionValoresService.Cotizacion_NombreCol, row.COTIZACION);
                        campos.Add(NotasCreditoPersonaAplicacionValoresService.MonedaId_NombreCol, row.MONEDA_ID);
                        campos.Add(NotasCreditoPersonaAplicacionValoresService.AplicacionDocumentoId_NombreCol, dtAplicacionDocumento.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol]);
                        NotasCreditoPersonaAplicacionValoresService.Guardar(campos, sesion);
                        #endregion agregar cabecera

                        #region agregar documentos
                        dtCtactePersonaDocumentos = CuentaCorrientePersonasService.GetOrdenadoPorVencimientoDataTable((decimal)dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.PersonaId_NombreCol], string.Empty, sesion);
                        sumaDocumentosDestino = 0;
                        for (int j = 0; j < dtCtactePersonaDocumentos.Rows.Count; j++)
                        {
                            //Asignar el monto maximo que podria pagarse del documento
                            montoDocumentoOrigen = (decimal)dtCtactePersonaDocumentos.Rows[j][CuentaCorrientePersonasService.VistaSaldoDebito_NombreCol] * (-1);
                            if ((decimal)dtCtactePersonaDocumentos.Rows[j][CuentaCorrientePersonasService.MonedaId_NombreCol] != row.MONEDA_ID)
                                montoDocumentoDestino = montoDocumentoOrigen / (decimal)dtCtactePersonaDocumentos.Rows[j][CuentaCorrientePersonasService.CotizacionMoneda_NombreCol] * row.COTIZACION;
                            else
                                montoDocumentoDestino = montoDocumentoOrigen;

                            //Encontrar el monto maximo que puede pagarse segun detalle de la planilla
                            if (montoDocumentoDestino + sumaDocumentosDestino > (decimal)dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.Monto_NombreCol])
                            {
                                decimal porcentaje = ((decimal)dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.Monto_NombreCol] - sumaDocumentosDestino) / montoDocumentoDestino;
                                montoDocumentoOrigen *= porcentaje;
                                montoDocumentoDestino *= porcentaje;
                            }

                            sumaDocumentosDestino += montoDocumentoDestino;

                            campos = new Hashtable();
                            campos.Add(NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol, dtCtactePersonaDocumentos.Rows[j][CuentaCorrientePersonasService.Id_NombreCol]);
                            campos.Add(NotasCreditoPersonaAplicacionDocumentosService.MonedaId_NombreCol, row.MONEDA_ID);
                            campos.Add(NotasCreditoPersonaAplicacionDocumentosService.Cotizacion_NombreCol, row.COTIZACION);
                            campos.Add(NotasCreditoPersonaAplicacionDocumentosService.MontoDestino_NombreCol, montoDocumentoDestino);
                            campos.Add(NotasCreditoPersonaAplicacionDocumentosService.MontoOrigen_NombreCol, montoDocumentoOrigen);
                            campos.Add(NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol, dtAplicacionDocumento.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol]);
                            NotasCreditoPersonaAplicacionDocumentosService.Guardar(campos, sesion);

                            if (sumaDocumentosDestino >= (decimal)dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.Monto_NombreCol])
                                break;
                        }
                        #endregion agregar documentos

                        if (Math.Round(sumaDocumentosDestino, MonedasService.CantidadDecimalesStatic(row.MONEDA_ID, sesion)) < Math.Round((decimal)dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.Monto_NombreCol], MonedasService.CantidadDecimalesStatic(row.MONEDA_ID, sesion)))
                            throw new Exception("En el detalle " + i + " el cliente paga " + dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.Monto_NombreCol] + " pero los documentos adeudados suman " + sumaDocumentosDestino + ".");

                        PlanillaAsocFuncionariosDetService.ActualizarCasoAsociado((decimal)dtDetalles.Rows[i][PlanillaAsocFuncionariosDetService.Id_NombreCol], casoCreadoId, sesion);

                        exito = (new NotasCreditoPersonaAplicacionesService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, false, out casoCreadoMensaje, sesion);
                        if (exito)
                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, "Transición Automática por Planilla de Asociación de Funcionarios.", sesion);

                        exito = (new NotasCreditoPersonaAplicacionesService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, false, out casoCreadoMensaje, sesion);
                        if (exito)
                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, "Transición Automática por Planilla de Asociación de Funcionarios.", sesion);

                        dResultado.Add(casoCreadoId, "Creado exitosamente.");
                    }

                    sesion.CommitTransaction();
                    return dResultado;
                }
                catch (Exception e)
                {
                    sesion.RollbackTransaction();
                    throw e;
                }
            }
        }
        #endregion CrearAplicacionDocumentos

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PLANILLA_ASOC_FUNCIONARIOSRow planillaAsocFuncionarios = new PLANILLA_ASOC_FUNCIONARIOSRow();
                    String valorAnterior = string.Empty;

                    if (!campos.Contains(PlanillaAsocFuncionariosService.Id_NombreCol))
                    {
                        planillaAsocFuncionarios.ID = sesion.Db.GetSiguienteSecuencia("planilla_asoc_func_sqc");
                        planillaAsocFuncionarios.GENERADO = Definiciones.SiNo.No;
                        planillaAsocFuncionarios.ESTADO = Definiciones.Estado.Activo;
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        planillaAsocFuncionarios = sesion.Db.PLANILLA_ASOC_FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + (decimal)campos[Id_NombreCol]);
                        valorAnterior = planillaAsocFuncionarios.ToString();
                    }

                    if (campos.Contains(PlanillaAsocFuncionariosService.Id_NombreCol))
                    {
                        planillaAsocFuncionarios.ID = (decimal)campos[PlanillaAsocFuncionariosService.Id_NombreCol];
                    }

                    if (campos.Contains(PlanillaAsocFuncionariosService.FuncionarioId_NombreCol))
                    {
                        planillaAsocFuncionarios.FUNCIONARIO_ID = (decimal)campos[PlanillaAsocFuncionariosService.FuncionarioId_NombreCol];
                    }

                    if (campos.Contains(PlanillaAsocFuncionariosService.Fecha_NombreCol))
                    {
                        planillaAsocFuncionarios.FECHA = (DateTime)campos[PlanillaAsocFuncionariosService.Fecha_NombreCol];
                    }

                    if (campos.Contains(PlanillaAsocFuncionariosService.CasoAsociadoId_NombreCol))
                    {
                        planillaAsocFuncionarios.CASO_ASOCIADO_ID = (decimal)campos[PlanillaAsocFuncionariosService.CasoAsociadoId_NombreCol];
                    }

                    if (campos.Contains(PlanillaAsocFuncionariosService.Generado_NombreCol))
                    {
                        planillaAsocFuncionarios.GENERADO = (string)campos[PlanillaAsocFuncionariosService.Generado_NombreCol];
                    }

                    if (campos.Contains(PlanillaAsocFuncionariosService.Observacion_NombreCol))
                    {
                        planillaAsocFuncionarios.OBSERVACION = (string)campos[PlanillaAsocFuncionariosService.Observacion_NombreCol];
                    }

                    if (campos.Contains(PlanillaAsocFuncionariosService.PersonaId_NombreCol))
                    {
                        planillaAsocFuncionarios.PERSONA_ID = (decimal)campos[PlanillaAsocFuncionariosService.PersonaId_NombreCol];
                    }

                    if (campos.Contains(PlanillaAsocFuncionariosService.Monto_NombreCol))
                    {
                        planillaAsocFuncionarios.MONTO = (decimal)campos[PlanillaAsocFuncionariosService.Monto_NombreCol];
                    }

                    if (campos.Contains(PlanillaAsocFuncionariosService.MonedaId_NombreCol))
                    {
                        planillaAsocFuncionarios.MONEDA_ID = (decimal)campos[PlanillaAsocFuncionariosService.MonedaId_NombreCol];
                    }

                    if (campos.Contains(PlanillaAsocFuncionariosService.Cotizacion_NombreCol))
                    {
                        planillaAsocFuncionarios.COTIZACION = (decimal)campos[PlanillaAsocFuncionariosService.Cotizacion_NombreCol];
                    }

                    if (campos.Contains(PlanillaAsocFuncionariosService.Estado_NombreCol))
                    {
                        planillaAsocFuncionarios.ESTADO = (string)campos[PlanillaAsocFuncionariosService.Estado_NombreCol];
                    }

                    if (campos.Contains(PlanillaAsocFuncionariosService.NroComprobante_NombreCol))
                    {
                        planillaAsocFuncionarios.NRO_COMPROBANTE = (string)campos[PlanillaAsocFuncionariosService.NroComprobante_NombreCol];
                    }

                    if (!campos.Contains(PlanillaAsocFuncionariosService.Id_NombreCol)) sesion.Db.PLANILLA_ASOC_FUNCIONARIOSCollection.Insert(planillaAsocFuncionarios);
                    else sesion.Db.PLANILLA_ASOC_FUNCIONARIOSCollection.Update(planillaAsocFuncionarios);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, planillaAsocFuncionarios.ID, valorAnterior, planillaAsocFuncionarios.ToString(), sesion);

                    sesion.Db.CommitTransaction();

                    return planillaAsocFuncionarios.ID;
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
            get { return "PLANILLA_ASOC_FUNCIONARIOS"; }
        }

        public static string Id_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOSCollection.IDColumnName; }
        }

        public static string FuncionarioId_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOSCollection.FUNCIONARIO_IDColumnName; }
        }

        public static string Fecha_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOSCollection.FECHAColumnName; }
        }

        public static string CasoAsociadoId_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOSCollection.CASO_ASOCIADO_IDColumnName; }
        }

        public static string Generado_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOSCollection.GENERADOColumnName; }
        }

        public static string Observacion_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOSCollection.OBSERVACIONColumnName; }
        }

        public static string PersonaId_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOSCollection.PERSONA_IDColumnName; }
        }

        public static string Monto_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOSCollection.MONTOColumnName; }
        }

        public static string MonedaId_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOSCollection.MONEDA_IDColumnName; }
        }

        public static string Cotizacion_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOSCollection.COTIZACIONColumnName; }
        }

        public static string Estado_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOSCollection.ESTADOColumnName; }
        }

        public static string NroComprobante_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOSCollection.NRO_COMPROBANTEColumnName; }
        }

        public static string PersonaNombreCompleto_NombreCol
        {
            get { return PLANILLA_ASOC_FUNC_INFO_COMPCollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }

        public static string FuncionarioNombre_NombreCol
        {
            get { return PLANILLA_ASOC_FUNC_INFO_COMPCollection.FUNCIONARIO_NOMBREColumnName; }
        }

        #endregion Accessors
    }
}

