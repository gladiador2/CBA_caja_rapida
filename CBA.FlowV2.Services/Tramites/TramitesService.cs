#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using System.Data;
using System.Collections;
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.Tramites
{
    public class TramitesService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.TRAMITES;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var drCabecera = (DataRow)caso_cabecera;
            var drDetalle = (DataRow)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);

            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, );
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, drCabecera[TramitesService.TextoPredefinidoId_NombreCol]);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }

        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza las acciones necesarias al cambiar de estado un caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_destino">The estado_destino.</param>
        /// <param name="cambio_pedido_por_usuario">El cambio fue pedido por el usuario o por el sistema</param>
        /// <param name="mensaje">The mensaje de salida.</param>
        /// <returns>
        /// True si no los controles se ejecutaron exitosamente, si no false.
        /// </returns>
        public override bool ProcesarCambioEstado(decimal caso_id, string estado_destino, bool cambio_pedido_por_usuario, out string mensaje, SessionService sesion)
        {
            bool exito = false;
            bool revisarRequisitos = false;
            mensaje = string.Empty;

            try
            {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                TRAMITESRow cabeceraRow = sesion.Db.TRAMITESCollection.GetByCASO_ID(caso_id)[0];
                TRAMITES_CAMPOS_ETAPAS_VALORESRow[] valoresRows = sesion.Db.TRAMITES_CAMPOS_ETAPAS_VALORESCollection.GetByTRAMITE_ID(cabeceraRow.ID);
                // de Borrador a Anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna accion.
                    exito = true;
                    revisarRequisitos = true;
                }
                // de Borrador a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Generar nro de comprobante
                    exito = true;
                    revisarRequisitos = true;

                    #region Generar autonumeracion
                    //Si no existe un comprobante se crea
                    if (ClaseCBABase.GetStringHelper(cabeceraRow.NRO_COMPROBANTE).Length <= 0)
                    {
                        if (cabeceraRow.IsAUTONUMERACION_IDNull)
                            throw new Exception("Debe indicarse el talonario.");
                        cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);
                    }
                    #endregion Generar autonumeracion
                }
                // de Pendiente a Borrador
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //Ninguna accion.
                    exito = true;
                    revisarRequisitos = false;
                }
                // de Pendiente a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna accion.
                    exito = true;
                    revisarRequisitos = true;
                }
                // de Pendiente a Aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones
                    //Ninguna accion.
                    revisarRequisitos = true;
                    exito = true;
                }
                // de Aprobado a Vigente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Vigente))
                {
                    //Acciones
                    //Ninguna accion.
                    revisarRequisitos = true;
                    exito = true;
                }
                // de Vigente a Cerrado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Vigente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                {
                    //Acciones
                    //Ninguna accion.
                    revisarRequisitos = true;
                    exito = true;
                }

                //Verificar si se cumplen los requisitos
                if (exito && revisarRequisitos)
                {
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                }

                if (exito)
                {
                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.Db.TRAMITESCollection.Update(cabeceraRow);
                }
            }
            catch (Exception exp)
            {
                exito = false;
                throw exp;
            }
            return exito;
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion) 
        {
            EjecutarAccionesLuegoDeCambioEstadoPorCliente(caso_id, estado_destino_id, sesion);
        }

        private void EjecutarAccionesLuegoDeCambioEstadoPorCliente(decimal caso_id, string estado_destino_id, SessionService sesion)
        {
            switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.Cliente))
            { 
                case Definiciones.Clientes.TyC:
                    EjecutarAccionesLuegoDeCambioEstadoPorCliente_12(caso_id, estado_destino_id, sesion);
                    break;
            }
        }

        private void EjecutarAccionesLuegoDeCambioEstadoPorCliente_12(decimal caso_id, string estado_destino_id, SessionService sesion)
        {
            var caso = new CasosService(caso_id, sesion);
            TRAMITESRow cabeceraRow = sesion.Db.TRAMITESCollection.GetByCASO_ID(caso_id)[0];
            
            //Si es de tipo Orden de Servicio que pasó de pendiente a aprobado,
            //crear un caso de tipo Orden de Trabajo
            if (cabeceraRow.TRAMITE_TIPO_ID == 1 && caso.EstadoAnterior == Definiciones.EstadosFlujos.Pendiente && caso.EstadoId == Definiciones.EstadosFlujos.Aprobado)
            {
                Hashtable campos = null;

                #region Crear un caso de trámite tipo Orden de Trabajo
                decimal casoCreadoId = Definiciones.Error.Valor.EnteroPositivo;
                string casoCreadoEstado = string.Empty;
                campos = new Hashtable()
                {
                    { TramitesService.MonedaId_NombreCol, cabeceraRow.MONEDA_ID },
                    { TramitesService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID },
                    { TramitesService.TramiteTipoId_NombreCol, 2m /* tipo Orden de Trabajo */ },
                    { TramitesService.Titulo_NombreCol, cabeceraRow.TITULO },
                    { TramitesService.Fecha_NombreCol, DateTime.Now.Date },
                    { TramitesService.Observacion_NombreCol, cabeceraRow.OBSERVACION },
                    { TramitesService.CasoOriginarioId_NombreCol, cabeceraRow.CASO_ID }
                };

                if (!cabeceraRow.IsPERSONA_IDNull)
                    campos.Add(TramitesService.PersonaId_NombreCol, cabeceraRow.PERSONA_ID);
                if (!cabeceraRow.IsTEXTO_PREDEFINIDO_IDNull)
                    campos.Add(TramitesService.TextoPredefinidoId_NombreCol, cabeceraRow.TEXTO_PREDEFINIDO_ID);

                TramitesService.Guardar(campos, true, ref casoCreadoId, ref casoCreadoEstado, sesion);
                #endregion Crear un caso de trámite tipo Orden de Trabajo

                #region Agregar valores de campos fijos
                var dCamposEquivalencia = new Dictionary<decimal, decimal>() 
                {
                    { 1, 18 }, //Equipo
                    { 2, 19 }, //Fecha inicio
                    { 3, 20 }, //Fecha fin
                    { 4, 21 }, //Funcionario
                    { 5, 22 }, //Horómetro entrada
                    { 6, 23 }, //Horómetro salida
                    { 7, 24 }, //Días de reparación
                    { 8, 25 }, //Recepción de gato
                    { 9, 26 }, //Recepción de baliza
                    { 10, 27 }, //Recepción de habilitaciones
                    { 11, 28 }, //Recepción de rueda auxilio
                    { 12, 29 }, //Recepción de ficha mant.
                    { 13, 30 }, //Recepción de extintor
                    { 14, 31 }, //Recepción de llave
                    { 15, 32 }, //Recepción de rueda
                    { 16, 33 }, //Recepción de manija de llave
                    { 17, 34 }, //Otros
                };

                var dtCabeceraCreada = TramitesService.GetTramitesDataTable(TramitesService.CasoId_NombreCol + " = " + casoCreadoId, string.Empty, sesion);
                var dtValoresCamposFijos = TramitesCamposEtapasValoresService.GetTramitesCamposEtapasValoresDataTable(TramitesCamposEtapasValoresService.TramiteId_NombreCol + " = " + cabeceraRow.ID, TramitesCamposEtapasValoresService.TramiteCamposEtapasId_NombreCol, sesion);

                //Excluir fecha inicio, fecha fin, funcionario
                List<decimal> exclusiones = new List<decimal>() { 2, 3, 4 };

                for (int i = 0; i < dtValoresCamposFijos.Rows.Count; i++)
                {
                    if (exclusiones.Contains((decimal)dtValoresCamposFijos.Rows[i][TramitesCamposEtapasValoresService.TramiteCamposEtapasId_NombreCol]))
                        continue;

                    campos = new Hashtable();
                    campos.Add(TramitesCamposEtapasValoresService.TramiteCamposEtapasId_NombreCol, dCamposEquivalencia[(decimal)dtValoresCamposFijos.Rows[i][TramitesCamposEtapasValoresService.TramiteCamposEtapasId_NombreCol]]);
                    campos.Add(TramitesCamposEtapasValoresService.TramiteId_NombreCol, dtCabeceraCreada.Rows[0][TramitesService.Id_NombreCol]);
                    if (!Interprete.EsNullODBNull(dtValoresCamposFijos.Rows[i][TramitesCamposEtapasValoresService.ValorFecha_NombreCol]))
                        campos.Add(TramitesCamposEtapasValoresService.ValorFecha_NombreCol, dtValoresCamposFijos.Rows[i][TramitesCamposEtapasValoresService.ValorFecha_NombreCol]);
                    if (!Interprete.EsNullODBNull(dtValoresCamposFijos.Rows[i][TramitesCamposEtapasValoresService.ValorNumero_NombreCol]))
                        campos.Add(TramitesCamposEtapasValoresService.ValorNumero_NombreCol, dtValoresCamposFijos.Rows[i][TramitesCamposEtapasValoresService.ValorNumero_NombreCol]);
                    if (!Interprete.EsNullODBNull(dtValoresCamposFijos.Rows[i][TramitesCamposEtapasValoresService.ValorTexto_NombreCol]))
                        campos.Add(TramitesCamposEtapasValoresService.ValorTexto_NombreCol, dtValoresCamposFijos.Rows[i][TramitesCamposEtapasValoresService.ValorTexto_NombreCol]);
                    TramitesCamposEtapasValoresService.Guardar(campos, true, sesion);
                }
                #endregion Agregar valores de campos fijos

                #region Asociar bidireccionalmente en casos asociados
                campos = new Hashtable()
                {
                    { TramitesCasosAsociadosService.TramiteId_NombreCol, cabeceraRow.ID},
                    { TramitesCasosAsociadosService.FechaAgregado_NombreCol, DateTime.Now},
                    { TramitesCasosAsociadosService.UsuarioId_NombreCol, sesion.Usuario.ID},
                    { TramitesCasosAsociadosService.Observacion_NombreCol, string.Empty},
                    { TramitesCasosAsociadosService.CasoId_NombreCol, casoCreadoId },
                };
                Tramites.TramitesCasosAsociadosService.Guardar(campos, true, sesion);

                campos = new Hashtable()
                {
                    { TramitesCasosAsociadosService.TramiteId_NombreCol, dtCabeceraCreada.Rows[0][TramitesService.Id_NombreCol]},
                    { TramitesCasosAsociadosService.FechaAgregado_NombreCol, DateTime.Now},
                    { TramitesCasosAsociadosService.UsuarioId_NombreCol, sesion.Usuario.ID},
                    { TramitesCasosAsociadosService.Observacion_NombreCol, string.Empty},
                    { TramitesCasosAsociadosService.CasoId_NombreCol, cabeceraRow.CASO_ID },
                };
                Tramites.TramitesCasosAsociadosService.Guardar(campos, true, sesion);
                #endregion Agregar caso asociado
            }

            //Si es de tipo Orden de Trabajo que pasó a Cerrado,
            //se actualice la fecha fin del caso origen que es de tipo Orde de Servicio
            if (cabeceraRow.TRAMITE_TIPO_ID == 2 && caso.EstadoId == Definiciones.EstadosFlujos.Cerrado && !cabeceraRow.IsCASO_ORIGINARIO_IDNull)
            {
                decimal campoEtapaFechaFinOT = 20;
                decimal campoEtapaFechaFinOS = 3;
                
                var dtTramiteOS = TramitesService.GetTramitesDataTable(TramitesService.CasoId_NombreCol + " = " + cabeceraRow.CASO_ORIGINARIO_ID, string.Empty, sesion);
                if ((decimal)dtTramiteOS.Rows[0][TramitesService.TramiteTipoId_NombreCol] == 1)
                { 
                    var dtTramiteCamposValoresOT = TramitesCamposEtapasValoresService.GetTramitesCamposEtapasValoresDataTable(TramitesCamposEtapasValoresService.TramiteId_NombreCol + " = " + cabeceraRow.ID + " and " + TramitesCamposEtapasValoresService.TramiteCamposEtapasId_NombreCol + " = " + campoEtapaFechaFinOT, string.Empty, sesion);
                    if (dtTramiteCamposValoresOT.Rows.Count <= 0)
                        throw new Exception("La OT no tiene una fecha de fin establecida.");

                    var dtTramiteCamposValoresOS = TramitesCamposEtapasValoresService.GetTramitesCamposEtapasValoresDataTable(TramitesCamposEtapasValoresService.TramiteId_NombreCol + " = " + dtTramiteOS.Rows[0][TramitesService.Id_NombreCol] + " and " + TramitesCamposEtapasValoresService.TramiteCamposEtapasId_NombreCol + " = " + campoEtapaFechaFinOS, string.Empty, sesion);

                    var ht = new Hashtable();
                    if (dtTramiteCamposValoresOS.Rows.Count > 0)
                        ht.Add(TramitesCamposEtapasValoresService.Id_NombreCol, dtTramiteCamposValoresOS.Rows[0][TramitesCamposEtapasValoresService.Id_NombreCol]);
                    ht.Add(TramitesCamposEtapasValoresService.TramiteCamposEtapasId_NombreCol, campoEtapaFechaFinOS);
                    ht.Add(TramitesCamposEtapasValoresService.TramiteId_NombreCol, dtTramiteOS.Rows[0][TramitesService.Id_NombreCol]);
                    ht.Add(TramitesCamposEtapasValoresService.ValorFecha_NombreCol, dtTramiteCamposValoresOT.Rows[0][TramitesCamposEtapasValoresService.ValorFecha_NombreCol]);
                    TramitesCamposEtapasValoresService.Guardar(ht, dtTramiteCamposValoresOS.Rows.Count > 0, sesion);
                }
            }
        }
        #endregion Implementacion de metodos abstract

        #region GetTramiteIdPorCaso
        public static decimal GetTramiteIdPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.TRAMITESCollection.GetByCASO_ID(caso_id)[0].ID;
            }
        }
        #endregion GetTramiteIdPorCaso

        #region GetTramitesDataTable
        public static DataTable GetTramitesDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTramitesDataTable(clausula, orden, sesion);
            }
        }

        public static DataTable GetTramitesDataTable(string clausula, string orden, SessionService sesion)
        {
            return sesion.Db.TRAMITESCollection.GetAsDataTable(clausula, orden);
        }
        #endregion GetTramitesDataTable

        #region GetTramitesInfoCompleta
        public static DataTable GetTramitesInfoCompleta(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;
                dt = sesion.Db.TRAMITES_INFO_COMPLETACollection.GetAsDataTable(clausula, orden);

                return dt;
            }
        }
        #endregion GetTramitesInfoCompleta

        #region CambiarDeEstado
        public static void CambiarDeEstado(decimal tramite_id, decimal estado_destino_Id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    TRAMITESRow row = sesion.Db.TRAMITESCollection.GetByPrimaryKey(tramite_id);
                    string valorAnterior = row.ToString();

                    row.TRAMITE_ESTADO_ACTUAL_ID = estado_destino_Id;

                    sesion.Db.TRAMITESCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion CambiarDeEstado

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, SessionService sesion)
        {
            TRAMITESRow row = new TRAMITESRow();

            try
            {
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("tramites_sqc");
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[TramitesService.SucursalId_NombreCol].ToString()),
                                                         int.Parse(Definiciones.FlujosIDs.TRAMITES.ToString()),
                                                         int.Parse(sesion.Usuario_Id.ToString()),
                                                         SessionService.GetClienteIP());
                    row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    row.TRAMITE_TIPO_ID = (decimal)campos[TramitesService.TramiteTipoId_NombreCol];
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    estado_id = Definiciones.EstadosFlujos.Borrador;
                }
                else
                {
                    row = sesion.Db.TRAMITESCollection.GetRow(TramitesService.Id_NombreCol + " = " + campos[TramitesService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                if (!insertarNuevo && !row.TRAMITE_TIPO_ID.Equals(DBNull.Value) 
                    && (decimal)campos[TramitesService.TramiteTipoId_NombreCol] != row.TRAMITE_TIPO_ID)
                    throw new Exception("No puede cambiarse el tipo de " + Traducciones.Tramites);

                row.SUCURSAL_ID = (decimal)campos[TramitesService.SucursalId_NombreCol];
                if (campos.Contains(TramitesService.PersonaId_NombreCol))
                    row.PERSONA_ID = (decimal)campos[TramitesService.PersonaId_NombreCol];
                else
                    row.IsPERSONA_IDNull = true;
                row.FECHA = (DateTime)campos[TramitesService.Fecha_NombreCol];
                row.MONEDA_ID = (decimal)campos[TramitesService.MonedaId_NombreCol];

                if (campos.Contains(TramitesService.TextoPredefinidoId_NombreCol))
                    row.TEXTO_PREDEFINIDO_ID = (decimal)campos[TramitesService.TextoPredefinidoId_NombreCol];
                else
                    row.IsTEXTO_PREDEFINIDO_IDNull = true;

                if (campos.Contains(TramitesService.AutonumeracionId_NombreCol))
                    row.AUTONUMERACION_ID = (decimal)campos[TramitesService.AutonumeracionId_NombreCol];
                else
                    row.IsAUTONUMERACION_IDNull = true;

                if (campos.Contains(TramitesService.NroComprobante_NombreCol))
                    row.NRO_COMPROBANTE = (string)campos[TramitesService.NroComprobante_NombreCol];
                else
                    row.NRO_COMPROBANTE = string.Empty;

                if (campos.Contains(TramitesService.Titulo_NombreCol))
                    row.TITULO = (string)campos[TramitesService.Titulo_NombreCol];
                else
                    row.TITULO = string.Empty;

                if (campos.Contains(TramitesService.Observacion_NombreCol))
                    row.OBSERVACION = (string)campos[TramitesService.Observacion_NombreCol];
                else
                    row.OBSERVACION = string.Empty;

                if (campos.Contains(TramitesService.CasoOriginarioId_NombreCol))
                    row.CASO_ORIGINARIO_ID = (decimal)campos[TramitesService.CasoOriginarioId_NombreCol];

                #region EstadoActual
                if (insertarNuevo)
                {
                    //Se busca el estado inicial del tipo de tramite, para marcarlo como actual
                    DataTable etapaInicial = TramitesTiposEtapasService.GetTramitesTiposEtapasDataTable(TramitesTiposEtapasService.TramiteTipoId_NombreCol + " = " + row.TRAMITE_TIPO_ID + " and " + TramitesTiposEtapasService.Orden_NombreCol + " = " + 1, string.Empty);
                    if (etapaInicial.Rows.Count != 1)
                        throw new Exception("No existe una sola etapa con orden = 1 para este tipo de tramite.");

                    DataTable estadoInicial = TramitesTiposEstadosService.GetTramitesTiposEstadosServiceDataTable(TramitesTiposEstadosService.TramiteTipoEtapaId_NombreCol + " = " + (decimal)etapaInicial.Rows[0][TramitesTiposEtapasService.Id_NombreCol] + " and " + TramitesTiposEstadosService.EsInicio_NombreCol + " = '" + Definiciones.SiNo.Si + "'", string.Empty);

                    if (estadoInicial.Rows.Count != 1)
                        throw new Exception("En este tipo de trámite existen más de un estado inicial.");
                    else
                        row.TRAMITE_ESTADO_ACTUAL_ID = (decimal)estadoInicial.Rows[0][TramitesTiposEstadosService.Id_NombreCol];
                }
                else
                {
                    row.TRAMITE_ESTADO_ACTUAL_ID = (decimal)campos[TramitesService.TramiteEstadoActualId_NombreCol];
                }
                #endregion EstadoActual

                if (insertarNuevo) 
                    sesion.Db.TRAMITESCollection.Insert(row);
                else 
                    sesion.Db.TRAMITESCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                caso_id = row.CASO_ID;

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                if (!row.IsPERSONA_IDNull)
                    camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                #endregion Actualizar datos en tabla casos
            }
            catch (Exception exp)
            {
                if (insertarNuevo && row.CASO_ID > 0)
                {
                    (new CasosService()).Eliminar(row.CASO_ID, sesion);
                    caso_id = Definiciones.Error.Valor.EnteroPositivo;
                    estado_id = string.Empty;
                }
                throw exp;
            }
        }
        #endregion Guardar

        #region Borrar
        public static bool Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = true;
                    string mensaje = string.Empty;

                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    TRAMITESRow cabecera = sesion.Db.TRAMITESCollection.GetByCASO_ID(caso_id)[0];
                    TRAMITES_CAMPOS_ETAPAS_VALORESRow[] valores = sesion.Db.TRAMITES_CAMPOS_ETAPAS_VALORESCollection.GetByTRAMITE_ID(cabecera.ID);

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso debe estar en el estado borrador para poder borrarse.";
                    }

                    if (exito && valores.Length > 0)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que posee valores definidos.";
                    }

                    if (exito)
                    {
                        sesion.Db.TRAMITESCollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                        (new CasosService()).Eliminar(caso_id, sesion);
                    }
                    else
                    {
                        throw new System.ArgumentException(mensaje);
                    }

                    sesion.CommitTransaction();
                    return exito;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TRAMITES"; }
        }
        public static string Nombre_Vista
        {
            get { return "tramites_info_completa"; }
        }
        public static string Id_NombreCol
        {
            get { return TRAMITESCollection.IDColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return TRAMITESCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return TRAMITESCollection.CASO_IDColumnName; }
        }
        public static string CasoOriginarioId_NombreCol
        {
            get { return TRAMITESCollection.CASO_ORIGINARIO_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return TRAMITESCollection.FECHAColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return TRAMITESCollection.MONEDA_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return TRAMITESCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return TRAMITESCollection.OBSERVACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return TRAMITESCollection.PERSONA_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return TRAMITESCollection.SUCURSAL_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return TRAMITESCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string Titulo_NombreCol
        {
            get { return TRAMITESCollection.TITULOColumnName; }
        }
        public static string TramiteEstadoActualId_NombreCol
        {
            get { return TRAMITESCollection.TRAMITE_ESTADO_ACTUAL_IDColumnName; }
        }
        public static string TramiteTipoId_NombreCol
        {
            get { return TRAMITESCollection.TRAMITE_TIPO_IDColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return TRAMITES_INFO_COMPLETACollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCasoOriginarioEstado_NombreCol
        {
            get { return TRAMITES_INFO_COMPLETACollection.CASO_ORIGINARIO_ESTADOColumnName; }
        }
        public static string VistaCasoOriginarioFlujoDesc_NombreCol
        {
            get { return TRAMITES_INFO_COMPLETACollection.CASO_ORIGINARIO_FLUJO_DESCColumnName; }
        }
        public static string VistaCasoOriginarioFlujoId_NombreCol
        {
            get { return TRAMITES_INFO_COMPLETACollection.CASO_ORIGINARIO_FLUJO_IDColumnName; }
        }
        public static string VistaCasoFechaCreacion_NombreCol
        {
            get { return TRAMITES_INFO_COMPLETACollection.CASO_FECHA_CREACIONColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return TRAMITES_INFO_COMPLETACollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return TRAMITES_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaTextoPredefinidoTipoId_NombreCol
        {
            get { return TRAMITES_INFO_COMPLETACollection.TEXTO_PREDEFINIDO_TIPO_IDColumnName; }
        }
        public static string VistaTextoPredefinido_NombreCol
        {
            get { return TRAMITES_INFO_COMPLETACollection.TEXTO_PREDEFINIDOColumnName; }
        }
        public static string VistaTramiteEstadoActualNombre_NombreCol
        {
            get { return TRAMITES_INFO_COMPLETACollection.TRAMITE_ESTADO_ACTUAL_NOMBREColumnName; }
        }
        public static string VistaTramiteTipoEtapaActualId_NombreCol
        {
            get { return TRAMITES_INFO_COMPLETACollection.TRAMITE_TIPO_ETAPA_ACTUAL_IDColumnName; }
        }
        public static string VistaTramiteTipoEtapaActualNombre_NombreCol
        {
            get { return TRAMITES_INFO_COMPLETACollection.TRAMITE_TIPO_ETAPA_ACTUAL_NOMBColumnName; }
        }
        public static string VistaTramiteTipoNombre_NombreCol
        {
            get { return TRAMITES_INFO_COMPLETACollection.TRAMITE_TIPO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
